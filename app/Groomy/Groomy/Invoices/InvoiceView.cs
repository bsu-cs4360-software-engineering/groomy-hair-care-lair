using Groomy.Utilities;
using System.Data;

namespace Groomy.Invoices
{
    public partial class InvoiceView : Form
    {
        Dictionary<string, string> invoiceData;
        List<Dictionary<string, string>> invoiceNotes;
        List<Dictionary<string, string>> invoiceDetails;
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
            loadServices();

            setInvoiceEditMode(false);
            setDetailEditMode(false);
            SetNotesEditMode(false);

            //Load invoice data
            this.timeInvoiceCreateDate.Value = DateTime.Parse(invoiceData["CreateDate"]);
            this.timeInvoiceDueDate.Value = DateTime.Parse(invoiceData["DueDate"]);
            this.chkIsPaid.Checked = bool.Parse(invoiceData["IsPaid"]);
            fieldInvoiceID.Text = invoiceData["InvoiceID"];

            setInvoiceTotal();

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
            //Load invoice details
            loadInvoiceDetails();
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
                var servicePrice = float.Parse(serviceData["ServicePrice"]);
                invoiceSum += servicePrice * detailQuantity;
            }
            return invoiceSum;
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
        private void canPressInvoiceButtons(bool canPress)
        {
            btnInvoiceEditSave.Enabled = canPress;
        }
        private void canPressDetailsAllButtons(bool canPress)
        {
            btnNewInvoiceService.Enabled = canPress;
            btnViewInvoiceService.Enabled = canPress;
            btnDeleteInvoiceService.Enabled = canPress;

            btnInvoiceServicesBack.Enabled = canPress;
            btnInvoiceServiceEditSave.Enabled = canPress;
        }
        private void canPressNotesAllButtons(bool canPress)
        {
            btnNotesInvoiceNew.Enabled = canPress;
            btnNotesInvoiceView.Enabled = canPress;
            btnNotesInvoiceDelete.Enabled = canPress;

            btnInvoiceNotesBack.Enabled = canPress;
            btnInvoiceNotesEditSave.Enabled = canPress;
        }
        private void setInvoiceEditMode(bool isEditable)
        {
            comboCustomer.Enabled = isEditable;
            timeInvoiceCreateDate.Enabled = isEditable;
            timeInvoiceDueDate.Enabled = isEditable;
            chkIsPaid.Enabled = isEditable;

            // Disable/Enable the detail edit buttons
            canPressDetailsAllButtons(!isEditable);

            // Disable/Enable the notes edit buttons
            canPressNotesAllButtons(!isEditable);
        }
        private void setDetailEditMode(bool isEditable)
        {
            btnInvoiceServicesBack.Enabled = !isEditable;
            comboServices.Enabled = isEditable;
            txtQuantity.ReadOnly = !isEditable;

            // Disable/Enable the invoice edit buttons
            canPressInvoiceButtons(!isEditable);

            // Disable/Enable the notes edit buttons
            canPressNotesAllButtons(!isEditable);
        }


        private void SetNotesEditMode(bool isEditable)
        {
            txtNotesInvoiceTitle.ReadOnly = !isEditable;
            txtNotesInvoicePayload.ReadOnly = !isEditable;
            timeNoteInvoiceCreateDate.Enabled = isEditable;

            // Disable/Enable the invoice edit buttons
            canPressInvoiceButtons(!isEditable);

            // Disable/Enable the detail edit buttons
            canPressDetailsAllButtons(!isEditable);
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
        private void btnNotesInvoiceView_Click(object sender, EventArgs e)
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
            SetNotesEditMode(false);
            loadInvoiceNotes();
            Helpers.activatePanel(panelNotesInvoiceAll, panelSize, notesPanelLocation);
        }
        private void btnInvoiceNotesEditSave_Click(object sender, EventArgs e)
        {
            if (btnInvoiceNotesEditSave.Text == "Edit")
            {
                SetNotesEditMode(true);
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
                SetNotesEditMode(false);
                btnInvoiceNotesEditSave.Text = "Edit";
                loadInvoiceNotes();
            }
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

        private void btnNewInvoiceService_Click(object sender, EventArgs e)
        {
            clearDetailFields();
            btnInvoiceDetailEditSave_Click(sender, e);
            Helpers.activatePanel(panelServiceInvoiceNewEdit, panelSize, servicePanelLoc);
        }

        private void btnDeleteInvoiceService_Click(object sender, EventArgs e)
        {
            var detailToDelete = Helpers.GetFieldFromSelection("DetailID", invoiceDetailsDatagridview);
            if (detailToDelete != null)
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this service?"))
                {
                    ms.iDBS.SoftDeleteDetail(detailToDelete);
                    loadInvoiceDetails();
                }
            }
            else
            {
                Helpers.messageBoxError("Please select a service to delete.");
            }
        }
        private void clearDetailFields()
        {
            txtQuantity.Text = "";
            txtInvoiceTotal.Text = "";
            txtServiceTotal.Text = "";
            setDetailIdVisibility(false);
        }
        private void setDetailIdVisibility(bool isVisible)
        {
            lblDetailID.Visible = isVisible;
            fieldDetailID.Visible = isVisible;
        }

