using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships.Notes
{
    internal class Invoice_Detail_Relationship
    {
        string invoiceID;
        string detailID;
        public static string relationshipFilePath = "invoices_details.json";
        public Invoice_Detail_Relationship(string iID, string dID)
        {
            invoiceID = iID;
            detailID = dID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("invoiceID", invoiceID);
            ids.Add("detailID", detailID);
            return ids;
        }
    }
}
