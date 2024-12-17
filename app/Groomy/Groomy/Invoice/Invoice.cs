using Groomy.Appointments;
using Groomy.Relationships;
using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

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

            AppendFormattedText("Appointments:\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("----------------------------------------\n", FontStyle.Bold | FontStyle.Underline, 14);

            // Fetch and display appointments
            //var appointments = GetAppointmentsForCustomer(customerData["CustomerID"]);
            var appointmentIDs = ms.dbrs.GetForeignIDsFromPrimaryID(customerData["CustomerID"], "customers_appointments.json");
            if (appointmentIDs.Any())
            {
                foreach (var appointment in appointmentIDs)
                {
                    var appointmentData = ms.aDBS.ReadAppointmentData(appointment);
                    var apptName = appointmentData["Description"];
                    var timeStart = DateTime.Parse(appointmentData["StartTime"]);
                    var timeEnd = DateTime.Parse(appointmentData["EndTime"]);
                    var location = appointmentData["Location"];
                    invRichText.AppendText($"- {apptName} at {location}\n");
                    invRichText.AppendText($" Time In: {timeStart} | Time Out: {timeEnd}\n");
                    invRichText.AppendText($"\n");
                }
            }
            else
            {
                invRichText.AppendText("No appointments found.\n");
            }
            invRichText.AppendText("\n");

            AppendFormattedText("Invoice Details:\n", FontStyle.Bold | FontStyle.Underline, 14);
            AppendFormattedText("----------------------------------------\n", FontStyle.Bold | FontStyle.Underline, 14);

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


        private List<string> GetAppointmentsForCustomer(string customerID)
        {
            var appointments = new List<string>();
            try
            {
                if (File.Exists(Customer_Appointment_Relationship.relationshipFilePath))
                {
                    var jsonData = File.ReadAllText(Customer_Appointment_Relationship.relationshipFilePath);
                    var relationships = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonData);

                    if (relationships != null)
                    {
                        appointments = relationships
                            .Where(r => r["customerID"] == customerID)
                            .Select(r => r["appointmentID"])
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }

            return appointments;
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