        private void btnInvoiceDetailEditSave_Click(object sender, EventArgs e)
        {
            if (btnInvoiceServiceEditSave.Text == "Edit")
            {
                setDetailEditMode(true);
                btnInvoiceServiceEditSave.Text = "Save";
            }
            else if (btnInvoiceServiceEditSave.Text == "Save")
            {
                var invoiceID = fieldInvoiceID.Text;
                if (validateInvoiceDetail())
                {
                    var selectedService = ((string, string))comboServices.SelectedItem;
                    var serviceID = ms.sDBS.GetServiceIDByName(selectedService.Item1);
                    var editedDetail = new InvoiceDetail(serviceID, int.Parse(txtQuantity.Text), fieldDetailID.Text);
                    //If new detail
                    if (lblDetailID.Visible == false)
                    {
                        var newDetail = new InvoiceDetail(serviceID, int.Parse(txtQuantity.Text));
                        ms.iDBS.CreateDetail(newDetail, invoiceID);
                    }
                    //If existing detail
                    else
                    { 
                        ms.iDBS.UpdateDetailData(editedDetail, invoiceID);
                    }
                    setDetailEditMode(false);
                    btnInvoiceServiceEditSave.Text = "Edit";
                    setInvoiceTotal();
                    loadInvoiceDetails();
                }
                loadInvoiceDetails();
            }
        }
        private void setInvoiceDetaiIlDVisibility(bool isVisible)
        {
            lblDetailID.Visible = isVisible;
            fieldDetailID.Visible = isVisible;
        }
        private bool validateInvoiceDetail()
        {
            if (comboCustomer.SelectedIndex == -1)
            {
                Helpers.messageBoxError("Please select a customer.");
                return false;
            }
            if (txtQuantity.Text == "")
            {
                Helpers.messageBoxError("Please enter a quantity.");
                return false;
            }
            return true;
        }
        private void loadInvoiceDetails()
        {
            //include Service name from detail , quantity from detail
            this.invoiceDetails = new List<Dictionary<string, string>>();

            var specialDetailData = new List<Dictionary<string,string>>();

            var invoiceDetailIDs = ms.dbrs.GetForeignIDsFromPrimaryID(invoiceData["InvoiceID"], "invoices_details.json");
            foreach (var detailID in invoiceDetailIDs)
            {
                var serviceID = ms.iDBS.ReadDetailData(detailID)["ServiceID"];
                var serviceData = ms.sDBS.ReadServiceData(serviceID);
                var detailData = ms.iDBS.ReadDetailData(detailID);

                detailData["ServiceName"] = serviceData["ServiceName"];
                detailData["Total"] = calculateDetailTotal(detailID).ToString("C2");
                specialDetailData.Add(detailData);
            }
            invoiceDetailsDatagridview.DataSource = Helpers.ConvertToDataTable(specialDetailData);
            if (invoiceDetailsDatagridview.Columns.Count > 0)
            {
                invoiceDetailsDatagridview.Columns["DetailID"].Visible = false;
                invoiceDetailsDatagridview.Columns["ServiceID"].Visible = false;

                invoiceDetailsDatagridview.Columns["ServiceName"].DisplayIndex = 0;
                invoiceDetailsDatagridview.Columns["Quantity"].DisplayIndex = 1;
                invoiceDetailsDatagridview.Columns["Total"].DisplayIndex = 2;
                invoiceDetailsDatagridview.Columns["Total"].DefaultCellStyle.Format = "C2";
                invoiceDetailsDatagridview.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Optional: Align right

            }
        }
        
