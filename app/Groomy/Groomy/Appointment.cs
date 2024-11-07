using Groomy.Customers;

namespace Groomy
{
    internal class Appointment : IGenericObject
    {
        private string userID;
        private string customerID;
        private string title;
        private string description;
        private DateTime startTime;
        private DateTime endTime;
        private string location;

        public string appointmentID => Helpers.GenerateSHA256Hash(userID + customerID);

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "AppointmentData", "appointments.json" }
        };
        public IGenericObject FromDictionary(Dictionary<string, object> dict)
        {
            userID = dict["UserID"].ToString();
            customerID = dict["CustomerID"].ToString();
            title = dict["Title"].ToString();
            description = dict["Description"].ToString();
            startTime = (DateTime)dict["StartTime"];
            endTime = (DateTime)dict["EndTime"];
            location = dict["Location"].ToString();
            return this;
        }
        public Appointment(string uID, string cID, string t, string d, DateTime sT, DateTime eT, string l)
        {
            userID = uID;
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
                { "Title", title },
                { "Description", description },
                { "StartTime", startTime },
                { "EndTime", endTime },
                { "Location", location },
                { "UserID", userID },
                { "CustomerID", customerID },
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
