using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;
using System.Text.Json;
using Moq;

namespace Groomy.Invoices.Tests
{
    [TestClass()]
    public class InvoiceDBServiceTests
    {
        [TestMethod()]
        public void InvoiceDBServiceManagerSingleton()
        {
            var ms = new ManagerSingleton();
            var idbs = new InvoiceDBService(ms);
            Assert.IsInstanceOfType(idbs, typeof(InvoiceDBService));
        }

        [TestMethod()]
        public void InvoiceDBServiceTest1()
        {
            var fs = new FileService();
            var dbm = new DatabaseManager(fs);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);
            Assert.IsInstanceOfType(idbs, typeof(InvoiceDBService));
        }

        [TestMethod()]
        public void CreateInvoiceTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testCustomerID = "testCustomerID";
            var testCreateDate = DateTime.Now;
            var testDueDate = DateTime.Now;
            var testIsPaid = false;

            var invoice = new Invoice(testCustomerID, testCreateDate, testDueDate, testIsPaid);

            var invoiceDBFilepath = "invoices.json";
            var initialInvoiceDB = "[]";

            var relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = "[]";

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(initialInvoiceDB);
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(initialRelationshipDB);
            mockFS.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedInvoiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoiceDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedInvoiceDB = content);

            string retirevedRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedRelationshipDB = content);

            //Act
            idbs.CreateInvoice(invoice, testCustomerID);

            //Assert
            Assert.IsNotNull(retrievedInvoiceDB);
            //Deserialize the retrievedInvoiceDB and check if the invoice was added
            var invoices = JsonSerializer.Deserialize<List<Dictionary<string,string>>>(retrievedInvoiceDB);
            Assert.IsNotNull(invoices);
            Assert.AreEqual(1, invoices.Count);
            Assert.AreEqual(testCustomerID, invoices[0]["CustomerID"]);
            Assert.AreEqual(testCreateDate.ToString(), invoices[0]["CreateDate"]);
            Assert.AreEqual(testDueDate.ToString(), invoices[0]["DueDate"]);
            Assert.AreEqual(testIsPaid.ToString(), invoices[0]["IsPaid"]);
        }

        [TestMethod()]
        public void ReadInvoiceDataTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testCustomerID = "testCustomerID";
            var testCreateDate = DateTime.Now;
            var testDueDate = DateTime.Now;
            var testIsPaid = false;
            var testInvoiceID = "testInvoiceID";

            var invoiceDBFilepath = "invoices.json";
            var initialInvoiceDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "CreateDate", testCreateDate.ToString() },
                    { "DueDate", testDueDate.ToString() },
                    { "IsPaid", testIsPaid.ToString() },
                    { "InvoiceID", testInvoiceID }
                }
            };

            var relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "InvoiceID", testInvoiceID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDB));
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            //Act
            var retrievedInvoice = idbs.ReadInvoiceData(testInvoiceID);

            //Assert
            Assert.IsNotNull(retrievedInvoice);
            Assert.AreEqual(testCustomerID, retrievedInvoice["CustomerID"]);
            Assert.AreEqual(testCreateDate.ToString(), retrievedInvoice["CreateDate"]);
            Assert.AreEqual(testDueDate.ToString(), retrievedInvoice["DueDate"]);
            Assert.AreEqual(testIsPaid.ToString(), retrievedInvoice["IsPaid"]);
            Assert.AreEqual(testInvoiceID, retrievedInvoice["InvoiceID"]);

        }

        [TestMethod()]
        public void UpdateInvoiceDataTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testCustomerID = "testCustomerID";
            var testCreateDate = DateTime.Now;
            var testDueDate = DateTime.Now;
            var testIsPaid = false;
            var testInvoiceID = "testInvoiceID";

            var newIsPaid = true;

            var invoice = new Invoice(testCustomerID, testCreateDate, testDueDate, newIsPaid, testInvoiceID);

            var invoiceDBFilepath = "invoices.json";
            var initialInvoiceDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "CreateDate", testCreateDate.ToString() },
                    { "DueDate", testDueDate.ToString() },
                    { "IsPaid", testIsPaid.ToString() },
                    { "InvoiceID", testInvoiceID }
                }
            };

            var relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "InvoiceID", testInvoiceID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDB));
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedInvoiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoiceDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedInvoiceDB = content);

            string retirevedRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedRelationshipDB = content);

            //Act
            idbs.UpdateInvoiceData(invoice, testCustomerID);

            //Assert
            Assert.IsNotNull(retrievedInvoiceDB);
            //Deserialize the retrievedInvoiceDB and check if the invoice was added
            var invoices = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedInvoiceDB);
            Assert.IsNotNull(invoices);
            Assert.AreEqual(1, invoices.Count);
            Assert.AreEqual(testCustomerID, invoices[0]["CustomerID"]);
            Assert.AreEqual(testCreateDate.ToString(), invoices[0]["CreateDate"]);
            Assert.AreEqual(testDueDate.ToString(), invoices[0]["DueDate"]);
            //Check if the IsPaid was updated
            Assert.AreEqual(newIsPaid.ToString(), invoices[0]["IsPaid"]);
            Assert.AreEqual(testInvoiceID, invoices[0]["InvoiceID"]);

        }

        [TestMethod()]
        public void DeleteInvoiceTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testCustomerID = "testCustomerID";
            var testCreateDate = DateTime.Now;
            var testDueDate = DateTime.Now;
            var testIsPaid = false;
            var testInvoiceID = "testInvoiceID";

            var invoiceDBFilepath = "invoices.json";
            var initialInvoiceDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "CreateDate", testCreateDate.ToString() },
                    { "DueDate", testDueDate.ToString() },
                    { "IsPaid", testIsPaid.ToString() },
                    { "InvoiceID", testInvoiceID }
                }
            };

            var relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "customerID", testCustomerID },
                    { "invoiceID", testInvoiceID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDB));
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedInvoiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoiceDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedInvoiceDB = content);

            string retirevedRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedRelationshipDB = content);

            //Act
            idbs.DeleteInvoice(testInvoiceID);

            //Assert
            Assert.IsNotNull(retrievedInvoiceDB);
            //Deserialize the retrievedInvoiceDB and check if the invoice was added
            var invoices = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedInvoiceDB);
            Assert.IsNotNull(invoices);
            Assert.AreEqual(0, invoices.Count);

            Assert.IsNotNull(retirevedRelationshipDB);
            //Deserialize the retirevedRelationshipDB and check if the relationship was deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retirevedRelationshipDB);
            Assert.IsNotNull(relationships);
            Assert.AreEqual(0, relationships.Count);

        }

        [TestMethod()]
        public void SoftDeleteInvoiceTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testCustomerID = "testCustomerID";
            var testCreateDate = DateTime.Now;
            var testDueDate = DateTime.Now;
            var testIsPaid = false;
            var testInvoiceID = "testInvoiceID";

            var invoiceDBFilepath = "invoices.json";
            var initialInvoiceDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", testCustomerID },
                    { "CreateDate", testCreateDate.ToString() },
                    { "DueDate", testDueDate.ToString() },
                    { "IsPaid", testIsPaid.ToString() },
                    { "InvoiceID", testInvoiceID }
                }
            };

            var relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "customerID", testCustomerID },
                    { "invoiceID", testInvoiceID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDB));
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedInvoiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoiceDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedInvoiceDB = content);

            string retirevedRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedRelationshipDB = content);

            //Act
            idbs.SoftDeleteInvoice(testInvoiceID);

            mockFS.Verify(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()), Times.Once);

            //Assert
            Assert.IsNotNull(retrievedInvoiceDB);
            //Deserialize the retrievedInvoiceDB and check if the invoice was added
            var invoices = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedInvoiceDB);
            Assert.IsNotNull(invoices);
            Assert.AreEqual(1, invoices.Count);
            Assert.AreEqual(testCustomerID, invoices[0]["CustomerID"]);
            Assert.AreEqual(testCreateDate.ToString(), invoices[0]["CreateDate"]);
            Assert.AreEqual(testDueDate.ToString(), invoices[0]["DueDate"]);
            Assert.AreEqual(testIsPaid.ToString(), invoices[0]["IsPaid"]);
            Assert.AreEqual(testInvoiceID, invoices[0]["InvoiceID"]);
            Assert.AreEqual("true", invoices[0]["IsDeleted"]);

            Assert.IsNotNull(retirevedRelationshipDB);
            //Deserialize the retirevedRelationshipDB and check if the relationship was deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retirevedRelationshipDB);
            Assert.IsNotNull(relationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(testCustomerID, relationships[0]["customerID"]);
            Assert.AreEqual(testInvoiceID, relationships[0]["invoiceID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void CreateDetailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadDetailDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateDetailDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteDetailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteDetailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetInvoicesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDetailsTest()
        {
            Assert.Fail();
        }
    }
}