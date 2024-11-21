using System.Data;
using System.Diagnostics;
using Groomy.Utilities;

namespace Groomy.Appointments
{
    internal class AppointmentDBService
    {
        ManagerSingleton ms;

        public AppointmentDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateAppointment(Appointment appointment, string customerID)
        {
            ms.dbm.AddObjectsToDB(appointment);
            ms.dbm.AddRelationshipToDB(new Relationships.Customer_Appointment_Relationship(customerID, appointment.GetKey()));
        }
        public Dictionary<string, string> ReadAppointmentData(string appointmentID)
        {
            return ms.dbm.LoadJsonFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void UpdateAppointmentData(Appointment appointment, string customerID)
        {
            var appointmentID = appointment.GetKey();
            var appointmentData = appointment.GetFields()["AppointmentData"];

            //update appointment
            ms.dbm.UpdateObjectInDB(appointmentID, appointmentData, Appointment.FilePaths["AppointmentData"]);
            //update relationship
            ms.dbm.UpdateRelationshipInDB(new Relationships.Customer_Appointment_Relationship(customerID, appointmentID));
        }
        public void DeleteAppointment(string appointmentID)
        {
            ms.dbm.RemoveObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            ms.dbm.DeleteRelationshipFromDB(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
        }
        public void SoftDeleteAppointment(string appointmentID)
        {
            ms.dbm.SoftDeleteObjectInDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            ms.dbm.SoftDeleteRelationshipFromDB(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
        }

        public List<Dictionary<string, string>> GetAppointments()
        {
            var appointments = new List<Dictionary<string, string>>();
            var customerIDs = ms.dbrs.GetCustomerIDs();
            foreach (var customerID in customerIDs)
            {
                var customerAppointmentIDs = ms.dbrs.GetAppointmentsFromCustomerID(customerID);
                foreach (var appointmentID in customerAppointmentIDs)
                {
                    appointments.Add(ReadAppointmentData(appointmentID));
                }
            }
            return appointments;
        }
        public DataTable GetAppointmentDataTable(List<string> keys = null)
        {
            var appointments = GetAppointments();
            var dataTable = new DataTable();

            if (appointments.Count > 0)
            {
                if (keys == null || keys.Count == 0)
                {
                    keys = appointments.First().Keys.ToList();
                }

                foreach (var key in keys)
                {
                    dataTable.Columns.Add(key);
                }

                foreach (var appointment in appointments)
                {
                    if (appointment != null)
                    {
                        var row = dataTable.NewRow();
                        foreach (var key in keys)
                        {
                            if (appointment.ContainsKey(key))
                            {
                                row[key] = appointment[key];
                            }
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }
            return dataTable;
        }
    }
}
