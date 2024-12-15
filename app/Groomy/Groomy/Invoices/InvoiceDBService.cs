using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Invoices
{
    public class InvoiceDBService
    {
        private DatabaseManager dbm;
        private DBRelationshipService dbrs;
        public InvoiceDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.dbrs = ms.dbrs;
        }
        public void CreateInvoice(Invoice invoice)
        {
            dbm.CreateObjectInDB(invoice);
        }
        public Dictionary<string, string> ReadInvoiceData(string invoiceID)
        {
            return dbm.ReadObjectFromDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
        }
        public void UpdateInvoiceData(Invoice invoice)
        {
            var invoiceID = invoice.GetKey();
            var invoiceData = invoice.GetFields()["InvoiceData"];

            dbm.UpdateObjectInDB(invoiceID, invoiceData, Invoice.FilePaths["InvoiceData"]);
        }
        public void DeleteInvoice(string invoiceID)
        {
            dbm.DeleteObjectFromDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
        }
        public void SoftDeleteInvoice(string invoiceID)
        {
            dbm.SoftDeleteObjectInDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
        }
        public List<Dictionary<string, string>> GetInvoices()
        {
            var invoices = new List<Dictionary<string, string>>();
            var invoiceIDs = dbrs.GetInvoiceIDs();
            foreach (var invoiceID in invoiceIDs)
            {
                invoices.Add(ReadInvoiceData(invoiceID));
            }
            return invoices;
        }

    }
}
