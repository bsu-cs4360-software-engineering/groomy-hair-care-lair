using Groomy.Appointments;
using Groomy.Customers;
using System.Data;
using System.Diagnostics;

namespace Groomy
{
    public partial class Menu : Form
    {
        ManagerSingleton ms;
        Size panelWH = new Size(520, 550);
        Point panelLoc = new Point(227, 9);
        public bool editing;
        public Menu()
        {
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        private void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(750, 550);
            ms = ManagerSingleton.GetInstance();
            editing = false; // Use the class-level 'editing' variable
            Helpers.activatePanel(panelWelcome, panelWH, panelLoc);
            loadAppointmentData();
            loadCustomerData();
        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Helpers.activatePanel(panelCustomers, panelWH, panelLoc);
        }
        private void btnWelcome_Click(object sender, EventArgs e)
        {
            //windowFx.OpenForm("Groomy.Login", false);
            Helpers.activatePanel(panelWelcome, panelWH, panelLoc);
        }
        private void btnCustomerNew_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer("", "", "", "", "", "");
            var customerData = newCustomer.GetFields()["CustomerData"];
            Form customerView = new CustomerView(customerData, this);
            customerView.Show();
        }
        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            var newAppointment = new Appointments.Appointment("", "", DateTime.Now, DateTime.Now, "", "");
            var appointmentData = newAppointment.GetFields()["AppointmentData"];
            Form appointmentView = new Appointments.AppointmentView(appointmentData, this);
            appointmentView.Show();
        }
        private void btnBackToCustomers_Click(object sender, EventArgs e)
        {
            Helpers.activatePanel(panelCustomers, panelWH, panelLoc);
        }
        public void reloadData()
        {
            loadAppointmentData();
            loadCustomerData();
        }
        /*
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (validateCustomerForms())
            {
                //initialize new customer and notes
                var newCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text);
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
                    
                };

                loadCustomerData();
                Helpers.activatePanel(panelCustomers, panelWH, panelLoc);
            }
        }
        */
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
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var email = Helpers.GetFieldFromSelection("Email", dataGridView1);
            var customerID = ms.cDBS.GetCustomerIDByEmail(email);

            if (!string.IsNullOrEmpty(email))
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this customer?"))
                {
                    var noteIDs = ms.dbrs.GetNotesIDFromCustomerID(customerID);
                    foreach(var noteID in noteIDs)
                    {
                        ms.nDBS.SoftDeleteCustomerNotes(noteID);
                    }
                    ms.cDBS.SoftDeleteCustomer(customerID);
                    loadCustomerData();
                }
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to delete.");
            }
        }
        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            var appointmentID = Helpers.GetFieldFromSelection("AppointmentID", apptView);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this appointment?"))
            {
                var noteIDs = ms.dbrs.GetNotesIDFromAppointmentID(appointmentID);
                foreach (var noteID in noteIDs)
                {
                    ms.nDBS.SoftDeleteAppointmentNotes(noteID);
                }

                ms.aDBS.SoftDeleteAppointment(appointmentID);
                loadAppointmentData();
            }
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
        private void btnSaveAppointment_Click(object sender, EventArgs e)
        {

            if (validateAppointmentForms())
            {
                var selectedCustomer = ((string, string))comboCustomer.SelectedItem;
                var customerID = ms.cDBS.GetCustomerIDByFirstLast(selectedCustomer);
                Debug.WriteLine($"CustomerID: {customerID}");
                var newAppointment = new Appointments.Appointment(txtTitle.Text, txtDescription.Text, timeStart.Value, timeEnd.Value, txtLocation.Text);
                //var appointmentNotes = new Notes.Notes("appointment", txtApptNotes.Text, DateTime.Now.ToString());

                if (editing)
                {
                    //if editing assign new appointment and notes with existing IDs
                    var appointmentID = fieldAppointmentID.Text;
                    newAppointment = new Appointments.Appointment(txtTitle.Text, txtDescription.Text, timeStart.Value, timeEnd.Value, txtLocation.Text, appointmentID);
                    ms.aDBS.UpdateAppointmentData(newAppointment, customerID);

                    var noteID = ms.dbrs.GetNotesIDFromAppointmentID(appointmentID);
                   // appointmentNotes = new Notes.Notes("appointment", txtApptNotes.Text, DateTime.Now.ToString(), noteID);
                    //ms.nDBS.UpdateAppointmentNotesData(appointmentNotes, newAppointment.GetKey());

                    editing = false;

                }
                else
                {
                    //if not editing save new appointment and notes to DB
                    ms.aDBS.CreateAppointment(newAppointment, customerID);
                    var appointmentID = newAppointment.GetKey();
                    //ms.nDBS.CreateAppointmentNotes(appointmentNotes, appointmentID);
                }

                loadAppointmentData();
                Helpers.activatePanel(apptPanel, panelWH, panelLoc);
            }
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
            Helpers.activatePanel(apptPanel, panelWH, panelLoc);
        }
        private void apptBack_Click(object sender, EventArgs e)
        {
            Helpers.activatePanel(apptPanel, panelWH, panelLoc);
        }

        

        private void btnAppointmentView_Click(object sender, EventArgs e)
        {
            var appointmentID = Helpers.GetFieldFromSelection("AppointmentID", apptView);
            if (!string.IsNullOrEmpty(appointmentID))
            {
                var appointmentData = ms.aDBS.ReadAppointmentData(appointmentID);
                Form appointmentView = new Appointments.AppointmentView(appointmentData, this);
                appointmentView.Show();
            }
            else
            {
                Helpers.messageBoxError("No appointment selected. Please select an appointment.");
            }
        }

        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            var email = Helpers.GetFieldFromSelection("Email", dataGridView1);
            if (!string.IsNullOrEmpty(email))
            {
                var customerID = ms.cDBS.GetCustomerIDByEmail(email);
                var customerData = ms.cDBS.ReadCustomer(customerID);
                Form customerView = new CustomerView(customerData, this);
                customerView.Show();
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer.");
            }
        }
    }
}
