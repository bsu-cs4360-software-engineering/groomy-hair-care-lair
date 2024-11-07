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
        private CustomerDBService customerDBService;
        public Tabs()
        {
            InitializeComponent();
            CustomerDBService customerDBService;
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
        private void loadCustomerData()
        {
            dataGridView1.DataSource = customerDBService.GetCustomerDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void customersTab_Click(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            {
                string email = GetFieldFromSelection("Email", dataGridView1);

                if (!string.IsNullOrEmpty(email))
                {
                    // Retrieve the customer data
                    var editedCustomer = customerDBService.ReadCustomer(Helpers.GenerateSHA256Hash(email));

                    windowFx.OpenForm("Groomy.DialogBoxes.creNewCus", true);
                    creNewCus customerFields = new creNewCus();
                    customerFields.UpdateCustomerFields(editedCustomer);
                }
                else
                {
                    Helpers.messageBoxError("No customer selected. Please select a customer to edit.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            windowFx.OpenForm("Groomy.DialogBoxes.creNewCus", true);
        }
    }
}
