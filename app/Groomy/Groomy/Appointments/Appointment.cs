using Groomy.Customers;

namespace Groomy.Appointments
{
    internal class Appointment : IGenericObject
    {
        private string title;
        private string description;
        private DateTime startTime;
        private DateTime endTime;
        private string location;

        public string appointmentID;

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
            {
                { "AppointmentData", "appointments.json" }
            };
        public Appointment(string t, string d, DateTime sT, DateTime eT, string l, string aID)
        {
            title = t;
            description = d;
            startTime = sT;
            endTime = eT;
            location = l;
            appointmentID = aID;
        }

        public Appointment(string t, string d, DateTime sT, DateTime eT, string l) : this(t, d, sT, eT, l, Helpers.RandomSHA256Hash())
        {
        }

        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["AppointmentData"] = new Dictionary<string, string>
                {
                    { "AppointmentID", appointmentID.ToString() },
                    { "Title", title.ToString() },
                    { "Description", description.ToString() },
                    { "StartTime", startTime.ToString() },
                    { "EndTime", endTime.ToString() },
                    { "Location", location.ToString() }
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
