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
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var testServiceID = "testServiceID";
            var testServiceQuantity = 1;

            var testDetail = new InvoiceDetail(testServiceID, testServiceQuantity);

            var expectedDetailID = testDetail.GetKey();

            var detailDBFilepath = "details.json";
            var initialDetailDB = "[]";

            var invoice_detail_relationshipDBFilepath = "invoices_details.json";
            var initialInvoiceDetailRelationshipDB = "[]";

            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(initialDetailDB);
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(invoice_detail_relationshipDBFilepath)).Returns(initialInvoiceDetailRelationshipDB);
            mockFS.Setup(fs => fs.Exists(invoice_detail_relationshipDBFilepath)).Returns(true);

            string retrievedDetailDB = null;
            mockFS.Setup(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedDetailDB = content);

            string retirevedInvoiceDetailRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedInvoiceDetailRelationshipDB = content);

            //Act
            idbs.CreateDetail(testDetail, testInvoiceID);

            //Assert
            Assert.IsNotNull(retrievedDetailDB);
            //Deserialize the retrievedDetailDB and check if the detail was added
            var details = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedDetailDB);
            Assert.IsNotNull(details);
            Assert.AreEqual(1, details.Count);
            Assert.AreEqual(testServiceID, details[0]["ServiceID"]);
            Assert.AreEqual(testServiceQuantity.ToString(), details[0]["Quantity"]);
            Assert.AreEqual(expectedDetailID, details[0]["DetailID"]);

            //Deserialize the retirevedInvoiceDetailRelationshipDB and check if the relationship was added
            Assert.IsNotNull(retirevedInvoiceDetailRelationshipDB);
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retirevedInvoiceDetailRelationshipDB);
            Assert.IsNotNull(relationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(expectedDetailID, relationships[0]["detailID"]);
            Assert.AreEqual(testInvoiceID, relationships[0]["invoiceID"]);
        }

        [TestMethod()]
        public void ReadDetailDataTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var testServiceID = "testServiceID";
            var testServiceQuantity = 1;
            var testDetialID = "testDetailID";

            var detailDBFilepath = "details.json";
            var initialDetailDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "ServiceID", testServiceID },
                    { "Quantity", testServiceQuantity.ToString() },
                    { "DetailID", testDetialID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(JsonSerializer.Serialize(initialDetailDB));
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            //Act
            var retrievedDetail = idbs.ReadDetailData(testDetialID);

            //Assert
            Assert.IsNotNull(retrievedDetail);
            Assert.AreEqual(testServiceID, retrievedDetail["ServiceID"]);
            Assert.AreEqual(testServiceQuantity.ToString(), retrievedDetail["Quantity"]);
            Assert.AreEqual(testDetialID, retrievedDetail["DetailID"]);
        }

        [TestMethod()]
        public void UpdateDetailDataTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var testServiceID = "testServiceID";
            var testServiceQuantity = 1;
            var testDetialID = "testDetailID";

            var detailDBFilepath = "details.json";
            var initialDetailDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "ServiceID", testServiceID },
                    { "Quantity", testServiceQuantity.ToString() },
                    { "DetailID", testDetialID }
                }
            };

            var invoice_detail_relationshipDBFilepath = "invoices_details.json";
            var initialInvoiceDetailRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "detailID", testDetialID },
                    { "invoiceID", testInvoiceID }
                }
            };


            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(JsonSerializer.Serialize(initialDetailDB));
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(invoice_detail_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDetailRelationshipDB));
            mockFS.Setup(fs => fs.Exists(invoice_detail_relationshipDBFilepath)).Returns(true);

            string retrievedDetailDB = null;
            mockFS.Setup(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedDetailDB = content);

            string retirevedInvoiceDetailRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedInvoiceDetailRelationshipDB = content);

            //Act
           
        }

        [TestMethod()]
        public void DeleteDetailTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var testServiceID = "testServiceID";
            var testServiceQuantity = 1;
            var testDetialID = "testDetailID";

            var detailDBFilepath = "details.json";
            var initialDetailDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()    {
                    { "ServiceID", testServiceID },
                    { "Quantity", testServiceQuantity.ToString() },
                    { "DetailID", testDetialID }
                }
            };

            var invoice_detail_relationshipDBFilepath = "invoices_details.json";
            var initialInvoiceDetailRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "invoiceID", testInvoiceID },
                    { "detailID", testDetialID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(JsonSerializer.Serialize(initialDetailDB));
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(invoice_detail_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDetailRelationshipDB));
            mockFS.Setup(fs => fs.Exists(invoice_detail_relationshipDBFilepath)).Returns(true);

            string retrievedDetailDB = null;
            mockFS.Setup(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedDetailDB = content);

            string retirevedInvoiceDetailRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedInvoiceDetailRelationshipDB = content);

            //Act
            idbs.DeleteDetail(testDetialID);

            mockFS.Verify(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()), Times.Once);
            mockFS.Verify(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()), Times.Once);

            //Assert
            Assert.IsNotNull(retrievedDetailDB);
            //Deserialize the retrievedDetailDB and check if the detail was added
            var details = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedDetailDB);
            Assert.IsNotNull(details);
            Assert.AreEqual(0, details.Count);

            Assert.IsNotNull(retirevedInvoiceDetailRelationshipDB);
            //Deserialize the retirevedInvoiceDetailRelationshipDB and check if the relationship was deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retirevedInvoiceDetailRelationshipDB);
            Assert.IsNotNull(relationships);
            Assert.AreEqual(0, relationships.Count);

        }

        [TestMethod()]
        public void SoftDeleteDetailTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var testServiceID = "testServiceID";
            var testServiceQuantity = 1;
            var testDetialID = "testDetailID";

            var detailDBFilepath = "details.json";
            var initialDetailDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()    {
                    { "ServiceID", testServiceID },
                    { "Quantity", testServiceQuantity.ToString() },
                    { "DetailID", testDetialID }
                }
            };

            var invoice_detail_relationshipDBFilepath = "invoices_details.json";
            var initialInvoiceDetailRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "invoiceID", testInvoiceID },
                    { "detailID", testDetialID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(JsonSerializer.Serialize(initialDetailDB));
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(invoice_detail_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialInvoiceDetailRelationshipDB));
            mockFS.Setup(fs => fs.Exists(invoice_detail_relationshipDBFilepath)).Returns(true);

            string retrievedDetailDB = null;
            mockFS.Setup(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedDetailDB = content);

            string retirevedInvoiceDetailRelationshipDB = null;
            mockFS.Setup(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retirevedInvoiceDetailRelationshipDB = content);

            //Act
            idbs.SoftDeleteDetail(testDetialID);

            mockFS.Verify(fs => fs.WriteAllText(detailDBFilepath, It.IsAny<string>()), Times.Once);
            mockFS.Verify(fs => fs.WriteAllText(invoice_detail_relationshipDBFilepath, It.IsAny<string>()), Times.Once);

            //Assert
            Assert.IsNotNull(retrievedDetailDB);
            //Deserialize the retrievedDetailDB and check if the detail was added
            var details = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedDetailDB);
            Assert.IsNotNull(details);
            Assert.AreEqual(1, details.Count);
            Assert.AreEqual(testServiceID, details[0]["ServiceID"]);
            Assert.AreEqual(testServiceQuantity.ToString(), details[0]["Quantity"]);
            Assert.AreEqual(testDetialID, details[0]["DetailID"]);
            Assert.AreEqual("true", details[0]["IsDeleted"]);

            Assert.IsNotNull(retirevedInvoiceDetailRelationshipDB);
            //Deserialize the retirevedInvoiceDetailRelationshipDB and check if the relationship was deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retirevedInvoiceDetailRelationshipDB);
            Assert.IsNotNull(relationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(testInvoiceID, relationships[0]["invoiceID"]);
            Assert.AreEqual(testDetialID, relationships[0]["detailID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);
                
        }

        [TestMethod()]
        public void GetInvoicesTest()
        {
            // Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);
            var idbs = new InvoiceDBService(dbm, dbrs);
            var testUserID = "testUserID";

            var test1CustomerID = "test1CustomerID";
            var test2CustomerID = "test2CustomerID";

            var user_customer_relationshipDBFilepath = "users_customers.json";
            var initialUserCustomerDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "userID", testUserID },
                    { "customerID", test1CustomerID }
                },
                new Dictionary<string, string>()
                {
                    { "userID", testUserID },
                    { "customerID", test2CustomerID }
                }
            };

            var test1CreateDate = DateTime.Now;
            var test1DueDate = DateTime.Now;
            var test1IsPaid = false;
            var test1InvoiceID = "testInvoiceID";

            var test2CreateDate = DateTime.Now;
            var test2DueDate = DateTime.Now;
            var test2IsPaid = false;
            var test2InvoiceID = "testInvoiceID2";

            var customers_invoices_relationshipDBFilepath = "customers_invoices.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "customerID", test1CustomerID },
                    { "invoiceID", test1InvoiceID }
                },
                new Dictionary<string, string>()
                {
                    { "customerID", test2CustomerID },
                    { "invoiceID", test2InvoiceID }
                }
            };

            var invoiceDBFilepath = "invoices.json";
            var invoiceDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "CustomerID", test1CustomerID },
                    { "CreateDate", test1CreateDate.ToString() },
                    { "DueDate", test1DueDate.ToString() },
                    { "IsPaid", test1IsPaid.ToString() },
                    { "InvoiceID", test1InvoiceID }
                },
                new Dictionary<string, string>()
                {
                    { "CustomerID", test2CustomerID },
                    { "CreateDate", test2CreateDate.ToString() },
                    { "DueDate", test2DueDate.ToString() },
                    { "IsPaid", test2IsPaid.ToString() },
                    { "InvoiceID", test2InvoiceID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(user_customer_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialUserCustomerDB));
            mockFS.Setup(fs => fs.Exists(user_customer_relationshipDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(invoiceDBFilepath)).Returns(JsonSerializer.Serialize(invoiceDB));
            mockFS.Setup(fs => fs.Exists(invoiceDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(customers_invoices_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(customers_invoices_relationshipDBFilepath)).Returns(true);

            mockUA.Setup(ua => ua.getID()).Returns(testUserID);

            //Act
            var invoices = idbs.GetInvoices();

            //Assert
            Assert.IsNotNull(invoices);
            Assert.AreEqual(2, invoices.Count);
            Assert.AreEqual(test1CustomerID, invoices[0]["CustomerID"]);
            Assert.AreEqual(test1CreateDate.ToString(), invoices[0]["CreateDate"]);
            Assert.AreEqual(test1DueDate.ToString(), invoices[0]["DueDate"]);
            Assert.AreEqual(test1IsPaid.ToString(), invoices[0]["IsPaid"]);
            Assert.AreEqual(test1InvoiceID, invoices[0]["InvoiceID"]);

            Assert.AreEqual(test2CustomerID, invoices[1]["CustomerID"]);
            Assert.AreEqual(test2CreateDate.ToString(), invoices[1]["CreateDate"]);
            Assert.AreEqual(test2DueDate.ToString(), invoices[1]["DueDate"]);
            Assert.AreEqual(test2IsPaid.ToString(), invoices[1]["IsPaid"]);
            Assert.AreEqual(test2InvoiceID, invoices[1]["InvoiceID"]);

        }

        [TestMethod()]
        public void GetDetailsTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var idbs = new InvoiceDBService(dbm, dbrs);

            var testInvoiceID = "testInvoiceID";

            var test1DetailID = "test1DetailID";
            var test2DetailID = "test2DetailID";

            var invoice_detail_relationshipDBFilepath = "invoices_details.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "invoiceID", testInvoiceID },
                    { "detailID", test1DetailID }
                },
                new Dictionary<string, string>()
                {
                    { "invoiceID", testInvoiceID },
                    { "detailID", test2DetailID }
                }
            };

            var test1ServiceID = "test1ServiceID";
            var test1ServiceQuantity = 1;

            var test2ServiceID = "test2ServiceID";
            var test2ServiceQuantity = 2;

            var detailDBFilepath = "details.json";
            var initialDetailDB = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    { "ServiceID", test1ServiceID },
                    { "Quantity", test1ServiceQuantity.ToString() },
                    { "DetailID", test1DetailID }
                },
                new Dictionary<string, string>()
                {
                    { "ServiceID", test2ServiceID },
                    { "Quantity", test2ServiceQuantity.ToString() },
                    { "DetailID", test2DetailID }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoice_detail_relationshipDBFilepath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(invoice_detail_relationshipDBFilepath)).Returns(true);
            mockFS.Setup(fs => fs.ReadAllText(detailDBFilepath)).Returns(JsonSerializer.Serialize(initialDetailDB));
            mockFS.Setup(fs => fs.Exists(detailDBFilepath)).Returns(true);

            //Act
            var details = idbs.GetDetails(testInvoiceID);

            //Assert
            Assert.IsNotNull(details);
            Assert.AreEqual(2, details.Count);
            Assert.AreEqual(test1ServiceID, details[0]["ServiceID"]);
            Assert.AreEqual(test1ServiceQuantity.ToString(), details[0]["Quantity"]);
            Assert.AreEqual(test1DetailID, details[0]["DetailID"]);

            Assert.AreEqual(test2ServiceID, details[1]["ServiceID"]);
            Assert.AreEqual(test2ServiceQuantity.ToString(), details[1]["Quantity"]);
            Assert.AreEqual(test2DetailID, details[1]["DetailID"]);


        }
    }
}