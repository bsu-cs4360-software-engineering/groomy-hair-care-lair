using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships.Notes
{
    internal class CustomerNotesRelationship : IRelationship
    {
        string customerID;
        string noteID;
        public static string relationshipFilePath = "customers_notes.json";
        public CustomerNotesRelationship(string cID, string nID)
        {
            customerID = cID;
            noteID = nID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("customerID", customerID);
            ids.Add("noteID", noteID);
            return ids;
        }
    }
}
