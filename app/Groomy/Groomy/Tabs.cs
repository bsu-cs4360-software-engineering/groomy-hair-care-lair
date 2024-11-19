using Groomy.Appointments;
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
            apptDataView.DataSource = appointmentDBService.GetAppointmentDataTable();
            // To Do: Implement a way of acsessing the appointment data and put it in the dataview
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
            creNewAppt newApptForm = new creNewAppt(id);  // Pass nothing for now
            newApptForm.ShowDialog();  // Show the form
        }

        private void btnEditAppt_Click(object sender, EventArgs e)
        {
            //To-Do: Grab the appointment ID from the DataView and push it to the newApptForm. See above example
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // To-Do: Delete the selected appointment from the database
        }

        private void Tabs_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.BackColor = Color.FromArgb(21, 96, 130);  // Set the background color of the tab area

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;

            // Set the background color of the tab area
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                // Active (selected) tab
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new SolidBrush(Color.FromArgb(29, 129, 175)); // Active tab background color
                bshFore = Brushes.White; // Active tab font color (White)
            }
            else
            {
                // Inactive (unselected) tab
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.White); // Inactive tab background color (White)
                bshFore = Brushes.Black; // Inactive tab font color (Black)
            }

            // Get the name of the current tab
            string tabName = this.tabControl1.TabPages[e.Index].Text;

            // Create a StringFormat to center the text in the tab
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;

            // Fill the tab's background
            e.Graphics.FillRectangle(bshBack, e.Bounds);

            // Adjust the rectangle for the text position (optional: tweak margins if necessary)
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4); // Optional tweak for vertical alignment

            // Draw the tab's text
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

    }
}
