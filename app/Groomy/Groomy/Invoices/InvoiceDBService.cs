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

        string ci_fp = "customers_invoices.json";
        string id_fp = "invoices_details.json";
        public InvoiceDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.dbrs = ms.dbrs;
        }
        public InvoiceDBService(DatabaseManager dbm, DBRelationshipService dbrs)
        {
            this.dbm = dbm;
            this.dbrs = dbrs;
        }

        public void CreateInvoice(Invoice invoice, string customerID)
        {
            dbm.CreateObjectInDB(invoice);
            dbm.CreateRelationshipEntry(new Relationships.Customer_Invoice_Relationship(customerID, invoice.GetKey()));
        }
        public Dictionary<string, string> ReadInvoiceData(string invoiceID)
        {
            return dbm.ReadObjectFromDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
        }
        public void UpdateInvoiceData(Invoice invoice, string customerID)
        {
            var invoiceID = invoice.GetKey();
            var invoiceData = invoice.GetFields()["InvoiceData"];

            dbm.UpdateObjectInDB(invoiceID, invoiceData, Invoice.FilePaths["InvoiceData"]);
            dbm.UpdateRelationshipEntry(new Relationships.Customer_Invoice_Relationship(customerID, invoiceID));
        }
        public void DeleteInvoice(string invoiceID)
        {
            dbm.DeleteObjectFromDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
            //dbm.DeleteRelationshipEntry(new Relationships.Customer_Invoice_Relationship(dbrs.GetCustomerIDFromInvoiceID(invoiceID), invoiceID));
            dbm.DeleteRelationshipEntry(new Relationships.Customer_Invoice_Relationship(dbrs.GetPrimaryIDFromForeignID(invoiceID, ci_fp), invoiceID));
        }
        public void SoftDeleteInvoice(string invoiceID)
        {
            dbm.SoftDeleteObjectInDB(invoiceID, Invoice.FilePaths["InvoiceData"]);
            //dbm.SoftDeleteRelationshipEntry(new Relationships.Customer_Invoice_Relationship(dbrs.GetCustomerIDFromInvoiceID(invoiceID), invoiceID));
            dbm.SoftDeleteRelationshipEntry(new Relationships.Customer_Invoice_Relationship(dbrs.GetPrimaryIDFromForeignID(invoiceID, ci_fp), invoiceID));
        }

        public void CreateDetail(InvoiceDetail detail, string invoiceID)
        {
            dbm.CreateObjectInDB(detail);
            dbm.CreateRelationshipEntry(new Relationships.Invoice_Detail_Relationship(invoiceID, detail.GetKey()));
        }

        public Dictionary<string, string> ReadDetailData(string detailID)
        {
            return dbm.ReadObjectFromDB(detailID, InvoiceDetail.FilePaths["DetailData"]);
        }
        public void UpdateDetailData(InvoiceDetail detail, string invoiceID)
        {
            var detailID = detail.GetKey();
            var detailData = detail.GetFields()["DetailData"];

            dbm.UpdateObjectInDB(detailID, detailData, InvoiceDetail.FilePaths["DetailData"]);
            dbm.UpdateRelationshipEntry(new Relationships.Invoice_Detail_Relationship(invoiceID, detailID));
        }
        public void DeleteDetail(string detailID)
        {
            dbm.DeleteObjectFromDB(detailID, InvoiceDetail.FilePaths["DetailData"]);
            //dbm.DeleteRelationshipEntry(new Relationships.Invoice_Detail_Relationship(dbrs.GetInvoiceIDFromDetailID(detailID), detailID));
            dbm.DeleteRelationshipEntry(new Relationships.Invoice_Detail_Relationship(dbrs.GetPrimaryIDFromForeignID(detailID, "customers_notes.json"), detailID));
        }
        public void SoftDeleteDetail(string detailID)
        {
            dbm.SoftDeleteObjectInDB(detailID, InvoiceDetail.FilePaths["DetailData"]);
            //dbm.SoftDeleteRelationshipEntry(new Relationships.Invoice_Detail_Relationship(dbrs.GetInvoiceIDFromDetailID(detailID), detailID));
            dbm.SoftDeleteRelationshipEntry(new Relationships.Invoice_Detail_Relationship(dbrs.GetPrimaryIDFromForeignID(detailID, "customers_notes.json"), detailID));
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
        public List<Dictionary<string, string>> GetDetails(string invoiceID)
        {
            var details = new List<Dictionary<string, string>>();
            //var detailIDs = dbrs.GetDetailIDsFromInvoiceID(invoiceID);
            var detailIDs = dbrs.GetForeignIDsFromPrimaryID(invoiceID, id_fp);
            foreach (var detailID in detailIDs)
            {
                details.Add(ReadDetailData(detailID));
            }
            return details;
        }

    }
}
