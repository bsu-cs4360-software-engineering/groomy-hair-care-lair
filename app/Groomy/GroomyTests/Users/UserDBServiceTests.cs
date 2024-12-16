using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var fs = new Utilities.FileService();
            var dbm = new Utilities.DatabaseManager(fs);
            var udbs = new UserDBService(dbm);
            Assert.IsInstanceOfType(udbs, typeof(UserDBService));
        }

        [TestMethod()]
        public void IsUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsCorrectPasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            Assert.Fail();
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