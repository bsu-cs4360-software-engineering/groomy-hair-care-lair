using Groomy.Users;
using Groomy.Utilities;

namespace Groomy.Services.Tests
{
    [TestClass()]
    public class ServiceDBServiceTests
    {
        [TestMethod()]
        public void ServiceDBServiceManagerSingleton()
        {
            var ms = new ManagerSingleton();
            var sdbs = new ServiceDBService(ms);
            Assert.IsInstanceOfType(sdbs, typeof(ServiceDBService));
        }

        [TestMethod()]
        public void ServiceDBServiceDependancyInjection()
        {
            var fs = new FileService();
            var dbm = new DatabaseManager(fs);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);
        }

        [TestMethod()]
        public void CreateServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadServiceDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateServiceDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetServicesTest()
        {
            Assert.Fail();
        }
    }
}