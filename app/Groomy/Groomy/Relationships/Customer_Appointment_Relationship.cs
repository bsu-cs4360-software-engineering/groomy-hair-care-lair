namespace Groomy.Relationships
{
    internal class Customer_Appointment_Relationship : IRelationship
    {
        string customerID;
        string appointmentID;
        public static string relationshipFilePath = "customers_appointments.json";
        public Customer_Appointment_Relationship(string cID, string aID)
        {
            customerID = cID;
            appointmentID = aID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("customerID", customerID);
            ids.Add("appointmentID", appointmentID);
            return ids;
        }
    }
}
