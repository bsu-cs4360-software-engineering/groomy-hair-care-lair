using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy.Invoices
{
    public partial class InvoicePrint : Form
    {
        string invoiceID = "";
        string invoiceTotal = "";
        ManagerSingleton ms;
        public InvoicePrint(string invoiceID, string invoiceTotal)
        {
            InitializeComponent();
            this.invoiceID = invoiceID;
            this.invoiceTotal = invoiceTotal;
            ms = ManagerSingleton.GetInstance();
            this.Load += new EventHandler(onLoad);
        }
        public void onLoad(object sender, EventArgs e)
        {
            generateInvoice(invoiceID);
            var invoiceData = ms.iDBS.ReadInvoiceData(invoiceID);
            var isPaid = bool.Parse(invoiceData["IsPaid"]);
            if (isPaid)
            {
                btnSaveInv.Enabled = false;
            }
        }
        private void AppendFormattedText(string text, FontStyle style, int size = 10)
        {
            invRichText.SelectionFont = new Font("Microsoft Sans Serif", size, style);
            invRichText.AppendText(text);
            invRichText.SelectionFont = invRichText.Font;
        }
        private void generateInvoice(string invoiceID)
        {
            invRichText.Clear();
            var invoiceData = ms.iDBS.ReadInvoiceData(invoiceID);
            var customerID = ms.dbrs.GetPrimaryIDFromForeignID(invoiceID, "customers_invoices.json");
            var customerData = ms.cDBS.ReadCustomer(customerID);
            var userID = ms.dbrs.GetPrimaryIDFromForeignID(customerID, "users_customers.json");
            var userData = ms.uDBS.ReadUserData(userID);

            string currentDateTime = DateTime.Now.ToString("MMMM dd, yyyy HH:mm");
            AppendFormattedText($"Date: {currentDateTime}\n", FontStyle.Bold | FontStyle.Bold, 12);
            AppendFormattedText($"You Were Serviced By: ", FontStyle.Bold | FontStyle.Bold, 12);
            invRichText.AppendText($"{userData["FirstName"]} {userData["LastName"]}\n");

            AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 16);
            AppendFormattedText("INVOICE\n", FontStyle.Bold | FontStyle.Underline, 16);
            AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 16);

            invRichText.AppendText("\n========================================\n");

            bool isInvPaid = bool.Parse(invoiceData["IsPaid"]);
            bool hasDueDate = !isInvPaid;
            DateTime? dueDate = null;

            if (!isInvPaid)
            {
                dueDate = DateTime.Now.AddDays(7);
            }

            if (isInvPaid)
            {
                AppendFormattedText("PAID\n", FontStyle.Bold, 14);
            }
            else
            {
                AppendFormattedText("UNPAID\n", FontStyle.Bold, 14);
            }
            if (hasDueDate && dueDate.HasValue)
            {
                AppendFormattedText("Invoice Due By: ", FontStyle.Bold, 14);
                invRichText.AppendText($"{dueDate.Value.ToString("MMMM dd, yyyy")}\n");
            }

            invRichText.AppendText("\n========================================\n");

            AppendFormattedText("Customer Information:\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("----------------------------------------\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("Name: ", FontStyle.Bold, 10);
            invRichText.AppendText($"{customerData["FirstName"]} {customerData["LastName"]}\n");
            AppendFormattedText("Phone: ", FontStyle.Bold, 10);
            invRichText.AppendText($"{customerData["PhoneNumber"]}\n");
            AppendFormattedText("Email: ", FontStyle.Bold, 10);
            invRichText.AppendText($"{customerData["Email"]}\n");
            AppendFormattedText("Address: ", FontStyle.Bold, 10);
            invRichText.AppendText($"{customerData["Address"]}\n");
            invRichText.AppendText("\n");

            AppendFormattedText("Invoice Details:\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("----------------------------------------\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("Item\t\tPrice\t\tQty\t\tTotal\n", FontStyle.Bold, 10);
            AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular, 10);
            
            decimal totalAmount = 0;

            var detailIDs = ms.dbrs.GetForeignIDsFromPrimaryID(invoiceID, "invoices_details.json");
            foreach ( var detailID in detailIDs )
            {
                var detailData = ms.iDBS.ReadDetailData(detailID);
                var serviceData = ms.sDBS.ReadServiceData(detailData["ServiceID"]);
                var serviceName = serviceData["ServiceName"];
                var servicePrice = decimal.Parse(serviceData["ServicePrice"]);

                var quantity = int.Parse(ms.iDBS.ReadDetailData(detailID)["Quantity"]);

                var detailTotal = servicePrice * quantity;
                totalAmount += detailTotal;
                invRichText.AppendText($"{serviceName,-25}\t\t{servicePrice,-15:C}\t\t{quantity,-10}\t\t{totalAmount,-15:C}\n");
            }

            AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular, 10);
            invRichText.AppendText("\n");
            invRichText.AppendText($"Total Amount Due: {invoiceTotal:C}\n");
            invRichText.AppendText("\n========================================\n");
            invRichText.AppendText("Thank you for your business!\n");
            invRichText.AppendText("========================================\n");
        }
        private void btnSaveInv_Click(object sender, EventArgs e)
        {
            //Opens windows dialog box for saving invoice to file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Saves as rich text file or txt file
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
            saveFileDialog.Title = "Save Invoice";
            saveFileDialog.FileName = $"Invoice_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                invRichText.SaveFile(saveFileDialog.FileName);
            }
        }

        private void isPaidTick_CheckedChanged(object sender, EventArgs e)
        {
            var customerID = ms.dbrs.GetPrimaryIDFromForeignID(invoiceID, "customers_invoices.json");
            var invoiceData = ms.iDBS.ReadInvoiceData(invoiceID);
            var newInvoice = new Invoice(customerID, DateTime.Parse(invoiceData["CreateDate"]), DateTime.Parse(invoiceData["DueDate"]), isPaidTick.Checked, invoiceID);
            ms.iDBS.UpdateInvoiceData(newInvoice, customerID);
            generateInvoice(invoiceID);
        }
    }
}
