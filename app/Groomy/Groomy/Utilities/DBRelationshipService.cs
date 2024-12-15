using Groomy.Customers;
using Groomy.Relationships;
using Groomy.Users;

namespace Groomy.Utilities
{
    public class DBRelationshipService
    {
        DatabaseManager dbm;
        UserAuth ua;

        public DBRelationshipService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.ua = ms.ua;
        }
        public DBRelationshipService(DatabaseManager dbm, UserAuth ua)
        {
            this.dbm = dbm;
            this.ua = ua;
        }
        public List<string> GetCustomerIDs()
        {
            var user_customer_relationships = dbm.ReadRelationshipEntry(ua.getID(), "users_customers.json");
            var customerIDs = new List<string>();
            foreach (var relationship in user_customer_relationships)
            {
                customerIDs.Add(relationship["customerID"]);
            }
            return customerIDs;
        }

        public List<string> GetInvoiceIDs()
        {
            var customerIDs = GetCustomerIDs();
            var invoiceIDs = new List<string>();
            foreach (var customerID in customerIDs)
            {
                var customer_invoice_relationships = dbm.ReadRelationshipEntry(customerID, "customers_invoices.json");
                foreach (var relationship in customer_invoice_relationships)
                {
                    invoiceIDs.Add(relationship["invoiceID"]);
                }
            }
            
            return invoiceIDs;
        }
        public List<string> GetServiceIDs()
        {
            var serviceIDs = new List<string>();
            var serviceDB = dbm.LoadJsonsFromDB("services.json");
            foreach (var service in serviceDB)
            {
                serviceIDs.Add(service["ServiceID"]);
            }
            return serviceIDs;
        }
        public List<string> GetAppointmentIDsFromCustomerID(string customerID)
        {
            var customer_appointment_relationships = dbm.ReadRelationshipEntry(customerID, "customers_appointments.json");
            var appointmentIDs = new List<string>();
            foreach (var relationship in customer_appointment_relationships)
            {
                appointmentIDs.Add(relationship["appointmentID"]);
            }
            
            return appointmentIDs;
        }
        public List<string> GetInvoiceIDsFromCustomerID(int customerID)
        {
            var customer_invoice_relationships = dbm.ReadRelationshipEntry(customerID.ToString(), "customers_invoices.json");
            var invoiceIDs = new List<string>();
            foreach (var relationship in customer_invoice_relationships)
            {
                invoiceIDs.Add(relationship["invoiceID"]);
            }
            return invoiceIDs;
        }
        public List<string> GetNotesIDFromCustomerID(string customerID)
        {
            var customer_notes_relationships = dbm.ReadRelationshipEntry(customerID, "customers_notes.json");

            var noteIDs = new List<string>();
            foreach (var relationship in customer_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public string GetUserIDFromCustomerID(string customerID)
        {
            var user_customer_relationships = dbm.ReadRelationshipEntry(customerID, "users_customers.json");
            return user_customer_relationships[0]["userID"];
        }
        public string GetCustomerIDFromAppointmentID(string appointmentID)
        {
            var appointment_customer_relationships = dbm.ReadRelationshipEntry(appointmentID, "customers_appointments.json");
            return appointment_customer_relationships[0]["customerID"];
        }
        public List<string> GetNoteIDsFromAppointmentID(string appointmentID)
        {
            var appointment_notes_relationships = dbm.ReadRelationshipEntry(appointmentID, "appointments_notes.json");
            var noteIDs = new List<string>();
            foreach (var relationship in appointment_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public List<string> GetNoteIDsFromServiceID(string serviceID)
        {
            var service_notes_relationships = dbm.ReadRelationshipEntry(serviceID, "services_notes.json");
            var noteIDs = new List<string>();
            foreach (var relationship in service_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public List<string> GetDetailIDsFromInvoiceID(string invoiceID)
        {
            var invoice_detail_relationships = dbm.ReadRelationshipEntry(invoiceID, "invoices_details.json");
            var detailIDs = new List<string>();
            foreach (var relationship in invoice_detail_relationships)
            {
                detailIDs.Add(relationship["detailID"]);
            }
            return detailIDs;
        }
        public List<string> GetNoteIDsFromInvoiceID(string invoiceID)
        {
            var invoice_notes_relationships = dbm.ReadRelationshipEntry(invoiceID, "invoices_notes.json");
            var noteIDs = new List<string>();
            foreach (var relationship in invoice_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public string GetCustomerIDFromInvoiceID(string invoiceID)
        {
            var invoice_customer_relationships = dbm.ReadRelationshipEntry(invoiceID, "customers_invoices.json");
            return invoice_customer_relationships[0]["customerID"];
        }

        public string GetCustomerIDFromNoteID(string noteID)
        {
            var customer_notes_relationships = dbm.ReadRelationshipEntry(noteID, "customers_notes.json");
            if (customer_notes_relationships.Count == 0)
            {
                throw new Exception("No relationships found for the provided noteID.");
            }
            return customer_notes_relationships[0]["customerID"];
        }
        public string GetAppointmentIDFromNoteID(string noteID)
        {
            var appointment_notes_relationships = dbm.ReadRelationshipEntry(noteID, "appointments_notes.json");
            return appointment_notes_relationships[0]["appointmentID"];
        }
        public string GetServiceIDFromNoteID(string noteID)
        {
            var service_notes_relationships = dbm.ReadRelationshipEntry(noteID, "services_notes.json");
            return service_notes_relationships[0]["serviceID"];
        }
        public string GetInvoiceIDFromNoteID(string noteID)
        {
            var invoice_notes_relationships = dbm.ReadRelationshipEntry(noteID, "invoices_notes.json");
            return invoice_notes_relationships[0]["invoiceID"];
        }
        public string GetInvoiceIDFromDetailID(string detailID)
        {
            var detail_invoice_relationships = dbm.ReadRelationshipEntry(detailID, "invoices_details.json");
            return detail_invoice_relationships[0]["invoiceID"];
        }
        public List<string> GetForeignIDsFromPrimaryID(string primaryID, string foreignType, string relationshipPath)
        {
            var object_relationships = dbm.ReadRelationshipEntry(primaryID, relationshipPath);
            var foreignIDs = new List<string>();
            foreach (var relationship in object_relationships)
            {
                foreignIDs.Add(relationship[foreignType]);
            }
            return foreignIDs;
        }
        public string GetPrimaryIDFromForeignID(string foreignID, string primaryType, string relationshipPath)
        {
            var object_relationships = dbm.ReadRelationshipEntry(foreignID, relationshipPath);
            return object_relationships[0][primaryType];
        }
    }
}
