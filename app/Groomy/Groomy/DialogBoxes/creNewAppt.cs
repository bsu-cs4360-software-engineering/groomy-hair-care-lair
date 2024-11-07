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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Groomy.DialogBoxes
{
    public partial class creNewAppt : Form
    {
        FileService fs;
        CustomerDBService customerDBService;
        AppointmentDBService appointmentDBService;
        DatabaseManager dbManager;
        private string ApptID;
        public creNewAppt(string ApptID)
        {
            fs = new FileService();
            dbManager = DatabaseManager.GetInstance(fs);
            customerDBService = new CustomerDBService(dbManager);
            appointmentDBService = new AppointmentDBService(dbManager);
            InitializeComponent();
            this.ApptID = ApptID;
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
        public void loadCustomerData()
        {
            cusDataView.DataSource = customerDBService.GetCustomerDataTable();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string appointmentID = txtAppointmentID.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string customerID = GetFieldFromSelection("Email", cusDataView); //For now. Change later if you want.

            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string location = txtLocation.Text;
            if (string.IsNullOrWhiteSpace(customerID) || string.IsNullOrWhiteSpace(title) || startTime == null || endTime == null || string.IsNullOrWhiteSpace(location))
            {
                Helpers.messageBoxError("Please fill in all fields.");
                return;
            }

            // Ensuring that the end time is after the start time
            if (endTime <= startTime)
            {
                Helpers.messageBoxError("End time must be after start time.");
                return;
            }

            // Creating a new Appointment object
            Appointment newAppointment = new Appointment(customerID, title, description, startTime, endTime, location);

            appointmentDBService.CreateAppointment(newAppointment);
            Helpers.messageBoxSuccess("Appointment saved successfully!");
            this.Hide();
        }

        private void creNewAppt_Load(object sender, EventArgs e)
        {
            // Only populate the fields if appointment ID is not empty and not set to "No ID"
            if (!string.IsNullOrEmpty(ApptID) && ApptID != "No ID")
            {
                // To do: When a ApptID is piped into the program fill the fields in appropriately so that the user can eidt the appointment
                this.Text = "Editing an Appointment";
                lblNewAppt.Text = "Edit Appointment";
            }
            else
            {
                loadCustomerData();
                Random random = new Random();
                int randomNumber = random.Next(10000, 100000);
                txtAppointmentID.Text = randomNumber.ToString();
            }
            
        }
    }
}
