using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Groomy.Invoices
{
    public partial class InvoicePrint : Form
    {
        string invoiceID = "";
        string invoiceTotal = "";
        ManagerSingleton ms;
        private PrintDocument printDocument; // PrintDocument object

        public InvoicePrint(string invoiceID, string invoiceTotal)
        {
            InitializeComponent();
            this.invoiceID = invoiceID;
            this.invoiceTotal = invoiceTotal;
            ms = ManagerSingleton.GetInstance();

            // Initialize PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

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

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Print the contents of invRichText
            string content = invRichText.Text; // Get text content from the RichTextBox
            Font printFont = new Font("Courier New", 10); // Font used for printing
            float yPos = 0; // Y-coordinate for text placement
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            // Split content into lines for printing
            string[] lines = content.Split(new[] { '\n' }, StringSplitOptions.None);

            // Loop through lines and print them
            foreach (string line in lines)
            {
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                count++;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Show a print dialog before printing
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void AppendFormattedText(string text, FontStyle style, int size = 10)
        {
            invRichText.SelectionFont = new Font("Courier New", size, style);
            invRichText.AppendText(text);
            invRichText.SelectionFont = invRichText.Font;
        }

        private void generateInvoice(string invoiceID)
        {
            invRichText.Clear();
            invRichText.Font = new Font("Courier New", 10); // Use a fixed-width font for consistent alignment

            var invoiceData = ms.iDBS.ReadInvoiceData(invoiceID);
            var customerID = ms.dbrs.GetPrimaryIDFromForeignID(invoiceID, "customers_invoices.json");
            var customerData = ms.cDBS.ReadCustomer(customerID);
            var userID = ms.dbrs.GetPrimaryIDFromForeignID(customerID, "users_customers.json");
            var userData = ms.uDBS.ReadUserData(userID);

            string currentDateTime = DateTime.Now.ToString("MMMM dd, yyyy HH:mm");
            AppendFormattedText($"Date: {currentDateTime}\n", FontStyle.Bold, 12);
            AppendFormattedText($"You Were Serviced By: {userData["FirstName"]} {userData["LastName"]}\n", FontStyle.Bold, 12);

            AppendFormattedText(new string('=', 50) + "\n", FontStyle.Bold, 12);
            AppendFormattedText("INVOICE\n", FontStyle.Bold, 14);
            AppendFormattedText(new string('=', 50) + "\n\n", FontStyle.Bold, 12);

            // Payment Status
            bool isInvPaid = bool.Parse(invoiceData["IsPaid"]);
            AppendFormattedText(isInvPaid ? "PAID\n" : "UNPAID\n", FontStyle.Bold, 12);

            if (!isInvPaid)
            {
                DateTime dueDate = DateTime.Now.AddDays(7);
                AppendFormattedText($"Invoice Due By: {dueDate:MMMM dd, yyyy}\n\n", FontStyle.Bold, 12);
            }

            AppendFormattedText("Customer Information:\n", FontStyle.Underline | FontStyle.Bold, 12);
            AppendFormattedText("Name: ".PadRight(12) + $"{customerData["FirstName"]} {customerData["LastName"]}\n", FontStyle.Regular);
            AppendFormattedText("Phone: ".PadRight(12) + $"{customerData["PhoneNumber"]}\n", FontStyle.Regular);
            AppendFormattedText("Email: ".PadRight(12) + $"{customerData["Email"]}\n", FontStyle.Regular);
            AppendFormattedText("Address: ".PadRight(12) + $"{customerData["Address"]}\n\n", FontStyle.Regular);

            // Invoice Details Header
            AppendFormattedText("Invoice Details:\n", FontStyle.Underline | FontStyle.Bold, 12);
            AppendFormattedText($"{"Item",-25}{"Price",-12}{"Qty",-8}{"Total",-12}\n", FontStyle.Bold);
            AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular);

            // Invoice Details Data
            decimal totalAmount = 0;
            var detailIDs = ms.dbrs.GetForeignIDsFromPrimaryID(invoiceID, "invoices_details.json");

            foreach (var detailID in detailIDs)
            {
                var detailData = ms.iDBS.ReadDetailData(detailID);
                var serviceData = ms.sDBS.ReadServiceData(detailData["ServiceID"]);
                var serviceName = serviceData["ServiceName"];
                var servicePrice = decimal.Parse(serviceData["ServicePrice"]);
                var quantity = int.Parse(detailData["Quantity"]);
                var detailTotal = servicePrice * quantity;

                totalAmount += detailTotal;

                // Align columns properly
                invRichText.AppendText($"{serviceName,-25}{servicePrice,-12:C}{quantity,-8}{detailTotal,-12:C}\n");
            }

            AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular);
            AppendFormattedText($"{"Total Amount " + (isInvPaid ? "Paid" : "Due") + ":".PadRight(40)}{totalAmount:C}\n", FontStyle.Bold);
            AppendFormattedText("\n" + new string('=', 50) + "\n", FontStyle.Bold);
            AppendFormattedText("Thank you for your business!\n", FontStyle.Italic);
            AppendFormattedText(new string('=', 50) + "\n", FontStyle.Bold);
        }


        private void btnSaveInv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
            saveFileDialog.Title = "Save Invoice";
            saveFileDialog.FileName = $"Invoice_{DateTime.Now:yyyyMMddHHmmss}";
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
