using System.Data;
using System.Diagnostics;
using Groomy.Utilities;

namespace Groomy.Appointments
{
    public class AppointmentDBService
    {
        DatabaseManager dbm;
        DBRelationshipService dbrs;
        public AppointmentDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.dbrs = ms.dbrs;
        }
        public AppointmentDBService(DatabaseManager dbm, DBRelationshipService dbrs)
        {
            this.dbm = dbm;
            this.dbrs = dbrs;
        }

        public void CreateAppointment(Appointment appointment, string customerID)
        {
            dbm.CreateObjectInDB(appointment);
            dbm.CreateRelationshipEntry(new Relationships.Customer_Appointment_Relationship(customerID, appointment.GetKey()));
        }
        public Dictionary<string, string> ReadAppointmentData(string appointmentID)
        {
            return dbm.ReadObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void UpdateAppointmentData(Appointment appointment, string customerID)
        {
            var appointmentID = appointment.GetKey();
            var appointmentData = appointment.GetFields()["AppointmentData"];

            //update appointment
            dbm.UpdateObjectInDB(appointmentID, appointmentData, Appointment.FilePaths["AppointmentData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.Customer_Appointment_Relationship(customerID, appointmentID));
        }
        public void DeleteAppointment(string appointmentID)
        {
            dbm.DeleteObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            dbm.DeleteRelationshipEntry(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
        }
        public void SoftDeleteAppointment(string appointmentID)
        {
            dbm.SoftDeleteObjectInDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            dbm.SoftDeleteRelationshipEntry(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
        }

        public List<Dictionary<string, string>> GetAppointments()
        {
            var appointments = new List<Dictionary<string, string>>();
            var customerIDs = dbrs.GetCustomerIDs();
            foreach (var customerID in customerIDs)
            {
                var customerAppointmentIDs = dbrs.GetAppointmentsFromCustomerID(customerID);
                foreach (var appointmentID in customerAppointmentIDs)
                {
                    appointments.Add(ReadAppointmentData(appointmentID));
                }
            }
            return appointments;
        }
    }
}
