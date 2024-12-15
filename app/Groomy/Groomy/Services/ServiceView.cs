using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy.Services
{
    public partial class ServiceView : Form
    {
        Dictionary<string, string> serviceData;
        List<Dictionary<string, string>> serviceNotes;
        Menu parentForm;
        Size panelSize = new Size(419, 308);
        Point panelLoc = new Point(327, 90);
        ManagerSingleton ms;
        public ServiceView(Dictionary<string, string> serviceData, Menu parentForm)
        {
            this.ms = ManagerSingleton.GetInstance();
            this.serviceData = serviceData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        public void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(778, 493);

            txtServiceName.Text = serviceData["ServiceName"];
            txtServiceDescription.Text = serviceData["ServiceDescription"];
            txtServicePrice.Text = serviceData["ServicePrice"];
            fieldServiceID.Text = serviceData["ServiceID"];

            if (fieldServiceID.Text == "")
            {
                btnServiceEditSave_Click(sender, e);
            }
            loadServiceNotes();
        }
        private void loadServiceNotes()
        {
            this.serviceNotes = new List<Dictionary<string, string>>();
            var serviceNotesIDs = ms.dbrs.GetNoteIDsFromServiceID(fieldServiceID.Text);

            foreach (var noteID in serviceNotesIDs)
            {
                serviceNotes.Add(ms.nDBS.ReadNotesData(noteID));
            }
            serviceNotesDataGridView.DataSource = Helpers.ConvertToDataTable(serviceNotes);
            if (serviceNotesDataGridView.Columns.Count > 0)
            {
                serviceNotesDataGridView.Columns["NoteID"].Visible = false;

                serviceNotesDataGridView.Columns["CreateDate"].DisplayIndex = 0;
                serviceNotesDataGridView.Columns["Title"].DisplayIndex = 1;
                serviceNotesDataGridView.Columns["Payload"].DisplayIndex = 2;
            }
        }
        private void btnServiceEditSave_Click(object sender, EventArgs e)
        {
            if (btnServiceEditSave.Text == "Edit")
            {
                setServiceEditMode(true);
                btnServiceEditSave.Text = "Save";
            }
            else if (btnServiceEditSave.Text == "Save")
            {
                if (validateServiceForms())
                {
                    if (fieldServiceID.Text == "")
                    {
                        setServiceNoteIDVisibility(false);
                        var newService = new Service(txtServiceName.Text, txtServiceDescription.Text, txtServicePrice.Text);
                        ms.sDBS.CreateService(newService);
                    }
                    else
                    {
                        var editedService = new Service(txtServiceName.Text, txtServiceDescription.Text, txtServicePrice.Text, fieldServiceID.Text);
                        ms.sDBS.UpdateServiceData(editedService);
                    }
                    setServiceEditMode(false);
                    btnServiceEditSave.Text = "Edit";
                }
            }
        }
        private void setServiceEditMode(bool isEditable)
        {
            txtServiceName.ReadOnly = !isEditable;
            txtServiceDescription.ReadOnly = !isEditable;
            txtServicePrice.ReadOnly = !isEditable;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.reloadData();
            this.Close();
        }
        private void loadNoteData(Dictionary<string, string> noteData)
        {
            txtNotesServiceTitle.Text = noteData["Title"];
            txtNotesServicePayload.Text = noteData["Payload"];
            timeNoteServiceCreateDate.Value = Convert.ToDateTime(noteData["CreateDate"]);
            fieldNotesServiceNoteID.Text = noteData["NoteID"];
        }

        private void btnNotesServiceView_Click(object sender, EventArgs e)
        {
            setServiceNoteIDVisibility(true);
            var noteID = Helpers.GetFieldFromSelection("NoteID", serviceNotesDataGridView);
            if (noteID != null)
            {
                loadNoteData(ms.nDBS.ReadNotesData(noteID));
                Helpers.activatePanel(panelNotesServiceNewEdit, panelSize, panelLoc);
            }
            else
            {
                Helpers.messageBoxError("No note selected. Please select a note.");
            }
        }
        private void btnServiceNotesBack_Click(object sender, EventArgs e)
        {
            loadServiceNotes();
            Helpers.activatePanel(panelNotesServiceAll, panelSize, panelLoc);
        }
        private void btnServiceNotesEditSave_Click(object sender, EventArgs e)
        {
            if (btnServiceNotesEditSave.Text == "Edit")
            {
                SetToggleNotesEditMode(true);
                btnServiceNotesEditSave.Text = "Save";
            }
            else if (btnServiceNotesEditSave.Text == "Save")
            {
                var editedNote = new Notes.Note(txtNotesServiceTitle.Text, txtNotesServicePayload.Text, timeNoteServiceCreateDate.Text, fieldNotesServiceNoteID.Text);
                if (lblNotesServiceNoteID.Visible == false) //new note
                {
                    editedNote = new Notes.Note(txtNotesServiceTitle.Text, txtNotesServicePayload.Text, timeNoteServiceCreateDate.Text);
                    ms.nDBS.CreateServiceNotes(editedNote, fieldServiceID.Text);
                }
                else //pre-existing note
                {
                    ms.nDBS.UpdateServiceNotesData(editedNote, fieldServiceID.Text);
                }
                SetToggleNotesEditMode(false);
                btnServiceNotesEditSave.Text = "Edit";
                loadServiceNotes();
            }
        }
        private void SetToggleNotesEditMode(bool isEditable)
        {
            txtNotesServiceTitle.ReadOnly = !isEditable;
            txtNotesServicePayload.ReadOnly = !isEditable;
            timeNoteServiceCreateDate.Enabled = isEditable;
        }
        private void setServiceIDVisibility(bool isVisible)
        {
            fieldServiceID.Visible = isVisible;
            lblServiceID.Visible = isVisible;
        }
        private void setServiceNoteIDVisibility(bool isVisible)
        {
            fieldNotesServiceNoteID.Visible = isVisible;
            lblNotesServiceNoteID.Visible = isVisible;
        }
        private void btnNotesServiceDelete_Click(object sender, EventArgs e)
        {
            var noteToDelete = Helpers.GetFieldFromSelection("NoteID", serviceNotesDataGridView);
            if (noteToDelete != null)
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this note?"))
                {
                    ms.nDBS.SoftDeleteServiceNotes(noteToDelete);
                    loadServiceNotes();
                }
            }
            else
            {
                Helpers.messageBoxError("No note selected. Please select a note.");
            }
        }
        private void clearNotesFields()
        {
            txtNotesServiceTitle.Text = "";
            txtNotesServicePayload.Text = "";
            timeNoteServiceCreateDate.Value = DateTime.Now;
            setServiceNoteIDVisibility(false);
        }
        private void btnNotesServiceNew_Click(object sender, EventArgs e)
        {
            clearNotesFields();
            btnServiceNotesEditSave_Click(sender, e);
            Helpers.activatePanel(panelNotesServiceNewEdit, panelSize, panelLoc);
        }
        private bool validateServiceForms()
        {
            if (txtServiceName.Text == "")
            {
                MessageBox.Show("Please enter a service name.");
                return false;
            }
            if (txtServiceDescription.Text == "")
            {
                MessageBox.Show("Please enter a service description.");
                return false;
            }
            if (txtServicePrice.Text == "")
            {
                MessageBox.Show("Please enter a service price.");
                return false;
            }
            return true;
        }
    }
}
