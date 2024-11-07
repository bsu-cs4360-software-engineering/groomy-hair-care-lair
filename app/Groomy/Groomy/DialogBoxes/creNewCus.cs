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
        public creNewCus()
        {
            InitializeComponent();
        }

        public void UpdateCustomerFields(Dictionary<string, object> editedCustomer)
        {
            // Check if the editedCustomer dictionary contains the required keys before accessing them
            if (editedCustomer.ContainsKey("FirstName"))
                txtFirst.Text = editedCustomer["FirstName"].ToString();

            if (editedCustomer.ContainsKey("LastName"))
                txtLast.Text = editedCustomer["LastName"].ToString();

            if (editedCustomer.ContainsKey("Email"))
                txtEmail.Text = editedCustomer["Email"].ToString();

            if (editedCustomer.ContainsKey("PhoneNumber"))
                txtPN.Text = editedCustomer["PhoneNumber"].ToString();

            if (editedCustomer.ContainsKey("Address"))
                txtAddress.Text = editedCustomer["Address"].ToString();
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

            // City input check
            if (string.IsNullOrWhiteSpace(txtPN.Text))
            {
                Helpers.messageBoxError("You did not enter a phone number. Please try again.");
                return false;
            }

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
                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
                // dbManager.AddObjectToDB(newCustomer);
            }
        }
    }
}
