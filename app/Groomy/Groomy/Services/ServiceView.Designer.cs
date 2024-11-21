namespace Groomy.Services
{
    partial class ServiceView
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
            panelNotesServiceAll = new Panel();
            btnNotesServiceDelete = new Button();
            btnNotesServiceView = new Button();
            btnNotesServiceNew = new Button();
            serviceNotesDataGridView = new DataGridView();
            lblNotes = new Label();
            btnServiceEditSave = new Button();
            btnBack = new Button();
            panelNotesServiceNewEdit = new Panel();
            fieldNotesServiceNoteID = new Label();
            lblNotesServiceNoteID = new Label();
            timeNoteServiceCreateDate = new DateTimePicker();
            btnServiceNotesEditSave = new Button();
            btnServiceNotesBack = new Button();
            lblNotesServiceCreateDate = new Label();
            txtNotesServicePayload = new TextBox();
            lblNotesServicePayload = new Label();
            txtNotesServiceTitle = new TextBox();
            lblNotesServiceTitle = new Label();
            lblGroomyService = new Label();
            fieldServiceID = new Label();
            lblServiceID = new Label();
            txtServiceName = new TextBox();
            lblServiceName = new Label();
            txtServiceDescription = new TextBox();
            lblServiceDescription = new Label();
            txtServicePrice = new TextBox();
            lblServicePrice = new Label();
            panelNotesServiceAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceNotesDataGridView).BeginInit();
            panelNotesServiceNewEdit.SuspendLayout();
            SuspendLayout();
            // 
            // panelNotesServiceAll
            // 
            panelNotesServiceAll.Controls.Add(btnNotesServiceDelete);
            panelNotesServiceAll.Controls.Add(btnNotesServiceView);
            panelNotesServiceAll.Controls.Add(btnNotesServiceNew);
            panelNotesServiceAll.Controls.Add(serviceNotesDataGridView);
            panelNotesServiceAll.Controls.Add(lblNotes);
            panelNotesServiceAll.Location = new Point(328, 93);
            panelNotesServiceAll.Name = "panelNotesServiceAll";
            panelNotesServiceAll.Size = new Size(419, 308);
            panelNotesServiceAll.TabIndex = 95;
            // 
            // btnNotesServiceDelete
            // 
            btnNotesServiceDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesServiceDelete.ForeColor = Color.White;
            btnNotesServiceDelete.Location = new Point(260, 37);
            btnNotesServiceDelete.Name = "btnNotesServiceDelete";
            btnNotesServiceDelete.Size = new Size(87, 23);
            btnNotesServiceDelete.TabIndex = 77;
            btnNotesServiceDelete.Text = "Delete";
            btnNotesServiceDelete.UseVisualStyleBackColor = false;
            btnNotesServiceDelete.Click += btnNotesServiceDelete_Click;
            // 
            // btnNotesServiceView
            // 
            btnNotesServiceView.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesServiceView.ForeColor = Color.White;
            btnNotesServiceView.Location = new Point(167, 37);
            btnNotesServiceView.Name = "btnNotesServiceView";
            btnNotesServiceView.Size = new Size(87, 23);
            btnNotesServiceView.TabIndex = 76;
            btnNotesServiceView.Text = "View";
            btnNotesServiceView.UseVisualStyleBackColor = false;
            btnNotesServiceView.Click += btnNotesServiceView_Click;
            // 
            // btnNotesServiceNew
            // 
            btnNotesServiceNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesServiceNew.ForeColor = Color.White;
            btnNotesServiceNew.Location = new Point(74, 37);
            btnNotesServiceNew.Name = "btnNotesServiceNew";
            btnNotesServiceNew.Size = new Size(87, 23);
            btnNotesServiceNew.TabIndex = 74;
            btnNotesServiceNew.Text = "New";
            btnNotesServiceNew.UseVisualStyleBackColor = false;
            btnNotesServiceNew.Click += btnNotesServiceNew_Click;
            // 
            // serviceNotesDataGridView
            // 
            serviceNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceNotesDataGridView.Location = new Point(9, 66);
            serviceNotesDataGridView.Name = "serviceNotesDataGridView";
            serviceNotesDataGridView.Size = new Size(404, 221);
            serviceNotesDataGridView.TabIndex = 73;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            lblNotes.ForeColor = Color.FromArgb(21, 96, 130);
            lblNotes.Location = new Point(167, 4);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(93, 33);
            lblNotes.TabIndex = 72;
            lblNotes.Text = "Notes";
            lblNotes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnServiceEditSave
            // 
            btnServiceEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceEditSave.ForeColor = Color.White;
            btnServiceEditSave.Location = new Point(178, 93);
            btnServiceEditSave.Name = "btnServiceEditSave";
            btnServiceEditSave.Size = new Size(103, 23);
            btnServiceEditSave.TabIndex = 94;
            btnServiceEditSave.Text = "Edit";
            btnServiceEditSave.UseVisualStyleBackColor = false;
            btnServiceEditSave.Click += btnServiceEditSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(69, 93);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 93;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelNotesServiceNewEdit
            // 
            panelNotesServiceNewEdit.Controls.Add(fieldNotesServiceNoteID);
            panelNotesServiceNewEdit.Controls.Add(lblNotesServiceNoteID);
            panelNotesServiceNewEdit.Controls.Add(timeNoteServiceCreateDate);
            panelNotesServiceNewEdit.Controls.Add(btnServiceNotesEditSave);
            panelNotesServiceNewEdit.Controls.Add(btnServiceNotesBack);
            panelNotesServiceNewEdit.Controls.Add(lblNotesServiceCreateDate);
            panelNotesServiceNewEdit.Controls.Add(txtNotesServicePayload);
            panelNotesServiceNewEdit.Controls.Add(lblNotesServicePayload);
            panelNotesServiceNewEdit.Controls.Add(txtNotesServiceTitle);
            panelNotesServiceNewEdit.Controls.Add(lblNotesServiceTitle);
            panelNotesServiceNewEdit.Location = new Point(767, 93);
            panelNotesServiceNewEdit.Name = "panelNotesServiceNewEdit";
            panelNotesServiceNewEdit.Size = new Size(420, 308);
            panelNotesServiceNewEdit.TabIndex = 92;
            // 
            // fieldNotesServiceNoteID
            // 
            fieldNotesServiceNoteID.AutoSize = true;
            fieldNotesServiceNoteID.Location = new Point(84, 253);
            fieldNotesServiceNoteID.Name = "fieldNotesServiceNoteID";
            fieldNotesServiceNoteID.Size = new Size(42, 15);
            fieldNotesServiceNoteID.TabIndex = 81;
            fieldNotesServiceNoteID.Text = "noteID";
            // 
            // lblNotesServiceNoteID
            // 
            lblNotesServiceNoteID.AutoSize = true;
            lblNotesServiceNoteID.Location = new Point(82, 238);
            lblNotesServiceNoteID.Name = "lblNotesServiceNoteID";
            lblNotesServiceNoteID.Size = new Size(50, 15);
            lblNotesServiceNoteID.TabIndex = 80;
            lblNotesServiceNoteID.Text = "Note ID:";
            // 
            // timeNoteServiceCreateDate
            // 
            timeNoteServiceCreateDate.Enabled = false;
            timeNoteServiceCreateDate.Format = DateTimePickerFormat.Time;
            timeNoteServiceCreateDate.Location = new Point(82, 59);
            timeNoteServiceCreateDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeNoteServiceCreateDate.Name = "timeNoteServiceCreateDate";
            timeNoteServiceCreateDate.Size = new Size(247, 23);
            timeNoteServiceCreateDate.TabIndex = 79;
            // 
            // btnServiceNotesEditSave
            // 
            btnServiceNotesEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceNotesEditSave.ForeColor = Color.White;
            btnServiceNotesEditSave.Location = new Point(216, 14);
            btnServiceNotesEditSave.Name = "btnServiceNotesEditSave";
            btnServiceNotesEditSave.Size = new Size(113, 23);
            btnServiceNotesEditSave.TabIndex = 75;
            btnServiceNotesEditSave.Text = "Edit";
            btnServiceNotesEditSave.UseVisualStyleBackColor = false;
            btnServiceNotesEditSave.Click += btnServiceNotesEditSave_Click;
            // 
            // btnServiceNotesBack
            // 
            btnServiceNotesBack.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceNotesBack.ForeColor = Color.White;
            btnServiceNotesBack.Location = new Point(82, 14);
            btnServiceNotesBack.Name = "btnServiceNotesBack";
            btnServiceNotesBack.Size = new Size(113, 23);
            btnServiceNotesBack.TabIndex = 74;
            btnServiceNotesBack.Text = "Back";
            btnServiceNotesBack.UseVisualStyleBackColor = false;
            btnServiceNotesBack.Click += btnServiceNotesBack_Click;
            // 
            // lblNotesServiceCreateDate
            // 
            lblNotesServiceCreateDate.AutoSize = true;
            lblNotesServiceCreateDate.Location = new Point(82, 41);
            lblNotesServiceCreateDate.Name = "lblNotesServiceCreateDate";
            lblNotesServiceCreateDate.Size = new Size(71, 15);
            lblNotesServiceCreateDate.TabIndex = 63;
            lblNotesServiceCreateDate.Text = "Create Date:";
            // 
            // txtNotesServicePayload
            // 
            txtNotesServicePayload.Location = new Point(82, 147);
            txtNotesServicePayload.Multiline = true;
            txtNotesServicePayload.Name = "txtNotesServicePayload";
            txtNotesServicePayload.ReadOnly = true;
            txtNotesServicePayload.Size = new Size(247, 85);
            txtNotesServicePayload.TabIndex = 62;
            // 
            // lblNotesServicePayload
            // 
            lblNotesServicePayload.AutoSize = true;
            lblNotesServicePayload.Location = new Point(82, 129);
            lblNotesServicePayload.Name = "lblNotesServicePayload";
            lblNotesServicePayload.Size = new Size(52, 15);
            lblNotesServicePayload.TabIndex = 61;
            lblNotesServicePayload.Text = "Payload:";
            // 
            // txtNotesServiceTitle
            // 
            txtNotesServiceTitle.Location = new Point(82, 103);
            txtNotesServiceTitle.Name = "txtNotesServiceTitle";
            txtNotesServiceTitle.ReadOnly = true;
            txtNotesServiceTitle.Size = new Size(247, 23);
            txtNotesServiceTitle.TabIndex = 60;
            // 
            // lblNotesServiceTitle
            // 
            lblNotesServiceTitle.AutoSize = true;
            lblNotesServiceTitle.Location = new Point(82, 85);
            lblNotesServiceTitle.Name = "lblNotesServiceTitle";
            lblNotesServiceTitle.Size = new Size(32, 15);
            lblNotesServiceTitle.TabIndex = 59;
            lblNotesServiceTitle.Text = "Title:";
            // 
            // lblGroomyService
            // 
            lblGroomyService.AutoSize = true;
            lblGroomyService.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyService.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyService.Location = new Point(203, 26);
            lblGroomyService.Name = "lblGroomyService";
            lblGroomyService.Size = new Size(300, 45);
            lblGroomyService.TabIndex = 91;
            lblGroomyService.Text = "Groomy Service";
            lblGroomyService.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldServiceID
            // 
            fieldServiceID.AutoSize = true;
            fieldServiceID.Location = new Point(46, 413);
            fieldServiceID.Name = "fieldServiceID";
            fieldServiceID.Size = new Size(54, 15);
            fieldServiceID.TabIndex = 90;
            fieldServiceID.Text = "serviceID";
            // 
            // lblServiceID
            // 
            lblServiceID.AutoSize = true;
            lblServiceID.Location = new Point(46, 398);
            lblServiceID.Name = "lblServiceID";
            lblServiceID.Size = new Size(61, 15);
            lblServiceID.TabIndex = 89;
            lblServiceID.Text = "Service ID:";
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(46, 152);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.ReadOnly = true;
            txtServiceName.Size = new Size(247, 23);
            txtServiceName.TabIndex = 80;
            // 
            // lblServiceName
            // 
            lblServiceName.AutoSize = true;
            lblServiceName.Location = new Point(46, 134);
            lblServiceName.Name = "lblServiceName";
            lblServiceName.Size = new Size(42, 15);
            lblServiceName.TabIndex = 79;
            lblServiceName.Text = "Name:";
            // 
            // txtServiceDescription
            // 
            txtServiceDescription.Location = new Point(46, 196);
            txtServiceDescription.Multiline = true;
            txtServiceDescription.Name = "txtServiceDescription";
            txtServiceDescription.ReadOnly = true;
            txtServiceDescription.Size = new Size(247, 83);
            txtServiceDescription.TabIndex = 97;
            // 
            // lblServiceDescription
            // 
            lblServiceDescription.AutoSize = true;
            lblServiceDescription.Location = new Point(46, 178);
            lblServiceDescription.Name = "lblServiceDescription";
            lblServiceDescription.Size = new Size(70, 15);
            lblServiceDescription.TabIndex = 96;
            lblServiceDescription.Text = "Description:";
            // 
            // txtServicePrice
            // 
            txtServicePrice.Location = new Point(46, 300);
            txtServicePrice.Name = "txtServicePrice";
            txtServicePrice.ReadOnly = true;
            txtServicePrice.Size = new Size(247, 23);
            txtServicePrice.TabIndex = 99;
            // 
            // lblServicePrice
            // 
            lblServicePrice.AutoSize = true;
            lblServicePrice.Location = new Point(46, 282);
            lblServicePrice.Name = "lblServicePrice";
            lblServicePrice.Size = new Size(36, 15);
            lblServicePrice.TabIndex = 98;
            lblServicePrice.Text = "Price:";
            // 
            // ServiceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 454);
            Controls.Add(txtServicePrice);
            Controls.Add(lblServicePrice);
            Controls.Add(txtServiceDescription);
            Controls.Add(lblServiceDescription);
            Controls.Add(panelNotesServiceAll);
            Controls.Add(btnServiceEditSave);
            Controls.Add(btnBack);
            Controls.Add(panelNotesServiceNewEdit);
            Controls.Add(lblGroomyService);
            Controls.Add(fieldServiceID);
            Controls.Add(lblServiceID);
            Controls.Add(txtServiceName);
            Controls.Add(lblServiceName);
            Name = "ServiceView";
            Text = "ServiceView";
            panelNotesServiceAll.ResumeLayout(false);
            panelNotesServiceAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)serviceNotesDataGridView).EndInit();
            panelNotesServiceNewEdit.ResumeLayout(false);
            panelNotesServiceNewEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelNotesServiceAll;
        private Button btnNotesServiceDelete;
        private Button btnNotesServiceView;
        private Button btnNotesServiceNew;
        private DataGridView serviceNotesDataGridView;
        private Label lblNotes;
        private Button btnServiceEditSave;
        private Button btnBack;
        private Panel panelNotesServiceNewEdit;
        private Label fieldNotesServiceNoteID;
        private Label lblNotesServiceNoteID;
        private DateTimePicker timeNoteServiceCreateDate;
        private Button btnServiceNotesEditSave;
        private Button btnServiceNotesBack;
        private Label lblNotesServiceCreateDate;
        private TextBox txtNotesServicePayload;
        private Label lblNotesServicePayload;
        private TextBox txtNotesServiceTitle;
        private Label lblNotesServiceTitle;
        private Label lblGroomyService;
        private Label fieldServiceID;
        private Label lblServiceID;
        private TextBox txtServiceName;
        private Label lblServiceName;
        private TextBox txtServiceDescription;
        private Label lblServiceDescription;
        private TextBox txtServicePrice;
        private Label lblServicePrice;
    }
}