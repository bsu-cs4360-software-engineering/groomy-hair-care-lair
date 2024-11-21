using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Notes
{
    internal class NotesDBService
    {
        private ManagerSingleton ms;
        public NotesDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateCustomerNotes(Notes notes, string customerID)
        {
            ms.dbm.AddObjectsToDB(notes);
            ms.dbm.AddRelationshipToDB(new Relationships.CustomerNotesRelationship(customerID, notes.GetKey()));
        }
        public void CreateAppointmentNotes(Notes notes, string appointmentID)
        {
            ms.dbm.AddObjectsToDB(notes);
            ms.dbm.AddRelationshipToDB(new Relationships.AppointmentNotesRelationship(appointmentID, notes.GetKey()));
        }
        public Dictionary<string, string> ReadNotesData(string noteID)
        {
            return ms.dbm.LoadJsonFromDB(noteID, Notes.FilePaths["NotesData"]);
        }
        public void UpdateCustomerNotesData(Notes notes, string customerID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Notes.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipInDB(new Relationships.CustomerNotesRelationship(customerID, noteID));
        }
        public void UpdateAppointmentNotesData(Notes notes, string appointmentID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Notes.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipInDB(new Relationships.AppointmentNotesRelationship(appointmentID, noteID));
        }
        public void DeleteCustomerNotes(string noteID)
        {
            ms.dbm.RemoveObjectFromDB(noteID, Notes.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipFromDB(new Relationships.CustomerNotesRelationship(ms.dbrs.GetCustomerIDFromNotesID(noteID), noteID));
        }
        public void DeleteAppointmentNotes(string noteID)
        {
            ms.dbm.RemoveObjectFromDB(noteID, Notes.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipFromDB(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
        public void SoftDeleteCustomerNotes(string customerID)
        {
            var noteIDs = ms.dbrs.GetNotesIDFromCustomerID(customerID);
            foreach (var noteID in noteIDs)
            {
                ms.dbm.SoftDeleteObjectInDB(noteID, Notes.FilePaths["NotesData"]);
                ms.dbm.SoftDeleteRelationshipFromDB(new Relationships.CustomerNotesRelationship(customerID, noteID));
            }
        }
        public void SoftDeleteAppointmentNotes(string noteID)
        {
            ms.dbm.SoftDeleteObjectInDB(noteID, Notes.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipFromDB(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
    }
}
