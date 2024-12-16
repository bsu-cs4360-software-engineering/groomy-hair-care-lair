using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Groomy.Invoice
{
    public partial class Invoice : Form
    {
        Dictionary<string, string> customerData;
        List<Dictionary<string, string>> customerNotes;
        Menu parentForm;
        Size panelSize = new Size(419, 308);
        Point panelLocation = new Point(327, 90);
        ManagerSingleton ms;
        public Invoice(Dictionary<string, string> customerData, Menu parentForm)
        {
            ms = ManagerSingleton.GetInstance();
            this.customerData = customerData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }

        public void onLoad(object sender, EventArgs e)
            {
                this.Size = new Size(971, 699);


                invRichText.Clear();

                AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 14);
                AppendFormattedText("INVOICE\n", FontStyle.Bold | FontStyle.Underline, 14);
                AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 14);
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

                // Add the Invoice Details Section
                AppendFormattedText("Invoice Details:\n", FontStyle.Bold | FontStyle.Underline, 14);
                AppendFormattedText("----------------------------------------\n", FontStyle.Bold | FontStyle.Underline, 14);

                // Example of item list (this can be dynamically generated)
                string[] items = { "Example Product" }; // Replace with actual items
                decimal[] prices = { 100.00m }; // Replace with actual prices
                int[] quantities = { 1 }; // Replace with actual quantities
                decimal totalAmount = 0;

                // Table-like structure for items
                AppendFormattedText("Item\t\tPrice\t\tQty\t\tTotal\n", FontStyle.Bold, 10);
                AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular, 10);

                for (int i = 0; i < items.Length; i++)
                {
                    decimal itemTotal = prices[i] * quantities[i];
                    totalAmount += itemTotal;
                    invRichText.AppendText($"{items[i],-25}{prices[i],-15:C}{quantities[i],-10}{itemTotal,-15:C}\n");
                }

                // Add a separator before the totals
                AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular, 10);
                invRichText.AppendText("\n");

                // Add the total amount
                invRichText.AppendText($"Total Amount Due: {totalAmount:C}\n");

                // Add footer and final notes
                invRichText.AppendText("\n========================================\n");
                invRichText.AppendText("Thank you for your business!\n");
                invRichText.AppendText("========================================\n");
            }

            // Helper method to append formatted text to the RichTextBox
            private void AppendFormattedText(string text, FontStyle style, int size = 10)
            {
                invRichText.SelectionFont = new Font("Microsoft Sans Serif", size, style);
                invRichText.AppendText(text);
                invRichText.SelectionFont = invRichText.Font; // Reset to default
            }

    }
}
