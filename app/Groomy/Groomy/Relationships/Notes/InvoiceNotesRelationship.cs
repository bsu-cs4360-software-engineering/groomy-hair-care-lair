using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships.Notes
{
    internal class InvoiceNotesRelationship
    {
        string invoiceID;
        string noteID;
        public static string relationshipFilePath = "invoices_notes.json";
        public InvoiceNotesRelationship(string iID, string nID)
        {
            invoiceID = iID;
            noteID = nID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string,string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("invoiceID", invoiceID);
            ids.Add("noteID", noteID);
            return ids;
        }
    }
}
