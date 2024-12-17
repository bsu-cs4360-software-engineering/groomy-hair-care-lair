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
        public void CreateInvoiceNotesTest()
        {
            Assert.Fail();
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
        public void UpdateInvoiceNotesDataTest()
        {
            Assert.Fail();
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

        [TestMethod()]
        public void SoftDeleteInvoiceNotesTest()
        {
            Assert.Fail();
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


            var primaryID = "testID";

            var relationshipPath = "testRelationshipPath.json";
            var initialRelationshipDB = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"PrimaryID", primaryID},
                    {"ForeignID", notesID}
                }
            };

            mockFS.Setup(fs => fs.ReadAllText(notesDBFilepath)).Returns(JsonSerializer.Serialize(initialNotesDB));
            mockFS.Setup(fs => fs.Exists(notesDBFilepath)).Returns(true);

            mockFS.Setup(fs => fs.ReadAllText(relationshipPath)).Returns(JsonSerializer.Serialize(initialRelationshipDB));
            mockFS.Setup(fs => fs.Exists(relationshipPath)).Returns(true);

            string retrievedNotesDB = null;
            mockFS.Setup(fs => fs.WriteAllText(notesDBFilepath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedNotesDB = data);

            string retrievedRelationship = null;
            mockFS.Setup(fs => fs.WriteAllText(relationshipPath, It.IsAny<string>()))
                .Callback<string, string>((path, data) => retrievedRelationship = data);

            //Act
            ndbs.SoftDeleteNote(notesID, relationshipPath);

            //Assert
            Assert.IsNotNull(retrievedNotesDB);
            //deserialize the json string and check if the note was soft deleted
            var notes = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedNotesDB);
            Assert.AreEqual(1, notes.Count);
            Assert.AreEqual(noteTitle, notes[0]["Title"]);
            Assert.AreEqual(notePayload, notes[0]["Payload"]);
            Assert.AreEqual(noteCreationDate, notes[0]["CreateDate"]);
            Assert.AreEqual(notesID, notes[0]["NoteID"]);
            Assert.AreEqual("true", notes[0]["IsDeleted"]);

            Assert.IsNotNull(retrievedRelationship);
            //deserialize the json string and check if the relationship was soft deleted
            var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(retrievedRelationship);
            Assert.AreEqual(1, relationships.Count);
            Assert.AreEqual(primaryID, relationships[0]["PrimaryID"]);
            Assert.AreEqual(notesID, relationships[0]["ForeignID"]);
            Assert.AreEqual("true", relationships[0]["IsDeleted"]);
        }
    }
}