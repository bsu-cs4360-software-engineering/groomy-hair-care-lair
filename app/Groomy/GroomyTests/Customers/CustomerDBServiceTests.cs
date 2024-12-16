using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;
using Moq;

using System.Text.Json;

namespace GroomyTests.Customers
{
    [TestClass()]
    public class CustomerDBServiceTests
    {
        [TestMethod()]
        public void CustomerDBServiceManagerSingletonTest()
        {
            var managerSingleton = new ManagerSingleton();
            var dbService = new CustomerDBService(managerSingleton);
            Assert.IsNotNull(dbService);
            Assert.IsTrue(dbService is CustomerDBService);
        }
        [TestMethod()]
        public void CustomerDBServiceDependancyInjectionTest()
        {
            var fileService = new FileService();
            var dbManager = new DatabaseManager(fileService);
            var userAuth = new UserAuth();
            var dbRelationshipService = new DBRelationshipService(dbManager, userAuth);
            var dbService = new CustomerDBService(dbManager, userAuth, dbRelationshipService);
            Assert.IsTrue(dbService is CustomerDBService);
        }

        [TestMethod()]
        public void CreateCustomerTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);

            var customerDBService = new CustomerDBService(dbm, mockUA.Object, dbrs);

            var testUserID = "testUserID";

            var customerFirst = "First";
            var customerLast = "Last";
            var customerEmail = "Email";
            var customerPhone = "Phone";
            var customerAddress = "Address";

            var newCustomer = new Customer(customerFirst, customerLast, customerEmail, customerPhone, customerAddress);

            var expectedCustomerID = newCustomer.GetKey();


            var customerDBFilepath = "customers.json";

            var initialCustomerDB = "[]";

            var relationshipDBFilepath = "users_customers.json";

            var initialRelationshipDB = "[]";


            mockUA.Setup(mockUA => mockUA.getID()).Returns(testUserID);

            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(initialRelationshipDB);

            mockFileService.Setup(fs => fs.ReadAllText(customerDBFilepath)).Returns(initialCustomerDB);
            mockFileService.Setup(fs => fs.Exists(customerDBFilepath)).Returns(true);