        private void btnInvoiceServicesBack_Click(object sender, EventArgs e)
        {
            loadInvoiceDetails();
            setDetailEditMode(false);
            Helpers.activatePanel(panelServicesInvoiceAll, panelSize, servicePanelLoc);
        }

        private void btnViewInvoiceDetail_Click(object sender, EventArgs e)
        {
            setInvoiceDetaiIlDVisibility(true);

            var detailID = Helpers.GetFieldFromSelection("DetailID", invoiceDetailsDatagridview);
            if (detailID != null)
            {
                loadDetailData(ms.iDBS.ReadDetailData(detailID));
                Helpers.activatePanel(panelServiceInvoiceNewEdit, panelSize, servicePanelLoc);
            }
            else
            {
                Helpers.messageBoxError("Please select a service to view.");
            }
        }
        private void loadDetailData(Dictionary<string, string> detailData)
        {
            var detailService = ms.sDBS.ReadServiceData(detailData["ServiceID"]);

            var servicePrice = float.Parse(detailService["ServicePrice"]);
            selectServiceByName(detailService["ServiceName"]);
            txtQuantity.Text = detailData["Quantity"];
            fieldDetailID.Text = detailData["DetailID"];

            if (detailService != null)
            {
                txtServiceTotal.Text = calculateDetailTotal(detailData["DetailID"]).ToString("C");
            }
        }
        private void selectServiceByName(string serviceName)
        {
            loadServices();
            for (int i = 0; i < comboServices.Items.Count; i++)
            {
                var item = ((string, string))comboServices.Items[i];
                if (item.Item1 == serviceName)
                {
                    comboServices.SelectedIndex = i;
                    break;
                }
            }
        }
        private float calculateDetailTotalFromQuantityAndServicePrice(int detailQuantity, float servicePrice)
        {
            return servicePrice * detailQuantity;
        }
        private float calculateDetailTotal(string detailID)
        {
            var detailData = ms.iDBS.ReadDetailData(detailID);

            if (detailData == null)
            {
                return 0.0f;
            }
            var detailQuantity = int.Parse(detailData["Quantity"]);
            var serviceID = detailData["ServiceID"];
            var serviceData = ms.sDBS.ReadServiceData(serviceID);
            var servicePrice = float.Parse(serviceData["ServicePrice"]);
            return servicePrice * detailQuantity;
        }
        private void loadServices()
        {
            var services = ms.sDBS.GetServices();

            comboServices.DataSource = services
                .Where(s => s != null && s.ContainsKey("ServiceName"))
                .Select(s => (s["ServiceName"], s["ServicePrice"]))
                .ToList();
        }

        private void setDetailTotal(object sender, EventArgs e)
        {
            txtServiceTotal.Text = calculateDetailTotal(fieldDetailID.Text).ToString("C");
        }
        private void otfQuantity_TextChanged(object sender, EventArgs e)
        {
            var detailData = ms.iDBS.ReadDetailData(fieldDetailID.Text);
            if (detailData != null)
            {
                var detailQuantity = 0;
                if (!string.IsNullOrEmpty(txtQuantity.Text))
                {
                    detailQuantity = int.Parse(txtQuantity.Text);
                }

                var servicePrice = 0.0f;
                var selectedService = ((string, string))comboServices.SelectedItem;
                if (!string.IsNullOrEmpty(selectedService.Item2))
                {
                    servicePrice = float.Parse(selectedService.Item2);
                }
                txtServiceTotal.Text = calculateDetailTotalFromQuantityAndServicePrice(detailQuantity, servicePrice).ToString("C");
            }
        }
        private void setInvoiceTotal()
        {
            txtInvoiceTotal.Text = calculateInvoiceTotal(fieldInvoiceID.Text).ToString("C");
        }
    }
}
