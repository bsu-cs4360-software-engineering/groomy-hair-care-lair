using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;

namespace Groomy.Notes
{
    internal class NotesDBService
    {
        private ManagerSingleton ms;
        public NotesDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateCustomerNotes(Note notes, string customerID)
        {
            ms.dbm.AddObjectsToDB(notes);
            ms.dbm.AddRelationshipToDB(new Relationships.CustomerNotesRelationship(customerID, notes.GetKey()));
        }
        public void CreateAppointmentNotes(Note notes, string appointmentID)
        {
            ms.dbm.AddObjectsToDB(notes);
            ms.dbm.AddRelationshipToDB(new Relationships.AppointmentNotesRelationship(appointmentID, notes.GetKey()));
        }
        public Dictionary<string, string> ReadNotesData(string noteID)
        {
            return ms.dbm.LoadJsonFromDB(noteID, Note.FilePaths["NotesData"]);
        }
        public void UpdateCustomerNotesData(Note notes, string customerID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipInDB(new Relationships.CustomerNotesRelationship(customerID, noteID));
        }
        public void UpdateAppointmentNotesData(Note notes, string appointmentID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipInDB(new Relationships.AppointmentNotesRelationship(appointmentID, noteID));
        }
        public void DeleteCustomerNotes(string noteID)
        {
            ms.dbm.RemoveObjectFromDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipFromDB(new Relationships.CustomerNotesRelationship(ms.dbrs.GetCustomerIDFromNotesID(noteID), noteID));
        }
        public void DeleteAppointmentNotes(string noteID)
        {
            ms.dbm.RemoveObjectFromDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipFromDB(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
        public void SoftDeleteCustomerNotes(string noteId)
        {
            ms.dbm.SoftDeleteObjectInDB(noteId, Note.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipFromDB(new Relationships.CustomerNotesRelationship(ms.dbrs.GetCustomerIDFromNotesID(noteId), noteId));
        }
        public void SoftDeleteAppointmentNotes(string noteID)
        {
            ms.dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipFromDB(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
    }
}
