using Groomy.Customers;
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

namespace Groomy
{
    public partial class Menu : Form
    {
        databaseManager dbManager = databaseManager.GetInstance(new FileService());
        private void activatePanel(Panel panel)
        {
            var panelWH = new Size(520, 550);
            var panelLoc = new Point(227, 9);
            panel.Size = panelWH;
            panel.Location = panelLoc;
            panel.BringToFront();
        }
        public Menu()
        {
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        private void onLoad(object sender, EventArgs e)
        {
            activatePanel(panelWelcome);
            loadCustomerData();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            //windowFx.OpenForm("Groomy.Login", false);
            activatePanel(panelWelcome);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            activatePanel(panelNewCustomer);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var email = selectedRow.Cells["Email"].Value.ToString();

            var editedCustomer = dbManager.LoadObjectFromDB(Helpers.GenerateSHA256Hash(email), Customer.CustomersFilePath);
            
            txtFirst.Text = editedCustomer["FirstName"].ToString();
            txtLast.Text = editedCustomer["LastName"].ToString();
            txtEmail.Text = editedCustomer["Email"].ToString();
            txtPN.Text = editedCustomer["PhoneNumber"].ToString();
            txtAddress.Text = editedCustomer["Address"].ToString();

            activatePanel(panelNewCustomer);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
                dbManager.AddObjectToDB(newCustomer, Customer.CustomersFilePath);
                loadCustomerData();
                activatePanel(panelCustomers);
            }
            else
            {
                Debug.WriteLine("fuck");
            }
        }
        private void loadCustomerData()
        {
            dataGridView1.DataSource = dbManager.GetDataTable(Customer.CustomersFilePath, 4);
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var email = selectedRow.Cells["Email"].Value.ToString();
                dbManager.RemoveObjectFromDB(Helpers.GenerateSHA256Hash(email), Customer.CustomersFilePath);
                loadCustomerData();
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to delete.");
            }
        }
    }
}
