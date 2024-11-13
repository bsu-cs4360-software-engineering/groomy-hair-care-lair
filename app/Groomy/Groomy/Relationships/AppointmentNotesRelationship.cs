using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships
{
    internal class AppointmentNotesRelationship
    {
        string appointmentID;
        string noteID;
        public static string relationshipFilePath = "appointments_notes.json";
        public AppointmentNotesRelationship(string aID, string nID)
        {
            appointmentID = aID;
            noteID = nID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("appointmentID", appointmentID);
            ids.Add("noteID", noteID);
            return ids;
        }
    }
}
