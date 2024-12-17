using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Relationships;
using Groomy.Utilities;

namespace Groomy.Notes
{
    public class NotesDBService
    {
        private DatabaseManager dbm;
        private DBRelationshipService dbrs;
        public NotesDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.dbrs = ms.dbrs;
        }
        public NotesDBService(DatabaseManager dbm, DBRelationshipService dbrs)
        {
            this.dbm = dbm;
            this.dbrs = dbrs;
        }
        public void CreateCustomerNotes(Note notes, string customerID)
        {
            dbm.CreateObjectInDB(notes);
            dbm.CreateRelationshipEntry(new Relationships.Notes.CustomerNotesRelationship(customerID, notes.GetKey()));
        }
        public void CreateAppointmentNotes(Note notes, string appointmentID)
        {
            dbm.CreateObjectInDB(notes);
            dbm.CreateRelationshipEntry(new Relationships.AppointmentNotesRelationship(appointmentID, notes.GetKey()));
        }
        public void CreateServiceNotes(Note notes, string serviceID)
        {
            dbm.CreateObjectInDB(notes);
            dbm.CreateRelationshipEntry(new Relationships.Notes.ServiceNotesRelationship(serviceID, notes.GetKey()));
        }
        public void CreateInvoiceNotes(Note notes, string invoiceID)
        {
            dbm.CreateObjectInDB(notes);
            dbm.CreateRelationshipEntry(new Relationships.Notes.InvoiceNotesRelationship(invoiceID, notes.GetKey()));
        }
        public void CreateNotes(Note notes, string primaryID, string relationshipPath)
        {
            dbm.CreateObjectInDB(notes);
            dbm.CreateRelationshipEntry(new PrimaryForeignRelationship(primaryID, notes.GetKey(), relationshipPath));
        }
        public Dictionary<string, string> ReadNotesData(string noteID)
        {
            return dbm.ReadObjectFromDB(noteID, Note.FilePaths["NotesData"]);
        }
        public void UpdateCustomerNotesData(Note notes, string customerID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.Notes.CustomerNotesRelationship(customerID, noteID));
        }
        public void UpdateAppointmentNotesData(Note notes, string appointmentID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.AppointmentNotesRelationship(appointmentID, noteID));
        }
        public void UpdateServiceNotesData(Note notes, string serviceID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.Notes.ServiceNotesRelationship(serviceID, noteID));
        }

        public void UpdateInvoiceNotesData(Note notes, string invoiceID)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.Notes.InvoiceNotesRelationship(invoiceID, noteID));
        }

        public void UpdateNotesData(Note notes, string relationshipPath)
        {
            var noteID = notes.GetKey();
            var notesData = notes.GetFields()["NotesData"];

            //update notes
            dbm.UpdateObjectInDB(noteID, notesData, Note.FilePaths["NotesData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new PrimaryForeignRelationship(dbrs.GetPrimaryIDFromForeignID(noteID, relationshipPath), noteID, relationshipPath));
        }
        public void SoftDeleteCustomerNotes(string noteId)
        {
            dbm.SoftDeleteObjectInDB(noteId, Note.FilePaths["NotesData"]);
            dbm.SoftDeleteRelationshipEntry(new Relationships.Notes.CustomerNotesRelationship(dbrs.GetPrimaryIDFromForeignID(noteId, "customers_notes.json"), noteId));
        }
        public void SoftDeleteAppointmentNotes(string noteID)
        {
            dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            dbm.SoftDeleteRelationshipEntry(new Relationships.AppointmentNotesRelationship(dbrs.GetPrimaryIDFromForeignID(noteID, "appointments_notes.json"), noteID));
        }
        public void SoftDeleteServiceNotes(string noteID)
        {
            dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            dbm.SoftDeleteRelationshipEntry(new Relationships.Notes.ServiceNotesRelationship(dbrs.GetPrimaryIDFromForeignID(noteID, "services_notes.json"), noteID));
        }
        public void SoftDeleteInvoiceNotes(string noteID)
        {
            dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            dbm.SoftDeleteRelationshipEntry(new Relationships.Notes.InvoiceNotesRelationship(dbrs.GetPrimaryIDFromForeignID(noteID, "invoices_notes.json"), noteID));
        }

        public void SoftDeleteNote(string noteID, string relationshipPath)
        {
            dbm.SoftDeleteObjectInDB(noteID, Note.FilePaths["NotesData"]);
            dbm.SoftDeleteRelationshipEntry(new PrimaryForeignRelationship(dbrs.GetPrimaryIDFromForeignID(noteID, relationshipPath), noteID, relationshipPath));
        }
    }
}
