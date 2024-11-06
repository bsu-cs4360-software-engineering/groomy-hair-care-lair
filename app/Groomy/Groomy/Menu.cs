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
        CustomerDBService customerDBService;

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

            customerDBService = new CustomerDBService(databaseManager.GetInstance(new FileService()));
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
            clearCustomerForms();
            activatePanel(panelNewCustomer);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string email = GetFieldFromSelection("Email", dataGridView1);

            if (!string.IsNullOrEmpty(email))
            {
                var editedCustomer = customerDBService.ReadCustomer(Helpers.GenerateSHA256Hash(email));

                txtFirst.Text = editedCustomer["FirstName"].ToString();
                txtLast.Text = editedCustomer["LastName"].ToString();
                txtEmail.Text = editedCustomer["Email"].ToString();
                txtPN.Text = editedCustomer["PhoneNumber"].ToString();
                txtAddress.Text = editedCustomer["Address"].ToString();

                activatePanel(panelNewCustomer);
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to edit.");
            }
        }
        private string GetFieldFromSelection(string field, DataGridView dgv)
        {
            string val = null;

            if (dgv.SelectedRows.Count > 0)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (selectedRow.Cells[field].Value != null)
                {
                    val = selectedRow.Cells[field].Value.ToString();
                }
            }
            else if (dgv.SelectedCells.Count > 0)
            {
                var selectedCell = dgv.SelectedCells[0];
                var selectedRow = dgv.Rows[selectedCell.RowIndex];
                if (selectedRow.Cells[field].Value != null)
                {
                    val = selectedRow.Cells[field].Value.ToString();
                }
            }
            return val;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
                //dbManager.AddObjectToDB(newCustomer);
                customerDBService.CreateCustomer(newCustomer);
                loadCustomerData();
                activatePanel(panelCustomers);
            }
        }
        private void loadCustomerData()
        { 
            dataGridView1.DataSource = customerDBService.GetCustomerDataTable();
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", dataGridView1);

            if (!string.IsNullOrEmpty(email))
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this customer?"))
                {
                    customerDBService.DeleteCustomer(Helpers.GenerateSHA256Hash(email));
                    loadCustomerData();
                }
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to delete.");
            }
        }
    }
}
