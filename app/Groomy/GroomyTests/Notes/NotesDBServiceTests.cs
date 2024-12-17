using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;
using System.Text.Json;
using Moq;

namespace Groomy.Notes.Tests
{
    [TestClass()]
    public class NotesDBServiceTests
    {
        [TestMethod()]
        public void NotesDBServiceManagerSingleton()
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
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var customerID = "testID";

            var customers_notes_relationshipsFilepath = "customers_notes.json";
            var initialCustomersNotesRelationships = "[]";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = "[]";

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var newNote = new Note(noteTitle, notePayload, noteCreationDate);

            var expectedNoteID = newNote.GetKey();

            mockFS.Setup(fs => fs.ReadAllText(customers_notes_relationshipsFilepath)).Returns(initialCustomersNotesRelationships);
            mockFS.Setup(fs => fs.Exists(customers_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(initialNotesDB);
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedCustomersNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(customers_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedCustomersNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.CreateCustomerNotes(newNote, customerID);

            //Assert
            Assert.IsNotNull(retrievedCustomersNotesRelationships);
            //deserialize the json string and check if the relationship was added
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedCustomersNotesRelationships);
            Assert.AreEqual(1, relationships.Count);

            Assert.AreEqual(customerID, relationships[0]["customerID"]);
            Assert.AreEqual(expectedNoteID, relationships[0]["noteID"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was added
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);

        }

        [TestMethod()]
        public void CreateAppointmentNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var appointmentID = "testID";

            var appointments_notes_relationshipsFilepath = "appointments_notes.json";
            var initialAppointmentsNotesRelationships = "[]";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = "[]";

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();
            var newNote = new Note(noteTitle, notePayload, noteCreationDate);

            var expectedNoteID = newNote.GetKey();

            mockFS.Setup(fs => fs.ReadAllText(appointments_notes_relationshipsFilepath)).Returns(initialAppointmentsNotesRelationships);
            mockFS.Setup(fs => fs.Exists(appointments_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(initialNotesDB);
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedAppointmentsNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(appointments_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedAppointmentsNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.CreateAppointmentNotes(newNote, appointmentID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentsNotesRelationships);
            //deserialize the json string and check if the relationship was added
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedAppointmentsNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(appointmentID, relationships[0]["appointmentID"]);
            Assert.AreEqual(expectedNoteID, relationships[0]["noteID"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was added
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);

        }

        [TestMethod()]
        public void CreateServiceNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var serviceID = "testID";

            var services_notes_relationshipsFilepath = "services_notes.json";
            var initialServicesNotesRelationships = "[]";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = "[]";

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();
            var newNote = new Note(noteTitle, notePayload, noteCreationDate);

            var expectedNoteID = newNote.GetKey();

            mockFS.Setup(fs => fs.ReadAllText(services_notes_relationshipsFilepath)).Returns(initialServicesNotesRelationships);
            mockFS.Setup(fs => fs.Exists(services_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(initialNotesDB);
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedServicesNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(services_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedServicesNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.CreateServiceNotes(newNote, serviceID);

            //Assert
            Assert.IsNotNull(retrievedServicesNotesRelationships);
            //deserialize the json string and check if the relationship was added
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServicesNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(serviceID, relationships[0]["serviceID"]);
            Assert.AreEqual(expectedNoteID, relationships[0]["noteID"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was added
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);

        }

        [TestMethod()]
        public void CreateInvoiceNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var invoiceID = "testID";

            var invoices_notes_relationshipsFilepath = "invoices_notes.json";
            var initialInvoicesNotesRelationships = "[]";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = "[]";

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();
            var newNote = new Note(noteTitle, notePayload, noteCreationDate);

            var expectedNoteID = newNote.GetKey();

            mockFS.Setup(fs => fs.ReadAllText(invoices_notes_relationshipsFilepath)).Returns(initialInvoicesNotesRelationships);
            mockFS.Setup(fs => fs.Exists(invoices_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(initialNotesDB);
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedInvoicesNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(invoices_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedInvoicesNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.CreateInvoiceNotes(newNote, invoiceID);

            //Assert
            Assert.IsNotNull(retrievedInvoicesNotesRelationships);
            //deserialize the json string and check if the relationship was added
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedInvoicesNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(invoiceID, relationships[0]["invoiceID"]);
            Assert.AreEqual(expectedNoteID, relationships[0]["noteID"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was added
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);

        }

        [TestMethod()]
        public void CreateNotesTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var notesDBFilepath = "notes.json";
            var initialNotesDB = "[]";

            var primaryID = "testID";

            var relationshipPath = "testRelationshipPath.json";
            var initialRelationshipDB = "[]";

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var newNote = new Note(noteTitle, notePayload, noteCreationDate);

            var expectNoteID = newNote.GetKey();

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(initialNotesDB);
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipPath)).Returns(initialRelationshipDB);
            mockFS.Setup(fs => fs.Exists(relationshipPath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            string retrievedRelationship = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipPath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedRelationship = data);


            //Act
            ndbs.CreateNotes(newNote, "testID", relationshipPath);


            mockFS.Verify(fs => fs.ReadAllText(notesDBFilepath), Times.Exactly(2));
            mockFS.Verify(fs => fs.WriteAllText(relationshipPath, It.IsAny<string>()), Times.Once);
            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was added
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);

            Assert.IsNotNull(retrievedRelationship);
            //deserialize the json string and check if the relationship was added
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationship);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(primaryID, relationships[0]["PrimaryID"]);
            Assert.AreEqual(expectNoteID, relationships[0]["ForeignID"]);
        }

        [TestMethod()]
        public void ReadNotesDataTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();
            var notesID = "testID";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            //Act
            var notesData = ndbs.ReadNotesData(notesID);

            //Assert
            Assert.IsNotNull(notesData);
            //deserialize the json string and check if the note was added
            Assert.AreEqual(noteTitle, notesData["Title"]);
            Assert.AreEqual(notePayload, notesData["Payload"]);
            Assert.AreEqual(noteCreationDate, notesData["CreateDate"]);
            Assert.AreEqual(notesID, notesData["NoteID"]);
        }

        [TestMethod()]
        public void UpdateCustomerNotesDataTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var customerID = "testCustomerID";
            var notesID = "testNoteID";

            var customers_notes_relationshipsFilepath = "customers_notes.json";
            var initialCustomersNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"customerID", customerID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            var newNotePayload = "This is a new test note.";

            var newNote = new Note(noteTitle, newNotePayload, noteCreationDate, notesID);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.UpdateCustomerNotesData(newNote, customerID);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was updated
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            //check if the payload was updated
            Assert.AreEqual(newNotePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);

        }

        [TestMethod()]
        public void UpdateAppointmentNotesDataTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var appointmentID = "testAppointmentID";
            var notesID = "testNoteID";

            var appointments_notes_relationshipsFilepath = "appointments_notes.json";
            var initialAppointmentsNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"appointmentID", appointmentID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            var newNotePayload = "This is a new test note.";

            var newNote = new Note(noteTitle, newNotePayload, noteCreationDate, notesID);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.UpdateAppointmentNotesData(newNote, appointmentID);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was updated
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            //check if the payload was updated
            Assert.AreEqual(newNotePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);

        }

        [TestMethod()]
        public void UpdateServiceNotesDataTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var serviceID = "testServiceID";
            var notesID = "testNoteID";

            var services_notes_relationshipsFilepath = "services_notes.json";
            var initialServicesNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"serviceID", serviceID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            var newNotePayload = "This is a new test note.";

            var newNote = new Note(noteTitle, newNotePayload, noteCreationDate, notesID);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.UpdateServiceNotesData(newNote, serviceID);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was updated
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            //check if the payload was updated
            Assert.AreEqual(newNotePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);

        }

        [TestMethod()]
        public void UpdateInvoiceNotesDataTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var invoiceID = "testInvoiceID";
            var notesID = "testNoteID";

            var invoices_notes_relationshipsFilepath = "invoices_notes.json";
            var initialInvoicesNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"invoiceID", invoiceID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            var newNotePayload = "This is a new note.";

            var newNote = new Note(noteTitle, newNotePayload, noteCreationDate, notesID);

            mockFS.Setup(fs => fs.ReadAllText
            (notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.UpdateInvoiceNotesData(newNote, invoiceID);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was updated
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);

            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            //check if the payload was updated
            Assert.AreEqual(newNotePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);

        }

        [TestMethod()]
        public void UpdateNotesDataTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();
            var notesID = "testID";

            var newNotePayload = "This is an updated test note.";

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            var updatedNote = new Note(noteTitle, newNotePayload, noteCreationDate, notesID);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.UpdateNotesData(updatedNote, notesID);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was updated
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            //check if the payload was updated
            Assert.AreEqual(newNotePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);

        }

        [TestMethod()]
        public void SoftDeleteCustomerNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var customerID = "testID";
            var notesID = "testNoteID";

            var customers_notes_relationshipsFilepath = "customers_notes.json";
            var initialCustomersNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"customerID", customerID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(customers_notes_relationshipsFilepath)).Returns(JsonSerializer.Serialize(initialCustomersNotesRelationships));
            mockFS.Setup(fs => fs.Exists(customers_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedCustomersNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(customers_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedCustomersNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.SoftDeleteCustomerNotes(notesID);

            //Assert
            Assert.IsNotNull(retrievedCustomersNotesRelationships);
            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedCustomersNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(customerID, relationships[0]["customerID"]);
            Assert.AreEqual(notesID, relationships[0]["noteID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);
            Assert.AreEqual("true", notes[0]["IsDeleted"]);
        }

        [TestMethod()]
        public void SoftDeleteAppointmentNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var appointmentID = "testID";
            var notesID = "testNoteID";

            var appointments_notes_relationshipsFilepath = "appointments_notes.json";
            var initialAppointmentsNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"appointmentID", appointmentID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(appointments_notes_relationshipsFilepath)).Returns(JsonSerializer.Serialize(initialAppointmentsNotesRelationships));
            mockFS.Setup(fs => fs.Exists(appointments_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedAppointmentsNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(appointments_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedAppointmentsNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.SoftDeleteAppointmentNotes(notesID);

            //Assert
            Assert.IsNotNull(retrievedAppointmentsNotesRelationships);

            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedAppointmentsNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(appointmentID, relationships[0]["appointmentID"]);
            Assert.AreEqual(notesID, relationships[0]["noteID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);
            Assert.AreEqual("true", notes[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void SoftDeleteServiceNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var serviceID = "testID";
            var notesID = "testNoteID";

            var services_notes_relationshipsFilepath = "services_notes.json";
            var initialServicesNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"serviceID", serviceID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(services_notes_relationshipsFilepath)).Returns(JsonSerializer.Serialize(initialServicesNotesRelationships));
            mockFS.Setup(fs => fs.Exists(services_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedServicesNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(services_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedServicesNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.SoftDeleteServiceNotes(notesID);

            //Assert
            Assert.IsNotNull(retrievedServicesNotesRelationships);
            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedServicesNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(serviceID, relationships[0]["serviceID"]);
            Assert.AreEqual(notesID, relationships[0]["noteID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);
            Assert.AreEqual("true", notes[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void SoftDeleteInvoiceNotesTest()
        {
            //Assign
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var invoiceID = "testID";
            var notesID = "testNoteID";

            var invoices_notes_relationshipsFilepath = "invoices_notes.json";
            var initialInvoicesNotesRelationships = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"invoiceID", invoiceID},
                    {"noteID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(invoices_notes_relationshipsFilepath)).Returns(JsonSerializer.Serialize(initialInvoicesNotesRelationships));
            mockFS.Setup(fs => fs.Exists(invoices_notes_relationshipsFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedInvoicesNotesRelationships = null;
            mockFS.Setup(fs => fs.WriteAllText(invoices_notes_relationshipsFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedInvoicesNotesRelationships = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.SoftDeleteInvoiceNotes(notesID);

            //Assert
            Assert.IsNotNull(retrievedInvoicesNotesRelationships);
            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedInvoicesNotesRelationships);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(invoiceID, relationships[0]["invoiceID"]);
            Assert.AreEqual(notesID, relationships[0]["noteID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);
            Assert.AreEqual("true", notes[0]["IsDeleted"]);

        }

        [TestMethod()]
        public void SoftDeleteNoteTest()
        {
            //Arrange
            var mockFS = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFS.Object);
            var ua = new UserAuth();
            var dbrs = new DBRelationshipService(dbm, ua);
            var ndbs = new NotesDBService(dbm, dbrs);

            var primaryID = "primaryID";
            var notesID = "testNoteID";

            var relationshipPath = "testRelationshipPath.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"PrimaryID", primaryID},
                    {"ForeignID", notesID}
                }
            };

            var noteTitle = "Test Note";
            var notePayload = "This is a test note.";
            var noteCreationDate = DateTime.Now.ToString();

            var notesDBFilepath = "notes.json";
            var initialNotesDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Title", noteTitle},
                    {"Payload", notePayload},
                    {"CreateDate", noteCreationDate},
                    {"NoteID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(relationshipPath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipPath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            string retrievedRelationship = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipPath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedRelationship = data);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            //Act
            ndbs.SoftDeleteNote(notesID, relationshipPath);

            mockFS.Verify(fs => fs.WriteAllText(relationshipPath, It.IsAny<string>()), Times.Once);
            mockFS.Verify(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()), Times.Once);

            //Assert
            Assert.IsNotNull(retrievedRelationship);
            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationship);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(primaryID, relationships[0]["PrimaryID"]);
            Assert.AreEqual(notesID, relationships[0]["ForeignID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);


        }
    }
}