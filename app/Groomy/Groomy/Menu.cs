using Groomy.Customers;
using System.Data;
using System.Diagnostics;

namespace Groomy
{
    public partial class Menu : Form
    {
        ManagerSingleton ms;
        public bool editing;

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
            ms = ManagerSingleton.GetInstance();
            editing = false; // Use the class-level 'editing' variable
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
        private void makeCustomerIDVisible()
        {
            lblCustomerID.Visible = fieldCustomerID.Visible = true;
        }
        private void makeCustomerIDInvisible()
        {
            lblCustomerID.Visible = fieldCustomerID.Visible = false;
        }
        private void btnCustomerNew_Click(object sender, EventArgs e)
        {
            makeCustomerIDInvisible();
            clearCustomerForms();
            activatePanel(panelNewCustomer);
        }
        private void btnBackToCustomers_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }
        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", dataGridView1);
            if (!string.IsNullOrEmpty(email))
            {
                var customerID = ms.cDBS.GetCustomerIDByEmail(email);
                var noteID = ms.dbrs.GetNotesIDFromCustomerID(customerID);
                var editedCustomer = ms.cDBS.ReadCustomer(customerID);
                //var editedNotes = ms.nDBS.ReadNotesData(noteID);

                //assign customer data
                txtFirst.Text = editedCustomer["FirstName"].ToString();
                txtLast.Text = editedCustomer["LastName"].ToString();
                txtEmail.Text = editedCustomer["Email"].ToString();
                txtPN.Text = editedCustomer["PhoneNumber"].ToString();
                txtAddress.Text = editedCustomer["Address"].ToString();
                fieldCustomerID.Text = editedCustomer["CustomerID"].ToString();
                //assign notes data
                //txtCustomerNotes.Text = editedNotes["Payload"].ToString();
                editing = true;

                makeCustomerIDVisible();
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
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                //initialize new customer and notes
                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
                var customerNotes = new Notes.Notes("customer", txtCustomerNotes.Text, DateTime.Now.ToString());
                if (editing)
                {
                    //create new customer and notes with existing IDs
                    var customerID = fieldCustomerID.Text;
                    newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text, customerID);
                    ms.cDBS.UpdateCustomerData(newCustomer);


                    //var noteID = ms.dbrs.GetNotesIDFromCustomerID(customerID);
                    //customerNotes = new Notes.Notes("customer", txtCustomerNotes.Text, DateTime.Now.ToString(), noteID);
                    //ms.nDBS.UpdateCustomerNotesData(customerNotes, newCustomer.GetKey());

                    editing = false;
                }
                else
                {
                    ms.cDBS.CreateCustomer(newCustomer);
                    var customerID = newCustomer.GetKey();
                    ms.nDBS.CreateCustomerNotes(customerNotes, newCustomer.GetKey());
                };

