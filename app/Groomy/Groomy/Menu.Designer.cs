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
            btnServices = new Label();
            btnAppointment = new Label();
            btnCustomers = new Label();
            btnWelcome = new Label();
            apptPanel = new Panel();
            apptView = new DataGridView();
            apptDel = new Button();
            btnAppointmentView = new Button();
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
            panelServices = new Panel();
            btnServiceView = new Button();
            dataServices = new DataGridView();
            btnServiceDelete = new Button();
            btnServiceNew = new Button();
            lblServices = new Label();
            panel1.SuspendLayout();
            apptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apptView).BeginInit();
            panelWelcome.SuspendLayout();
            panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataServices).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(btnServices);
            panel1.Controls.Add(btnAppointment);
            panel1.Controls.Add(btnCustomers);
            panel1.Controls.Add(btnWelcome);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.FromArgb(29, 129, 175);
            btnServices.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnServices.ForeColor = Color.White;
            btnServices.Location = new Point(0, 207);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(216, 44);
            btnServices.TabIndex = 23;
            btnServices.Text = "Services";
            btnServices.TextAlign = ContentAlignment.MiddleCenter;
            btnServices.Click += btnServices_Click;
            // 
            // btnAppointment
            // 
            btnAppointment.BackColor = Color.FromArgb(29, 129, 175);
            btnAppointment.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppointment.ForeColor = Color.White;
            btnAppointment.Location = new Point(0, 326);
            btnAppointment.Name = "btnAppointment";
            btnAppointment.Size = new Size(216, 44);
            btnAppointment.TabIndex = 22;
            btnAppointment.Text = "Appointments";
            btnAppointment.TextAlign = ContentAlignment.MiddleCenter;
            btnAppointment.Click += btnAppointment_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.FromArgb(29, 129, 175);
            btnCustomers.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Location = new Point(0, 267);
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
            btnWelcome.Location = new Point(0, 148);
            btnWelcome.Name = "btnWelcome";
            btnWelcome.Size = new Size(216, 44);
            btnWelcome.TabIndex = 20;
            btnWelcome.Text = "Welcome";
            btnWelcome.TextAlign = ContentAlignment.MiddleCenter;
            btnWelcome.Click += btnWelcome_Click;
            // 
            // apptPanel
            // 
            apptPanel.Controls.Add(apptView);
            apptPanel.Controls.Add(apptDel);
            apptPanel.Controls.Add(btnAppointmentView);
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
            apptView.Location = new Point(36, 128);
            apptView.Name = "apptView";
            apptView.Size = new Size(449, 377);
            apptView.TabIndex = 42;
            // 
            // apptDel
            // 
            apptDel.BackColor = Color.FromArgb(21, 96, 130);
            apptDel.ForeColor = Color.White;
            apptDel.Location = new Point(325, 83);
            apptDel.Name = "apptDel";
            apptDel.Size = new Size(123, 23);
            apptDel.TabIndex = 41;
            apptDel.Text = "Delete Appointment";
            apptDel.UseVisualStyleBackColor = false;
            apptDel.Click += apptDel_Click;
            // 
            // btnAppointmentView
            // 
            btnAppointmentView.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentView.ForeColor = Color.White;
            btnAppointmentView.Location = new Point(196, 83);
            btnAppointmentView.Name = "btnAppointmentView";
            btnAppointmentView.Size = new Size(123, 23);
            btnAppointmentView.TabIndex = 40;
            btnAppointmentView.Text = "View Appointment";
            btnAppointmentView.UseVisualStyleBackColor = false;
            btnAppointmentView.Click += btnAppointmentView_Click;
            // 
            // apptNew
            // 
            apptNew.BackColor = Color.FromArgb(21, 96, 130);
            apptNew.ForeColor = Color.White;
            apptNew.Location = new Point(67, 83);
            apptNew.Name = "apptNew";
            apptNew.Size = new Size(123, 23);
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
            btnCustomerView.Click += btnCustomerView_Click;
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
            // panelServices
            // 
            panelServices.Controls.Add(btnServiceView);
            panelServices.Controls.Add(dataServices);
            panelServices.Controls.Add(btnServiceDelete);
            panelServices.Controls.Add(btnServiceNew);
            panelServices.Controls.Add(lblServices);
            panelServices.Location = new Point(229, 559);
            panelServices.Name = "panelServices";
            panelServices.Size = new Size(520, 553);
            panelServices.TabIndex = 39;
            // 
            // btnServiceView
            // 
            btnServiceView.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceView.ForeColor = Color.White;
            btnServiceView.Location = new Point(207, 83);
            btnServiceView.Name = "btnServiceView";
            btnServiceView.Size = new Size(103, 23);
            btnServiceView.TabIndex = 38;
            btnServiceView.Text = "View Service";
            btnServiceView.UseVisualStyleBackColor = false;
            btnServiceView.Click += btnServiceView_Click;
            // 
            // dataServices
            // 
            dataServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataServices.Location = new Point(33, 128);
            dataServices.Name = "dataServices";
            dataServices.Size = new Size(449, 377);
            dataServices.TabIndex = 37;
            // 
            // btnServiceDelete
            // 
            btnServiceDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceDelete.ForeColor = Color.White;
            btnServiceDelete.Location = new Point(316, 83);
            btnServiceDelete.Name = "btnServiceDelete";
            btnServiceDelete.Size = new Size(103, 23);
            btnServiceDelete.TabIndex = 35;
            btnServiceDelete.Text = "Delete Service";
            btnServiceDelete.UseVisualStyleBackColor = false;
            btnServiceDelete.Click += btnServiceDelete_Click;
            // 
            // btnServiceNew
            // 
            btnServiceNew.BackColor = Color.FromArgb(21, 96, 130);
            btnServiceNew.ForeColor = Color.White;
            btnServiceNew.Location = new Point(98, 83);
            btnServiceNew.Name = "btnServiceNew";
            btnServiceNew.Size = new Size(103, 23);
            btnServiceNew.TabIndex = 22;
            btnServiceNew.Text = "New Service";
            btnServiceNew.UseVisualStyleBackColor = false;
            btnServiceNew.Click += btnServiceNew_Click;
            // 
            // lblServices
            // 
            lblServices.AutoSize = true;
            lblServices.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblServices.ForeColor = Color.FromArgb(21, 96, 130);
            lblServices.Location = new Point(97, 24);
            lblServices.Name = "lblServices";
            lblServices.Size = new Size(320, 45);
            lblServices.TabIndex = 21;
            lblServices.Text = "Groomy Services";
            lblServices.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panelServices);
            Controls.Add(apptPanel);
            Controls.Add(panelCustomers);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(9999, 9999);
            MinimumSize = new Size(100, 604);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Groomy";
            panel1.ResumeLayout(false);
            apptPanel.ResumeLayout(false);
            apptPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)apptView).EndInit();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelCustomers.ResumeLayout(false);
            panelCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelServices.ResumeLayout(false);
            panelServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataServices).EndInit();
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
        private DataGridView dataGridView1;
        private Label btnAppointment;
        private Panel apptPanel;
        private DataGridView apptView;
        private Button apptDel;
        private Button btnAppointmentView;
        private Button apptNew;
        private Label label2;
        private Label label5;
        private DateTimePicker apptDate;
        private Button btnCustomerView;
        private Label btnServices;
        private Panel panelServices;
        private Button btnServiceView;
        private DataGridView dataServices;
        private Button btnServiceDelete;
        private Button btnServiceNew;
        private Label lblServices;
    }
}