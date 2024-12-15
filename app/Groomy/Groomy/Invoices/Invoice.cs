using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Groomy.Invoices
{
    internal class Invoice : IGenericObject 
    {
        public string invoiceID;
        public string customerID;
        public DateTime createDate;
        public DateTime dueDate;
        public bool isPaid;

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "InvoiceData", "invoices.json" }
        };
        public Invoice(string cID, DateTime cD, DateTime dD, bool iP, string iID)
        {
            customerID = cID;
            createDate = cD;
            dueDate = dD;
            isPaid = iP;
            invoiceID = iID;
        }

        public Invoice(string cID, DateTime cD, DateTime dD, bool iP) : this(cID, cD, dD, iP, Helpers.RandomSHA256Hash())
        {
        }

        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["InvoiceData"] = new Dictionary<string, string>
                {
                    { "InvoiceID", invoiceID.ToString() },
                    { "CustomerID", customerID.ToString() },
                    { "CreateDate", createDate.ToString() },
                    { "DueDate", dueDate.ToString() },
                    { "IsPaid", isPaid.ToString() }
                };
            return temp;
        }
        public string GetKey()
        {
            return invoiceID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
}
    internal class InvoiceDetail: IGenericObject
    {
        public string detailID;
        public string serviceID;
        public int quantity;

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "InvoiceDetailData", "invoice_details.json" }
        };

        public InvoiceDetail(string sID, int q, string dID)
        {
            serviceID = sID;
            quantity = q;
            detailID = dID;
        }
        public InvoiceDetail(string sID, int q) : this(sID, q, Helpers.RandomSHA256Hash())
        {
        }
        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["InvoiceDetailData"] = new Dictionary<string, string>
                {
                    { "DetailID", detailID.ToString() },
                    { "ServiceID", serviceID.ToString() },
                    { "Quantity", quantity.ToString() }
                };
            return temp;
        }
        public string GetKey()
        {
            return detailID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }

}
