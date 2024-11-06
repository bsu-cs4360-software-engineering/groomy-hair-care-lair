using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Groomy.Customers;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;

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
        public void AddObjectsToDBTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testObject = new Mock<IGenericObject>();
            testObject.Setup(o => o.GetFields()).Returns(
                new Dictionary<string, Dictionary<string, object>>
                {
                    { testKey, new Dictionary<string, object>
                    {
                        { testKey, testValue }
                    }
                    }
                });
            testObject.Setup(o => o.GetDBFilePaths()).Returns(new Dictionary<string, string> { { testKey, testFilePath } });
            testObject.Setup(o => o.GetKey()).Returns(testID);

            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()));

            //Act
            DBM.AddObjectsToDB(testObject.Object);

            //Assert
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.Is<string>(s => s.Contains(testID) && s.Contains(testKey) && s.Contains(testValue))), Times.Once);
        }

        [TestMethod()]
        public void KeyExistsTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"{{""{testID}"": {{""{testKey}"": ""{testValue}""}} }}";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            //Act
            var keyExists = DBM.KeyExists(testID, testFilePath);

            //Assert
            Assert.IsTrue(keyExists);
        }

        [TestMethod()]
        public void LoadObjectFromDBTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"{{""{testID}"": {{""{testKey}"": ""{testValue}""}} }}";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            //Act
            var returnedJson = DBM.LoadObjectFromDB(testID, testFilePath);
            var actualValue = returnedJson[testKey].ToString();

            //Assert
            Assert.IsNotNull(returnedJson);
            Assert.IsTrue(returnedJson.ContainsKey(testKey));
            Assert.AreEqual(testValue, actualValue);
        }

        [TestMethod()]
        public void RemoveObjectFromDBTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = new DatabaseManager(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"{{""{testID}"": {{""{testKey}"": ""{testValue}""}} }}";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);
            mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()));

            //Act
            DBM.RemoveObjectFromDB(testID, testFilePath);

            //Assert
            mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.Is<string>(s => !s.Contains(testID))), Times.Once);
        }

        [TestMethod()]
public void SoftDeleteObjectInDBTest()
    {
        //Arrange
        var mockFileService = new Mock<IFileService>();
        var DBM = new DatabaseManager(mockFileService.Object);

        var testFilePath = "test.json";
        var testID = "testID";
        var testKey = "testKey";
        var testValue = "testValue";

        var testJson = $@"{{""{testID}"": {{""{testKey}"": ""{testValue}""}} }}";

        //Mock the file service methods
        mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
        mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

        //Variable to capture the content written to the file
        string updatedJson = null;
        mockFileService.Setup(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()))
            .Callback<string, string>((path, content) => updatedJson = content);

        //Act - Before SoftDelete: Load the current database
        var itemBeforeDelete = DBM.LoadObjectFromDB(testID, testFilePath); //Returns Dictionary<string, object>

        //Assert - Confirm "isDeleted" doesn't exist before SoftDelete
        Assert.IsNotNull(itemBeforeDelete, "The item should be a dictionary.");
        Assert.IsFalse(itemBeforeDelete.ContainsKey("isDeleted"), "isDeleted should not exist before soft deletion.");

        //Act - Perform SoftDelete
        DBM.SoftDeleteObjectInDB(testID, testFilePath);

        //Assert - Verify the content of the updatedJson
        Assert.IsNotNull(updatedJson, "The updated JSON should not be null.");

        //Deserialize the updated JSON content
        var dbAfterDelete = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(updatedJson);

        //Assert - Confirm "isDeleted" exists after SoftDelete
        Assert.IsTrue(dbAfterDelete.ContainsKey(testID), "The testID should still exist in the database after deletion.");
        var itemAfterDelete = dbAfterDelete[testID];
        Assert.IsTrue(itemAfterDelete.ContainsKey("isDeleted"), "isDeleted should exist after soft deletion.");
        Assert.AreEqual(true, itemAfterDelete["isDeleted"], "isDeleted should be true after soft deletion.");

        //Optional: Verify that WriteAllText was called once
        mockFileService.Verify(fs => fs.WriteAllText(testFilePath, It.IsAny<string>()), Times.Once);
    }



    [TestMethod()]
        public void GetDataTableTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var DBM = DatabaseManager.GetInstance(mockFileService.Object);

            var testFilePath = "test.json";
            var testID = "testID";
            var testKey = "testKey";
            var testValue = "testValue";

            var testJson = $@"{{""{testID}"": {{""{testKey}"": ""{testValue}""}} }}";

            mockFileService.Setup(fs => fs.ReadAllText(testFilePath)).Returns(testJson);
            mockFileService.Setup(fs => fs.Exists(testFilePath)).Returns(true);

            //Act
            var dataTable = DBM.GetDataTable(testFilePath, 4);

            //Assert
            Assert.IsNotNull(dataTable);
            Assert.IsTrue(dataTable.Rows.Count > 0);
            Assert.AreEqual(testValue, dataTable.Rows[0][testKey].ToString());
        }
    }
}