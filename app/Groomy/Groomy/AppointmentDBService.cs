using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy
{
    internal class AppointmentDBService
    {
        DatabaseManager _DatabaseManager;
        public AppointmentDBService(DatabaseManager dbm)
        {
            _DatabaseManager = dbm;
        }
        public void CreateAppointment(Appointment appointment)
        {
            _DatabaseManager.AddObjectsToDB(appointment);
        }
        public Dictionary<string, object> ReadAppointmentData(string appointmentID)
        {
            return _DatabaseManager.LoadObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void DeleteAppointment(string appointmentID)
        {
            _DatabaseManager.RemoveObjectFromDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
        public void SoftDeleteAppointment(string appointmentID)
        {
            _DatabaseManager.SoftDeleteObjectInDB(appointmentID, Appointment.FilePaths["AppointmentData"]);
        }
    }
}
