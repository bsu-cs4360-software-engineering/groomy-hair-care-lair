using Groomy.Customers;
using Groomy.Utilities;
using Moq;
using System.Text.Json;

namespace Groomy.Tests
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

            var initialJson = "[]"; // Empty database

            // Mock the file service methods
            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(initialJson);
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
                    { fieldType, new Dictionary<string, string> { 
                        { "objectID", objectID },
                        { testKey, testValue }
                    } }
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

            var testJson = $@"[{{""{testID}"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            // Act
            var returnedJson = DBM.ReadObjectFromDB(testID, testFilePath);
            var actualValue = returnedJson[testKey].ToString();

            // Assert
            Assert.IsNotNull(returnedJson);
            Assert.IsTrue(returnedJson.ContainsKey(testKey));
            Assert.AreEqual(testValue, actualValue);
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

            var testJson = $@"[{{""testID"": ""{testID}"", ""{testKey}"": ""{testValue}""}}]";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()));

            // Act
            DBM.DeleteObjectFromDB(testID, testFilePath);

            // Assert
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.Is<string>(s => !s.Contains(testID))), Times.Once);
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
            Assert.Fail();
        }
        [TestMethod()]
        public void ReadRelationshipEntryTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void UpdateRelationshipEntryTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void DeleteRelationshipEntryTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void SoftDeleteRelationshipEntryTest()
        {
            Assert.Fail();
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
            Assert.IsNotNull(objects);
            Assert.AreEqual(1, objects.Count);
            Assert.AreEqual(objectID, objects[0][idKey]);
        }
    }
}