            string retrievedUserDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(customerDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedUserDB = content;
                });

            string retrievedRelationshipDB = null; 
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedRelationshipDB = content;
                });

            //Act
            customerDBService.CreateCustomer(newCustomer);

            //Assert
            Assert.IsNotNull(retrievedUserDB);
            //Deserialize the retrievedUserData
            var retrievedUsers = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedUserDB);
            Assert.AreEqual(1, retrievedUsers.Count);
            Assert.AreEqual(expectedCustomerID, retrievedUsers[0]["CustomerID"]);
            Assert.AreEqual(customerFirst, retrievedUsers[0]["FirstName"]);
            Assert.AreEqual(customerLast, retrievedUsers[0]["LastName"]);
            Assert.AreEqual(customerEmail, retrievedUsers[0]["Email"]);
            Assert.AreEqual(customerPhone, retrievedUsers[0]["PhoneNumber"]);
            Assert.AreEqual(customerAddress, retrievedUsers[0]["Address"]);

            Assert.IsNotNull(retrievedRelationshipDB);
            //Deserialize the retrievedRelationshipData
            var retrievedRelationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipDB);
            Assert.AreEqual(1, retrievedRelationships.Count);
            Assert.AreEqual(testUserID, retrievedRelationships[0]["userID"]);
            Assert.AreEqual(expectedCustomerID, retrievedRelationships[0]["customerID"]);
        }

        [TestMethod()]
        public void ReadCustomerTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);

            var customerDBService = new CustomerDBService(dbm, ua, dbrs);

            var customerFirst = "First";
            var customerLast = "Last";
            var customerEmail = "Email";
            var customerPhone = "Phone";
            var customerAddress = "Address";
            var testCustomerID = "customerID"; 

            var customerDBFilepath = "customers.json";

            var initialCustomerDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "CustomerID", testCustomerID },
                    { "FirstName", customerFirst },
                    { "LastName", customerLast },
                    { "Email", customerEmail },
                    { "PhoneNumber", customerPhone },
                    { "Address", customerAddress }
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(customerDBFilepath)).Returns(JsonSerializer.Serialize(initialCustomerDB));
            mockFileService.Setup(fs => fs.Exists(customerDBFilepath)).Returns(true);

            //Act
            var retrievedCustomer = customerDBService.ReadCustomer(testCustomerID);

            //Assert
            Assert.IsNotNull(retrievedCustomer);
            Assert.AreEqual(testCustomerID, retrievedCustomer["CustomerID"]);
            Assert.AreEqual(customerFirst, retrievedCustomer["FirstName"]);
            Assert.AreEqual(customerLast, retrievedCustomer["LastName"]);
            Assert.AreEqual(customerEmail, retrievedCustomer["Email"]);
            Assert.AreEqual(customerPhone, retrievedCustomer["PhoneNumber"]);
            Assert.AreEqual(customerAddress, retrievedCustomer["Address"]);
        }

        [TestMethod()]
        public void UpdateCustomerDataTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);

            var customerDBService = new CustomerDBService(dbm, mockUA.Object, dbrs);

            var testUserID = "userID";

            var customerFirst = "First";
            var customerLast = "Last";
            var customerEmail = "Email";
            var customerPhone = "Phone";
            var customerAddress = "Address";
            var testCustomerID = "customerID";

            var newCustomerEmail = "NewEmail";
            var newCustomerPhone = "NewPhone";
            var newCustomerAddress = "NewAddress";

            var updatedCustomer = new Customer(customerFirst, customerLast, newCustomerEmail, newCustomerPhone, newCustomerAddress, testCustomerID);

            var customerDBFilepath = "customers.json";

            var initialCustomerDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "CustomerID", testCustomerID },
                    { "FirstName", customerFirst },
                    { "LastName", customerLast },
                    { "Email", customerEmail },
                    { "PhoneNumber", customerPhone },
                    { "Address", customerAddress }
                }
            };

            var relationshipDBFilepath = "users_customers.json";
            var initialRelationshipDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "userID", testUserID },
                    { "customerID", testCustomerID }
                }
            };
            mockUA.Setup(ua => ua.getID()).Returns(testUserID);

            mockFileService.Setup(fs => fs.ReadAllText(customerDBFilepath)).Returns(JsonSerializer.Serialize(initialCustomerDB));
            mockFileService.Setup(fs => fs.Exists(customerDBFilepath)).Returns(true);

            string retrievedCustomerDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(customerDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedCustomerDB = content;
                });

            //Act
            customerDBService.UpdateCustomerData(updatedCustomer);

            //Assert
            Assert.IsNotNull(retrievedCustomerDB);
            //Deserialize the retrievedUserData
            var retrievedUsers = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedCustomerDB);
            //Assert that the customer was updated
            Assert.AreEqual(1, retrievedUsers.Count);
            Assert.AreEqual(testCustomerID, retrievedUsers[0]["CustomerID"]);
            Assert.AreEqual(customerFirst, retrievedUsers[0]["FirstName"]);
            Assert.AreEqual(customerLast, retrievedUsers[0]["LastName"]);
            Assert.AreEqual(newCustomerEmail, retrievedUsers[0]["Email"]);
            Assert.AreEqual(newCustomerPhone, retrievedUsers[0]["PhoneNumber"]);
            Assert.AreEqual(newCustomerAddress, retrievedUsers[0]["Address"]);

        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);

            var customerDBService = new CustomerDBService(dbm, mockUA.Object, dbrs);

            var testUserID = "userID";

            var customerFirst = "First";
            var customerLast = "Last";
            var customerEmail = "Email";
            var customerPhone = "Phone";
            var customerAddress = "Address";
            var testCustomerID = "customerID";

            var customerDBFilepath = "customers.json";

            var initialCustomerDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "CustomerID", testCustomerID },
                    { "FirstName", customerFirst },
                    { "LastName", customerLast },
                    { "Email", customerEmail },
                    { "PhoneNumber", customerPhone },
                    { "Address", customerAddress }
                }
            };

            var relationshipDBFilepath = "users_customers.json";
            var initialRelationshipDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "userID", testUserID },
                    { "customerID", testCustomerID }
                }
            };
            mockUA.Setup(ua => ua.getID()).Returns(testUserID);

            mockFileService.Setup(fs => fs.ReadAllText(customerDBFilepath)).Returns(JsonSerializer.Serialize(initialCustomerDB));
            mockFileService.Setup(fs => fs.Exists(customerDBFilepath)).Returns(true);
            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFileService.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedCustomerDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(customerDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedCustomerDB = content;
                });

            string retrievedRelationshipDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedRelationshipDB = content;
                });

            //Act
            customerDBService.DeleteCustomer(testCustomerID);

            //Assert
            Assert.IsNotNull(retrievedCustomerDB);
            //Deserialize the retrievedUserData
            var retrievedUsers = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedCustomerDB);
            //Assert that the customer was deleted
            Assert.AreEqual(0, retrievedUsers.Count);

            Assert.IsNotNull(retrievedRelationshipDB);
            //Deserialize the retrievedRelationshipData
            var retrievedRelationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipDB);
            //Assert that the relationship was deleted
            Assert.AreEqual(0, retrievedRelationships.Count);
        }

        [TestMethod()]
        public void SoftDeleteCustomerTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);

            var customerDBService = new CustomerDBService(dbm, mockUA.Object, dbrs);

            var testUserID = "userID";

            var customerFirst = "First";
            var customerLast = "Last";
            var customerEmail = "Email";
            var customerPhone = "Phone";
            var customerAddress = "Address";
            var testCustomerID = "customerID";

            var customerDBFilepath = "customers.json";

            var initialCustomerDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "CustomerID", testCustomerID },
                    { "FirstName", customerFirst },
                    { "LastName", customerLast },
                    { "Email", customerEmail },
                    { "PhoneNumber", customerPhone },
                    { "Address", customerAddress }
                }
            };

            var relationshipDBFilepath = "users_customers.json";
            var initialRelationshipDB = new List<Dictionary<string, string>> {
                new Dictionary<string, string> {
                    { "userID", testUserID },
                    { "customerID", testCustomerID }
                }
            };
            mockUA.Setup(ua => ua.getID()).Returns(testUserID);

            mockFileService.Setup(fs => fs.ReadAllText(customerDBFilepath)).Returns(JsonSerializer.Serialize(initialCustomerDB));
            mockFileService.Setup(fs => fs.Exists(customerDBFilepath)).Returns(true);
            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFileService.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedCustomerDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(customerDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedCustomerDB = content;
                });

            string retrievedRelationshipDB = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) =>
                {
                    retrievedRelationshipDB = content;
                });

            //Act
            customerDBService.SoftDeleteCustomer(testCustomerID);

            //Assert
            Assert.IsNotNull(retrievedCustomerDB);
            //Deserialize the retrievedUserData
            var retrievedUsers = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedCustomerDB);
            //Assert that the customer was soft deleted
            Assert.AreEqual(1, retrievedUsers.Count);
            Assert.AreEqual(testCustomerID, retrievedUsers[0]["CustomerID"]);
            Assert.AreEqual(customerFirst, retrievedUsers[0]["FirstName"]);
            Assert.AreEqual(customerLast, retrievedUsers[0]["LastName"]);
            Assert.AreEqual(customerEmail, retrievedUsers[0]["Email"]);
            Assert.AreEqual(customerPhone, retrievedUsers[0]["PhoneNumber"]);
            Assert.AreEqual(customerAddress, retrievedUsers[0]["Address"]);
            Assert.AreEqual("true", retrievedUsers[0]["IsDeleted"]);

            //Assert that the relationship was soft deleted
            Assert.IsNotNull(retrievedRelationshipDB);
            //Deserialize the retrievedRelationshipData
            var retrievedRelationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipDB);
            Assert.AreEqual(1, retrievedRelationships.Count);
            Assert.AreEqual(testUserID, retrievedRelationships[0]["userID"]);
            Assert.AreEqual(testCustomerID, retrievedRelationships[0]["customerID"]);
            Assert.AreEqual("true", retrievedRelationships[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void GetCustomersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomerIDByEmailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomerIDByFirstLastTest()
        {
            Assert.Fail();
        }
    }
}