using System.Data;
using System.Diagnostics;
using Groomy.Utilities;

namespace Groomy.Appointments
{
    public class AppointmentDBService
    {
        ManagerSingleton ms;

        public AppointmentDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateAppointment(Appointment appointment, string customerID)
        {
            ms.dbm.CreateObjectInDB(appointment);
            ms.dbm.CreateRelationshipEntry(new Relationships.Customer_Appointment_Relationship(customerID, appointment.GetKey()));
        }
        public Dictionary<string, string> ReadAppointmentData(string appointmentID)
        {
            return ms.dbm.ReadObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void UpdateAppointmentData(Appointment appointment, string customerID)
        {
            var appointmentID = appointment.GetKey();
            var appointmentData = appointment.GetFields()["AppointmentData"];

            //update appointment
            ms.dbm.UpdateObjectInDB(appointmentID, appointmentData, Appointment.FilePaths["AppointmentData"]);
            //update relationship
            ms.dbm.UpdateRelationshipEntry(new Relationships.Customer_Appointment_Relationship(customerID, appointmentID));
        }
        public void DeleteAppointment(string appointmentID)
        {
            ms.dbm.DeleteObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            ms.dbm.DeleteRelationshipEntry(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
        }
        public void SoftDeleteAppointment(string appointmentID)
        {
            ms.dbm.SoftDeleteObjectInDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
            ms.dbm.SoftDeleteRelationshipEntry(new Relationships.Customer_Appointment_Relationship(ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID), appointmentID));
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
    }
}
