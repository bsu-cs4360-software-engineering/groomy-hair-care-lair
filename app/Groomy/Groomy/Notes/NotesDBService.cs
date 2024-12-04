using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;

namespace Groomy.Notes
{
    public class NotesDBService
    {
        private ManagerSingleton ms;
        public NotesDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateCustomerNotes(Note notes, string customerID)
        {
            ms.dbm.CreateObjectInDB(notes);
            ms.dbm.CreateRelationshipEntry(new Relationships.CustomerNotesRelationship(customerID, notes.GetKey()));
        }
        public void CreateAppointmentNotes(Note notes, string appointmentID)
        {
            ms.dbm.CreateObjectInDB(notes);
            ms.dbm.CreateRelationshipEntry(new Relationships.AppointmentNotesRelationship(appointmentID, notes.GetKey()));
        }
        public void CreateServiceNotes(Note notes, string serviceID)
        {
            ms.dbm.CreateObjectInDB(notes);
            ms.dbm.CreateRelationshipEntry(new Relationships.ServiceNotesRelationship(serviceID, notes.GetKey()));
        }
        public Dictionary<string, string> ReadNotesData(string noteID)
        {
            return ms.dbm.ReadObjectFromDB(noteID, Note.FilePaths["NotesData"]);
        }
        public void UpdateCustomerNotesData(Note notes, string customerID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipEntry(new Relationships.CustomerNotesRelationship(customerID, noteID));
        }
        public void UpdateAppointmentNotesData(Note notes, string appointmentID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipEntry(new Relationships.AppointmentNotesRelationship(appointmentID, noteID));
        }
        public void UpdateServiceNotesData(Note notes, string serviceID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            ms.dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            ms.dbm.UpdateRelationshipEntry(new Relationships.ServiceNotesRelationship(serviceID, noteID));
        }
        public void DeleteCustomerNotes(string noteID)
        {
            ms.dbm.DeleteObjectFromDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipEntry(new Relationships.CustomerNotesRelationship(ms.dbrs.GetCustomerIDFromNotesID(noteID), noteID));
        }
        public void DeleteAppointmentNotes(string noteID)
        {
            ms.dbm.DeleteObjectFromDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.DeleteRelationshipEntry(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
        public void SoftDeleteCustomerNotes(string noteId)
        {
            ms.dbm.SoftDeleteObjectInDB(noteId, Note.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipEntry(new Relationships.CustomerNotesRelationship(ms.dbrs.GetCustomerIDFromNotesID(noteId), noteId));
        }
        public void SoftDeleteAppointmentNotes(string noteID)
        {
            ms.dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipEntry(new Relationships.AppointmentNotesRelationship(ms.dbrs.GetAppointmentIDFromNotesID(noteID), noteID));
        }
        public void SoftDeleteServiceNotes(string noteID)
        {
            ms.dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            ms.dbm.SoftDeleteRelationshipEntry(new Relationships.ServiceNotesRelationship(ms.dbrs.GetServiceIDFromNotesID(noteID), noteID));
        }
    }
}
