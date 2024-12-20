﻿namespace Groomy.Invoices
{
    partial class InvoiceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelNotesInvoiceAll = new Panel();
            btnNotesInvoiceDelete = new Button();
            btnNotesInvoiceView = new Button();
            btnNotesInvoiceNew = new Button();
            invoiceNotesDataGridView = new DataGridView();
            lblNotes = new Label();
            btnInvoiceEditSave = new Button();
            btnBack = new Button();
            panelNotesServiceNewEdit = new Panel();
            fieldNotesInvoiceNoteID = new Label();
            lblNotesInvoiceNoteID = new Label();
            timeNoteInvoiceCreateDate = new DateTimePicker();
            btnInvoiceNotesEditSave = new Button();
            btnInvoiceNotesBack = new Button();
            lblNotesInvoiceCreateDate = new Label();
            txtNotesInvoicePayload = new TextBox();
            lblNotesInvoicePayload = new Label();
            txtNotesInvoiceTitle = new TextBox();
            lblNotesInvoiceTitle = new Label();
            lblGroomyInvoice = new Label();
            fieldInvoiceID = new Label();
            lblInvoiceID = new Label();
            panelServicesInvoiceAll = new Panel();
            btnDeleteInvoiceService = new Button();
            btnViewInvoiceService = new Button();
            btnNewInvoiceService = new Button();
            invoiceDetailsDatagridview = new DataGridView();
            lblIServices = new Label();
            comboCustomer = new ComboBox();
            lblCustomer = new Label();
            lblInvoiceDueDate = new Label();
            lblCreateDate = new Label();
            timeInvoiceCreateDate = new DateTimePicker();
            timeInvoiceDueDate = new DateTimePicker();
            chkIsPaid = new CheckBox();
            lblTotal = new Label();
            txtInvoiceTotal = new TextBox();
            btnInvoiceServicesBack = new Button();
            btnInvoiceDetailEditSave = new Button();
            lblDetailID = new Label();
            fieldDetailID = new Label();
            lblServiceMulti = new Label();
            comboServices = new ComboBox();
            panelServiceInvoiceNewEdit = new Panel();
            txtServiceTotal = new TextBox();
            lblServiceTotal = new Label();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            panelNotesInvoiceAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceNotesDataGridView).BeginInit();
            panelNotesServiceNewEdit.SuspendLayout();
            panelServicesInvoiceAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceDetailsDatagridview).BeginInit();
            panelServiceInvoiceNewEdit.SuspendLayout();
            SuspendLayout();
            // 
            // panelNotesInvoiceAll
            // 
            panelNotesInvoiceAll.Controls.Add(btnNotesInvoiceDelete);
            panelNotesInvoiceAll.Controls.Add(btnNotesInvoiceView);
            panelNotesInvoiceAll.Controls.Add(btnNotesInvoiceNew);
            panelNotesInvoiceAll.Controls.Add(invoiceNotesDataGridView);
            panelNotesInvoiceAll.Controls.Add(lblNotes);
            panelNotesInvoiceAll.Location = new Point(651, 93);
            panelNotesInvoiceAll.Name = "panelNotesInvoiceAll";
            panelNotesInvoiceAll.Size = new Size(319, 308);
            panelNotesInvoiceAll.TabIndex = 108;
            // 
            // btnNotesInvoiceDelete
            // 
            btnNotesInvoiceDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesInvoiceDelete.ForeColor = Color.White;
            btnNotesInvoiceDelete.Location = new Point(211, 37);
            btnNotesInvoiceDelete.Name = "btnNotesInvoiceDelete";
            btnNotesInvoiceDelete.Size = new Size(87, 23);
            btnNotesInvoiceDelete.TabIndex = 77;
            btnNotesInvoiceDelete.Text = "Delete";
            btnNotesInvoiceDelete.UseVisualStyleBackColor = false;
            btnNotesInvoiceDelete.Click += btnNotesServiceDelete_Click;
            // 
            // btnNotesInvoiceView
            // 
            btnNotesInvoiceView.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesInvoiceView.ForeColor = Color.White;
            btnNotesInvoiceView.Location = new Point(118, 37);
            btnNotesInvoiceView.Name = "btnNotesInvoiceView";
            btnNotesInvoiceView.Size = new Size(87, 23);
            btnNotesInvoiceView.TabIndex = 76;
            btnNotesInvoiceView.Text = "View";
            btnNotesInvoiceView.UseVisualStyleBackColor = false;
            btnNotesInvoiceView.Click += btnNotesInvoiceView_Click;
            // 
            // btnNotesInvoiceNew
            // 
            btnNotesInvoiceNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesInvoiceNew.ForeColor = Color.White;
            btnNotesInvoiceNew.Location = new Point(25, 37);
            btnNotesInvoiceNew.Name = "btnNotesInvoiceNew";
            btnNotesInvoiceNew.Size = new Size(87, 23);
            btnNotesInvoiceNew.TabIndex = 74;
            btnNotesInvoiceNew.Text = "New";
            btnNotesInvoiceNew.UseVisualStyleBackColor = false;
            btnNotesInvoiceNew.Click += btnNotesServiceNew_Click;
            // 
            // invoiceNotesDataGridView
            // 
            invoiceNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            invoiceNotesDataGridView.Location = new Point(9, 66);
            invoiceNotesDataGridView.Name = "invoiceNotesDataGridView";
            invoiceNotesDataGridView.Size = new Size(307, 221);
            invoiceNotesDataGridView.TabIndex = 73;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            lblNotes.ForeColor = Color.FromArgb(21, 96, 130);
            lblNotes.Location = new Point(118, 4);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(93, 33);
            lblNotes.TabIndex = 72;
            lblNotes.Text = "Notes";
            lblNotes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInvoiceEditSave
            // 
            btnInvoiceEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceEditSave.ForeColor = Color.White;
            btnInvoiceEditSave.Location = new Point(178, 93);
            btnInvoiceEditSave.Name = "btnInvoiceEditSave";
            btnInvoiceEditSave.Size = new Size(103, 23);
            btnInvoiceEditSave.TabIndex = 107;
            btnInvoiceEditSave.Text = "Edit";
            btnInvoiceEditSave.UseVisualStyleBackColor = false;
            btnInvoiceEditSave.Click += btnInvoiceEditSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(69, 93);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 106;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelNotesServiceNewEdit
            // 
            panelNotesServiceNewEdit.Controls.Add(fieldNotesInvoiceNoteID);
            panelNotesServiceNewEdit.Controls.Add(lblNotesInvoiceNoteID);
            panelNotesServiceNewEdit.Controls.Add(timeNoteInvoiceCreateDate);
            panelNotesServiceNewEdit.Controls.Add(btnInvoiceNotesEditSave);
            panelNotesServiceNewEdit.Controls.Add(btnInvoiceNotesBack);
            panelNotesServiceNewEdit.Controls.Add(lblNotesInvoiceCreateDate);
            panelNotesServiceNewEdit.Controls.Add(txtNotesInvoicePayload);
            panelNotesServiceNewEdit.Controls.Add(lblNotesInvoicePayload);
            panelNotesServiceNewEdit.Controls.Add(txtNotesInvoiceTitle);
            panelNotesServiceNewEdit.Controls.Add(lblNotesInvoiceTitle);
            panelNotesServiceNewEdit.Location = new Point(1301, 93);
            panelNotesServiceNewEdit.Name = "panelNotesServiceNewEdit";
            panelNotesServiceNewEdit.Size = new Size(319, 308);
            panelNotesServiceNewEdit.TabIndex = 105;
            // 
            // fieldNotesInvoiceNoteID
            // 
            fieldNotesInvoiceNoteID.AutoSize = true;
            fieldNotesInvoiceNoteID.Location = new Point(44, 269);
            fieldNotesInvoiceNoteID.Name = "fieldNotesInvoiceNoteID";
            fieldNotesInvoiceNoteID.Size = new Size(42, 15);
            fieldNotesInvoiceNoteID.TabIndex = 81;
            fieldNotesInvoiceNoteID.Text = "noteID";
            // 
            // lblNotesInvoiceNoteID
            // 
            lblNotesInvoiceNoteID.AutoSize = true;
            lblNotesInvoiceNoteID.Location = new Point(42, 254);
            lblNotesInvoiceNoteID.Name = "lblNotesInvoiceNoteID";
            lblNotesInvoiceNoteID.Size = new Size(50, 15);
            lblNotesInvoiceNoteID.TabIndex = 80;
            lblNotesInvoiceNoteID.Text = "Note ID:";
            // 
            // timeNoteInvoiceCreateDate
            // 
            timeNoteInvoiceCreateDate.Enabled = false;
            timeNoteInvoiceCreateDate.Format = DateTimePickerFormat.Time;
            timeNoteInvoiceCreateDate.Location = new Point(42, 75);
            timeNoteInvoiceCreateDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeNoteInvoiceCreateDate.Name = "timeNoteInvoiceCreateDate";
            timeNoteInvoiceCreateDate.Size = new Size(247, 23);
            timeNoteInvoiceCreateDate.TabIndex = 79;
            // 
            // btnInvoiceNotesEditSave
            // 
            btnInvoiceNotesEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceNotesEditSave.ForeColor = Color.White;
            btnInvoiceNotesEditSave.Location = new Point(176, 30);
            btnInvoiceNotesEditSave.Name = "btnInvoiceNotesEditSave";
            btnInvoiceNotesEditSave.Size = new Size(113, 23);
            btnInvoiceNotesEditSave.TabIndex = 75;
            btnInvoiceNotesEditSave.Text = "Edit";
            btnInvoiceNotesEditSave.UseVisualStyleBackColor = false;
            btnInvoiceNotesEditSave.Click += btnInvoiceNotesEditSave_Click;
            // 
            // btnInvoiceNotesBack
            // 
            btnInvoiceNotesBack.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceNotesBack.ForeColor = Color.White;
            btnInvoiceNotesBack.Location = new Point(42, 30);
            btnInvoiceNotesBack.Name = "btnInvoiceNotesBack";
            btnInvoiceNotesBack.Size = new Size(113, 23);
            btnInvoiceNotesBack.TabIndex = 74;
            btnInvoiceNotesBack.Text = "Back";
            btnInvoiceNotesBack.UseVisualStyleBackColor = false;
            btnInvoiceNotesBack.Click += btnInvoiceNotesBack_Click;
            // 
            // lblNotesInvoiceCreateDate
            // 
            lblNotesInvoiceCreateDate.AutoSize = true;
            lblNotesInvoiceCreateDate.Location = new Point(42, 57);
            lblNotesInvoiceCreateDate.Name = "lblNotesInvoiceCreateDate";
            lblNotesInvoiceCreateDate.Size = new Size(71, 15);
            lblNotesInvoiceCreateDate.TabIndex = 63;
            lblNotesInvoiceCreateDate.Text = "Create Date:";
            // 
            // txtNotesInvoicePayload
            // 
            txtNotesInvoicePayload.Location = new Point(42, 163);
            txtNotesInvoicePayload.Multiline = true;
            txtNotesInvoicePayload.Name = "txtNotesInvoicePayload";
            txtNotesInvoicePayload.ReadOnly = true;
            txtNotesInvoicePayload.Size = new Size(247, 85);
            txtNotesInvoicePayload.TabIndex = 62;
            // 
            // lblNotesInvoicePayload
            // 
            lblNotesInvoicePayload.AutoSize = true;
            lblNotesInvoicePayload.Location = new Point(42, 145);
            lblNotesInvoicePayload.Name = "lblNotesInvoicePayload";
            lblNotesInvoicePayload.Size = new Size(52, 15);
            lblNotesInvoicePayload.TabIndex = 61;
            lblNotesInvoicePayload.Text = "Payload:";
            // 
            // txtNotesInvoiceTitle
            // 
            txtNotesInvoiceTitle.Location = new Point(42, 119);
            txtNotesInvoiceTitle.Name = "txtNotesInvoiceTitle";
            txtNotesInvoiceTitle.ReadOnly = true;
            txtNotesInvoiceTitle.Size = new Size(247, 23);
            txtNotesInvoiceTitle.TabIndex = 60;
            // 
            // lblNotesInvoiceTitle
            // 
            lblNotesInvoiceTitle.AutoSize = true;
            lblNotesInvoiceTitle.Location = new Point(42, 101);
            lblNotesInvoiceTitle.Name = "lblNotesInvoiceTitle";
            lblNotesInvoiceTitle.Size = new Size(32, 15);
            lblNotesInvoiceTitle.TabIndex = 59;
            lblNotesInvoiceTitle.Text = "Title:";
            // 
            // lblGroomyInvoice
            // 
            lblGroomyInvoice.AutoSize = true;
            lblGroomyInvoice.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyInvoice.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyInvoice.Location = new Point(326, 20);
            lblGroomyInvoice.Name = "lblGroomyInvoice";
            lblGroomyInvoice.Size = new Size(292, 45);
            lblGroomyInvoice.TabIndex = 104;
            lblGroomyInvoice.Text = "Groomy Invoice";
            lblGroomyInvoice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldInvoiceID
            // 
            fieldInvoiceID.AutoSize = true;
            fieldInvoiceID.Location = new Point(46, 413);
            fieldInvoiceID.Name = "fieldInvoiceID";
            fieldInvoiceID.Size = new Size(56, 15);
            fieldInvoiceID.TabIndex = 103;
            fieldInvoiceID.Text = "invoiceID";
            // 
            // lblInvoiceID
            // 
            lblInvoiceID.AutoSize = true;
            lblInvoiceID.Location = new Point(46, 398);
            lblInvoiceID.Name = "lblInvoiceID";
            lblInvoiceID.Size = new Size(62, 15);
            lblInvoiceID.TabIndex = 102;
            lblInvoiceID.Text = "Invoice ID:";
            // 
            // panelServicesInvoiceAll
            // 
            panelServicesInvoiceAll.Controls.Add(btnDeleteInvoiceService);
            panelServicesInvoiceAll.Controls.Add(btnViewInvoiceService);
            panelServicesInvoiceAll.Controls.Add(btnNewInvoiceService);
            panelServicesInvoiceAll.Controls.Add(invoiceDetailsDatagridview);
            panelServicesInvoiceAll.Controls.Add(lblIServices);
            panelServicesInvoiceAll.Location = new Point(326, 93);
            panelServicesInvoiceAll.Name = "panelServicesInvoiceAll";
            panelServicesInvoiceAll.Size = new Size(319, 308);
            panelServicesInvoiceAll.TabIndex = 113;
            // 
            // btnDeleteInvoiceService
            // 
            btnDeleteInvoiceService.BackColor = Color.FromArgb(21, 96, 130);
            btnDeleteInvoiceService.ForeColor = Color.White;
            btnDeleteInvoiceService.Location = new Point(206, 37);
            btnDeleteInvoiceService.Name = "btnDeleteInvoiceService";
            btnDeleteInvoiceService.Size = new Size(87, 23);
            btnDeleteInvoiceService.TabIndex = 77;
            btnDeleteInvoiceService.Text = "Delete";
            btnDeleteInvoiceService.UseVisualStyleBackColor = false;
            btnDeleteInvoiceService.Click += btnDeleteInvoiceService_Click;
            // 
            // btnViewInvoiceService
            // 
            btnViewInvoiceService.BackColor = Color.FromArgb(21, 96, 130);
            btnViewInvoiceService.ForeColor = Color.White;
            btnViewInvoiceService.Location = new Point(113, 37);
            btnViewInvoiceService.Name = "btnViewInvoiceService";
            btnViewInvoiceService.Size = new Size(87, 23);
            btnViewInvoiceService.TabIndex = 76;
            btnViewInvoiceService.Text = "View";
            btnViewInvoiceService.UseVisualStyleBackColor = false;
            btnViewInvoiceService.Click += btnViewInvoiceDetail_Click;
            // 
            // btnNewInvoiceService
            // 
            btnNewInvoiceService.BackColor = Color.FromArgb(21, 96, 130);
            btnNewInvoiceService.ForeColor = Color.White;
            btnNewInvoiceService.Location = new Point(20, 37);
            btnNewInvoiceService.Name = "btnNewInvoiceService";
            btnNewInvoiceService.Size = new Size(87, 23);
            btnNewInvoiceService.TabIndex = 74;
            btnNewInvoiceService.Text = "New";
            btnNewInvoiceService.UseVisualStyleBackColor = false;
            btnNewInvoiceService.Click += btnNewInvoiceService_Click;
            // 
            // invoiceDetailsDatagridview
            // 
            invoiceDetailsDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            invoiceDetailsDatagridview.Location = new Point(9, 66);
            invoiceDetailsDatagridview.Name = "invoiceDetailsDatagridview";
            invoiceDetailsDatagridview.Size = new Size(307, 221);
            invoiceDetailsDatagridview.TabIndex = 73;
            // 
            // lblIServices
            // 
            lblIServices.AutoSize = true;
            lblIServices.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            lblIServices.ForeColor = Color.FromArgb(21, 96, 130);
            lblIServices.Location = new Point(94, 4);
            lblIServices.Name = "lblIServices";
            lblIServices.Size = new Size(130, 33);
            lblIServices.TabIndex = 72;
            lblIServices.Text = "Services";
            lblIServices.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboCustomer
            // 
            comboCustomer.FormattingEnabled = true;
            comboCustomer.Location = new Point(46, 147);
            comboCustomer.Name = "comboCustomer";
            comboCustomer.Size = new Size(247, 23);
            comboCustomer.TabIndex = 116;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(47, 129);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 115;
            lblCustomer.Text = "Customer:";
            // 
            // lblInvoiceDueDate
            // 
            lblInvoiceDueDate.AutoSize = true;
            lblInvoiceDueDate.Location = new Point(44, 217);
            lblInvoiceDueDate.Name = "lblInvoiceDueDate";
            lblInvoiceDueDate.Size = new Size(58, 15);
            lblInvoiceDueDate.TabIndex = 119;
            lblInvoiceDueDate.Text = "Due Date:";
            // 
            // lblCreateDate
            // 
            lblCreateDate.AutoSize = true;
            lblCreateDate.Location = new Point(46, 173);
            lblCreateDate.Name = "lblCreateDate";
            lblCreateDate.Size = new Size(71, 15);
            lblCreateDate.TabIndex = 118;
            lblCreateDate.Text = "Create Date:";
            // 
            // timeInvoiceCreateDate
            // 
            timeInvoiceCreateDate.Enabled = false;
            timeInvoiceCreateDate.Format = DateTimePickerFormat.Time;
            timeInvoiceCreateDate.Location = new Point(46, 191);
            timeInvoiceCreateDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeInvoiceCreateDate.Name = "timeInvoiceCreateDate";
            timeInvoiceCreateDate.Size = new Size(247, 23);
            timeInvoiceCreateDate.TabIndex = 120;
            // 
            // timeInvoiceDueDate
            // 
            timeInvoiceDueDate.Enabled = false;
            timeInvoiceDueDate.Format = DateTimePickerFormat.Time;
            timeInvoiceDueDate.Location = new Point(47, 235);
            timeInvoiceDueDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeInvoiceDueDate.Name = "timeInvoiceDueDate";
            timeInvoiceDueDate.Size = new Size(247, 23);
            timeInvoiceDueDate.TabIndex = 121;
            // 
            // chkIsPaid
            // 
            chkIsPaid.AutoSize = true;
            chkIsPaid.Location = new Point(47, 308);
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.Size = new Size(49, 19);
            chkIsPaid.TabIndex = 122;
            chkIsPaid.Text = "Paid";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(46, 261);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 15);
            lblTotal.TabIndex = 123;
            lblTotal.Text = "Total:";
            // 
            // txtInvoiceTotal
            // 
            txtInvoiceTotal.Location = new Point(47, 279);
            txtInvoiceTotal.Name = "txtInvoiceTotal";
            txtInvoiceTotal.ReadOnly = true;
            txtInvoiceTotal.Size = new Size(247, 23);
            txtInvoiceTotal.TabIndex = 124;
            // 
            // btnInvoiceServicesBack
            // 
            btnInvoiceServicesBack.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceServicesBack.ForeColor = Color.White;
            btnInvoiceServicesBack.Location = new Point(42, 30);
            btnInvoiceServicesBack.Name = "btnInvoiceServicesBack";
            btnInvoiceServicesBack.Size = new Size(113, 23);
            btnInvoiceServicesBack.TabIndex = 74;
            btnInvoiceServicesBack.Text = "Back";
            btnInvoiceServicesBack.UseVisualStyleBackColor = false;
            btnInvoiceServicesBack.Click += btnInvoiceServicesBack_Click;
            // 
            // btnInvoiceServiceEditSave
            // 
            btnInvoiceDetailEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceDetailEditSave.ForeColor = Color.White;
            btnInvoiceDetailEditSave.Location = new Point(176, 30);
            btnInvoiceDetailEditSave.Name = "btnInvoiceServiceEditSave";
            btnInvoiceDetailEditSave.Size = new Size(113, 23);
            btnInvoiceDetailEditSave.TabIndex = 75;
            btnInvoiceDetailEditSave.Text = "Edit";
            btnInvoiceDetailEditSave.UseVisualStyleBackColor = false;
            btnInvoiceDetailEditSave.Click += btnInvoiceDetailEditSave_Click;
            // 
            // lblDetailID
            // 
            lblDetailID.AutoSize = true;
            lblDetailID.Location = new Point(42, 254);
            lblDetailID.Name = "lblDetailID";
            lblDetailID.Size = new Size(54, 15);
            lblDetailID.TabIndex = 80;
            lblDetailID.Text = "Detail ID:";
            // 
            // fieldDetailID
            // 
            fieldDetailID.AutoSize = true;
            fieldDetailID.Location = new Point(44, 269);
            fieldDetailID.Name = "fieldDetailID";
            fieldDetailID.Size = new Size(47, 15);
            fieldDetailID.TabIndex = 81;
            fieldDetailID.Text = "detailID";
            // 
            // lblServiceMulti
            // 
            lblServiceMulti.AutoSize = true;
            lblServiceMulti.Location = new Point(43, 57);
            lblServiceMulti.Name = "lblServiceMulti";
            lblServiceMulti.Size = new Size(47, 15);
            lblServiceMulti.TabIndex = 117;
            lblServiceMulti.Text = "Service:";
            // 
            // comboServices
            // 
            comboServices.FormattingEnabled = true;
            comboServices.Location = new Point(42, 75);
            comboServices.Name = "comboServices";
            comboServices.Size = new Size(247, 23);
            comboServices.TabIndex = 118;
            comboServices.SelectedIndexChanged += otfQuantity_TextChanged;
            comboServices.SelectedValueChanged += otfQuantity_TextChanged;
            comboServices.TextChanged += otfQuantity_TextChanged;
            comboServices.Leave += otfQuantity_TextChanged;
            // 
            // panelServiceInvoiceNewEdit
            // 
            panelServiceInvoiceNewEdit.Controls.Add(btnInvoiceServicesBack);
            panelServiceInvoiceNewEdit.Controls.Add(txtServiceTotal);
            panelServiceInvoiceNewEdit.Controls.Add(lblServiceTotal);
            panelServiceInvoiceNewEdit.Controls.Add(txtQuantity);
            panelServiceInvoiceNewEdit.Controls.Add(lblQuantity);
            panelServiceInvoiceNewEdit.Controls.Add(comboServices);
            panelServiceInvoiceNewEdit.Controls.Add(lblServiceMulti);
            panelServiceInvoiceNewEdit.Controls.Add(fieldDetailID);
            panelServiceInvoiceNewEdit.Controls.Add(lblDetailID);
            panelServiceInvoiceNewEdit.Controls.Add(btnInvoiceDetailEditSave);
            panelServiceInvoiceNewEdit.Location = new Point(976, 93);
            panelServiceInvoiceNewEdit.Name = "panelServiceInvoiceNewEdit";
            panelServiceInvoiceNewEdit.Size = new Size(319, 308);
            panelServiceInvoiceNewEdit.TabIndex = 114;
            // 
            // txtServiceTotal
            // 
            txtServiceTotal.Location = new Point(44, 168);
            txtServiceTotal.Name = "txtServiceTotal";
            txtServiceTotal.ReadOnly = true;
            txtServiceTotal.Size = new Size(247, 23);
            txtServiceTotal.TabIndex = 122;
            // 
            // lblServiceTotal
            // 
            lblServiceTotal.AutoSize = true;
            lblServiceTotal.Location = new Point(44, 150);
            lblServiceTotal.Name = "lblServiceTotal";
            lblServiceTotal.Size = new Size(35, 15);
            lblServiceTotal.TabIndex = 121;
            lblServiceTotal.Text = "Total:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(42, 121);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.ReadOnly = true;
            txtQuantity.Size = new Size(247, 23);
            txtQuantity.TabIndex = 120;
            txtQuantity.TextChanged += otfQuantity_TextChanged;
            txtQuantity.Leave += otfQuantity_TextChanged;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(42, 103);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 119;
            lblQuantity.Text = "Quantity:";
            // 
            // InvoiceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1855, 454);
            Controls.Add(txtInvoiceTotal);
            Controls.Add(lblTotal);
            Controls.Add(chkIsPaid);
            Controls.Add(timeInvoiceDueDate);
            Controls.Add(timeInvoiceCreateDate);
            Controls.Add(lblInvoiceDueDate);
            Controls.Add(lblCreateDate);
            Controls.Add(comboCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(panelServiceInvoiceNewEdit);
            Controls.Add(panelServicesInvoiceAll);
            Controls.Add(panelNotesInvoiceAll);
            Controls.Add(btnInvoiceEditSave);
            Controls.Add(btnBack);
            Controls.Add(panelNotesServiceNewEdit);
            Controls.Add(lblGroomyInvoice);
            Controls.Add(fieldInvoiceID);
            Controls.Add(lblInvoiceID);
            Name = "InvoiceView";
            Text = "InvoiceView";
            panelNotesInvoiceAll.ResumeLayout(false);
            panelNotesInvoiceAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceNotesDataGridView).EndInit();
            panelNotesServiceNewEdit.ResumeLayout(false);
            panelNotesServiceNewEdit.PerformLayout();
            panelServicesInvoiceAll.ResumeLayout(false);
            panelServicesInvoiceAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceDetailsDatagridview).EndInit();
            panelServiceInvoiceNewEdit.ResumeLayout(false);
            panelServiceInvoiceNewEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServicePrice;
        private Label lblServicePrice;
        private Panel panelNotesInvoiceAll;
        private Button btnNotesInvoiceDelete;
        private Button btnNotesInvoiceView;
        private Button btnNotesInvoiceNew;
        private DataGridView invoiceNotesDataGridView;
        private Label lblNotes;
        private Button btnInvoiceEditSave;
        private Button btnBack;
        private Panel panelNotesServiceNewEdit;
        private Label fieldNotesInvoiceNoteID;
        private Label lblNotesInvoiceNoteID;
        private DateTimePicker timeNoteInvoiceCreateDate;
        private Button btnInvoiceNotesEditSave;
        private Button btnInvoiceNotesBack;
        private Label lblNotesInvoiceCreateDate;
        private TextBox txtNotesInvoicePayload;
        private Label lblNotesInvoicePayload;
        private TextBox txtNotesInvoiceTitle;
        private Label lblNotesInvoiceTitle;
        private Label lblGroomyInvoice;
        private Label fieldInvoiceID;
        private Label lblInvoiceID;
        private Panel panelServicesInvoiceAll;
        private Button btnDeleteInvoiceService;
        private Button btnViewInvoiceService;
        private Button btnNewInvoiceService;
        private DataGridView invoiceDetailsDatagridview;
        private Label lblIServices;
        private ComboBox comboCustomer;
        private Label lblCustomer;
        private Label lblInvoiceDueDate;
        private Label lblCreateDate;
        private DateTimePicker timeInvoiceCreateDate;
        private DateTimePicker timeInvoiceDueDate;
        private CheckBox chkIsPaid;
        private Label lblTotal;
        private TextBox txtInvoiceTotal;
        private Button btnInvoiceServicesBack;
        private Button btnInvoiceDetailEditSave;
        private Label lblDetailID;
        private Label fieldDetailID;
        private Label lblServiceMulti;
        private ComboBox comboServices;
        private Panel panelServiceInvoiceNewEdit;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private TextBox txtServiceTotal;
        private Label lblServiceTotal;
    }
}