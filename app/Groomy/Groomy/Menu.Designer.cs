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
            apptPanel = new Panel();
            apptView = new DataGridView();
            apptDel = new Button();
            apptEdit = new Button();
            apptNew = new Button();
            label2 = new Label();
            apptTime = new DateTimePicker();
            label4 = new Label();
            apptDate = new DateTimePicker();
            apptSave = new Button();
            apptBack = new Button();
            label3 = new Label();
            label5 = new Label();
            label9 = new Label();
            panelWelcome = new Panel();
            panelCustomers = new Panel();
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnEdit = new Button();
            btnNew = new Button();
            lblGroomyCustomers = new Label();
            panelNewCustomer = new Panel();
            btnSave = new Button();
            btnBack = new Button();
            lblNewCustomer = new Label();
            txtNotes = new TextBox();
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
            apptCusSel = new DataGridView();
            panel1.SuspendLayout();
            apptCreEdit.SuspendLayout();
            apptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apptView).BeginInit();
            panelWelcome.SuspendLayout();
            panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelNewCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apptCusSel).BeginInit();
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
            apptCreEdit.Controls.Add(apptCusSel);
            apptCreEdit.Controls.Add(apptPanel);
            apptCreEdit.Controls.Add(apptTime);
            apptCreEdit.Controls.Add(label4);
            apptCreEdit.Controls.Add(apptDate);
            apptCreEdit.Controls.Add(apptSave);
            apptCreEdit.Controls.Add(apptBack);
            apptCreEdit.Controls.Add(label3);
            apptCreEdit.Controls.Add(label5);
            apptCreEdit.Location = new Point(222, 0);
            apptCreEdit.Name = "apptCreEdit";
            apptCreEdit.Size = new Size(528, 550);
            apptCreEdit.TabIndex = 43;
            // 
            // apptPanel
            // 
            apptPanel.Controls.Add(apptView);
            apptPanel.Controls.Add(apptDel);
            apptPanel.Controls.Add(apptEdit);
            apptPanel.Controls.Add(apptNew);
            apptPanel.Controls.Add(label2);
            apptPanel.Location = new Point(4, 12);
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
            apptEdit.Click += apptEdit_Click;
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
            apptNew.Click += button3_Click;
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
            // apptTime
            // 
            apptTime.Format = DateTimePickerFormat.Time;
            apptTime.Location = new Point(88, 354);
            apptTime.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            apptTime.Name = "apptTime";
            apptTime.Size = new Size(321, 23);
            apptTime.TabIndex = 70;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 336);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 69;
            label4.Text = "Time";
            // 
            // apptDate
            // 
            apptDate.Location = new Point(88, 304);
            apptDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            apptDate.Name = "apptDate";
            apptDate.Size = new Size(321, 23);
            apptDate.TabIndex = 68;
            // 
            // apptSave
            // 
            apptSave.BackColor = Color.FromArgb(21, 96, 130);
            apptSave.ForeColor = Color.White;
            apptSave.Location = new Point(259, 71);
            apptSave.Name = "apptSave";
            apptSave.Size = new Size(103, 23);
            apptSave.TabIndex = 67;
            apptSave.Text = "Save";
            apptSave.UseVisualStyleBackColor = false;
            apptSave.Click += apptSave_Click;
            // 
            // apptBack
            // 
            apptBack.BackColor = Color.FromArgb(21, 96, 130);
            apptBack.ForeColor = Color.White;
            apptBack.Location = new Point(137, 71);
            apptBack.Name = "apptBack";
            apptBack.Size = new Size(103, 23);
            apptBack.TabIndex = 66;
            apptBack.Text = "Back";
            apptBack.UseVisualStyleBackColor = false;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 286);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 61;
            label5.Text = "Date";
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
            panelCustomers.Controls.Add(dataGridView1);
            panelCustomers.Controls.Add(btnDelete);
            panelCustomers.Controls.Add(btnEdit);
            panelCustomers.Controls.Add(btnNew);
            panelCustomers.Controls.Add(lblGroomyCustomers);
            panelCustomers.Location = new Point(227, 9);
            panelCustomers.Name = "panelCustomers";
            panelCustomers.Size = new Size(520, 553);
            panelCustomers.TabIndex = 19;
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
            btnDelete.Location = new Point(320, 87);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 23);
            btnDelete.TabIndex = 35;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(21, 96, 130);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(211, 87);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 23);
            btnEdit.TabIndex = 34;
            btnEdit.Text = "Edit Customer";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(102, 87);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(103, 23);
            btnNew.TabIndex = 22;
            btnNew.Text = "New Customer";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
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
            panelNewCustomer.Controls.Add(btnSave);
            panelNewCustomer.Controls.Add(btnBack);
            panelNewCustomer.Controls.Add(lblNewCustomer);
            panelNewCustomer.Controls.Add(txtNotes);
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
            panelNewCustomer.Location = new Point(230, 12);
            panelNewCustomer.Name = "panelNewCustomer";
            panelNewCustomer.Size = new Size(520, 550);
            panelNewCustomer.TabIndex = 36;
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
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(157, 74);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 52;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
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
            // txtNotes
            // 
            txtNotes.Location = new Point(108, 398);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(321, 70);
            txtNotes.TabIndex = 49;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(108, 380);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(41, 15);
            lblNotes.TabIndex = 48;
            lblNotes.Text = "Notes:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(108, 307);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(321, 70);
            txtAddress.TabIndex = 47;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(108, 289);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 46;
            lblAddress.Text = "Address:";
            // 
            // txtPN
            // 
            txtPN.Location = new Point(108, 263);
            txtPN.Name = "txtPN";
            txtPN.Size = new Size(321, 23);
            txtPN.TabIndex = 45;
            // 
            // lblPN
            // 
            lblPN.AutoSize = true;
            lblPN.Location = new Point(108, 245);
            lblPN.Name = "lblPN";
            lblPN.Size = new Size(91, 15);
            lblPN.TabIndex = 44;
            lblPN.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(108, 219);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(321, 23);
            txtEmail.TabIndex = 43;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(108, 201);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 42;
            lblEmail.Text = "Email:";
            // 
            // txtLast
            // 
            txtLast.Location = new Point(108, 175);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(321, 23);
            txtLast.TabIndex = 41;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(108, 157);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(66, 15);
            lblLast.TabIndex = 40;
            lblLast.Text = "Last Name:";
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(108, 131);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(321, 23);
            txtFirst.TabIndex = 39;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(108, 113);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(67, 15);
            lblFirst.TabIndex = 38;
            lblFirst.Text = "First Name:";
            // 
            // apptCusSel
            // 
            apptCusSel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptCusSel.Location = new Point(88, 104);
            apptCusSel.Name = "apptCusSel";
            apptCusSel.Size = new Size(321, 150);
            apptCusSel.TabIndex = 71;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(apptCreEdit);
            Controls.Add(panelCustomers);
            Controls.Add(panelNewCustomer);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "Menu";
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
            ((System.ComponentModel.ISupportInitialize)apptCusSel).EndInit();
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
        private Button btnEdit;
        private Panel panelNewCustomer;
        private TextBox txtNotes;
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
        private Label label4;
        private DateTimePicker apptTime;
        private DataGridView apptCusSel;
    }
}