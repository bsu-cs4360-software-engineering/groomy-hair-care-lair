using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Moq;

using System.Text.Json;

namespace Groomy.Users.Tests
{
    [TestClass()]
    public class UserDBServiceTests
    {
        [TestMethod()]
        public void UserDBServiceManagerSingleton()
        {
            var ms = new Utilities.ManagerSingleton();
            var udbs = new UserDBService(ms);
            Assert.IsInstanceOfType(udbs, typeof(UserDBService));
        }

        [TestMethod()]
        public void UserDBServiceDependancyInjection()
        {
            var fs = new FileService();
            var dbm = new DatabaseManager(fs);
            var udbs = new UserDBService(dbm);
            Assert.IsInstanceOfType(udbs, typeof(UserDBService));
        }

        [TestMethod()]
        public void IsUserTest()
        { 
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var udbs = new UserDBService(dbm);

            var testUserID = "testUserID";

            var passwordDBFilepath = "passwords.json";

            var passwordDB = new List<Dictionary<string, string>>
            {
               new Dictionary<string, string>
               {
                   {"UserID", testUserID},
                   {"Password", "testPassword"}
               }
            };

            mockFS.Setup(fs => fs.ReadAllText(passwordDBFilepath)).Returns(JsonSerializer.Serialize(passwordDB));
            mockFS.Setup(fs => fs.Exists(passwordDBFilepath)).Returns(true);



            //Act
            var isUser = udbs.IsUser(testUserID);

            //Assert
            Assert.IsTrue(isUser);
        }
        [TestMethod()]
        public void IsUserNotFoundTest()
        {
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var udbs = new UserDBService(dbm);


            //Act
            var isUser = udbs.IsUser("testUser");

            //Assert
            Assert.IsFalse(isUser);
        }
        [TestMethod()]
        public void IsCorrectPasswordTest()
        {
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var udbs = new UserDBService(dbm);

            var testPassword = "testUserID";
            var testUserID = "testUserID";

            var passwordDBFilepath = "passwords.json";

            var passwordDB = new List<Dictionary<string, string>>
            {
               new Dictionary<string, string>
               {
                   {"UserID", testUserID},
                   {"Password", testPassword}
               }
            };

            var userDBFilepath = "users.json";

            var userDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"UserID", testUserID},
                    {"FirstName", "testFirstName"},
                    {"LastName", "testLastName"},
                    {"Email", "testEmail"},
                    {"Phone", "testPhone"},
                    {"Address", "testAddress"}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(passwordDBFilepath)).Returns(JsonSerializer.Serialize(passwordDB));
            mockFS.Setup(fs => fs.Exists(passwordDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(userDBFilepath)).Returns(JsonSerializer.Serialize(userDB));
            mockFS.Setup(fs => fs.Exists(userDBFilepath)).Returns(true);

            //Act
            var isCorrect = udbs.IsCorrectPassword(testUserID, testPassword);

            //Assert
            Assert.IsTrue(isCorrect);
        }

        [TestMethod()]
        public void IsIncorrectPasswordTest()
        {
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var udbs = new UserDBService(dbm);

            var testPassword = "testUserID";
            var testUserID = "testUserID";

            var passwordDBFilepath = "passwords.json";

            var passwordDB = new List<Dictionary<string, string>>
            {
               new Dictionary<string, string>
               {
                   {"UserID", testUserID},
                   {"Password", testPassword}
               }
            };

            var userDBFilepath = "users.json";

            var userDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"UserID", testUserID},
                    {"FirstName", "testFirstName"},
                    {"LastName", "testLastName"},
                    {"Email", "testEmail"},
                    {"Phone", "testPhone"},
                    {"Address", "testAddress"}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(passwordDBFilepath)).Returns(JsonSerializer.Serialize(passwordDB));
            mockFS.Setup(fs => fs.Exists(passwordDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(userDBFilepath)).Returns(JsonSerializer.Serialize(userDB));
            mockFS.Setup(fs => fs.Exists(userDBFilepath)).Returns(true);

            //Act
            var isCorrect = udbs.IsCorrectPassword(testUserID, "wrongPassword");

            //Assert
            Assert.IsFalse(isCorrect);
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var udbs = new UserDBService(dbm);

            var userDBFilepath = "users.json";
            var initialUserDB = "[]";
            var passwordDBFilepath = "passwords.json";
            var initialPasswordDB = "[]";

            var testUserFirst = "testFirst";
            var testUserLast = "testLast";
            var testUserEmail = "testEmail";
            var testUserPassword = "testPassword";

            var hashedPassword = Helpers.GenerateSHA256Hash(testUserPassword);

            var expectedUserID = Helpers.GenerateSHA256Hash(testUserEmail);

            var newUser = new User(testUserFirst, testUserLast, testUserEmail, testUserPassword);

            mockFS.Setup(fs => fs.ReadAllText(userDBFilepath)).Returns(initialUserDB);
            mockFS.Setup(fs => fs.Exists(userDBFilepath)).Returns(true);
            mockFS.Setup(fs => fs.ReadAllText(passwordDBFilepath)).Returns(initialPasswordDB);
            mockFS.Setup(fs => fs.Exists(passwordDBFilepath)).Returns(true);

            string retrievedUserDB = null;
            mockFS.Setup(fs => fs.WriteAllText(userDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedUserDB = content;
                });
            string retrievedPasswordDB = null;
            mockFS.Setup(fs => fs.WriteAllText(passwordDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedPasswordDB = content;
                });

            //Act
            udbs.CreateUser(newUser);

            //Assert
            Assert.IsNotNull(retrievedUserDB);
            //deserialize the retrievedUserDB
            var userDB = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedUserDB);
            Assert.IsNotNull(userDB);
            Assert.AreEqual(1, userDB.Count);
            Assert.AreEqual(expectedUserID, userDB[0]["UserID"]);
            Assert.AreEqual(testUserFirst, userDB[0]["FirstName"]);
            Assert.AreEqual(testUserLast, userDB[0]["LastName"]);
            Assert.AreEqual(testUserEmail, userDB[0]["Email"]);

            //deserialize the retrievedPasswordDB
            var passwordDB = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedPasswordDB);
            Assert.IsNotNull(passwordDB);
            Assert.AreEqual(1, passwordDB.Count);
            Assert.AreEqual(expectedUserID, passwordDB[0]["UserID"]);
            Assert.AreEqual(hashedPassword, passwordDB[0]["Password"]);
        }

        [TestMethod()]
        public void ReadUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadPasswordDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            Assert.Fail();
        }
    }
}