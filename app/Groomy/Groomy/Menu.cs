using Castle.Core.Resource;
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
        AppointmentDBService appointmentDBService;
        FileService fs;

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
            fs = new FileService();
            customerDBService = new CustomerDBService(DatabaseManager.GetInstance(fs));
            appointmentDBService = new AppointmentDBService(DatabaseManager.GetInstance(fs));

            activatePanel(panelWelcome);
            loadAppointmentData();
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

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            clearCustomerForms();
            activatePanel(panelNewCustomer);
        }

        private void btnBackToCustomers_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
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
        private void apptEdit_Click(object sender, EventArgs e)
        {
            var customerID = GetFieldFromSelection("CustomerID", apptView);
            var userID = UserAuth.GetInstance().getID();
            Debug.WriteLine(userID);
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(customerID))
            {
                Helpers.messageBoxError("Error");
            }
            else
            {
                var tempAppointment = new Appointment(userID, customerID, "", "", DateTime.Now, DateTime.Now, "");
                var appointmentID = tempAppointment.GetKey();

                var editedAppointment = appointmentDBService.ReadAppointmentData(appointmentID);
                var appointmentCustomerData = customerDBService.ReadCustomer(customerID);
                var customerName = (appointmentCustomerData["FirstName"].ToString(), appointmentCustomerData["LastName"].ToString());
                selectCustomerByName(customerName);
                txtTitle.Text = editedAppointment["Title"].ToString();
                txtDescription.Text = editedAppointment["Description"].ToString();
                timeStart.Value = DateTime.Parse(editedAppointment["StartTime"].ToString());
                timeEnd.Value = DateTime.Parse(editedAppointment["EndTime"].ToString());
                txtLocation.Text = editedAppointment["Location"].ToString();
                activatePanel(apptCreEdit);
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
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                var newCustomer = new Customer(UserAuth.GetInstance().getID(), txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
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
        private void loadCustomers()
        {
            var userID = UserAuth.GetInstance().getID();
            var customers = customerDBService.GetCustomersByUserID(userID);
            comboCustomer.DataSource = customers.Select(c => (c.Item1, c.Item2)).ToList();
        }
        private void selectCustomerByName((string, string) name)
        {
            loadCustomers();
            for (int i = 0; i < comboCustomer.Items.Count; i++)
            {
                var item = ((string, string))comboCustomer.Items[i];
                if (item.Item1 == name.Item1 && item.Item2 == name.Item2)
                {
                    comboCustomer.SelectedIndex = i;
                    break;
                }
            }
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
        private void clearAppointmentForms()
        {
            loadCustomers();
            txtTitle.Text = "";
            txtDescription.Text = "";
            timeStart.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;
            txtLocation.Text = "";
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


        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", dataGridView1);

            if (!string.IsNullOrEmpty(email))
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this customer?"))
                {
                    customerDBService.SoftDeleteCustomer(Helpers.GenerateSHA256Hash(email));
                    loadCustomerData();
                }
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to delete.");
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            clearAppointmentForms();
            activatePanel(apptCreEdit);
        }

        private bool validateAppointmentForms()
        {
            if (txtTitle.Text == "")
            {
                Helpers.messageBoxError("Please enter a title for the appointment.");
                return false;
            }
            if (txtDescription.Text == "")
            {
                Helpers.messageBoxError("Please enter a description for the appointment.");
                return false;
            }
            if (timeStart.Value >= timeEnd.Value)
            {
                Helpers.messageBoxError("The start time must be before the end time.");
                return false;
            }
            if (txtLocation.Text == "")
            {
                Helpers.messageBoxError("Please enter a location for the appointment.");
                return false;
            }
            return true;
        }
        private void loadAppointmentData()
        {
            apptView.DataSource = appointmentDBService.GetAppointmentDataTable();
        }
        private void btnSaveAppointment_Click(object sender, EventArgs e)
        {
            if (validateAppointmentForms())
            {
                var selectedCustomer = ( (string, string) )comboCustomer.SelectedItem;
                var customerID = customerDBService.GetCustomerIDByFirstLast(selectedCustomer);
                var newAppointmnet = new Appointment(UserAuth.GetInstance().getID(), customerID, txtTitle.Text, txtDescription.Text, timeStart.Value, timeEnd.Value, txtLocation.Text);
                appointmentDBService.CreateAppointment(newAppointmnet);
                loadAppointmentData();
                activatePanel(apptPanel);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            activatePanel(apptPanel);
        }

        private void apptBack_Click(object sender, EventArgs e)
        {
            activatePanel(apptPanel);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void apptDel_Click(object sender, EventArgs e)
        {
            var customerID = GetFieldFromSelection("CustomerID", apptView);
            if (string.IsNullOrEmpty(customerID))
            {
                Helpers.messageBoxError("No appointment selected. Please select an appointment to delete.");
            } 
            else
            {
                // Create a temporary Appointment object to generate the appointmentID
                var tempAppointment = new Appointment(UserAuth.GetInstance().getID(), customerID, "", "", DateTime.Now, DateTime.Now, "");
                var appointmentID = tempAppointment.GetKey();

                if (Helpers.messageBoxConfirm("Are you sure you want to delete this appointment?"))
                {
                    appointmentDBService.SoftDeleteAppointment(appointmentID);
                    loadAppointmentData();
                }
            }
        }
    }
}
