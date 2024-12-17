using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Services;
using Groomy.Users;
using Groomy.Utilities;
using Moq;
using System.Text.Json;

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
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceDBFilePath = "services.json";
            var initialServiceDB = "[]";

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";


            var newService = new Service(serviceName, serviceDescription, servicePrice, serviceID);

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(initialServiceDB);
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            string retrievedServiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(serviceDBFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedServiceDB = content);

            //Act
            sdbs.CreateService(newService);

            //Assert
            Assert.IsNotNull(retrievedServiceDB);
            //deserialize the retrievedServiceDB
            var services = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServiceDB);
            Assert.IsNotNull(services);
            Assert.AreEqual(1, services.Count);
            Assert.AreEqual(serviceID, services[0]["ServiceID"]);
            Assert.AreEqual(serviceName, services[0]["ServiceName"]);
            Assert.AreEqual(serviceDescription, services[0]["ServiceDescription"]);
            Assert.AreEqual(servicePrice, services[0]["ServicePrice"]);
        }

        [TestMethod()]
        public void ReadServiceDataTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";


            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", serviceID },
                    { "ServiceName", serviceName },
                    { "ServiceDescription", serviceDescription },
                    { "ServicePrice", servicePrice }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            //Act
            var retrievedService = sdbs.ReadServiceData(serviceID);

            //Assert
            Assert.IsNotNull(retrievedService);
            Assert.AreEqual(serviceID, retrievedService["ServiceID"]);
            Assert.AreEqual(serviceName, retrievedService["ServiceName"]);
            Assert.AreEqual(serviceDescription, retrievedService["ServiceDescription"]);
            Assert.AreEqual(servicePrice, retrievedService["ServicePrice"]);
        }

        [TestMethod()]
        public void UpdateServiceDataTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";

            var newServicePrice = "20.00";


            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", serviceID },
                    { "ServiceName", serviceName },
                    { "ServiceDescription", serviceDescription },
                    { "ServicePrice", servicePrice }
                }
            };

            var updatedService = new Service(serviceName, serviceDescription, newServicePrice, serviceID);

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            string retrievedServiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(serviceDBFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedServiceDB = content);

            //Act
            sdbs.UpdateServiceData(updatedService);

            //Assert
            Assert.IsNotNull(retrievedServiceDB);
            //deserialize the retrievedServiceDB
            var services = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServiceDB);
            Assert.IsNotNull(services);
            Assert.AreEqual(1, services.Count);
            Assert.AreEqual(serviceID, services[0]["ServiceID"]);
            Assert.AreEqual(serviceName, services[0]["ServiceName"]);
            Assert.AreEqual(serviceDescription, services[0]["ServiceDescription"]);
            //Check if the service price has been updated
            Assert.AreEqual(newServicePrice, services[0]["ServicePrice"]);
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";

            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", serviceID },
                    { "ServiceName", serviceName },
                    { "ServiceDescription", serviceDescription },
                    { "ServicePrice", servicePrice }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            string retrievedServiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(serviceDBFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedServiceDB = content);

            //Act
            sdbs.DeleteService(serviceID);

            //Assert
            Assert.IsNotNull(retrievedServiceDB);
            //deserialize the retrievedServiceDB
            var services = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServiceDB);
            Assert.IsNotNull(services);
            Assert.AreEqual(0, services.Count);

        }

        [TestMethod()]
        public void SoftDeleteServiceTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";

            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", serviceID },
                    { "ServiceName", serviceName },
                    { "ServiceDescription", serviceDescription },
                    { "ServicePrice", servicePrice }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            string retrievedServiceDB = null;
            mockFS.Setup(fs => fs.WriteAllText(serviceDBFilePath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedServiceDB = content);

            //Act
            sdbs.SoftDeleteService(serviceID);

            //Assert
            Assert.IsNotNull(retrievedServiceDB);
            //deserialize the retrievedServiceDB
            var services = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServiceDB);
            Assert.IsNotNull(services);
            Assert.AreEqual(1, services.Count);
            Assert.AreEqual(serviceID, services[0]["ServiceID"]);
            Assert.AreEqual(serviceName, services[0]["ServiceName"]);
            Assert.AreEqual(serviceDescription, services[0]["ServiceDescription"]);
            Assert.AreEqual(servicePrice, services[0]["ServicePrice"]);
            Assert.AreEqual("true", services[0]["IsDeleted"]);
        }

        [TestMethod()]
        public void GetServicesTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var service1Name = "Test Service";
            var service1Description = "This is a test service.";
            var service1Price = "10.00";
            var service1ID = "TestService";

            var service2Name = "Test Service 2";
            var service2Description = "This is a test service 2.";
            var service2Price = "20.00";
            var service2ID = "TestService2";


            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", service1ID },
                    { "ServiceName", service1Name },
                    { "ServiceDescription", service1Description },
                    { "ServicePrice", service1Price }
                },
                new Dictionary<string, string>
                {
                    { "ServiceID", service2ID },
                    { "ServiceName", service2Name },
                    { "ServiceDescription", service2Description },
                    { "ServicePrice", service2Price }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            //Act
            var retrievedServices = sdbs.GetServices();

            //Assert
            Assert.IsNotNull(retrievedServices);
            Assert.AreEqual(2, retrievedServices.Count);
            Assert.AreEqual(service1ID, retrievedServices[0]["ServiceID"]);
            Assert.AreEqual(service1Name, retrievedServices[0]["ServiceName"]);
            Assert.AreEqual(service1Description, retrievedServices[0]["ServiceDescription"]);
            Assert.AreEqual(service1Price, retrievedServices[0]["ServicePrice"]);

            Assert.AreEqual(service2ID, retrievedServices[1]["ServiceID"]);
            Assert.AreEqual(service2Name, retrievedServices[1]["ServiceName"]);
            Assert.AreEqual(service2Description, retrievedServices[1]["ServiceDescription"]);
            Assert.AreEqual(service2Price, retrievedServices[1]["ServicePrice"]);

        }

        [TestMethod()]
        public void GetServiceIDByNameTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var sdbs = new ServiceDBService(dbm, dbrs);

            var serviceName = "Test Service";
            var serviceDescription = "This is a test service.";
            var servicePrice = "10.00";
            var serviceID = "TestService";

            var serviceDBFilePath = "services.json";
            var initialServiceDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "ServiceID", serviceID },
                    { "ServiceName", serviceName },
                    { "ServiceDescription", serviceDescription },
                    { "ServicePrice", servicePrice }
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(serviceDBFilePath)).Returns(JsonSerializer.Serialize(initialServiceDB));
            mockFS.Setup(fs => fs.Exists(serviceDBFilePath)).Returns(true);

            //Act
            var retrievedServiceID = sdbs.GetServiceIDByName(serviceName);

            //Assert
            Assert.IsNotNull(retrievedServiceID);
            Assert.AreEqual(serviceID, retrievedServiceID);


        }
    }
}