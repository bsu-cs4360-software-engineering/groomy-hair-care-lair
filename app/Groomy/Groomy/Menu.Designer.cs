﻿namespace Groomy
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
            btnInvoices = new Label();
            btnServices = new Label();
            btnAppointment = new Label();
            btnCustomers = new Label();
            btnWelcome = new Label();
            apptPanel = new Panel();
            dataAppointments = new DataGridView();
            btnAppointmentDelete = new Button();
            btnAppointmentView = new Button();
            btnAppointmentNew = new Button();
            label2 = new Label();
            label9 = new Label();
            panelWelcome = new Panel();
            panelCustomers = new Panel();
            btnCustomerView = new Button();
            dataCustomers = new DataGridView();
            btnCustomerDelete = new Button();
            btnCustomerNew = new Button();
            lblGroomyCustomers = new Label();
            panelServices = new Panel();
            btnServiceView = new Button();
            dataServices = new DataGridView();
            btnServiceDelete = new Button();
            btnServiceNew = new Button();
            lblServices = new Label();
            panelInvoices = new Panel();
            btnInvoiceView = new Button();
            btnInvoiceDelete = new Button();
            btnInvoiceNew = new Button();
            dataInvoices = new DataGridView();
            label1 = new Label();
            btnPrintInvoice = new Button();
            panel1.SuspendLayout();
            apptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataAppointments).BeginInit();
            panelWelcome.SuspendLayout();
            panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomers).BeginInit();
            panelServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataServices).BeginInit();
            panelInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataInvoices).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(btnInvoices);
            panel1.Controls.Add(btnServices);
            panel1.Controls.Add(btnAppointment);
            panel1.Controls.Add(btnCustomers);
            panel1.Controls.Add(btnWelcome);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = Color.FromArgb(29, 129, 175);
            btnInvoices.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInvoices.ForeColor = Color.White;
            btnInvoices.Location = new Point(0, 382);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Size = new Size(216, 44);
            btnInvoices.TabIndex = 24;
            btnInvoices.Text = "Invoices";
            btnInvoices.TextAlign = ContentAlignment.MiddleCenter;
            btnInvoices.Click += btnInvoices_Click;
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
            apptPanel.Controls.Add(dataAppointments);
            apptPanel.Controls.Add(btnAppointmentDelete);
            apptPanel.Controls.Add(btnAppointmentView);
            apptPanel.Controls.Add(btnAppointmentNew);
            apptPanel.Controls.Add(label2);
            apptPanel.Location = new Point(1281, 18);
            apptPanel.Name = "apptPanel";
            apptPanel.Size = new Size(521, 553);
            apptPanel.TabIndex = 38;
            // 
            // dataAppointments
            // 
            dataAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAppointments.Location = new Point(36, 128);
            dataAppointments.Name = "dataAppointments";
            dataAppointments.Size = new Size(449, 377);
            dataAppointments.TabIndex = 42;
            // 
            // apptDel
            // 
            btnAppointmentDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentDelete.ForeColor = Color.White;
            btnAppointmentDelete.Location = new Point(325, 83);
            btnAppointmentDelete.Name = "apptDel";
            btnAppointmentDelete.Size = new Size(123, 23);
            btnAppointmentDelete.TabIndex = 41;
            btnAppointmentDelete.Text = "Delete Appointment";
            btnAppointmentDelete.UseVisualStyleBackColor = false;
            btnAppointmentDelete.Click += apptDel_Click;
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
            btnAppointmentNew.BackColor = Color.FromArgb(21, 96, 130);
            btnAppointmentNew.ForeColor = Color.White;
            btnAppointmentNew.Location = new Point(67, 83);
            btnAppointmentNew.Name = "apptNew";
            btnAppointmentNew.Size = new Size(123, 23);
            btnAppointmentNew.TabIndex = 39;
            btnAppointmentNew.Text = "New Appointment";
            btnAppointmentNew.UseVisualStyleBackColor = false;
            btnAppointmentNew.Click += btnNewAppointment_Click;
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
            panelCustomers.Controls.Add(dataCustomers);
            panelCustomers.Controls.Add(btnCustomerDelete);
            panelCustomers.Controls.Add(btnCustomerNew);
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
            // dataCustomers
            // 
            dataCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCustomers.Location = new Point(33, 128);
            dataCustomers.Name = "dataCustomers";
            dataCustomers.Size = new Size(449, 377);
            dataCustomers.TabIndex = 37;
            // 
            // btnDelete
            // 
            btnCustomerDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerDelete.ForeColor = Color.White;
            btnCustomerDelete.Location = new Point(316, 83);
            btnCustomerDelete.Name = "btnDelete";
            btnCustomerDelete.Size = new Size(103, 23);
            btnCustomerDelete.TabIndex = 35;
            btnCustomerDelete.Text = "Delete Customer";
            btnCustomerDelete.UseVisualStyleBackColor = false;
            btnCustomerDelete.Click += btnDeleteCustomer_Click;
            // 
            // btnNew
            // 
            btnCustomerNew.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerNew.ForeColor = Color.White;
            btnCustomerNew.Location = new Point(98, 83);
            btnCustomerNew.Name = "btnNew";
            btnCustomerNew.Size = new Size(103, 23);
            btnCustomerNew.TabIndex = 22;
            btnCustomerNew.Text = "New Customer";
            btnCustomerNew.UseVisualStyleBackColor = false;
            btnCustomerNew.Click += btnCustomerNew_Click;
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
            // panelInvoices
            // 
            panelInvoices.Controls.Add(btnPrintInvoice);
            panelInvoices.Controls.Add(btnInvoiceView);
            panelInvoices.Controls.Add(btnInvoiceDelete);
            panelInvoices.Controls.Add(btnInvoiceNew);
            panelInvoices.Controls.Add(dataInvoices);
            panelInvoices.Controls.Add(label1);
            panelInvoices.Location = new Point(755, 577);
            panelInvoices.Name = "panelInvoices";
            panelInvoices.Size = new Size(520, 553);
            panelInvoices.TabIndex = 40;
            // 
            // btnInvoiceView
            // 
            btnInvoiceView.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceView.ForeColor = Color.White;
            btnInvoiceView.Location = new Point(152, 86);
            btnInvoiceView.Name = "btnInvoiceView";
            btnInvoiceView.Size = new Size(103, 23);
            btnInvoiceView.TabIndex = 41;
            btnInvoiceView.Text = "View Invoice";
            btnInvoiceView.UseVisualStyleBackColor = false;
            btnInvoiceView.Click += btnInvoiceView_Click;
            // 
            // btnInvoiceDelete
            // 
            btnInvoiceDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceDelete.ForeColor = Color.White;
            btnInvoiceDelete.Location = new Point(370, 86);
            btnInvoiceDelete.Name = "btnInvoiceDelete";
            btnInvoiceDelete.Size = new Size(103, 23);
            btnInvoiceDelete.TabIndex = 40;
            btnInvoiceDelete.Text = "Delete Invoice";
            btnInvoiceDelete.UseVisualStyleBackColor = false;
            btnInvoiceDelete.Click += btnInvoiceDelete_Click;
            // 
            // btnInvoiceNew
            // 
            btnInvoiceNew.BackColor = Color.FromArgb(21, 96, 130);
            btnInvoiceNew.ForeColor = Color.White;
            btnInvoiceNew.Location = new Point(43, 86);
            btnInvoiceNew.Name = "btnInvoiceNew";
            btnInvoiceNew.Size = new Size(103, 23);
            btnInvoiceNew.TabIndex = 39;
            btnInvoiceNew.Text = "New Invoice";
            btnInvoiceNew.UseVisualStyleBackColor = false;
            btnInvoiceNew.Click += btnInvoiceNew_Click;
            // 
            // dataInvoices
            // 
            dataInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataInvoices.Location = new Point(33, 128);
            dataInvoices.Name = "dataInvoices";
            dataInvoices.Size = new Size(449, 377);
            dataInvoices.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(21, 96, 130);
            label1.Location = new Point(83, 24);
            label1.Name = "label1";
            label1.Size = new Size(312, 45);
            label1.TabIndex = 21;
            label1.Text = "Groomy Invoices";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.BackColor = Color.FromArgb(21, 96, 130);
            btnPrintInvoice.ForeColor = Color.White;
            btnPrintInvoice.Location = new Point(261, 86);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(103, 23);
            btnPrintInvoice.TabIndex = 42;
            btnPrintInvoice.Text = "Print Invoice";
            btnPrintInvoice.UseVisualStyleBackColor = false;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panelInvoices);
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
            ((System.ComponentModel.ISupportInitialize)dataAppointments).EndInit();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelCustomers.ResumeLayout(false);
            panelCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomers).EndInit();
            panelServices.ResumeLayout(false);
            panelServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataServices).EndInit();
            panelInvoices.ResumeLayout(false);
            panelInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataInvoices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label9;
        private Label btnWelcome;
        private Label btnCustomers;
        private Panel panelWelcome;
        private Panel panelCustomers;
        private Button btnCustomerNew;
        private Label lblGroomyCustomers;
        private Button btnCustomerDelete;
        private DataGridView dataCustomers;
        private Label btnAppointment;
        private Panel apptPanel;
        private DataGridView dataAppointments;
        private Button btnAppointmentDelete;
        private Button btnAppointmentView;
        private Button btnAppointmentNew;
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
        private Panel panelInvoices;
        private Button btnGenInv;
        private DataGridView dataInvoices;
        private Label label1;
        private Label btnInvoices;
        private Button btnInvoiceView;
        private Button btnInvoiceDelete;
        private Button btnInvoiceNew;
        private Button btnPrintInvoice;
    }
}