using Groomy.Appointments;
using Groomy.Relationships;
using Groomy.Utilities;
using Microsoft.VisualBasic;
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
            this.Size = new Size(1249, 493);
            invRichText.Clear();
            serviceOfferedBox.Name = $"Services Offered To: {customerData["FirstName"]}";

            var services = ms.sDBS.GetServices();
            servicesTickBox.Items.Clear();
            foreach (var service in services)
            {
                if (service.ContainsKey("ServiceName") && service.ContainsKey("ServiceID"))
                {
                    string serviceName = service["ServiceName"];
                    string serviceId = service["ServiceID"];
                    servicesTickBox.Items.Add(serviceName, false);
                    servicesTickBox.Tag = serviceId;
                }
            }
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

        private void AppendFormattedText(string text, FontStyle style, int size = 10)
        {
            invRichText.SelectionFont = new Font("Microsoft Sans Serif", size, style);
            invRichText.AppendText(text);
            invRichText.SelectionFont = invRichText.Font;
        }

        private void btnGenInv_Click(object sender, EventArgs e)
        {
            // Enable the print and save button
            btnPrint.Enabled = true;
            btnSaveInv.Enabled = true;

            invRichText.Clear();
            string currentDateTime = DateTime.Now.ToString("MMMM dd, yyyy HH:mm");
            AppendFormattedText($"Date: {currentDateTime}\n", FontStyle.Bold | FontStyle.Bold, 12);
            AppendFormattedText($"You Were Serviced By: ", FontStyle.Bold | FontStyle.Bold, 12);
            // I need help implmenting this
            // invRichText.AppendText($"{userData["FirstName"]} {userData["LastName"]}\n");

            AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 16);
            AppendFormattedText("INVOICE\n", FontStyle.Bold | FontStyle.Underline, 16);
            AppendFormattedText("========================================\n", FontStyle.Bold | FontStyle.Underline, 16);

            invRichText.AppendText("\n========================================\n");

            bool isInvPaid = isPaidTick.Checked;
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
            List<string> selectedServices = new List<string>();
            foreach (var checkedItem in servicesTickBox.CheckedItems)
            {
                selectedServices.Add(checkedItem.ToString());
            }

            foreach (string serviceName in selectedServices)
            {
                var serviceData = ms.sDBS.GetServices()
                    .FirstOrDefault(service => service.ContainsKey("ServiceName") && service["ServiceName"] == serviceName);
                if (serviceData != null)
                {
                    string serviceId = serviceData["ServiceID"];
                    decimal price = decimal.Parse(serviceData["ServicePrice"]);
                    decimal itemTotal = price * 1; // Assuming 1 item per service
                    totalAmount += itemTotal;
                    invRichText.AppendText($"{serviceName,-25}{price,-15:C}{1,-10}{itemTotal,-15:C}\n");
                }
            }

            AppendFormattedText(new string('-', 60) + "\n", FontStyle.Regular, 10);
            invRichText.AppendText("\n");
            invRichText.AppendText($"Total Amount Due: {totalAmount:C}\n");
            invRichText.AppendText("\n========================================\n");
            invRichText.AppendText("Thank you for your business!\n");
            invRichText.AppendText("========================================\n");
        }



    }
}
