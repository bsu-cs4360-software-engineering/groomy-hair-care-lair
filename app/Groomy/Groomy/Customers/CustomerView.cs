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

namespace Groomy.Customers
{
    public partial class CustomerView : Form
    {
        Dictionary<string, string> customerData;
        List<Dictionary<string, string>> customerNotes;
        Menu parentForm;
        Size panelSize = new Size(419, 308);
        Point panelLocation = new Point(327, 90);

        ManagerSingleton ms;
        public CustomerView(Dictionary<string, string> customerData, Menu parentForm)
        {
            ms = ManagerSingleton.GetInstance();
            this.customerData = customerData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }

        public void loadCustomerNotes()
        {
            this.customerNotes = new List<Dictionary<string, string>>();
            var customerNotesIDs = ms.dbrs.GetNotesIDFromCustomerID(customerData["CustomerID"]);

            foreach (var noteID in customerNotesIDs)
            {
                customerNotes.Add(ms.nDBS.ReadNotesData(noteID));
            }
            customerNotesDataGridView.DataSource = Helpers.ConvertToDataTable(customerNotes);
            if (customerNotesDataGridView.Columns.Count > 0)
            {
                customerNotesDataGridView.Columns["NoteID"].Visible = false;

                customerNotesDataGridView.Columns["CreateDate"].DisplayIndex = 0;
                customerNotesDataGridView.Columns["Title"].DisplayIndex = 1;
                customerNotesDataGridView.Columns["Payload"].DisplayIndex = 2;
            }
        }
        public void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(778, 493);
            txtFirst.Text = customerData["FirstName"];
            txtLast.Text = customerData["LastName"];
            txtPN.Text = customerData["PhoneNumber"];
            txtEmail.Text = customerData["Email"];
            txtAddress.Text = customerData["Address"];
            fieldCustomerID.Text = customerData["CustomerID"];
            loadCustomerNotes();
            Helpers.activatePanel(panelNotesCustomerAll, panelSize, panelLocation);
        }

        private void btnCustomerEditSave_Click(object sender, EventArgs e)
        {
            if (btnCustomerEditSave.Text == "Edit")
            {
                ToggleCustomerEditMode(true);
                btnCustomerEditSave.Text = "Save";
            }
            else if (btnCustomerEditSave.Text == "Save")
            {
                var editedCustomer = new Customer(txtFirst.Text, txtLast.Text, txtEmail.Text, txtPN.Text, txtAddress.Text, fieldCustomerID.Text);
                ms.cDBS.UpdateCustomerData(editedCustomer);
                ToggleCustomerEditMode(false);
                btnCustomerEditSave.Text = "Edit";
            }
        }
        private void ToggleCustomerEditMode(bool isEditable)
        {
            txtFirst.ReadOnly = !isEditable;
            txtLast.ReadOnly = !isEditable;
            txtPN.ReadOnly = !isEditable;
            txtEmail.ReadOnly = !isEditable;
            txtAddress.ReadOnly = !isEditable;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.reloadData();
            this.Close();

        }
        private void loadNoteData(Dictionary<string, string> noteData)
        {
            txtNotesCustomerTitle.Text = noteData["Title"];
            txtNotesCustomerPayload.Text = noteData["Payload"];
            timeNotesCustomersCreateDate.Value = Convert.ToDateTime(noteData["CreateDate"]);
            fieldNotesCustomersNoteID.Text = noteData["NoteID"];
        }
        private void btnNotesCustomerView_Click(object sender, EventArgs e)
        {
            var noteID = Helpers.GetFieldFromSelection("NoteID", customerNotesDataGridView);
            if (noteID != null)
            {
                loadNoteData(ms.nDBS.ReadNotesData(noteID));
                Helpers.activatePanel(panelNotesCustomerNewEdit, panelSize, panelLocation);
            }
            else
            {
                Helpers.messageBoxError("Please select a note to view.");
            }
        }
        private void btnCustomerNotesBack_Click(object sender, EventArgs e)
        {
            loadCustomerNotes();
            Helpers.activatePanel(panelNotesCustomerAll, panelSize, panelLocation);
        }

        private void btnCustomerNotesEditSave_Click(object sender, EventArgs e)
        {
            if (btnCustomerNotesEditSave.Text == "Edit")
            {
                ToggleNotesEditMode(true);
                btnCustomerNotesEditSave.Text = "Save";
            }
            else if (btnCustomerNotesEditSave.Text == "Save")
            {
                var editedNote = new Notes.Notes(txtNotesCustomerTitle.Text, txtNotesCustomerPayload.Text, timeNotesCustomersCreateDate.Text, fieldNotesCustomersNoteID.Text);
                ms.nDBS.UpdateCustomerNotesData(editedNote, fieldCustomerID.Text);
                ToggleNotesEditMode(false);
                btnCustomerNotesEditSave.Text = "Edit";
            }
        }

        private void ToggleNotesEditMode(bool isEditable)
        {
            txtNotesCustomerTitle.ReadOnly = !isEditable;
            txtNotesCustomerPayload.ReadOnly = !isEditable;
            timeNotesCustomersCreateDate.Enabled = isEditable;
        }

        private void btnNotesCustomerDelete_Click(object sender, EventArgs e)
        {
            var noteToDelete = Helpers.GetFieldFromSelection("NoteID", customerNotesDataGridView);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this note?"))
            {
                ms.nDBS.SoftDeleteCustomerNotes(noteToDelete);
                loadCustomerNotes();
            }
        }
    }
}
