using Groomy.Customers;
using Groomy.Relationships;
using Groomy.Utilities;
using Moq;
using System.Text.Json;

namespace GroomyTests.Utilities
{

    [TestClass()]
    public class databaseManagerTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            DatabaseManager.ResetInstance();
        }
        [TestMethod()]
        public void DBM_is_DBM()
        {
            var fs = new FileService();
            var DBM = new DatabaseManager(fs);
            var objectType = typeof(DatabaseManager);
            Assert.IsInstanceOfType(DBM, objectType);
        }
        [TestMethod()]
        public void CreateObjectInDBTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var fieldType = "testData";
            var idKey = "objectID";
            var objectID = "objectID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testFields = new Dictionary<string, string> {
                { idKey, objectID },
                { testKey, testValue }
            };

            var initialObjectDB = "[]"; // Empty database

            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(initialObjectDB);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Variable to capture the updated JSON content
            string updatedJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedJson = content);


            // Mock an object implementing IGenericObject
            var mockGenericObject = new Mock<IGenericObject>();
            mockGenericObject.Setup(obj => obj.GetKey()).Returns(objectID);
            mockGenericObject.Setup(obj => obj.GetFields()).Returns(
                new Dictionary<string, Dictionary<string, string>>
                {
                    { fieldType, testFields }
                });
            mockGenericObject.Setup(obj => obj.GetDBFilePaths()).Returns(
                new Dictionary<string, string>
                {
                    { fieldType, testFilePath }
                });

            // Act
            DBM.CreateObjectInDB(mockGenericObject.Object);

            // Assert
            Assert.IsNotNull(updatedJson, "The updated JSON should not be null.");

            // Deserialize the updated JSON content
            var dbAfterAdd = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedJson);
            Assert.AreEqual(1, dbAfterAdd.Count, "The database should contain exactly one object.");
            var addedObject = dbAfterAdd.First();
            Assert.IsTrue(addedObject.ContainsKey(idKey), $"The added object should contain the key '{idKey}'.");
            Assert.IsTrue(addedObject.ContainsKey(testKey), $"The added object should contain the key '{testKey}'.");
            Assert.AreEqual(objectID, addedObject[idKey], $"The value for '{idKey}' should match the input.");
            Assert.AreEqual(testValue, addedObject[testKey], $"The value for '{testKey}' should match the input.");
            // Verify that WriteAllText was called once
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()), Times.Once);
        }
        [TestMethod()]
        public void ReadObjectFromDBTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var existingObjectDB = $@"[{{""{testID}"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(existingObjectDB);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Act
            var retrievedObject = DBM.ReadObjectFromDB(testID, testFilePath);

            // Assert
            Assert.IsNotNull(retrievedObject, "Retrieved Object should not be null");
            Assert.IsTrue(retrievedObject.ContainsKey(testID), "Retrieved Object should contain the key 'testID'");
            Assert.IsTrue(retrievedObject.ContainsKey(testKey), "Retrieved Object should contain the key 'testKey'");
            Assert.AreEqual(retrievedObject[testID], testID, "Retrieved Object should have the same ID as the object in the initial database");
            Assert.AreEqual(retrievedObject[testKey], testValue, "Retrieved Object should have the same value as the object in the initial database");

        }
        [TestMethod()]
        public void UpdateObjectInDBTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var fieldType = "testData";
            var idKey = "objectID";
            var objectID = "objectID";
            var testKey = "testKey";
            var initialValue = "initialValue";
            var updatedValue = "updatedValue";

            var initialDatabase = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { idKey, objectID },
                    { testKey, initialValue }
                }
            };
            var initialDBJson = JsonSerializer.Serialize(initialDatabase, new JsonSerializerOptions { WriteIndented = true });

            var updatedObjectFields = new Dictionary<string, string> {
                { idKey, objectID },
                { testKey, updatedValue }
            };

            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(initialDBJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Variable to capture the updated JSON content
            string updatedDBJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedDBJson = content);

            // Mock an object implementing IGenericObject
            var mockGenericObject = new Mock<IGenericObject>();
            mockGenericObject.Setup(obj => obj.GetKey()).Returns(objectID);
            mockGenericObject.Setup(obj => obj.GetFields()).Returns(
                new Dictionary<string, Dictionary<string, string>>
                {
                    { fieldType, new Dictionary<string, string> {
                        { idKey, objectID },
                        { testKey, updatedValue }
                    } }
                });
            mockGenericObject.Setup(obj => obj.GetDBFilePaths()).Returns(
                new Dictionary<string, string>
                {
                    { fieldType, testFilePath }
                });
            // Act
            DBM.UpdateObjectInDB(objectID, updatedObjectFields, testFilePath);

            // Assert
            Assert.IsNotNull(updatedDBJson, "The updated Database should not be null.");

            // Deserialize the updated JSON content
            var updatedDatabase = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedDBJson);

            Assert.AreEqual(1, updatedDatabase.Count, "The database should contain exactly one object.");
            var updatedObject = updatedDatabase.First();
            Assert.IsTrue(updatedObject.ContainsKey(idKey), $"The updated object should contain the key '{idKey}'.");
            Assert.IsTrue(updatedObject.ContainsKey(testKey), $"The updated object should contain the key '{testKey}'.");
            Assert.AreEqual(objectID, updatedObject[idKey], $"The value for '{idKey}' should match the input.");
            Assert.AreEqual(updatedValue, updatedObject[testKey], $"The value for '{testKey}' should match the updated input.");
            // Verify that WriteAllText was called once
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()), Times.Once);
        }
        [TestMethod()]
        public void DeleteObjectFromDBTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            // Initial JSON data (with one object containing testID)
            var testJson = $@"[{{""testID"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            // Mock FileService behavior
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            string updatedJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedJson = content);

            // Act
            DBM.DeleteObjectFromDB(testID, testFilePath);

            // Assert
            // Check that the WriteAllText callback was called with the expected updated content
            Assert.IsNotNull(updatedJson, "The WriteAllText method should be called to save the updated file.");

            // Deserialize the updated JSON content to verify the object was deleted
            var updatedDatabase = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedJson);
            // verify that the updated database contains no objects
            Assert.AreEqual(0, updatedDatabase.Count, "The database should be empty after deletion.");
            // Verify that the item with testID has been deleted
            var deletedItem = updatedDatabase.FirstOrDefault(item => item.ContainsKey(testID));
            Assert.IsNull(deletedItem, $"The item with testID '{testID}' should be deleted.");
        }

        [TestMethod()]
        public void SoftDeleteObjectInDBTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"[{{""testID"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Variable to capture the content written to the file
            string updatedJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedJson = content);

            // Act - Before SoftDelete: Load the current database
            var itemBeforeDelete = DBM.ReadObjectFromDB(testID, testFilePath); // Returns Dictionary<string, string>

            // Assert - Confirm "isDeleted" doesn't exist before SoftDelete
            Assert.IsNotNull(itemBeforeDelete, "The item should be a dictionary.");
            Assert.IsFalse(itemBeforeDelete.ContainsKey(DBM.isDeletedKey), "isDeleted should not exist before soft deletion.");

            // Act - Perform SoftDelete
            DBM.SoftDeleteObjectInDB(testID, testFilePath);

            // Assert - Verify the content of the updatedJson
            Assert.IsNotNull(updatedJson, "The updated JSON should not be null.");

            // Deserialize the updated JSON content
            var dbAfterDelete = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedJson);

            // Assert - Confirm "isDeleted" exists after SoftDelete
            var itemAfterDelete = dbAfterDelete.FirstOrDefault(item => item["testID"] == testID);
            Assert.IsNotNull(itemAfterDelete, "The testID should still exist in the database after deletion.");
            Assert.IsTrue(itemAfterDelete.ContainsKey(DBM.isDeletedKey), "isDeleted should exist after soft deletion.");
            Assert.AreEqual("true", itemAfterDelete[DBM.isDeletedKey], "isDeleted should be true after soft deletion.");

            // Optional: Verify that WriteAllText was called once
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()), Times.Once);
        }
        [TestMethod()]
        public void KeyExistsTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"[{{""{testID}"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Act
            var keyExists = DBM.KeyExists(testID, testFilePath);

            // Assert
            Assert.IsTrue(keyExists);
        }
        [TestMethod()]
        public void CreateRelationshipEntryTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var relationshipFilepath = "test.json";
            var testID1 = "testID1";
            var testID2 = "testID2";

            var initialRelationshipDB = "[]"; 

            var relationshipIDs = new Dictionary<string, string>()
            {
                { testID1, testID1 },
                { testID2, testID2 }
            };

            var testRelationship = new Mock<IRelationship>();
            //Mock relationship methods
            testRelationship.Setup(rel => rel.GetIDs()).Returns(relationshipIDs);
            testRelationship.Setup(rel => rel.GetFilePath()).Returns(relationshipFilepath);
            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(initialRelationshipDB);
            mockFileService.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);
            // Variable to capture the updated JSON content
            string updatedRelationship = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedRelationship = content);
            
            //Act
            DBM.CreateRelationshipEntry(testRelationship.Object);
            //Assert
            Assert.IsNotNull(updatedRelationship, "The updated JSON should not be null.");

            //Deserialize relationship JSON
            var relationshipDBAfterAdd = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedRelationship);
            Assert.AreEqual(1, relationshipDBAfterAdd.Count, "The database should contain exactly one object.");
            var addedRelationship = relationshipDBAfterAdd.First();
            Assert.IsTrue(addedRelationship.ContainsKey("testID1"), "The added object should contain the key 'testID1'.");
            Assert.IsTrue(addedRelationship.ContainsKey("testID2"), "The added object should contain the key 'testID2'.");
            Assert.AreEqual(testID1, addedRelationship["testID1"], $"The value for '{testID1}' should match the input.");
            Assert.AreEqual(testID2, addedRelationship["testID2"], $"The value for '{testID2}' should match the input.");
        }
        [TestMethod()]
        public void ReadRelationshipEntryTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);


            var relationshipFilepath = "test.json";
            var testID1 = "testID1";
            var testID2 = "testID2";

            var existingRelationshipDB = $@"[{{""{testID1}"": ""{testID1}"", ""{testID2}"": ""{testID2}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(existingRelationshipDB);
            mockFileService.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            //Act
            var returnedJson = DBM.ReadRelationshipEntry(testID1, relationshipFilepath);

            //Assert
            Assert.IsTrue(returnedJson.Count == 1, "The relationship database should contain exactly one relationship.");
            var returnedRelationship = returnedJson.First();
            Assert.IsNotNull(returnedRelationship, "Returned relationship should not be null.");
            Assert.IsTrue(returnedRelationship.ContainsKey(testID1), "The returned relationship should contain the key 'testID1'.");
            Assert.IsTrue(returnedRelationship.ContainsKey(testID2), "The returned relationship should contain the key 'testID2'.");
            Assert.AreEqual(testID1, returnedRelationship[testID1], $"The value for '{testID1}' should match the input.");
            Assert.AreEqual(testID2, returnedRelationship[testID2], $"The value for '{testID2}' should match the input.");
        }
        [TestMethod]
        public void UpdateRelationshipEntryTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var relationshipFilepath = "test.json";
            var testID1 = "testID1";
            var testID2 = "testID2";
            var newTestID1 = "newTestID1";

            // Existing relationship data
            var existingRelationshipIDs = new Dictionary<string, string>()
            {
                { testID1, testID1 },
                { testID2, testID2 }
            };
            var existingRelationshipDB = new List<Dictionary<string, string>>() { existingRelationshipIDs };
            var existingRelationshipJsons = JsonSerializer.Serialize(existingRelationshipDB, new JsonSerializerOptions { WriteIndented = true });

            // Mock updated relationship
            var updatedRelationshipIDs = new Dictionary<string, string>()
            {
                { testID1, newTestID1 },
                { testID2, testID2 }
            };
            var updatedRelationship = new Mock<IRelationship>();
            updatedRelationship.Setup(rel => rel.GetIDs()).Returns(updatedRelationshipIDs);
            updatedRelationship.Setup(rel => rel.GetFilePath()).Returns(relationshipFilepath);

            // Mock file service behavior
            mockFileService.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(existingRelationshipJsons);
            mockFileService.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            // Variable to capture updated JSON
            string updatedRelationshipJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedRelationshipJson = content);

            // Act
            DBM.UpdateRelationshipEntry(updatedRelationship.Object);

            // Assert
            Assert.IsNotNull(updatedRelationshipJson, "Updated relationship JSON should not be null.");
            var updatedRelationshipDB = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedRelationshipJson);
            Assert.AreEqual(1, updatedRelationshipDB.Count, "The relationship database should contain exactly one relationship.");

            var updatedRelationshipEntry = updatedRelationshipDB.First();
            Assert.AreEqual(newTestID1, updatedRelationshipEntry[testID1], "The value for 'testID1' should be updated.");
            Assert.AreEqual(testID2, updatedRelationshipEntry[testID2], "The value for 'testID2' should remain unchanged.");
        }
        [TestMethod()]
        public void DeleteRelationshipEntryTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);


            var relationshipFilepath = "test.json";
            var testID1 = "testID1";
            var testID2 = "testID2";

            var existingRelationshipIDs = new Dictionary<string, string>()
            {
                { testID1, testID1 },
                { testID2, testID2 }
            };

            var existingRelationship = new Mock<IRelationship>();
            existingRelationship.Setup(rel => rel.GetIDs()).Returns(existingRelationshipIDs);
            existingRelationship.Setup(rel => rel.GetFilePath()).Returns(relationshipFilepath);

            var existingRelationshipDB = $@"[{{""{testID1}"": ""{testID1}"", ""{testID2}"": ""{testID2}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(existingRelationshipDB);
            mockFileService.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            string updatedJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedJson = content);

            // Act
            DBM.DeleteRelationshipEntry(existingRelationship.Object);

            //Assert
            // Check that the WriteAllText callback was called with the expected updated content
            Assert.IsNotNull(updatedJson, "The updated JSON should not be null.");
            // Deserialize the updated JSON content
            var updatedRelationshipDB = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedJson);
            // Verify that the updated database is empty
            Assert.AreEqual(0, updatedRelationshipDB.Count, "The relationship database should be empty after deletion.");
            // Verify that the item with testID1 has been deleted
            var deletedRelationship = updatedRelationshipDB.FirstOrDefault(item => item.ContainsKey(testID1));
            Assert.IsNull(deletedRelationship, "The relationship should be deleted.");
        }
        [TestMethod()]
        public void SoftDeleteRelationshipEntryTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);


            var relationshipFilepath = "test.json";
            var testID1 = "testID1";
            var testID2 = "testID2";

            var existingRelationshipIDs = new Dictionary<string, string>()
            {
                { testID1, testID1 },
                { testID2, testID2 }
            };

            var existingRelationship = new Mock<IRelationship>();
            existingRelationship.Setup(rel => rel.GetIDs()).Returns(existingRelationshipIDs);
            existingRelationship.Setup(rel => rel.GetFilePath()).Returns(relationshipFilepath);

            var existingRelationshipDB = $@"[{{""{testID1}"": ""{testID1}"", ""{testID2}"": ""{testID2}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(existingRelationshipDB);
            mockFileService.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            string updatedJson = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => updatedJson = content);
            //Act
            DBM.SoftDeleteRelationshipEntry(existingRelationship.Object);
            //Assert
            // Check that the WriteAllText callback was called with the expected updated content
            Assert.IsNotNull(updatedJson, "The updated JSON should not be null.");
            // Deserialize the updated JSON content
            var updatedRelationshipDB = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(updatedJson);
            // Verify the updated database isnt empty
            Assert.AreEqual(1, updatedRelationshipDB.Count, "The relationship database should not be empty after soft deletion.");
            // Verify that the item with testID1 exists
            var softDeletedRelationship = updatedRelationshipDB.FirstOrDefault(item => item.ContainsKey(testID1));
            Assert.IsNotNull(softDeletedRelationship, "The relationship should still exist in the database after soft deletion.");
            // Verify that the item with testID1 has been soft deleted
            Assert.IsTrue(softDeletedRelationship.ContainsKey(DBM.isDeletedKey), "isDeleted should exist after soft deletion.");
        }
        [TestMethod()]
        public void GetObjectsByKeyValueTest()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var fieldType = "testData";
            var idKey = "objectID";
            var objectID = "objectID";
            var testKey = "testKey";
            var testValue = "initialValue";

            var initialDatabase = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { idKey, objectID },
                    { testKey, testValue }
                }
            };
            var initialDBJson = JsonSerializer.Serialize(initialDatabase, new JsonSerializerOptions { WriteIndented = true });

            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(initialDBJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Act
            var objects = DBM.GetObjectsByKeyValue(testKey, testValue, testFilePath);
            Assert.IsNotNull(objects, "Retireved objects are not null");
            Assert.AreEqual(1, objects.Count, "There should be exactly one retrieved object");
            Assert.AreEqual(objectID, objects[0][idKey], "Retrieved object should have same ID as object in initial database");
        }
    }
}