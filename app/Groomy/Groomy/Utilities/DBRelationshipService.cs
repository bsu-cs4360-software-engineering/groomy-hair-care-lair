namespace Groomy.Utilities
{
    internal class DBRelationshipService
    {
        ManagerSingleton ms;
        public DBRelationshipService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public List<string> GetCustomerIDs()
        {
            var user_customer_relationships = ms.dbm.GetRelationshipsByID(ms.ua.getID(), "users_customers.json");
            var customerIDs = new List<string>();
            foreach (var relationship in user_customer_relationships)
            {
                customerIDs.Add(relationship["customerID"]);
            }
            return customerIDs;
        }
        public List<string> GetAppointmentsFromCustomerID(string customerID)
        {
            var customer_appointment_relationships = ms.dbm.GetRelationshipsByID(customerID, "customers_appointments.json");
            var appointmentIDs = new List<string>();
            foreach (var relationship in customer_appointment_relationships)
            {
                appointmentIDs.Add(relationship["appointmentID"]);
            }
            return appointmentIDs;
        }
        public string GetCustomerIDFromAppointmentID(string appointmentID)
        {
            var appointment_customer_relationships = ms.dbm.GetRelationshipsByID(appointmentID, "customers_appointments.json");
            return appointment_customer_relationships[0]["customerID"];
        }
        public string GetUserIDFromCustomerID(string customerID)
        {
            var user_customer_relationships = ms.dbm.GetRelationshipsByID(customerID, "users_customers.json");
            return user_customer_relationships[0]["userID"];
        }
        public List<string> GetNotesIDFromCustomerID(string customerID)
        {
            var customer_notes_relationships = ms.dbm.GetRelationshipsByID(customerID, "customers_notes.json");

            var noteIDs = new List<string>();
            foreach (var relationship in customer_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public List<string> GetNotesIDFromAppointmentID(string appointmentID)
        {
            var appointment_notes_relationships = ms.dbm.GetRelationshipsByID(appointmentID, "appointments_notes.json");
            var noteIDs = new List<string>();
            foreach (var relationship in appointment_notes_relationships)
            {
                noteIDs.Add(relationship["noteID"]);
            }
            return noteIDs;
        }
        public string GetCustomerIDFromNotesID(string noteID)
        {
            var customer_notes_relationships = ms.dbm.GetRelationshipsByID(noteID, "customers_notes.json");
            if (customer_notes_relationships.Count == 0)
            {
                throw new Exception("No relationships found for the provided noteID.");
            }
            return customer_notes_relationships[0]["customerID"];
        }
        public string GetAppointmentIDFromNotesID(string noteID)
        {
            var appointment_notes_relationships = ms.dbm.GetRelationshipsByID(noteID, "appointments_notes.json");
            return appointment_notes_relationships[0]["appointmentID"];
        }
    }
}
