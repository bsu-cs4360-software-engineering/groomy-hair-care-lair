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
    public partial class creNewAppt : Form
    {
        FileService fs;
        CustomerDBService customerDBService;
        AppointmentDBService appointmentDBService;
        DatabaseManager dbManager;
        public creNewAppt()
        {
            fs = new FileService();
            dbManager = DatabaseManager.GetInstance(fs);
            customerDBService = new CustomerDBService(dbManager);
            appointmentDBService = new AppointmentDBService(dbManager);
            InitializeComponent();
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
            // Collecting the data from form controls
            string appointmentID = txtAppointmentID.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string customerID = GetFieldFromSelection("Email", cusDataView); //For now. Change later if you want.

            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string location = txtLocation.Text;

            // Validating the input
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
            loadCustomerData();
        }
    }
}
