using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships
{
    internal class Customer_Invoice_Relationship : IRelationship
    {
        string customerID;
        string invoiceID;
        public static string relationshipFilePath = "customers_invoices.json";
        public Customer_Invoice_Relationship(string cID, string iID)
        {
            this.customerID = cID;
            this.invoiceID = iID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("customerID", customerID);
            ids.Add("invoiceID", invoiceID);
            return ids;
        }
    }
}
