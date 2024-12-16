using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;

namespace Groomy.Notes.Tests
{
    [TestClass()]
    public class NotesDBServiceTests
    {
        [TestMethod()]
        public void NotesDBServieManagerSingleton()
        {
            var ms = new ManagerSingleton();
            var ndbs = new NotesDBService(ms);
            Assert.IsInstanceOfType(ndbs, typeof(NotesDBService));
        }

        [TestMethod()]
        public void NotesDBServiceDependancyInjection()
        {
            var fs = new FileService();
            var dbm = new DatabaseManager(fs);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);
            Assert.IsInstanceOfType(ndbs, typeof(NotesDBService));
        }

        [TestMethod()]
        public void CreateCustomerNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAppointmentNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateServiceNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadNotesDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCustomerNotesDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAppointmentNotesDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateServiceNotesDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCustomerNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAppointmentNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteCustomerNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteAppointmentNotesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteServiceNotesTest()
        {
            Assert.Fail();
        }
    }
}