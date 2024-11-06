using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Reflection;

namespace Groomy.Tests
{

    [TestClass()]
    public class UserDatabaseTests

    {
        /*
        [TestInitialize]
        public void TestInitialize()
        {
            // Reset the singleton instance before each test
            typeof(UserDatabase).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, null);
        }
        [TestMethod()]
        public void UserDatabase_is_UserDatabase()
        {
            // Arrange
            var fileSerivce = new FileService();
            var database = UserDatabase.Instance(fileSerivce);

            //Assert
            Assert.IsInstanceOfType(database, typeof(UserDatabase));
        }
        [TestMethod()]
        public void UserDatabase_IsUser()
        {
            // Arrange
            string setFirst = "test";
            string setLast = "user";
            string setEmail = "test.user@gmail.com";
            string userID = Helpers.GenerateSHA256Hash(setEmail); // Generate the userID from the email

            // Create a mock for the IFileService
            var fileServiceMock = new Mock<IFileService>();

            // Setup the mock to return a JSON string representing existing users
            var json = Helpers.createUserJson(setFirst, setLast, setEmail);

            fileServiceMock.Setup(fs => fs.ReadAllText("users.json")).Returns(json);

            // Create an instance of UserDatabase with the mocked file service
            var userDatabase = UserDatabase.Instance(fileServiceMock.Object);

            // Verify the mock setup
            var mockJson = fileServiceMock.Object.ReadAllText("users.json");
            Assert.AreEqual(json, mockJson, "Mock setup failed: JSON does not match.");

            // Act
            var result = userDatabase.IsUser(userID);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void UserDatabase_GetUser()
        {
            // Arrange
            string setFirst = "test";
            string setLast = "user";
            string setEmail = "test.user@gmail.com"; // This should match the email in your JSON
            string userID = Helpers.GenerateSHA256Hash(setEmail); // Generate the userID from the email

            // Create a mock for the IFileService
            var fileServiceMock = new Mock<IFileService>();
            var userDatabase = UserDatabase.Instance(fileServiceMock.Object);

            // Setup the mock to return a JSON string representing existing users
            var json = Helpers.createUserJson(setFirst, setLast, setEmail);

            fileServiceMock.Setup(fs => fs.ReadAllText("users.json")).Returns(json);

            // Act
            var retrievedUser = userDatabase.GetUser(userID);
            var retrievedFirstName = retrievedUser["FirstName"].ToString();
            var retrievedLastName = retrievedUser["LastName"].ToString();
            var retrievedEmail = retrievedUser["Email"].ToString();

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(setFirst, retrievedFirstName);
            Assert.AreEqual(setLast, retrievedLastName);
            Assert.AreEqual(setEmail, retrievedEmail);
        }

        [TestMethod()]
        public void UserDatabase_GetPassword()
        {
            // Arrange
            string setPassword = "password";
            string setEmail = "test.user@gmail.com"; // This should match the email in your JSON
            string hashedPassword = Helpers.GenerateSHA256Hash(setPassword);
            string userID = Helpers.GenerateSHA256Hash(setEmail); // Generate the userID from the email

            // Create a mock for the IFileService
            var fileServiceMock = new Mock<IFileService>();
            var userDatabase = UserDatabase.Instance(fileServiceMock.Object);

            // Setup the mock to return a JSON string representing existing users
            var json = Helpers.createPasswordJson(setEmail, setPassword);

            fileServiceMock.Setup(fs => fs.ReadAllText("passwords.json")).Returns(json);

            // Act
            var retrievedPassword = userDatabase.GetPassword(userID)["Password"].ToString();

            // Assert
            Assert.IsNotNull(retrievedPassword);
            Assert.AreEqual(hashedPassword, retrievedPassword);
        }
        [TestMethod()]
        public void UserDatabase_AddUser()
        {
            // Arrange
            string setFirst = "test";
            string setLast = "user";
            string setEmail = "test.user@gmail.com"; // This should match the email in your JSON
            string setPassword = "password";
            string userID = Helpers.GenerateSHA256Hash(setEmail); // Generate the userID from the email

            // Create a mock for the IFileService
            var fileServiceMock = new Mock<IFileService>();
            var userDatabase = UserDatabase.Instance(fileServiceMock.Object);

            // Setup the mock to return an empty JSON string initially
            fileServiceMock.Setup(fs => fs.ReadAllText("users.json")).Returns("[]");

            // Act
            var newUser = new User(setFirst, setLast, setEmail, setPassword, userDatabase);
            userDatabase.AddUser(newUser);

            // Setup the mock to return the JSON string representing the added user
            var json = Helpers.createUserJson(setFirst, setLast, setEmail);
            fileServiceMock.Setup(fs => fs.ReadAllText("users.json")).Returns(json);

            // Assert
            var retrievedUser = userDatabase.GetUser(userID);
            Assert.IsNotNull(retrievedUser, "User should be retrieved from the database.");
            Assert.AreEqual(setFirst, retrievedUser["FirstName"].ToString(), "First name does not match.");
            Assert.AreEqual(setLast, retrievedUser["LastName"].ToString(), "Last name does not match.");
            Assert.AreEqual(setEmail, retrievedUser["Email"].ToString(), "Email does not match.");
        }
        */
    }
}