using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;
using Moq;

namespace Groomy.Appointments.Tests
{
    [TestClass()]
    public class AppointmentDBServiceTests
    {
        [TestMethod()]
        public void AppointmentDBServiceManagerSingletonTest()
        {
            ManagerSingleton ms = new ManagerSingleton();
            AppointmentDBService adbs = new AppointmentDBService(ms);
            Assert.IsInstanceOfType(adbs, typeof(AppointmentDBService));
        }

        [TestMethod()] 
        public void AppointmentDBServiceDependancyInjectionTest()
        {
            var fs = new FileService();
            var dbm = new DatabaseManager(fs);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            AppointmentDBService adbs = new AppointmentDBService(dbm, dbrs);
            Assert.IsInstanceOfType(adbs, typeof(AppointmentDBService));
        }

        [TestMethod()]
        public void CreateAppointmentTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var mockDatabaseManager = new Mock<DatabaseManager>(mockFileService.Object);
            var mockUserAuth = new Mock<IUserAuth>();
            var mockDBRelationshipService = new Mock<DBRelationshipService>(mockDatabaseManager.Object, mockUserAuth.Object);
            var adbs = new AppointmentDBService(mockDatabaseManager.Object, mockDBRelationshipService.Object);

            string customerID = "TestCustomerID";

            string appointmentTitle = "Test Appointment";
            string appointmentDescription = "This is a test appointment";
            DateTime appointmentStartTime = DateTime.Now;
            DateTime appointmentEndTime = DateTime.Now.AddHours(1);
            string appointmentLocation = "Test Location";

            var newAppointment = new Appointment(appointmentTitle, appointmentDescription, appointmentStartTime, appointmentEndTime, appointmentLocation);

            var expectedAppointmentID = newAppointment.GetKey();

            var appointmentDBFilepath = "appointments.json";

            var initialAppointmentDB = "[]";

            var relationshipDBFilepath = "customers_appointments.json";

            var initialRelationshipDB = "[]";

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(initialAppointmentDB);
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);
            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(initialRelationshipDB);
            mockFileService.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);

            string retrievedAppointmentData = null;
            mockFileService.Setup(fs => fs.WriteAllText(appointmentDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedAppointmentData = data);

            string retrievedRelationshipData = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedRelationshipData = data);



            //Act
            adbs.CreateAppointment(newAppointment, customerID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentData);
            //Deserialize the retrieved data
            var retrievedAppointments = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string,string>>>(retrievedAppointmentData);
            Assert.IsNotNull(retrievedAppointments);
            Assert.AreEqual(1, retrievedAppointments.Count);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("AppointmentID"));
            Assert.AreEqual(expectedAppointmentID, retrievedAppointments[0]["AppointmentID"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Title"));
            Assert.AreEqual(appointmentTitle, retrievedAppointments[0]["Title"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Description"));
            Assert.AreEqual(appointmentDescription, retrievedAppointments[0]["Description"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("StartTime"));
            Assert.AreEqual(appointmentStartTime.ToString(), retrievedAppointments[0]["StartTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("EndTime"));
            Assert.AreEqual(appointmentEndTime.ToString(), retrievedAppointments[0]["EndTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Location"));
            Assert.AreEqual(appointmentLocation, retrievedAppointments[0]["Location"]);

            //Deserialize the retrieved relationship data
            var retrievedRelationships = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipData);
            Assert.IsNotNull(retrievedRelationships);
            Assert.AreEqual(1, retrievedRelationships.Count);
            Assert.IsTrue(retrievedRelationships[0].ContainsKey("customerID"));
            Assert.AreEqual(customerID, retrievedRelationships[0]["customerID"]);
            Assert.IsTrue(retrievedRelationships[0].ContainsKey("appointmentID"));
            Assert.AreEqual(expectedAppointmentID, retrievedRelationships[0]["appointmentID"]);
        }

        [TestMethod()]
        public void ReadAppointmentDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAppointmentDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAppointmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteAppointmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAppointmentsTest()
        {
            Assert.Fail();
        }
    }
}