                loadCustomerData();
                activatePanel(panelCustomers);
            }
        }
        private void loadCustomerData()
        {
            dataGridView1.DataSource = ms.cDBS.GetCustomerDataTable(["FirstName", "LastName", "Email", "PhoneNumber"]);
        }
        private void loadCustomers()
        {
            var customers = ms.cDBS.GetCustomers();
            comboCustomer.DataSource = customers.Select(c => (c["FirstName"], c["LastName"])).ToList();
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
        private void clearCustomerForms()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtPN.Text = "";
            txtAddress.Text = "";
            txtCustomerNotes.Text = "";
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", dataGridView1);
            var customerID = Helpers.GenerateSHA256Hash(email);

            if (!string.IsNullOrEmpty(email))
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this customer?"))
                {
                    ms.cDBS.SoftDeleteCustomer(customerID);
                    ms.nDBS.SoftDeleteCustomerNotes(customerID);
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
        private void clearAppointmentForms()
        {
            loadCustomers();
            txtTitle.Text = "";
            txtDescription.Text = "";
            timeStart.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;
            txtLocation.Text = "";

            txtApptNotes.Text = "";
        }
        private void loadAppointmentData()
        {
            apptView.DataSource = ms.aDBS.GetAppointmentDataTable(null);
            if (apptView.Columns["AppointmentID"] != null)
            {
                apptView.Columns["AppointmentID"].Visible = false;
            }
            if (apptView.Columns["Description"] != null)
            {
                apptView.Columns["Description"].Visible = false;
            }
        }
        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            makeAppointmentIDInvisible();
            clearAppointmentForms();
            activatePanel(apptCreEdit);
        }
        private void btnSaveAppointment_Click(object sender, EventArgs e)
        {

            if (validateAppointmentForms())
            {
                var selectedCustomer = ((string, string))comboCustomer.SelectedItem;
                var customerID = ms.cDBS.GetCustomerIDByFirstLast(selectedCustomer);
                Debug.WriteLine($"CustomerID: {customerID}");
                var newAppointment = new Appointment(txtTitle.Text, txtDescription.Text, timeStart.Value, timeEnd.Value, txtLocation.Text);
                var appointmentNotes = new Notes.Notes("appointment", txtApptNotes.Text, DateTime.Now.ToString());

                if (editing)
                {
                    //if editing assign new appointment and notes with existing IDs
                    var appointmentID = fieldAppointmentID.Text;
                    newAppointment = new Appointment(txtTitle.Text, txtDescription.Text, timeStart.Value, timeEnd.Value, txtLocation.Text, appointmentID);
                    ms.aDBS.UpdateAppointmentData(newAppointment, customerID);

                    var noteID = ms.dbrs.GetNotesFromAppointmentID(appointmentID);
                    appointmentNotes = new Notes.Notes("appointment", txtApptNotes.Text, DateTime.Now.ToString(), noteID);
                    ms.nDBS.UpdateAppointmentNotesData(appointmentNotes, newAppointment.GetKey());

                    editing = false;

                }
                else
                {
                    //if not editing save new appointment and notes to DB
                    ms.aDBS.CreateAppointment(newAppointment, customerID);
                    var appointmentID = newAppointment.GetKey();
                    ms.nDBS.CreateAppointmentNotes(appointmentNotes, appointmentID);
                }

                loadAppointmentData();
                activatePanel(apptPanel);
            }
        }
        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            var appointmentID = GetFieldFromSelection("AppointmentID", apptView);

            var customerID = ms.dbrs.GetCustomerIDFromAppointmentID(appointmentID);
            var noteID = ms.dbrs.GetNotesFromAppointmentID(appointmentID);

            var editedAppointment = ms.aDBS.ReadAppointmentData(appointmentID);
            var editedNotes = ms.nDBS.ReadNotesData(noteID);

            var customerData = ms.cDBS.ReadCustomer(customerID);
            var customerName = (customerData["FirstName"].ToString(), customerData["LastName"].ToString());
            selectCustomerByName(customerName);

            //Loading Appointment Data
            txtTitle.Text = editedAppointment["Title"].ToString();
            txtDescription.Text = editedAppointment["Description"].ToString();
            timeStart.Value = DateTime.Parse(editedAppointment["StartTime"].ToString());
            timeEnd.Value = DateTime.Parse(editedAppointment["EndTime"].ToString());
            txtLocation.Text = editedAppointment["Location"].ToString();
            editing = true;
            fieldAppointmentID.Text = editedAppointment["AppointmentID"].ToString();
            //Loading Notes Data
            txtApptNotes.Text = editedNotes["Payload"].ToString();

            makeAppointmentIDVisible();
            activatePanel(apptCreEdit);
        }

        private void makeAppointmentIDVisible()
        {
            lblAppointmentID.Visible = fieldAppointmentID.Visible = true;
        }
        private void makeAppointmentIDInvisible()
        {
            lblAppointmentID.Visible = fieldAppointmentID.Visible = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            loadAppointmentData();
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
            var appointmentID = GetFieldFromSelection("AppointmentID", apptView);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this appointment?"))
            {
                ms.aDBS.SoftDeleteAppointment(appointmentID);
                var noteID = ms.dbrs.GetNotesFromAppointmentID(appointmentID);
                ms.nDBS.SoftDeleteAppointmentNotes(noteID);
                loadAppointmentData();
            }
        }

        private void btnCustomerView_Click_1(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", dataGridView1);
            if (!string.IsNullOrEmpty(email))
            {
                var customerID = ms.cDBS.GetCustomerIDByEmail(email);
                var customerData = ms.cDBS.ReadCustomer(customerID);
                Form customerView = new CustomerView(customerData);
                customerView.Show();
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer.");
            }
        }
    }
}
