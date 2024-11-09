using System.Data;
using System.Diagnostics;

namespace Groomy
{
    internal class AppointmentDBService
    {
        DatabaseManager databaseManager;
        DBRelationshipService dbRS;

        public AppointmentDBService(DatabaseManager dbm, DBRelationshipService dbrs)
        {
            databaseManager = dbm;
            dbRS = dbrs;
        }
        public void CreateAppointment(Appointment appointment, string customerID)
        {
            databaseManager.AddObjectsToDB(appointment);
            databaseManager.AddRelationshipToDB(new Relationships.Customer_Appointment_Relationship(customerID, appointment.GetKey()));
        }
        public Dictionary<string, string> ReadAppointmentData(string appointmentID)
        {
            return databaseManager.LoadJsonFromDBString(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void DeleteAppointment(string appointmentID)
        {
            databaseManager.RemoveObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void SoftDeleteAppointment(string appointmentID)
        {
            databaseManager.SoftDeleteObjectInDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }

        public List<Dictionary<string, string>> GetAppointments()
        {
            Debug.WriteLine("Getting appointments");
            var appointments = new List<Dictionary<string, string>>();
            var customerIDs = dbRS.GetCustomerIDs();
            foreach (var customerID in customerIDs)
            {
                Debug.WriteLine(customerID);
                var customerAppointmentIDs = dbRS.GetAppointmentsFromCustomerID(customerID);
                foreach (var appointmentID in customerAppointmentIDs)
                {
                    Debug.WriteLine(appointmentID);
                    appointments.Add(ReadAppointmentData(appointmentID));
                }
            }
            return appointments;
        }
        public DataTable GetAppointmentTable()
        {
            var appointments = GetAppointments();
            var dataTable = new DataTable();

            if (appointments.Count > 0)
            {
                // Add columns based on the keys of the first appointment
                foreach (var key in appointments[0].Keys)
                {
                    dataTable.Columns.Add(key);
                }

                // Add rows
                foreach (var appointment in appointments)
                {
                    var row = dataTable.NewRow();
                    foreach (var key in appointment.Keys)
                    {
                        row[key] = appointment[key];
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
    }
}
