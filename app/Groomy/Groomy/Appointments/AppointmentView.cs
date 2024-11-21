using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Groomy.Utilities;

namespace Groomy.Appointments
{
    public partial class AppointmentView : Form
    {
        Dictionary<string, string> appointmentData;
        List<Dictionary<string, string>> appointmentNotes;
        Menu parentForm;
        Size panelSize = new Size(419, 308);
        Point panelLocation = new Point(327, 90);
        ManagerSingleton ms;
        public AppointmentView(Dictionary<string, string> appointmentData, Menu parentForm)
        {
            this.ms = ManagerSingleton.GetInstance();
            this.appointmentData = appointmentData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }

        public void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(778, 493);
            loadCustomers();

            txtTitle.Text = appointmentData["Title"];
            txtDescription.Text = appointmentData["Description"];
            timeAppointmentStart.Value = DateTime.Parse(appointmentData["StartTime"]);
            timeAppointmentEnd.Value = DateTime.Parse(appointmentData["EndTime"]);
            txtLocation.Text = appointmentData["Location"];
            fieldAppointmentID.Text = appointmentData["AppointmentID"];

            if (fieldAppointmentID.Text == "")
            {
                btnAppointmentEditSave_Click(sender, e);
            } 
            else
            {
                var customerID = ms.dbrs.GetCustomerIDFromAppointmentID(fieldAppointmentID.Text);
                var customerData = ms.cDBS.ReadCustomer(customerID);
                var customerName = (customerData["FirstName"], customerData["LastName"]);
                selectCustomerByName(customerName);
            }
        }
        private void loadAppointmentNotes()
        {
            this.appointmentNotes = new List<Dictionary<string, string>>();
            var appointmentNotesIDs = ms.dbrs.GetNotesIDFromAppointmentID(appointmentData["AppointmentID"]);

            foreach (var noteID in appointmentNotesIDs)
            {
                appointmentNotes.Add(ms.nDBS.ReadNotesData(noteID));
            }
            appointmentNotesDataGridView.DataSource = Helpers.ConvertToDataTable(appointmentNotes);
            if (appointmentNotesDataGridView.Columns.Count > 0)
            {
                appointmentNotesDataGridView.Columns["NoteID"].Visible = false;

                appointmentNotesDataGridView.Columns["CreateDate"].DisplayIndex = 0;
                appointmentNotesDataGridView.Columns["Title"].DisplayIndex = 1;
                appointmentNotesDataGridView.Columns["Payload"].DisplayIndex = 2;
            }
        }

