namespace Groomy
{
    internal class DBRelationshipService
    {
        DatabaseManager databaseManager;
        UserAuth userAuth;
        public DBRelationshipService(DatabaseManager dbm, UserAuth ua)
        {
            databaseManager = dbm;            userAuth = ua;
        }
        public List<string> GetCustomerIDs()
        {
            var user_customer_relationships = databaseManager.GetRelationshipsByID(userAuth.getID(), "users_customers.json");
            var customerIDs = new List<string>();
            foreach (var relationship in user_customer_relationships)
            {
                customerIDs.Add(relationship["customerID"]);
            }
            return customerIDs;
        }
        public List<string> GetAppointmentsFromCustomerID(string customerID)
        {
            var customer_appointment_relationships = databaseManager.GetRelationshipsByID(customerID, "customers_appointments.json");
            var appointmentIDs = new List<string>();
            foreach (var relationship in customer_appointment_relationships)
            {
                appointmentIDs.Add(relationship["appointmentID"]);
            }
            return appointmentIDs;
        }
        public string GetCustomerIDFromAppointmentID(string appointmentID)
        {
            var appointment_customer_relationships = databaseManager.GetRelationshipsByID(appointmentID, "customers_appointments.json");
            return appointment_customer_relationships[0]["customerID"];
        }
        public string GetUserIDFromCustomerID(string customerID)
        {
            var user_customer_relationships = databaseManager.GetRelationshipsByID(customerID, "users_customers.json");
            return user_customer_relationships[0]["userID"];
        }
    }
}
