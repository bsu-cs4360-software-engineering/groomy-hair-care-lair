namespace Groomy.Appointments
{
    partial class AppointmentView
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
            panelNotesAppointmentAll = new Panel();
            btnNotesAppointmentDelete = new Button();
            btnNotesAppointmentView = new Button();
            btnNotesAppointmentNew = new Button();
            appointmentNotesDataGridView = new DataGridView();
            lblNotes = new Label();
            btnAppointmentEditSave = new Button();
            btnBack = new Button();
            panelNotesAppointmentNewEdit = new Panel();
            fieldNotesAppointmentNoteID = new Label();
            lblNotesAppointmentNoteID = new Label();
            timeNotesAppointmentCreateDate = new DateTimePicker();
            btnAppointmentNotesEditSave = new Button();
            btnAppointmentNotesBack = new Button();
            lblNotesAppointmentCreateDate = new Label();
            txtNotesAppointmentPayload = new TextBox();
            lblNotesAppointmentPayload = new Label();
            txtNotesAppointmentTitle = new TextBox();
            lblNotesAppointmentTitle = new Label();
            lblGroomyAppointment = new Label();
            fieldAppointmentID = new Label();
            lblAppointmentID = new Label();
            txtLocation = new TextBox();
            lblLocation = new Label();
            lblEndTime = new Label();
            lblStartTime = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            timeAppointmentStart = new DateTimePicker();
            timeAppointmentEnd = new DateTimePicker();
            comboCustomer = new ComboBox();
            lblCustomer = new Label();
            panelNotesAppointmentAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentNotesDataGridView).BeginInit();
            panelNotesAppointmentNewEdit.SuspendLayout();
            SuspendLayout();
            // 
            // panelNotesAppointmentAll
            // 
            panelNotesAppointmentAll.Controls.Add(btnNotesAppointmentDelete);
            panelNotesAppointmentAll.Controls.Add(btnNotesAppointmentView);
            panelNotesAppointmentAll.Controls.Add(btnNotesAppointmentNew);
            panelNotesAppointmentAll.Controls.Add(appointmentNotesDataGridView);
            panelNotesAppointmentAll.Controls.Add(lblNotes);
            panelNotesAppointmentAll.Location = new Point(328, 93);
            panelNotesAppointmentAll.Name = "panelNotesAppointmentAll";
            panelNotesAppointmentAll.Size = new Size(419, 308);
            panelNotesAppointmentAll.TabIndex = 95;
            // 
            // btnNotesAppointmentDelete
            // 
            btnNotesAppointmentDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesAppointmentDelete.ForeColor = Color.White;
            btnNotesAppointmentDelete.Location = new Point(260, 37);
            btnNotesAppointmentDelete.Name = "btnNotesAppointmentDelete";
            btnNotesAppointmentDelete.Size = new Size(87, 23);
            btnNotesAppointmentDelete.TabIndex = 77;
            btnNotesAppointmentDelete.Text = "Delete";
            btnNotesAppointmentDelete.UseVisualStyleBackColor = false;
            btnNotesAppointmentDelete.Click += btnNotesAppointmentDelete_Click;
            // 
            // btnNotesAppointmentView
            // 
            btnNotesAppointmentView.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesAppointmentView.ForeColor = Color.White;
            btnNotesAppointmentView.Location = new Point(167, 37);
            btnNotesAppointmentView.Name = "btnNotesAppointmentView";
            btnNotesAppointmentView.Size = new Size(87, 23);
            btnNotesAppointmentView.TabIndex = 76;
            btnNotesAppointmentView.Text = "View";
            btnNotesAppointmentView.UseVisualStyleBackColor = false;
            btnNotesAppointmentView.Click += btnNotesAppointmentView_Click;
            // 
            // btnNotesAppointmentNew
            // 
            btnNotesAppointmentNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesAppointmentNew.ForeColor = Color.White;
            btnNotesAppointmentNew.Location = new Point(74, 37);
            btnNotesAppointmentNew.Name = "btnNotesAppointmentNew";
            btnNotesAppointmentNew.Size = new Size(87, 23);
            btnNotesAppointmentNew.TabIndex = 74;
            btnNotesAppointmentNew.Text = "New";
            btnNotesAppointmentNew.UseVisualStyleBackColor = false;
            btnNotesAppointmentNew.Click += btnNotesAppointmentNew_Click;
            // 
            // appointmentNotesDataGridView
            // 
            appointmentNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentNotesDataGridView.Location = new Point(9, 66);
            appointmentNotesDataGridView.Name = "appointmentNotesDataGridView";
            appointmentNotesDataGridView.Size = new Size(404, 221);
            appointmentNotesDataGridView.TabIndex = 73;
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
            // btnAppointmentEditSave
            // 
            btnAppointmentEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentEditSave.ForeColor = Color.White;
            btnAppointmentEditSave.Location = new Point(178, 93);
            btnAppointmentEditSave.Name = "btnAppointmentEditSave";
            btnAppointmentEditSave.Size = new Size(103, 23);
            btnAppointmentEditSave.TabIndex = 94;
            btnAppointmentEditSave.Text = "Edit";
            btnAppointmentEditSave.UseVisualStyleBackColor = false;
            btnAppointmentEditSave.Click += btnAppointmentEditSave_Click;
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
            // panelNotesAppointmentNewEdit
            // 
            panelNotesAppointmentNewEdit.Controls.Add(fieldNotesAppointmentNoteID);
            panelNotesAppointmentNewEdit.Controls.Add(lblNotesAppointmentNoteID);
            panelNotesAppointmentNewEdit.Controls.Add(timeNotesAppointmentCreateDate);
            panelNotesAppointmentNewEdit.Controls.Add(btnAppointmentNotesEditSave);
            panelNotesAppointmentNewEdit.Controls.Add(btnAppointmentNotesBack);
            panelNotesAppointmentNewEdit.Controls.Add(lblNotesAppointmentCreateDate);
            panelNotesAppointmentNewEdit.Controls.Add(txtNotesAppointmentPayload);
            panelNotesAppointmentNewEdit.Controls.Add(lblNotesAppointmentPayload);
            panelNotesAppointmentNewEdit.Controls.Add(txtNotesAppointmentTitle);
            panelNotesAppointmentNewEdit.Controls.Add(lblNotesAppointmentTitle);
            panelNotesAppointmentNewEdit.Location = new Point(767, 93);
            panelNotesAppointmentNewEdit.Name = "panelNotesAppointmentNewEdit";
            panelNotesAppointmentNewEdit.Size = new Size(420, 308);
            panelNotesAppointmentNewEdit.TabIndex = 92;
            // 
            // fieldNotesAppointmentNoteID
            // 
            fieldNotesAppointmentNoteID.AutoSize = true;
            fieldNotesAppointmentNoteID.Location = new Point(84, 253);
            fieldNotesAppointmentNoteID.Name = "fieldNotesAppointmentNoteID";
            fieldNotesAppointmentNoteID.Size = new Size(42, 15);
            fieldNotesAppointmentNoteID.TabIndex = 81;
            fieldNotesAppointmentNoteID.Text = "noteID";
            // 
            // lblNotesAppointmentNoteID
            // 
            lblNotesAppointmentNoteID.AutoSize = true;
            lblNotesAppointmentNoteID.Location = new Point(82, 238);
            lblNotesAppointmentNoteID.Name = "lblNotesAppointmentNoteID";
            lblNotesAppointmentNoteID.Size = new Size(50, 15);
            lblNotesAppointmentNoteID.TabIndex = 80;
            lblNotesAppointmentNoteID.Text = "Note ID:";
            // 
            // timeNotesAppointmentCreateDate
            // 
            timeNotesAppointmentCreateDate.Enabled = false;
            timeNotesAppointmentCreateDate.Format = DateTimePickerFormat.Time;
            timeNotesAppointmentCreateDate.Location = new Point(82, 59);
            timeNotesAppointmentCreateDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeNotesAppointmentCreateDate.Name = "timeNotesAppointmentCreateDate";
            timeNotesAppointmentCreateDate.Size = new Size(247, 23);
            timeNotesAppointmentCreateDate.TabIndex = 79;
            // 
            // btnAppointmentNotesEditSave
            // 
            btnAppointmentNotesEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentNotesEditSave.ForeColor = Color.White;
            btnAppointmentNotesEditSave.Location = new Point(216, 14);
            btnAppointmentNotesEditSave.Name = "btnAppointmentNotesEditSave";
            btnAppointmentNotesEditSave.Size = new Size(113, 23);
            btnAppointmentNotesEditSave.TabIndex = 75;
            btnAppointmentNotesEditSave.Text = "Edit";
            btnAppointmentNotesEditSave.UseVisualStyleBackColor = false;
            btnAppointmentNotesEditSave.Click += btnAppointmentNotesEditSave_Click;
            // 
            // btnAppointmentNotesBack
            // 
            btnAppointmentNotesBack.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentNotesBack.ForeColor = Color.White;
            btnAppointmentNotesBack.Location = new Point(82, 14);
            btnAppointmentNotesBack.Name = "btnAppointmentNotesBack";
            btnAppointmentNotesBack.Size = new Size(113, 23);
            btnAppointmentNotesBack.TabIndex = 74;
            btnAppointmentNotesBack.Text = "Back";
            btnAppointmentNotesBack.UseVisualStyleBackColor = false;
            btnAppointmentNotesBack.Click += btnAppointmentNotesBack_Click;
            // 
            // lblNotesAppointmentCreateDate
            // 
            lblNotesAppointmentCreateDate.AutoSize = true;
            lblNotesAppointmentCreateDate.Location = new Point(82, 41);
            lblNotesAppointmentCreateDate.Name = "lblNotesAppointmentCreateDate";
            lblNotesAppointmentCreateDate.Size = new Size(71, 15);
            lblNotesAppointmentCreateDate.TabIndex = 63;
            lblNotesAppointmentCreateDate.Text = "Create Date:";
            // 
            // txtNotesAppointmentPayload
            // 
            txtNotesAppointmentPayload.Location = new Point(82, 147);
            txtNotesAppointmentPayload.Multiline = true;
            txtNotesAppointmentPayload.Name = "txtNotesAppointmentPayload";
            txtNotesAppointmentPayload.ReadOnly = true;
            txtNotesAppointmentPayload.Size = new Size(247, 85);
            txtNotesAppointmentPayload.TabIndex = 62;
            // 
            // lblNotesAppointmentPayload
            // 
            lblNotesAppointmentPayload.AutoSize = true;
            lblNotesAppointmentPayload.Location = new Point(82, 129);
            lblNotesAppointmentPayload.Name = "lblNotesAppointmentPayload";
            lblNotesAppointmentPayload.Size = new Size(52, 15);
            lblNotesAppointmentPayload.TabIndex = 61;
            lblNotesAppointmentPayload.Text = "Payload:";
            // 
            // txtNotesAppointmentTitle
            // 
            txtNotesAppointmentTitle.Location = new Point(82, 103);
            txtNotesAppointmentTitle.Name = "txtNotesAppointmentTitle";
            txtNotesAppointmentTitle.ReadOnly = true;
            txtNotesAppointmentTitle.Size = new Size(247, 23);
            txtNotesAppointmentTitle.TabIndex = 60;
            // 
            // lblNotesAppointmentTitle
            // 
            lblNotesAppointmentTitle.AutoSize = true;
            lblNotesAppointmentTitle.Location = new Point(82, 85);
            lblNotesAppointmentTitle.Name = "lblNotesAppointmentTitle";
            lblNotesAppointmentTitle.Size = new Size(32, 15);
            lblNotesAppointmentTitle.TabIndex = 59;
            lblNotesAppointmentTitle.Text = "Title:";
            // 
            // lblGroomyAppointment
            // 
            lblGroomyAppointment.AutoSize = true;
            lblGroomyAppointment.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyAppointment.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyAppointment.Location = new Point(203, 26);
            lblGroomyAppointment.Name = "lblGroomyAppointment";
            lblGroomyAppointment.Size = new Size(390, 45);
            lblGroomyAppointment.TabIndex = 91;
            lblGroomyAppointment.Text = "Groomy Appointment";
            lblGroomyAppointment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldAppointmentID
            // 
            fieldAppointmentID.AutoSize = true;
            fieldAppointmentID.Location = new Point(46, 423);
            fieldAppointmentID.Name = "fieldAppointmentID";
            fieldAppointmentID.Size = new Size(87, 15);
            fieldAppointmentID.TabIndex = 90;
            fieldAppointmentID.Text = "appointmentID";
            // 
            // lblAppointmentID
            // 
            lblAppointmentID.AutoSize = true;
            lblAppointmentID.Location = new Point(46, 408);
            lblAppointmentID.Name = "lblAppointmentID";
            lblAppointmentID.Size = new Size(95, 15);
            lblAppointmentID.TabIndex = 89;
            lblAppointmentID.Text = "Appointment ID:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(46, 353);
            txtLocation.Multiline = true;
            txtLocation.Name = "txtLocation";
            txtLocation.ReadOnly = true;
            txtLocation.Size = new Size(247, 48);
            txtLocation.TabIndex = 88;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(46, 335);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(56, 15);
            lblLocation.TabIndex = 87;
            lblLocation.Text = "Location:";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(46, 291);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(59, 15);
            lblEndTime.TabIndex = 85;
            lblEndTime.Text = "End Time:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(46, 247);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(63, 15);
            lblStartTime.TabIndex = 83;
            lblStartTime.Text = "Start Time:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(46, 222);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(247, 23);
            txtDescription.TabIndex = 82;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(46, 204);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 15);
            lblDescription.TabIndex = 81;
            lblDescription.Text = "Description:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(46, 178);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(247, 23);
            txtTitle.TabIndex = 80;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(46, 160);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 79;
            lblTitle.Text = "Title:";
            // 
            // timeAppointmentStart
            // 
            timeAppointmentStart.Enabled = false;
            timeAppointmentStart.Format = DateTimePickerFormat.Time;
            timeAppointmentStart.Location = new Point(46, 265);
            timeAppointmentStart.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeAppointmentStart.Name = "timeAppointmentStart";
            timeAppointmentStart.Size = new Size(247, 23);
            timeAppointmentStart.TabIndex = 80;
            // 
            // timeAppointmentEnd
            // 
            timeAppointmentEnd.Enabled = false;
            timeAppointmentEnd.Format = DateTimePickerFormat.Time;
            timeAppointmentEnd.Location = new Point(46, 309);
            timeAppointmentEnd.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeAppointmentEnd.Name = "timeAppointmentEnd";
            timeAppointmentEnd.Size = new Size(247, 23);
            timeAppointmentEnd.TabIndex = 96;
            // 
            // comboCustomer
            // 
            comboCustomer.FormattingEnabled = true;
            comboCustomer.Location = new Point(46, 137);
            comboCustomer.Name = "comboCustomer";
            comboCustomer.Size = new Size(247, 23);
            comboCustomer.TabIndex = 98;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(47, 119);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 97;
            lblCustomer.Text = "Customer:";
            // 
            // AppointmentView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 454);
            Controls.Add(comboCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(timeAppointmentEnd);
            Controls.Add(timeAppointmentStart);
            Controls.Add(panelNotesAppointmentAll);
            Controls.Add(btnAppointmentEditSave);
            Controls.Add(btnBack);
            Controls.Add(panelNotesAppointmentNewEdit);
            Controls.Add(lblGroomyAppointment);
            Controls.Add(fieldAppointmentID);
            Controls.Add(lblAppointmentID);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(lblEndTime);
            Controls.Add(lblStartTime);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Name = "AppointmentView";
            Text = "AppointmentView";
            panelNotesAppointmentAll.ResumeLayout(false);
            panelNotesAppointmentAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentNotesDataGridView).EndInit();
            panelNotesAppointmentNewEdit.ResumeLayout(false);
            panelNotesAppointmentNewEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelNotesAppointmentAll;
        private Button btnNotesAppointmentDelete;
        private Button btnNotesAppointmentView;
        private Button btnNotesAppointmentNew;
        private DataGridView appointmentNotesDataGridView;
        private Label lblNotes;
        private Button btnAppointmentEditSave;
        private Button btnBack;
        private Panel panelNotesAppointmentNewEdit;
        private Label fieldNotesAppointmentNoteID;
        private Label lblNotesAppointmentNoteID;
        private DateTimePicker timeNotesAppointmentCreateDate;
        private Button btnAppointmentNotesEditSave;
        private Button btnAppointmentNotesBack;
        private Label lblNotesAppointmentCreateDate;
        private TextBox txtNotesAppointmentPayload;
        private Label lblNotesAppointmentPayload;
        private TextBox txtNotesAppointmentTitle;
        private Label lblNotesAppointmentTitle;
        private Label lblGroomyAppointment;
        private Label fieldAppointmentID;
        private Label lblAppointmentID;
        private TextBox txtLocation;
        private Label lblAddress;
        private TextBox txtPN;
        private Label lblEndTime;
        private TextBox txtEmail;
        private Label lblStartTime;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtTitle;
        private Label lblTitle;
        private DateTimePicker timeAppointmentStart;
        private DateTimePicker timeAppointmentEnd;
        private Label lblLocation;
        private ComboBox comboCustomer;
        private Label lblCustomer;
    }
}