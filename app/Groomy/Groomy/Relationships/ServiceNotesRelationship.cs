using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships
{
    internal class ServiceNotesRelationship: IRelationship
    {
        string serviceID;
        string noteID;
        public static string relationshipFilePath = "services_notes.json";
        public ServiceNotesRelationship(string sID, string nID)
        {
            serviceID = sID;
            noteID = nID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("serviceID", serviceID);
            ids.Add("noteID", noteID);
            return ids;
        }
    }
}

