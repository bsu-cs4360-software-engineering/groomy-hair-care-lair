using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy.Invoices
{
    public partial class InvoiceView : Form
    {
        Dictionary<string, string> invoiceData;
        List<Dictionary<string, string>> invoiceNotes;
        Menu parentForm;
        Size panelSize = new Size(319, 308);
        Point servicePanelLoc = new Point(326, 93);
        Point notesPanelLocation = new Point(651, 93);
        ManagerSingleton ms;
        public InvoiceView(Dictionary<string, string> invoiceData, Menu parentForm)
        {
            this.ms = ManagerSingleton.GetInstance();
            this.invoiceData = invoiceData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        public void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(988, 493);
            loadCustomers();

            //Load invoice data
            this.timeInvoiceCreateDate.Value = DateTime.Parse(invoiceData["CreateDate"]);
            this.timeInvoiceDueDate.Value = DateTime.Parse(invoiceData["DueDate"]);
            this.chkIsPaid.Checked = bool.Parse(invoiceData["IsPaid"]);
            fieldInvoiceID.Text = invoiceData["InvoiceID"];

            var invoiceTotal = calculateInvoiceTotal(invoiceData["InvoiceID"]);
            this.txtTotal.Text = invoiceTotal.ToString();

            //If invoice not attached to customer (new invoice)
            if (fieldInvoiceID.Text == "")
            {
                btnInvoiceEditSave_Click(sender, e);
            }
            //If invoice is attached to customer
            else
            {
                //Load customer data
                var customerID = ms.dbrs.GetPrimaryIDFromForeignID(fieldInvoiceID.Text, "customers_invoices.json");

                var customerData = ms.cDBS.ReadCustomer(customerID);
                var customerName = (customerData["FirstName"], customerData["LastName"]);
                //select customer in combo box
                selectCustomerByName(customerName);
            }
            //Load invoice notes
            loadInvoiceNotes();
        }

        private float calculateInvoiceTotal(string invoiceID)
        {
            var invoiceDetailIDs = ms.dbrs.GetForeignIDsFromPrimaryID(invoiceID, "invoices_details.json");
            var invoiceSum = 0.0f;
            foreach (var detailID in invoiceDetailIDs)
            {
                var detailData = ms.iDBS.ReadDetailData(detailID);
                var detailQuantity = int.Parse(detailData["Quantity"]);

                var serviceID = detailData["ServiceID"];
                var serviceData = ms.sDBS.ReadServiceData(detailData["ServiceID"]);
                var servicePrice = float.Parse(serviceData["Price"]);
                invoiceSum += servicePrice * detailQuantity;
            }
            return 0.0f;
        }

        private void loadInvoiceNotes()
        {
            this.invoiceNotes = new List<Dictionary<string, string>>();

            var invoiceNoteIDs = ms.dbrs.GetForeignIDsFromPrimaryID(invoiceData["InvoiceID"], "invoices_notes.json");

            foreach (var noteID in invoiceNoteIDs)
            {
                invoiceNotes.Add(ms.nDBS.ReadNotesData(noteID));
            }
            invoiceNotesDataGridView.DataSource = Helpers.ConvertToDataTable(invoiceNotes);
            if (invoiceNotesDataGridView.Columns.Count > 0)
            {
                invoiceNotesDataGridView.Columns["CreateDate"].DisplayIndex = 0;
                invoiceNotesDataGridView.Columns["Title"].DisplayIndex = 1;
                invoiceNotesDataGridView.Columns["Payload"].DisplayIndex = 2;
            }
        }

        private void btnInvoiceServicesBack_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoiceEditSave_Click(object sender, EventArgs e)
        {
            if (btnInvoiceEditSave.Text == "Edit")
            {
                setInvoiceEditMode(true);
                btnInvoiceEditSave.Text = "Save";
            }
            else if (btnInvoiceEditSave.Text == "Save")
            {
                //If new invoice
                if (fieldInvoiceID.Text == "")
                {
                    setInvoiceNotesIdVisibility(false);
                    var selectedCustomer = ((string, string))comboCustomer.SelectedItem;
                    var newInvoiceCustomerID = ms.cDBS.GetCustomerIDByFirstLast(selectedCustomer);
                    var newInvoice = new Invoice(newInvoiceCustomerID, timeInvoiceCreateDate.Value, timeInvoiceDueDate.Value, chkIsPaid.Checked);
                    ms.iDBS.CreateInvoice(newInvoice, newInvoiceCustomerID);
                }
                //If existing invoice
                else
                {
                    var customerID = ms.dbrs.GetPrimaryIDFromForeignID(fieldInvoiceID.Text, "customers_invoices.json");
                    var editedInvoice = new Invoice(customerID, timeInvoiceCreateDate.Value, timeInvoiceDueDate.Value, chkIsPaid.Checked, fieldInvoiceID.Text);
                    ms.iDBS.UpdateInvoiceData(editedInvoice, customerID);
                }
                setInvoiceEditMode(false);
                btnInvoiceEditSave.Text = "Edit";
            }
        }
        private void setInvoiceEditMode(bool isEditable)
        {
            comboCustomer.Enabled = isEditable;
            timeInvoiceCreateDate.Enabled = isEditable;
            timeInvoiceDueDate.Enabled = isEditable;
            chkIsPaid.Enabled = isEditable;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.reloadData();
            this.Close();
        }
        private void loadNoteData(Dictionary<string, string> noteData)
        {
            txtNotesInvoiceTitle.Text = noteData["Title"];
            txtNotesInvoicePayload.Text = noteData["Payload"];
            timeNoteInvoiceCreateDate.Value = DateTime.Parse(noteData["CreateDate"]);
            fieldNotesInvoiceNoteID.Text = noteData["NoteID"];
        }
        private void btnNotesServiceView_Click(object sender, EventArgs e)
        {
            setInvoiceNotesIdVisibility(true);
            var noteID = Helpers.GetFieldFromSelection("NoteID", invoiceNotesDataGridView);
            //If note is selected
            if (noteID != null)
            {
                loadNoteData(ms.nDBS.ReadNotesData(noteID));
                Helpers.activatePanel(panelNotesServiceNewEdit, panelSize, notesPanelLocation);
            }
            //If note is not selected
            else
            {
                Helpers.messageBoxError("Please select a note to view.");
            }

        }
        private void btnInvoiceNotesBack_Click(object sender, EventArgs e)
        {
            loadInvoiceNotes();
            Helpers.activatePanel(panelNotesInvoiceAll, panelSize, notesPanelLocation);
        }
        private void btnInvoiceNotesEditSave_Click(object sender, EventArgs e)
        {
            if (btnInvoiceNotesEditSave.Text == "Edit")
            {
                SetToggleNotesEditMode(true);
                btnInvoiceNotesEditSave.Text = "Save";
            }
            else if (btnInvoiceNotesEditSave.Text == "Save")
            {
                var editedNote = new Notes.Note(txtNotesInvoiceTitle.Text, txtNotesInvoicePayload.Text, timeNoteInvoiceCreateDate.Text, fieldNotesInvoiceNoteID.Text);
                //if new note
                if (lblNotesInvoiceNoteID.Visible == false)
                {
                    editedNote = new Notes.Note(txtNotesInvoiceTitle.Text, txtNotesInvoicePayload.Text, timeNoteInvoiceCreateDate.Text);
                    ms.nDBS.CreateInvoiceNotes(editedNote, fieldInvoiceID.Text);
                }
                //if existing note
                else
                {
                    ms.nDBS.UpdateNotesData(editedNote, fieldInvoiceID.Text);
                }
                SetToggleNotesEditMode(false);
                btnInvoiceNotesEditSave.Text = "Edit";
                loadInvoiceNotes();
            }
        }
        private void SetToggleNotesEditMode(bool isEditable)
        {
            txtNotesInvoiceTitle.ReadOnly = !isEditable;
            txtNotesInvoicePayload.ReadOnly = !isEditable;
            timeNoteInvoiceCreateDate.Enabled = isEditable;
        }
        private void setInvoiceNotesIdVisibility(bool isVisible)
        {
            lblNotesInvoiceNoteID.Visible = isVisible;
            fieldNotesInvoiceNoteID.Visible = isVisible;
        }
        private void btnNotesServiceDelete_Click(object sender, EventArgs e)
        {
            var noteToDelete = Helpers.GetFieldFromSelection("NoteID", invoiceNotesDataGridView);
            if (noteToDelete != null)
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this note?"))
                {
                    ms.nDBS.SoftDeleteInvoiceNotes(noteToDelete);
                    loadInvoiceNotes();
                }
            }
            else
            {
                Helpers.messageBoxError("Please select a note to delete.");
            }
        }
        private void clearNotesFields()
        {
            txtNotesInvoiceTitle.Text = "";
            txtNotesInvoicePayload.Text = "";
            timeNoteInvoiceCreateDate.Value = DateTime.Now;
            setInvoiceNotesIdVisibility(false);
        }
        private void btnNotesServiceNew_Click(object sender, EventArgs e)
        {
            clearNotesFields();
            btnInvoiceNotesEditSave_Click(sender, e);
            Helpers.activatePanel(panelNotesServiceNewEdit, panelSize, notesPanelLocation);
        }
        private void loadCustomers()
        {
            var customers = ms.cDBS.GetCustomers();
            comboCustomer.DataSource = customers
                .Where(c => c != null && c.ContainsKey("FirstName") && c.ContainsKey("LastName"))
                .Select(c => (c["FirstName"], c["LastName"]))
                .ToList();
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
    }
}
