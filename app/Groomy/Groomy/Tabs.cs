using Groomy.Customers;
using Groomy.DialogBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy
{
    public partial class Tabs : Form
    {
        FileService fs;
        CustomerDBService customerDBService;
        AppointmentDBService appointmentDBService;
        DatabaseManager dbManager;
        public Tabs()
        {
            fs = new FileService();
            dbManager = DatabaseManager.GetInstance(fs);
            customerDBService = new CustomerDBService(dbManager);
            appointmentDBService = new AppointmentDBService(dbManager);
            InitializeComponent();
        }
        public string pubEmail = "No Email";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var email = GetFieldFromSelection("Email", cusDataView);

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string email = GetFieldFromSelection("Email", cusDataView);

            if (!string.IsNullOrEmpty(email))
            {
                creNewCus editCustomerForm = new creNewCus(email); // Pass email here
                editCustomerForm.ShowDialog();
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to edit.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = "No Email";  // Define the email as "No Email"
            creNewCus newCustomerForm = new creNewCus(email);  // Pass the email to the form
            newCustomerForm.ShowDialog();  // Show the form
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void btnNewAppt_Click(object sender, EventArgs e)
        {
            string id = "No ID";  // Define the id as "No ID". Ignored for now
            creNewAppt newApptForm = new creNewAppt();  // Pass nothing for now
            newApptForm.ShowDialog();  // Show the form
        }

        private void btnEditAppt_Click(object sender, EventArgs e)
        {
            //To-Do
        }

        
    }
}
