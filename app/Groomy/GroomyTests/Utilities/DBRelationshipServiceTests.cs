using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Users;
using Moq;
using System.Text.Json;

namespace Groomy.Utilities.Tests
{
    [TestClass()]
    public class DBRelationshipServiceTests
    {
        [TestMethod()]
        public void DBRelationshipServiceTestManagerSingletoninitialization()
        {
            ManagerSingleton ms = new ManagerSingleton();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(ms);
            Assert.IsInstanceOfType(dbRelationshipService, typeof(DBRelationshipService));
        }

        [TestMethod()]
        public void DBRelationshipServiceTestDependancyInjectionInitialization()
        {
            FileService fs = new FileService();
            DatabaseManager dbm = new DatabaseManager(fs);
            UserAuth ua = new UserAuth();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, ua);
            Assert.IsInstanceOfType(dbRelationshipService, typeof(DBRelationshipService));
        }

        [TestMethod()]
        public void GetCustomerIDsTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var mockUA = new Mock<IUserAuth>();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, mockUA.Object);

            var relationshipFilepath = "users_customers.json";

            var userID1 = "user1";
            var customerID1 = "customer1";
            var customerID2 = "customer2";

            var user_customer_relationshipsDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "userID", userID1 }, { "customerID", customerID1 } },
                new Dictionary<string, string> { { "userID", userID1 }, { "customerID", customerID2 } }
            };

            mockFS.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(JsonSerializer.Serialize(user_customer_relationshipsDB));
            mockFS.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            mockUA.Setup(ua => ua.getID()).Returns(userID1);

            //Act
            var retrievedCustomerIDs = dbRelationshipService.GetCustomerIDs();
            //Assert
            
            Assert.AreEqual(2, retrievedCustomerIDs.Count, "should return 2 customer IDs");
            Assert.AreEqual(customerID1, retrievedCustomerIDs[0], $"The value for {customerID1} should match the input");
            Assert.AreEqual(customerID2, retrievedCustomerIDs[1], $"The value for {customerID2} should match the input");
        }

        [TestMethod()]
        public void GetInvoiceIDsTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var mockUA = new Mock<IUserAuth>();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, mockUA.Object);

            var uc_rp = "users_customers.json";

            var userID1 = "user1";
            var customerID1 = "customer1";
            var customerID2 = "customer2";

            var user_customer_relationshipsDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "userID", userID1 }, { "customerID", customerID1 } },
                new Dictionary<string, string> { { "userID", userID1 }, { "customerID", customerID2 } }
            };

            var ci_rp = "customers_invoices.json";

            var invoiceID1 = "invoice1";
            var invoiceID2 = "invoice2";
            var invoiceID3 = "invoice3";
            var invoiceID4 = "invoice4";

            var customer_invoice_relationshipsDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "customerID", customerID1 }, { "invoiceID", invoiceID1 } },
                new Dictionary<string, string> { { "customerID", customerID1 }, { "invoiceID", invoiceID2 } },
                new Dictionary<string, string> { { "customerID", customerID2 }, { "invoiceID", invoiceID3 } },
                new Dictionary<string, string> { { "customerID", customerID2 }, { "invoiceID", invoiceID4 } }
            };

            mockUA.Setup(ua => ua.getID()).Returns(userID1);

            mockFS.Setup(fs => fs.ReadAllText(uc_rp)).Returns(JsonSerializer.Serialize(user_customer_relationshipsDB));
            mockFS.Setup(fs => fs.Exists(uc_rp)).Returns(true);
            mockFS.Setup(fs => fs.ReadAllText(ci_rp)).Returns(JsonSerializer.Serialize(customer_invoice_relationshipsDB));
            mockFS.Setup(fs => fs.Exists(ci_rp)).Returns(true);

            //Act
            var retrievedInvoiceIDs = dbRelationshipService.GetInvoiceIDs();

            //Assert
            Assert.AreEqual(4, retrievedInvoiceIDs.Count, "should return 4 invoice IDs");
            Assert.AreEqual(invoiceID1, retrievedInvoiceIDs[0], $"The value for {invoiceID1} should match the input");
            Assert.AreEqual(invoiceID2, retrievedInvoiceIDs[1], $"The value for {invoiceID2} should match the input");
            Assert.AreEqual(invoiceID3, retrievedInvoiceIDs[2], $"The value for {invoiceID3} should match the input");
            Assert.AreEqual(invoiceID4, retrievedInvoiceIDs[3], $"The value for {invoiceID4} should match the input");


        }

        [TestMethod()]
        public void GetServiceIDsTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, ua);

            var serviceFilepath = "services.json";

            var serviceID1 = "service1";
            var serviceID2 = "service2";

            var serviceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "ServiceID", serviceID1 } },
                new Dictionary<string, string> { { "ServiceID", serviceID2 } }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceFilepath)).Returns(JsonSerializer.Serialize(serviceDB));
            mockFS.Setup(fs => fs.Exists(serviceFilepath)).Returns(true);

            //Act
            var retrievedServiceIDs = dbRelationshipService.GetServiceIDs();

            //Assert
            Assert.AreEqual(2, retrievedServiceIDs.Count, "should return 2 service IDs");
            Assert.AreEqual(serviceID1, retrievedServiceIDs[0], $"The value for {serviceID1} should match the input");
            Assert.AreEqual(serviceID2, retrievedServiceIDs[1], $"The value for {serviceID2} should match the input");
        }

        [TestMethod()]
        public void GetForeignIDsFromPrimaryIDTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, ua);


            var relationshipFilepath = "test.json";
            var foreign_primary_relationship_db = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "foreignID", "foreign1" }, { "primaryID", "primary1" } },
                new Dictionary<string, string> { { "foreignID", "foreign2" }, { "primaryID", "primary1" } },
                new Dictionary<string, string> { { "foreignID", "foreign3" }, { "primaryID", "primary2" } },
                new Dictionary<string, string> { { "foreignID", "foreign4" }, { "primaryID", "primary2" } }
            };

            mockFS.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(JsonSerializer.Serialize(foreign_primary_relationship_db));
            mockFS.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            //Act
            var retrievedForeignIDs = dbRelationshipService.GetForeignIDsFromPrimaryID("primary1", "test.json");

            //Assert
            Assert.AreEqual(2, retrievedForeignIDs.Count, "should return 2 foreign IDs");
            Assert.AreEqual("foreign1", retrievedForeignIDs[0], "The value for foreign1 should match the input");
            Assert.AreEqual("foreign2", retrievedForeignIDs[1], "The value for foreign2 should match the input");
        }

        [TestMethod()]
        public void GetPrimaryIDFromForeignIDTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            DBRelationshipService dbRelationshipService = new DBRelationshipService(dbm, ua);

            var relationshipFilepath = "test.json";
            var foreign_primary_relationship_db = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "foreignID", "foreign1" }, { "primaryID", "primary1" } },
                new Dictionary<string, string> { { "foreignID", "foreign2" }, { "primaryID", "primary1" } },
                new Dictionary<string, string> { { "foreignID", "foreign3" }, { "primaryID", "primary2" } },
                new Dictionary<string, string> { { "foreignID", "foreign4" }, { "primaryID", "primary2" } }
            };

            mockFS.Setup(fs => fs.ReadAllText(relationshipFilepath)).Returns(JsonSerializer.Serialize(foreign_primary_relationship_db));
            mockFS.Setup(fs => fs.Exists(relationshipFilepath)).Returns(true);

            //Act
            var retrievedForeignIDs = dbRelationshipService.GetPrimaryIDFromForeignID("foreign3", "test.json");

            //Assert
            Assert.AreEqual("primary2", retrievedForeignIDs, "should return primary2");
        }
    }
}