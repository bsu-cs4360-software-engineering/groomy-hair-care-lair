namespace Groomy
{
    partial class Tabs
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabs));
            tabControl1 = new TabControl();
            welcomeTab = new TabPage();
            label3 = new Label();
            label2 = new Label();
            customersTab = new TabPage();
            button1 = new Button();
            bttnNewCus = new Button();
            cusDataView = new DataGridView();
            lblGroomyCustomers = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            appointmentsTab = new TabPage();
            btnNewAppt = new Button();
            apptDataView = new DataGridView();
            label1 = new Label();
            btnApptDel = new Button();
            btnEditAppt = new Button();
            refreshTimer = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            welcomeTab.SuspendLayout();
            customersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cusDataView).BeginInit();
            appointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apptDataView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(welcomeTab);
            tabControl1.Controls.Add(customersTab);
            tabControl1.Controls.Add(appointmentsTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.ItemSize = new Size(40, 250);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1204, 700);
            tabControl1.TabIndex = 0;
            tabControl1.DrawItem += tabControl1_DrawItem;
            // 
            // welcomeTab
            // 
            welcomeTab.BackColor = Color.White;
            welcomeTab.Controls.Add(label3);
            welcomeTab.Controls.Add(label2);
            welcomeTab.Location = new Point(254, 4);
            welcomeTab.Name = "welcomeTab";
            welcomeTab.Padding = new Padding(3);
            welcomeTab.Size = new Size(946, 692);
            welcomeTab.TabIndex = 0;
            welcomeTab.Text = "Welcome";
            // 
            // label3
            // 
            label3.Font = new Font("Arial Black", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(21, 96, 130);
            label3.Location = new Point(3, 48);
            label3.Name = "label3";
            label3.Size = new Size(937, 45);
            label3.TabIndex = 41;
            label3.Text = "To get started, select a tab on the left-hand side";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(21, 96, 130);
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(937, 45);
            label2.TabIndex = 40;
            label2.Text = "Welcome to Groomy!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customersTab
            // 
            customersTab.BackColor = Color.White;
            customersTab.Controls.Add(button1);
            customersTab.Controls.Add(bttnNewCus);
            customersTab.Controls.Add(cusDataView);
            customersTab.Controls.Add(lblGroomyCustomers);
            customersTab.Controls.Add(btnDelete);
            customersTab.Controls.Add(btnEdit);
            customersTab.Location = new Point(254, 4);
            customersTab.Name = "customersTab";
            customersTab.Padding = new Padding(3);
            customersTab.Size = new Size(946, 692);
            customersTab.TabIndex = 1;
            customersTab.Text = "Customers";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(21, 96, 130);
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1145, 55);
            button1.Name = "button1";
            button1.Size = new Size(43, 39);
            button1.TabIndex = 44;
            button1.Text = "🔄";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // bttnNewCus
            // 
            bttnNewCus.BackColor = Color.FromArgb(21, 96, 130);
            bttnNewCus.ForeColor = Color.White;
            bttnNewCus.Location = new Point(270, 51);
            bttnNewCus.Name = "bttnNewCus";
            bttnNewCus.Size = new Size(136, 40);
            bttnNewCus.TabIndex = 43;
            bttnNewCus.Text = "New Customer";
            bttnNewCus.UseVisualStyleBackColor = false;
            bttnNewCus.Click += button1_Click;
            // 
            // cusDataView
            // 
            cusDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cusDataView.Location = new Point(16, 97);
            cusDataView.Name = "cusDataView";
            cusDataView.Size = new Size(922, 376);
            cusDataView.TabIndex = 42;
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(6, 3);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(937, 45);
            lblGroomyCustomers.TabIndex = 39;
            lblGroomyCustomers.Text = "Groomy Customers";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(554, 51);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 40);
            btnDelete.TabIndex = 41;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(21, 96, 130);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(412, 51);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(136, 40);
            btnEdit.TabIndex = 40;
            btnEdit.Text = "Edit Customer";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // appointmentsTab
            // 
            appointmentsTab.BackColor = Color.White;
            appointmentsTab.Controls.Add(btnNewAppt);
            appointmentsTab.Controls.Add(apptDataView);
            appointmentsTab.Controls.Add(label1);
            appointmentsTab.Controls.Add(btnApptDel);
            appointmentsTab.Controls.Add(btnEditAppt);
            appointmentsTab.Location = new Point(254, 4);
            appointmentsTab.Name = "appointmentsTab";
            appointmentsTab.Size = new Size(946, 692);
            appointmentsTab.TabIndex = 2;
            appointmentsTab.Text = "Appointments";
            // 
            // btnNewAppt
            // 
            btnNewAppt.BackColor = Color.FromArgb(21, 96, 130);
            btnNewAppt.ForeColor = Color.White;
            btnNewAppt.Location = new Point(272, 53);
            btnNewAppt.Name = "btnNewAppt";
            btnNewAppt.Size = new Size(136, 40);
            btnNewAppt.TabIndex = 48;
            btnNewAppt.Text = "New Appointment";
            btnNewAppt.UseVisualStyleBackColor = false;
            btnNewAppt.Click += btnNewAppt_Click;
            // 
            // apptDataView
            // 
            apptDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptDataView.Location = new Point(14, 102);
            apptDataView.Name = "apptDataView";
            apptDataView.Size = new Size(924, 377);
            apptDataView.TabIndex = 47;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(21, 96, 130);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(943, 45);
            label1.TabIndex = 44;
            label1.Text = "Groomy Appointments";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnApptDel
            // 
            btnApptDel.BackColor = Color.FromArgb(21, 96, 130);
            btnApptDel.ForeColor = Color.White;
            btnApptDel.Location = new Point(556, 53);
            btnApptDel.Name = "btnApptDel";
            btnApptDel.Size = new Size(136, 40);
            btnApptDel.TabIndex = 46;
            btnApptDel.Text = "Delete Appointment";
            btnApptDel.UseVisualStyleBackColor = false;
            btnApptDel.Click += button3_Click;
            // 
            // btnEditAppt
            // 
            btnEditAppt.BackColor = Color.FromArgb(21, 96, 130);
            btnEditAppt.ForeColor = Color.White;
            btnEditAppt.Location = new Point(414, 53);
            btnEditAppt.Name = "btnEditAppt";
            btnEditAppt.Size = new Size(136, 40);
            btnEditAppt.TabIndex = 45;
            btnEditAppt.Text = "Edit Appointment";
            btnEditAppt.UseVisualStyleBackColor = false;
            btnEditAppt.Click += btnEditAppt_Click;
            // 
            // refreshTimer
            // 
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 2000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // Tabs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 96, 130);
            ClientSize = new Size(1204, 700);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Tabs";
            Text = "Groomy";
            Load += Tabs_Load;
            tabControl1.ResumeLayout(false);
            welcomeTab.ResumeLayout(false);
            customersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cusDataView).EndInit();
            appointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)apptDataView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage welcomeTab;
        private TabPage customersTab;
        private TabPage appointmentsTab;
        private Button bttnNewCus;
        private DataGridView cusDataView;
        private Label lblGroomyCustomers;
        private Button btnDelete;
        private Button btnEdit;
        private System.Windows.Forms.Timer refreshTimer;
        private Button button1;
        private Button btnNewAppt;
        private DataGridView apptDataView;
        private Label label1;
        private Button btnApptDel;
        private Button btnEditAppt;
        private Label label3;
        private Label label2;
    }
}