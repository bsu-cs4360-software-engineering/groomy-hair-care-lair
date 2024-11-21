namespace Groomy
{
    partial class Menu
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
            panel1 = new Panel();
            btnAppointment = new Label();
            btnCustomers = new Label();
            btnWelcome = new Label();
            apptCreEdit = new Panel();
            fieldAppointmentID = new Label();
            lblAppointmentID = new Label();
            comboCustomer = new ComboBox();
            lblCustomer = new Label();
            txtApptNotes = new TextBox();
            lblApptNotes = new Label();
            label1 = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            lblLocation = new Label();
            txtLocation = new TextBox();
            timeEnd = new DateTimePicker();
            lblEndTime = new Label();
            txtDescription = new TextBox();
            timeStart = new DateTimePicker();
            lblStartTime = new Label();
            apptSave = new Button();
            apptBack = new Button();
            label3 = new Label();
            apptPanel = new Panel();
            apptView = new DataGridView();
            apptDel = new Button();
            apptEdit = new Button();
            apptNew = new Button();
            label2 = new Label();
            label9 = new Label();
            panelWelcome = new Panel();
            panelCustomers = new Panel();
            btnCustomerView = new Button();
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnNew = new Button();
            lblGroomyCustomers = new Label();
            panelNewCustomer = new Panel();
            fieldCustomerID = new Label();
            lblCustomerID = new Label();
            btnSave = new Button();
            btnBack = new Button();
            lblNewCustomer = new Label();
            txtCustomerNotes = new TextBox();
            lblNotes = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPN = new TextBox();
            lblPN = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtLast = new TextBox();
            lblLast = new Label();
            txtFirst = new TextBox();
            lblFirst = new Label();
            panel1.SuspendLayout();
            apptCreEdit.SuspendLayout();
            apptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apptView).BeginInit();
            panelWelcome.SuspendLayout();
            panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelNewCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(btnAppointment);
            panel1.Controls.Add(btnCustomers);
            panel1.Controls.Add(btnWelcome);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
            // 
            // btnAppointment
            // 
            btnAppointment.BackColor = Color.FromArgb(29, 129, 175);
            btnAppointment.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppointment.ForeColor = Color.White;
            btnAppointment.Location = new Point(0, 320);
            btnAppointment.Name = "btnAppointment";
            btnAppointment.Size = new Size(216, 44);
            btnAppointment.TabIndex = 22;
            btnAppointment.Text = "Appointments";
            btnAppointment.TextAlign = ContentAlignment.MiddleCenter;
            btnAppointment.Click += label1_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.FromArgb(29, 129, 175);
            btnCustomers.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Location = new Point(0, 261);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(216, 44);
            btnCustomers.TabIndex = 21;
            btnCustomers.Text = "Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleCenter;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnWelcome
            // 
            btnWelcome.BackColor = Color.FromArgb(29, 129, 175);
            btnWelcome.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWelcome.ForeColor = Color.White;
            btnWelcome.Location = new Point(0, 200);
            btnWelcome.Name = "btnWelcome";
            btnWelcome.Size = new Size(216, 44);
            btnWelcome.TabIndex = 20;
            btnWelcome.Text = "Welcome";
            btnWelcome.TextAlign = ContentAlignment.MiddleCenter;
            btnWelcome.Click += btnWelcome_Click;
            // 
            // apptCreEdit
            // 
            apptCreEdit.Controls.Add(fieldAppointmentID);
            apptCreEdit.Controls.Add(lblAppointmentID);
            apptCreEdit.Controls.Add(comboCustomer);
            apptCreEdit.Controls.Add(lblCustomer);
            apptCreEdit.Controls.Add(txtApptNotes);
            apptCreEdit.Controls.Add(lblApptNotes);
            apptCreEdit.Controls.Add(label1);
            apptCreEdit.Controls.Add(txtTitle);
            apptCreEdit.Controls.Add(lblDescription);
            apptCreEdit.Controls.Add(lblLocation);
            apptCreEdit.Controls.Add(txtLocation);
            apptCreEdit.Controls.Add(timeEnd);
            apptCreEdit.Controls.Add(lblEndTime);
            apptCreEdit.Controls.Add(txtDescription);
            apptCreEdit.Controls.Add(timeStart);
            apptCreEdit.Controls.Add(lblStartTime);
            apptCreEdit.Controls.Add(apptSave);
            apptCreEdit.Controls.Add(apptBack);
            apptCreEdit.Controls.Add(label3);
            apptCreEdit.Location = new Point(1281, 577);
            apptCreEdit.Name = "apptCreEdit";
            apptCreEdit.Size = new Size(528, 550);
            apptCreEdit.TabIndex = 43;
            // 
            // fieldAppointmentID
            // 
            fieldAppointmentID.AutoSize = true;
            fieldAppointmentID.Location = new Point(98, 508);
            fieldAppointmentID.Name = "fieldAppointmentID";
            fieldAppointmentID.Size = new Size(87, 15);
            fieldAppointmentID.TabIndex = 85;
            fieldAppointmentID.Text = "appointmentID";
            // 
            // lblAppointmentID
            // 
            lblAppointmentID.AutoSize = true;
            lblAppointmentID.Location = new Point(98, 491);
            lblAppointmentID.Name = "lblAppointmentID";
            lblAppointmentID.Size = new Size(92, 15);
            lblAppointmentID.TabIndex = 84;
            lblAppointmentID.Text = "AppointmentID:";
            // 
            // comboCustomer
            // 
            comboCustomer.FormattingEnabled = true;
            comboCustomer.Location = new Point(97, 98);
            comboCustomer.Name = "comboCustomer";
            comboCustomer.Size = new Size(321, 23);
            comboCustomer.TabIndex = 83;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(98, 80);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 82;
            lblCustomer.Text = "Customer:";
            // 
            // txtApptNotes
            // 
            txtApptNotes.Location = new Point(97, 410);
            txtApptNotes.Multiline = true;
            txtApptNotes.Name = "txtApptNotes";
            txtApptNotes.Size = new Size(321, 71);
            txtApptNotes.TabIndex = 80;
            // 
            // lblApptNotes
            // 
            lblApptNotes.AutoSize = true;
            lblApptNotes.Location = new Point(97, 392);
            lblApptNotes.Name = "lblApptNotes";
            lblApptNotes.Size = new Size(41, 15);
            lblApptNotes.TabIndex = 79;
            lblApptNotes.Text = "Notes:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 124);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 78;
            label1.Text = "Title:";
            label1.Click += label1_Click_1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(97, 142);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(321, 23);
            txtTitle.TabIndex = 77;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(97, 168);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 15);
            lblDescription.TabIndex = 76;
            lblDescription.Text = "Description:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(97, 300);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(56, 15);
            lblLocation.TabIndex = 75;
            lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(97, 318);
            txtLocation.Multiline = true;
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(321, 71);
            txtLocation.TabIndex = 74;
            // 
            // timeEnd
            // 
            timeEnd.Format = DateTimePickerFormat.Time;
            timeEnd.Location = new Point(97, 274);
            timeEnd.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeEnd.Name = "timeEnd";
            timeEnd.Size = new Size(321, 23);
            timeEnd.TabIndex = 73;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(97, 256);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(59, 15);
            lblEndTime.TabIndex = 72;
            lblEndTime.Text = "End Time:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(97, 186);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(321, 23);
            txtDescription.TabIndex = 71;
            // 
            // timeStart
            // 
            timeStart.Format = DateTimePickerFormat.Time;
            timeStart.Location = new Point(97, 230);
            timeStart.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeStart.Name = "timeStart";
            timeStart.Size = new Size(321, 23);
            timeStart.TabIndex = 70;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(97, 212);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(63, 15);
            lblStartTime.TabIndex = 69;
            lblStartTime.Text = "Start Time:";
            // 
            // apptSave
            // 
            apptSave.BackColor = Color.FromArgb(21, 96, 130);
            apptSave.ForeColor = Color.White;
            apptSave.Location = new Point(259, 53);
            apptSave.Name = "apptSave";
            apptSave.Size = new Size(103, 23);
            apptSave.TabIndex = 67;
            apptSave.Text = "Save";
            apptSave.UseVisualStyleBackColor = false;
            apptSave.Click += btnSaveAppointment_Click;
            // 
            // apptBack
            // 
            apptBack.BackColor = Color.FromArgb(21, 96, 130);
            apptBack.ForeColor = Color.White;
            apptBack.Location = new Point(137, 53);
            apptBack.Name = "apptBack";
            apptBack.Size = new Size(103, 23);
            apptBack.TabIndex = 66;
            apptBack.Text = "Back";
            apptBack.UseVisualStyleBackColor = false;
            apptBack.Click += apptBack_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(21, 96, 130);
            label3.Location = new Point(44, 9);
            label3.Name = "label3";
            label3.Size = new Size(448, 45);
            label3.TabIndex = 65;
            label3.Text = "Create/Edit Appointment";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // apptPanel
            // 
            apptPanel.Controls.Add(apptView);
            apptPanel.Controls.Add(apptDel);
            apptPanel.Controls.Add(apptEdit);
            apptPanel.Controls.Add(apptNew);
            apptPanel.Controls.Add(label2);
            apptPanel.Location = new Point(1281, 18);
            apptPanel.Name = "apptPanel";
            apptPanel.Size = new Size(521, 553);
            apptPanel.TabIndex = 38;
            // 
            // apptView
            // 
            apptView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptView.Location = new Point(36, 140);
            apptView.Name = "apptView";
            apptView.Size = new Size(449, 377);
            apptView.TabIndex = 42;
            // 
            // apptDel
            // 
            apptDel.BackColor = Color.FromArgb(21, 96, 130);
            apptDel.ForeColor = Color.White;
            apptDel.Location = new Point(345, 99);
            apptDel.Name = "apptDel";
            apptDel.Size = new Size(140, 23);
            apptDel.TabIndex = 41;
            apptDel.Text = "Delete Appointment";
            apptDel.UseVisualStyleBackColor = false;
            apptDel.Click += apptDel_Click;
            // 
            // apptEdit
            // 
            apptEdit.BackColor = Color.FromArgb(21, 96, 130);
            apptEdit.ForeColor = Color.White;
            apptEdit.Location = new Point(192, 99);
            apptEdit.Name = "apptEdit";
            apptEdit.Size = new Size(140, 23);
            apptEdit.TabIndex = 40;
            apptEdit.Text = "Edit Appointment";
            apptEdit.UseVisualStyleBackColor = false;
            apptEdit.Click += btnEditAppointment_Click;
            // 
            // apptNew
            // 
            apptNew.BackColor = Color.FromArgb(21, 96, 130);
            apptNew.ForeColor = Color.White;
            apptNew.Location = new Point(36, 99);
            apptNew.Name = "apptNew";
            apptNew.Size = new Size(140, 23);
            apptNew.TabIndex = 39;
            apptNew.Text = "New Appointment";
            apptNew.UseVisualStyleBackColor = false;
            apptNew.Click += btnNewAppointment_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(21, 96, 130);
            label2.Location = new Point(56, 24);
            label2.Name = "label2";
            label2.Size = new Size(410, 45);
            label2.TabIndex = 38;
            label2.Text = "Groomy Appointments";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(21, 96, 130);
            label9.Location = new Point(33, 24);
            label9.Name = "label9";
            label9.Size = new Size(449, 180);
            label9.TabIndex = 16;
            label9.Text = "Welcome to\r\n Groomy!";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelWelcome
            // 
            panelWelcome.Controls.Add(label9);
            panelWelcome.Location = new Point(227, 12);
            panelWelcome.Name = "panelWelcome";
            panelWelcome.Size = new Size(520, 541);
            panelWelcome.TabIndex = 18;
            // 
            // panelCustomers
            // 
            panelCustomers.Controls.Add(btnCustomerView);
            panelCustomers.Controls.Add(dataGridView1);
            panelCustomers.Controls.Add(btnDelete);
            panelCustomers.Controls.Add(btnNew);
            panelCustomers.Controls.Add(lblGroomyCustomers);
            panelCustomers.Location = new Point(755, 18);
            panelCustomers.Name = "panelCustomers";
            panelCustomers.Size = new Size(520, 553);
            panelCustomers.TabIndex = 19;
            // 
            // btnCustomerView
            // 
            btnCustomerView.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerView.ForeColor = Color.White;
            btnCustomerView.Location = new Point(207, 83);
            btnCustomerView.Name = "btnCustomerView";
            btnCustomerView.Size = new Size(103, 23);
            btnCustomerView.TabIndex = 38;
            btnCustomerView.Text = "View Customer";
            btnCustomerView.UseVisualStyleBackColor = false;
            btnCustomerView.Click += btnCustomerView_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(449, 377);
            dataGridView1.TabIndex = 37;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(316, 83);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 23);
            btnDelete.TabIndex = 35;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDeleteCustomer_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(98, 83);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(103, 23);
            btnNew.TabIndex = 22;
            btnNew.Text = "New Customer";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnCustomerNew_Click;
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.AutoSize = true;
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(83, 24);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(356, 45);
            lblGroomyCustomers.TabIndex = 21;
            lblGroomyCustomers.Text = "Groomy Customers";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelNewCustomer
            // 
            panelNewCustomer.AllowDrop = true;
            panelNewCustomer.Controls.Add(fieldCustomerID);
            panelNewCustomer.Controls.Add(lblCustomerID);
            panelNewCustomer.Controls.Add(btnSave);
            panelNewCustomer.Controls.Add(btnBack);
            panelNewCustomer.Controls.Add(lblNewCustomer);
            panelNewCustomer.Controls.Add(txtCustomerNotes);
            panelNewCustomer.Controls.Add(lblNotes);
            panelNewCustomer.Controls.Add(txtAddress);
            panelNewCustomer.Controls.Add(lblAddress);
            panelNewCustomer.Controls.Add(txtPN);
            panelNewCustomer.Controls.Add(lblPN);
            panelNewCustomer.Controls.Add(txtEmail);
            panelNewCustomer.Controls.Add(lblEmail);
            panelNewCustomer.Controls.Add(txtLast);
            panelNewCustomer.Controls.Add(lblLast);
            panelNewCustomer.Controls.Add(txtFirst);
            panelNewCustomer.Controls.Add(lblFirst);
            panelNewCustomer.Location = new Point(227, 12);
            panelNewCustomer.Name = "panelNewCustomer";
            panelNewCustomer.Size = new Size(520, 550);
            panelNewCustomer.TabIndex = 36;
            // 
            // fieldCustomerID
            // 
            fieldCustomerID.AutoSize = true;
            fieldCustomerID.Location = new Point(108, 479);
            fieldCustomerID.Name = "fieldCustomerID";
            fieldCustomerID.Size = new Size(68, 15);
            fieldCustomerID.TabIndex = 56;
            fieldCustomerID.Text = "customerID";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(108, 464);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(76, 15);
            lblCustomerID.TabIndex = 54;
            lblCustomerID.Text = "Customer ID:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(21, 96, 130);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(266, 72);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 53;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSaveCustomer_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(157, 72);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 52;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBackToCustomers_Click;
            // 
            // lblNewCustomer
            // 
            lblNewCustomer.AutoSize = true;
            lblNewCustomer.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblNewCustomer.ForeColor = Color.FromArgb(21, 96, 130);
            lblNewCustomer.Location = new Point(83, 24);
            lblNewCustomer.Name = "lblNewCustomer";
            lblNewCustomer.Size = new Size(393, 45);
            lblNewCustomer.TabIndex = 50;
            lblNewCustomer.Text = "Create/Edit Customer";
            lblNewCustomer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCustomerNotes
            // 
            txtCustomerNotes.Location = new Point(108, 391);
            txtCustomerNotes.Multiline = true;
            txtCustomerNotes.Name = "txtCustomerNotes";
            txtCustomerNotes.Size = new Size(321, 70);
            txtCustomerNotes.TabIndex = 49;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(108, 373);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(41, 15);
            lblNotes.TabIndex = 48;
            lblNotes.Text = "Notes:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(108, 300);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(321, 70);
            txtAddress.TabIndex = 47;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(108, 282);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 46;
            lblAddress.Text = "Address:";
            // 
            // txtPN
            // 
            txtPN.Location = new Point(108, 256);
            txtPN.Name = "txtPN";
            txtPN.Size = new Size(321, 23);
            txtPN.TabIndex = 45;
            // 
            // lblPN
            // 
            lblPN.AutoSize = true;
            lblPN.Location = new Point(108, 238);
            lblPN.Name = "lblPN";
            lblPN.Size = new Size(91, 15);
            lblPN.TabIndex = 44;
            lblPN.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(108, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(321, 23);
            txtEmail.TabIndex = 43;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(108, 194);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 42;
            lblEmail.Text = "Email:";
            // 
            // txtLast
            // 
            txtLast.Location = new Point(108, 168);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(321, 23);
            txtLast.TabIndex = 41;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(108, 150);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(66, 15);
            lblLast.TabIndex = 40;
            lblLast.Text = "Last Name:";
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(108, 124);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(321, 23);
            txtFirst.TabIndex = 39;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(108, 106);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(67, 15);
            lblFirst.TabIndex = 38;
            lblFirst.Text = "First Name:";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(apptPanel);
            Controls.Add(apptCreEdit);
            Controls.Add(panelCustomers);
            Controls.Add(panelNewCustomer);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(9999, 9999);
            MinimumSize = new Size(100, 604);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Groomy";
            Load += Menu_Load;
            panel1.ResumeLayout(false);
            apptCreEdit.ResumeLayout(false);
            apptCreEdit.PerformLayout();
            apptPanel.ResumeLayout(false);
            apptPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)apptView).EndInit();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelCustomers.ResumeLayout(false);
            panelCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelNewCustomer.ResumeLayout(false);
            panelNewCustomer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label9;
        private Label btnWelcome;
        private Label btnCustomers;
        private Panel panelWelcome;
        private Panel panelCustomers;
        private Button btnNew;
        private Label lblGroomyCustomers;
        private Button btnDelete;
        private Panel panelNewCustomer;
        private TextBox txtCustomerNotes;
        private Label lblNotes;
        private TextBox txtAddress;
        private Label lblAddress;
        private TextBox txtPN;
        private Label lblPN;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtLast;
        private Label lblLast;
        private TextBox txtFirst;
        private Label lblFirst;
        private Label lblNewCustomer;
        private Button btnSave;
        private Button btnBack;
        private DataGridView dataGridView1;
        private Label btnAppointment;
        private Panel apptPanel;
        private DataGridView apptView;
        private Button apptDel;
        private Button apptEdit;
        private Button apptNew;
        private Label label2;
        private Panel apptCreEdit;
        private Button apptBack;
        private Label label3;
        private Label label5;
        private Button apptSave;
        private DateTimePicker apptDate;
        private Label lblStartTime;
        private DateTimePicker timeStart;
        private TextBox txtDescription;
        private DateTimePicker timeEnd;
        private Label lblEndTime;
        private Label lblDescription;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label label1;
        private TextBox txtTitle;
        private TextBox txtApptNotes;
        private Label lblApptNotes;
        private Label lblCustomer;
        private ComboBox comboCustomer;
        private Label fieldAppointmentID;
        private Label lblAppointmentID;
        private Label fieldCustomerID;
        private Label lblCustomerID;
        private Button btnCustomerView;
    }
}