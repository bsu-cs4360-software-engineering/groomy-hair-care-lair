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
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var adbs = new AppointmentDBService(dbm, dbrs);

            string appointmentTitle = "Test Appointment";
            string appointmentDescription = "This is a test appointment";
            DateTime appointmentStartTime = DateTime.Now;
            DateTime appointmentEndTime = DateTime.Now.AddHours(1);
            string appointmentLocation = "Test Location";
            string testAppointmentID = "TestAppointmentID";

            string customerID = "TestCustomerID";

            var appointmentDBFilepath = "appointments.json";
            var existingAppointmentDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID},
                    {"Title", appointmentTitle},
                    {"Description", appointmentDescription},
                    {"StartTime", appointmentStartTime.ToString()},
                    {"EndTime", appointmentEndTime.ToString()},
                    {"Location", appointmentLocation}
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingAppointmentDB));
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);

            //Act
            var retrievedAppointmentData = adbs.ReadAppointmentData(testAppointmentID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentData);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("AppointmentID"));
            Assert.AreEqual(testAppointmentID, retrievedAppointmentData["AppointmentID"]);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("Title"));
            Assert.AreEqual(appointmentTitle, retrievedAppointmentData["Title"]);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("Description"));
            Assert.AreEqual(appointmentDescription, retrievedAppointmentData["Description"]);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("StartTime"));
            Assert.AreEqual(appointmentStartTime.ToString(), retrievedAppointmentData["StartTime"]);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("EndTime"));
            Assert.AreEqual(appointmentEndTime.ToString(), retrievedAppointmentData["EndTime"]);
            Assert.IsTrue(retrievedAppointmentData.ContainsKey("Location"));
            Assert.AreEqual(appointmentLocation, retrievedAppointmentData["Location"]);

        }

        [TestMethod()]
        public void UpdateAppointmentDataTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var adbs = new AppointmentDBService(dbm, dbrs);

            string appointmentTitle = "Test Appointment";
            string appointmentDescription = "This is a test appointment";
            DateTime appointmentStartTime = DateTime.Now;
            DateTime appointmentEndTime = DateTime.Now.AddHours(1);
            string appointmentLocation = "Test Location";
            string testAppointmentID = "TestAppointmentID";

            string newAppointmentTitle = "Updated Test Appointment";

            var updatedAppointment = new Appointment(newAppointmentTitle, appointmentDescription, appointmentStartTime, appointmentEndTime, appointmentLocation, testAppointmentID);

            string customerID = "TestCustomerID";

            var appointmentDBFilepath = "appointments.json";
            var initialAppointmentDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID},
                    {"Title", appointmentTitle},
                    {"Description", appointmentDescription},
                    {"StartTime", appointmentStartTime.ToString()},
                    {"EndTime", appointmentEndTime.ToString()},
                    {"Location", appointmentLocation}
                }
            };

            var relationshipDBFilepath = "customers_appointments.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"customerID", customerID},
                    {"appointmentID", testAppointmentID}
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(initialAppointmentDB));
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);


            string retrievedAppointmentData = null;
            mockFileService.Setup(fs => fs.WriteAllText(appointmentDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedAppointmentData = content);

            //Act
            adbs.UpdateAppointmentData(updatedAppointment, customerID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentData);
            //Deserialize the retrieved data
            var retrievedAppointments = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedAppointmentData);
            Assert.IsNotNull(retrievedAppointments);
            Assert.AreEqual(1, retrievedAppointments.Count);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("AppointmentID"));
            Assert.AreEqual(testAppointmentID, retrievedAppointments[0]["AppointmentID"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Title"));
            Assert.AreEqual(newAppointmentTitle, retrievedAppointments[0]["Title"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Description"));
            Assert.AreEqual(appointmentDescription, retrievedAppointments[0]["Description"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("StartTime"));
            Assert.AreEqual(appointmentStartTime.ToString(), retrievedAppointments[0]["StartTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("EndTime"));
            Assert.AreEqual(appointmentEndTime.ToString(), retrievedAppointments[0]["EndTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Location"));
            Assert.AreEqual(appointmentLocation, retrievedAppointments[0]["Location"]);


        }

        [TestMethod()]
        public void DeleteAppointmentTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var adbs = new AppointmentDBService(dbm, dbrs);

            string appointmentTitle = "Test Appointment";
            string appointmentDescription = "This is a test appointment";
            DateTime appointmentStartTime = DateTime.Now;
            DateTime appointmentEndTime = DateTime.Now.AddHours(1);
            string appointmentLocation = "Test Location";
            string testAppointmentID = "TestAppointmentID";

            string customerID = "TestCustomerID";

            var appointmentDBFilepath = "appointments.json";
            var existingAppointmentDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID},
                    {"Title", appointmentTitle},
                    {"Description", appointmentDescription},
                    {"StartTime", appointmentStartTime.ToString()},
                    {"EndTime", appointmentEndTime.ToString()},
                    {"Location", appointmentLocation}
                }
            };

            var relationshipDBFilepath = "customers_appointments.json";
            var existingRelationshipDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"customerID", customerID},
                    {"appointmentID", testAppointmentID}
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingAppointmentDB));
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);

            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingRelationshipDB));
            mockFileService.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);


            string retrievedAppointmentData = null;
            mockFileService.Setup(fs => fs.WriteAllText(appointmentDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedAppointmentData = content);

            string retrievedRelationshipData = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedRelationshipData = content);

            //Act
            adbs.DeleteAppointment(testAppointmentID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentData);
            //Deserialize the retrieved data
            var retrievedAppointments = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedAppointmentData);
            Assert.IsNotNull(retrievedAppointments);
            Assert.AreEqual(0, retrievedAppointments.Count);

            //Deserialize the retrieved relationship data
            var retrievedRelationships = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipData);
            Assert.IsNotNull(retrievedRelationships);
            Assert.AreEqual(0, retrievedRelationships.Count);
        }

        [TestMethod()]
        public void SoftDeleteAppointmentTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var adbs = new AppointmentDBService(dbm, dbrs);

            string appointmentTitle = "Test Appointment";
            string appointmentDescription = "This is a test appointment";
            DateTime appointmentStartTime = DateTime.Now;
            DateTime appointmentEndTime = DateTime.Now.AddHours(1);
            string appointmentLocation = "Test Location";
            string testAppointmentID = "TestAppointmentID";

            string customerID = "TestCustomerID";

            var appointmentDBFilepath = "appointments.json";
            var existingAppointmentDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID},
                    {"Title", appointmentTitle},
                    {"Description", appointmentDescription},
                    {"StartTime", appointmentStartTime.ToString()},
                    {"EndTime", appointmentEndTime.ToString()},
                    {"Location", appointmentLocation}
                }
            };

            var relationshipDBFilepath = "customers_appointments.json";
            var existingRelationshipDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"customerID", customerID},
                    {"appointmentID", testAppointmentID}
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingAppointmentDB));
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);

            mockFileService.Setup(fs => fs.ReadAllText(relationshipDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingRelationshipDB));
            mockFileService.Setup(fs => fs.Exists(relationshipDBFilepath)).Returns(true);


            string retrievedAppointmentData = null;
            mockFileService.Setup(fs => fs.WriteAllText(appointmentDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedAppointmentData = content);

            string retrievedRelationshipData = null;
            mockFileService.Setup(fs => fs.WriteAllText(relationshipDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, content) => retrievedRelationshipData = content);

            //Act
            adbs.SoftDeleteAppointment(testAppointmentID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentData);
            //Deserialize the retrieved data
            var retrievedAppointments = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedAppointmentData);
            Assert.IsNotNull(retrievedAppointments);
            Assert.AreEqual(1, retrievedAppointments.Count);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("AppointmentID"));
            Assert.AreEqual(testAppointmentID, retrievedAppointments[0]["AppointmentID"]);
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
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("IsDeleted"));
            Assert.AreEqual("true", retrievedAppointments[0]["IsDeleted"]);

            //Deserialize the retrieved relationship data
            var retrievedRelationships = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationshipData);
            Assert.IsNotNull(retrievedRelationships);
            Assert.AreEqual(1, retrievedRelationships.Count);
            Assert.IsTrue(retrievedRelationships[0].ContainsKey("customerID"));
            Assert.AreEqual(customerID, retrievedRelationships[0]["customerID"]);
            Assert.IsTrue(retrievedRelationships[0].ContainsKey("appointmentID"));
            Assert.AreEqual(testAppointmentID, retrievedRelationships[0]["appointmentID"]);
            Assert.IsTrue(retrievedRelationships[0].ContainsKey("IsDeleted"));
            Assert.AreEqual("true", retrievedRelationships[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void GetAppointmentsTest()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var mockUA = new Mock<IUserAuth>();
            var dbrs = new DBRelationshipService(dbm, mockUA.Object);
            var adbs = new AppointmentDBService(dbm, dbrs);

            var userID = "TestUserID";

            string appointmentTitle1 = "Test Appointment";
            string appointmentDescription1 = "This is a test appointment";
            DateTime appointmentStartTime1 = DateTime.Now;
            DateTime appointmentEndTime1 = DateTime.Now.AddHours(1);
            string appointmentLocation1 = "Test Location";
            string testAppointmentID1 = "TestAppointmentID";

            string appointmentTitle2 = "Test Appointment 2";
            string appointmentDescription2 = "This is a test appointment 2";
            DateTime appointmentStartTime2 = DateTime.Now;
            DateTime appointmentEndTime2 = DateTime.Now.AddHours(1);
            string appointmentLocation2 = "Test Location 2";
            string testAppointmentID2 = "TestAppointmentID2";

            string customerID = "TestCustomerID";

            var appointmentDBFilepath = "appointments.json";
            var existingAppointmentDB = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID1},
                    {"Title", appointmentTitle1},
                    {"Description", appointmentDescription1},
                    {"StartTime", appointmentStartTime1.ToString()},
                    {"EndTime", appointmentEndTime1.ToString()},
                    {"Location", appointmentLocation1}
                },
                new Dictionary<string, string>(){
                    {"AppointmentID", testAppointmentID2},
                    {"Title", appointmentTitle2},
                    {"Description", appointmentDescription2},
                    {"StartTime", appointmentStartTime2.ToString()},
                    {"EndTime", appointmentEndTime2.ToString()},
                    {"Location", appointmentLocation2}
                }
            };

            var customer_appointments_fp = "customers_appointments.json";
            var customer_appointments_db = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"customerID", customerID},
                    {"appointmentID", testAppointmentID1}
                },
                new Dictionary<string, string>(){
                    {"customerID", customerID},
                    {"appointmentID", testAppointmentID2}
                }
            };

            var user_customer_fp = "users_customers.json";
            var user_customer_db = new List<Dictionary<string, string>>(){
                new Dictionary<string, string>(){
                    {"userID", userID},
                    {"customerID", customerID}
                }
            };

            mockFileService.Setup(fs => fs.ReadAllText(appointmentDBFilepath)).Returns(System.Text.Json.JsonSerializer.Serialize(existingAppointmentDB));
            mockFileService.Setup(fs => fs.Exists(appointmentDBFilepath)).Returns(true);

            mockFileService.Setup(fs => fs.ReadAllText(customer_appointments_fp)).Returns(System.Text.Json.JsonSerializer.Serialize(customer_appointments_db));
            mockFileService.Setup(fs => fs.Exists(customer_appointments_fp)).Returns(true);

            mockFileService.Setup(fs => fs.ReadAllText(user_customer_fp)).Returns(System.Text.Json.JsonSerializer.Serialize(user_customer_db));
            mockFileService.Setup(fs => fs.Exists(user_customer_fp)).Returns(true);

            mockUA.Setup(ua => ua.getID()).Returns(userID);

            //Act
            var retrievedAppointments = adbs.GetAppointments();

            //Assert
            Assert.IsNotNull(retrievedAppointments);
            Assert.AreEqual(2, retrievedAppointments.Count);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("AppointmentID"));
            Assert.AreEqual(testAppointmentID1, retrievedAppointments[0]["AppointmentID"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Title"));
            Assert.AreEqual(appointmentTitle1, retrievedAppointments[0]["Title"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Description"));
            Assert.AreEqual(appointmentDescription1, retrievedAppointments[0]["Description"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("StartTime"));
            Assert.AreEqual(appointmentStartTime1.ToString(), retrievedAppointments[0]["StartTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("EndTime"));
            Assert.AreEqual(appointmentEndTime1.ToString(), retrievedAppointments[0]["EndTime"]);
            Assert.IsTrue(retrievedAppointments[0].ContainsKey("Location"));
            Assert.AreEqual(appointmentLocation1, retrievedAppointments[0]["Location"]);

            Assert.IsTrue(retrievedAppointments[1].ContainsKey("AppointmentID"));
            Assert.AreEqual(testAppointmentID2, retrievedAppointments[1]["AppointmentID"]);
            Assert.IsTrue(retrievedAppointments[1].ContainsKey("Title"));
            Assert.AreEqual(appointmentTitle2, retrievedAppointments[1]["Title"]);
            Assert.IsTrue(retrievedAppointments[1].ContainsKey("Description"));
            Assert.AreEqual(appointmentDescription2, retrievedAppointments[1]["Description"]);
            Assert.IsTrue(retrievedAppointments[1].ContainsKey("StartTime"));
            Assert.AreEqual(appointmentStartTime2.ToString(), retrievedAppointments[1]["StartTime"]);
            Assert.IsTrue(retrievedAppointments[1].ContainsKey("EndTime"));
            Assert.AreEqual(appointmentEndTime2.ToString(), retrievedAppointments[1]["EndTime"]);
            Assert.IsTrue(retrievedAppointments[1].ContainsKey("Location"));
            Assert.AreEqual(appointmentLocation2, retrievedAppointments[1]["Location"]);


        }
    }
}