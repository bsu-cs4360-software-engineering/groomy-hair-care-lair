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
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCustomerDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteCustomerTest()
        {
            Assert.Fail();
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