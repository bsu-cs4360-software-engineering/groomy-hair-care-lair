using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadInvoiceDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateInvoiceDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteInvoiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteInvoiceTest()
        {
            Assert.Fail();
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