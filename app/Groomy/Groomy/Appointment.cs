using Groomy.Customers;

namespace Groomy
{
    internal class Appointment : IGenericObject
    {
        private string customerID;
        private string title;
        private string description;
        private DateTime startTime;
        private DateTime endTime;
        private string location;

        public string appointmentID => Helpers.GenerateSHA256Hash(customerID + title + startTime.ToString());

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "AppointmentData", "appointments.json" }
        };

        public Appointment(string cID, string t, string d, DateTime sT, DateTime eT, string l)
        {
            customerID = cID;
            title = t;
            description = d;
            startTime = sT;
            endTime = eT;
            location = l;
        }
        public Dictionary<string, Dictionary<string, object>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, object>>();
            temp["AppointmentData"] = new Dictionary<string, object>
            {
                { "CustomerID", customerID },
                { "Title", title },
                { "Description", description },
                { "StartTime", startTime },
                { "EndTime", endTime },
                { "Location", location }
            };
            return temp;
        }
        public string GetKey()
        {
            return appointmentID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}
