using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy.DialogBoxes
{
    public partial class creNewCus : Form
    {
        FileService fs;
        CustomerDBService customerDBService;
        DatabaseManager dbManager;
        private string email;  // Store the passed email here

        // Modify constructor to accept the email as a parameter
        public creNewCus(string email)
        {
            fs = new FileService();
            dbManager = DatabaseManager.GetInstance(fs);
            customerDBService = new CustomerDBService(dbManager);
            InitializeComponent();
            this.email = email; // Set the email to use for fetching customer data
        }

        private void clearCustomerForms()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtPN.Text = "";
            txtAddress.Text = "";
            txtNotes.Text = "";
        }

        private bool validateCustomerForms()
        {
            // First name check
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                Helpers.messageBoxError("You did not enter a first name. Please try again.");
                return false;
            }

            // Last name check
            if (string.IsNullOrWhiteSpace(txtLast.Text))
            {
                Helpers.messageBoxError("You did not enter a last name. Please try again.");
                return false;
            }

            // Valid email check using a simple regex for validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Helpers.messageBoxError("You did not enter a valid email. Please try again.");
                return false;
            }

            // Phone number input check
            if (string.IsNullOrWhiteSpace(txtPN.Text))
            {
                Helpers.messageBoxError("You did not enter a phone number. Please try again.");
                return false;
            }

            // Address input check
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                Helpers.messageBoxError("You did not enter an Address. Please try again.");
                return false;
            }

            // If all checks pass, return true
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                // Check if customerDBService is initialized
                if (customerDBService == null)
                {
                    Helpers.messageBoxError("Customer database service is not initialized.");
                    return;
                }

                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
                customerDBService.CreateCustomer(newCustomer); // Create the customer in the database

                // Refresh the Tabs form after saving
                Tabs tabsForm = new Tabs();
                tabsForm.loadCustomerData(); // Reload the customer data in the parent form
                this.Hide(); // Hide the current form after saving
            }
        }

        private void creNewCus_Load(object sender, EventArgs e)
        {
            // Only populate the fields if email is not empty and not set to "No Email"
            if (!string.IsNullOrEmpty(email) && email != "No Email")
            {
                var editedCustomer = customerDBService.ReadCustomer(Helpers.GenerateSHA256Hash(email));

                // Populate the form fields with the customer data
                txtFirst.Text = editedCustomer["FirstName"].ToString();
                txtLast.Text = editedCustomer["LastName"].ToString();
                txtEmail.Text = editedCustomer["Email"].ToString();
                txtPN.Text = editedCustomer["PhoneNumber"].ToString();
                txtAddress.Text = editedCustomer["Address"].ToString();

                this.Text = "Editing a Customer";
                lblNewCustomer.Text = "Edit Customer";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