        private void btnAppointmentEditSave_Click(object sender, EventArgs e)
        {
            if (btnAppointmentEditSave.Text == "Edit")
            {
                setAppointmentEditMode(true);
                btnAppointmentEditSave.Text = "Save";
            }
            else if (btnAppointmentEditSave.Text == "Save")
            {
                if (validateAppointmentForms())
                {
                    if (fieldAppointmentID.Text == "")
                    {
                        setsAppointmentNoteIDVisibility(false);
                        var newAppointment = new Appointment(txtTitle.Text, txtDescription.Text, timeAppointmentStart.Value, timeAppointmentEnd.Value, txtLocation.Text);
                        var selectedCustomer = ((string, string))comboCustomer.SelectedItem;
                        var customerID = ms.cDBS.GetCustomerIDByFirstLast(selectedCustomer);
                        ms.aDBS.CreateAppointment(newAppointment, customerID);
                    }
                    else
                    {
                        var editedAppointment = new Appointment(txtTitle.Text, txtDescription.Text, timeAppointmentStart.Value, timeAppointmentEnd.Value, txtLocation.Text, fieldAppointmentID.Text);
                        var customerID = ms.dbrs.GetCustomerIDFromAppointmentID(fieldAppointmentID.Text);
                        ms.aDBS.UpdateAppointmentData(editedAppointment, customerID);
                    }
                    setAppointmentEditMode(false);
                    btnAppointmentEditSave.Text = "Edit";
                }
            }
        }
        private void setAppointmentEditMode(bool isEditable)
        {
            comboCustomer.Enabled = isEditable;
            txtTitle.ReadOnly = !isEditable;
            txtDescription.ReadOnly = !isEditable;
            timeAppointmentStart.Enabled = isEditable;
            timeAppointmentEnd.Enabled = isEditable;
            txtLocation.ReadOnly = !isEditable;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.reloadData();
            this.Close();
        }
        private void loadNoteData(Dictionary<string, string> noteData)
        {
            txtNotesAppointmentTitle.Text = noteData["Title"];
            txtNotesAppointmentPayload.Text = noteData["Payload"];
            timeNotesAppointmentCreateDate.Value = Convert.ToDateTime(noteData["CreateDate"]);
            fieldNotesAppointmentNoteID.Text = noteData["NoteID"];
        }
        private void btnNotesAppointmentView_Click(object sender, EventArgs e)
        {
            setsAppointmentNoteIDVisibility(true);
            var noteID = Helpers.GetFieldFromSelection("NoteID", appointmentNotesDataGridView);
            if (noteID != null)
            {
                loadNoteData(ms.nDBS.ReadNotesData(noteID));
                Helpers.activatePanel(panelNotesAppointmentNewEdit, panelSize, panelLocation);
            }
            else
            {
                Helpers.messageBoxError("Please select a note to view.");
            }
        }
        private void btnAppointmentNotesBack_Click(object sender, EventArgs e)
        {
            loadAppointmentNotes();
            Helpers.activatePanel(panelNotesAppointmentAll, panelSize, panelLocation);
        }
        private void btnAppointmentNotesEditSave_Click(object sender, EventArgs e)
        {
            if (btnAppointmentNotesEditSave.Text == "Edit")
            {
                SetToggleNotesEditMode(true);
                btnAppointmentNotesEditSave.Text = "Save";
            }
            else if (btnAppointmentNotesEditSave.Text == "Save")
            {
                var editedNote = new Notes.Note(txtNotesAppointmentTitle.Text, txtNotesAppointmentPayload.Text, timeNotesAppointmentCreateDate.Text, fieldNotesAppointmentNoteID.Text);
                if (lblNotesAppointmentNoteID.Visible == false) //new note
                {
                    editedNote = new Notes.Note(txtNotesAppointmentTitle.Text, txtNotesAppointmentPayload.Text, timeNotesAppointmentCreateDate.Text);
                    ms.nDBS.CreateAppointmentNotes(editedNote, fieldAppointmentID.Text);
                }
                else //pre-existing note
                {
                    ms.nDBS.UpdateAppointmentNotesData(editedNote, fieldAppointmentID.Text);
                }
                SetToggleNotesEditMode(false);
                btnAppointmentNotesEditSave.Text = "Edit";
                loadAppointmentNotes();
            }
        }
        private void SetToggleNotesEditMode(bool isEditable)
        {
            txtNotesAppointmentTitle.ReadOnly = !isEditable;
            txtNotesAppointmentPayload.ReadOnly = !isEditable;
            timeNotesAppointmentCreateDate.Enabled = isEditable;
        }
        private void setAppointmentIDVisibility(bool isVisible)
        {
            fieldAppointmentID.Visible = isVisible;
            lblAppointmentID.Visible = isVisible;
        }
        private void setsAppointmentNoteIDVisibility(bool isVisible)
        {
            lblNotesAppointmentNoteID.Visible = isVisible;
            fieldNotesAppointmentNoteID.Visible = isVisible;
        }
        private void btnNotesAppointmentDelete_Click(object sender, EventArgs e)
        {
            var noteToDelete = Helpers.GetFieldFromSelection("NoteID", appointmentNotesDataGridView);
            if (noteToDelete != null)
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this note?"))
                {
                    ms.nDBS.DeleteAppointmentNotes(noteToDelete);
                    loadAppointmentNotes();
                }
            }
            else
            {
                Helpers.messageBoxError("Please select a note to delete.");

            }
        }
        private void clearNoteFields()
        {
            txtNotesAppointmentTitle.Text = "";
            txtNotesAppointmentPayload.Text = "";
            timeNotesAppointmentCreateDate.Value = DateTime.Now;
            setsAppointmentNoteIDVisibility(false);
        }
        private void btnNotesAppointmentNew_Click(object sender, EventArgs e)
        {
            clearNoteFields();
            btnAppointmentNotesEditSave_Click(sender, e);
            Helpers.activatePanel(panelNotesAppointmentNewEdit, panelSize, panelLocation);
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
            if (timeAppointmentStart.Value >= timeAppointmentEnd.Value)
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