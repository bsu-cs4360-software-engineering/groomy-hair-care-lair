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
            tabControl1 = new TabControl();
            welcomeTab = new TabPage();
            customersTab = new TabPage();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            lblGroomyCustomers = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            appointmentsTab = new TabPage();
            tabControl1.SuspendLayout();
            customersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(welcomeTab);
            tabControl1.Controls.Add(customersTab);
            tabControl1.Controls.Add(appointmentsTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1204, 700);
            tabControl1.TabIndex = 0;
            // 
            // welcomeTab
            // 
            welcomeTab.Location = new Point(4, 24);
            welcomeTab.Name = "welcomeTab";
            welcomeTab.Padding = new Padding(3);
            welcomeTab.Size = new Size(1196, 672);
            welcomeTab.TabIndex = 0;
            welcomeTab.Text = "Welcome";
            welcomeTab.UseVisualStyleBackColor = true;
            // 
            // customersTab
            // 
            customersTab.Controls.Add(button1);
            customersTab.Controls.Add(dataGridView1);
            customersTab.Controls.Add(lblGroomyCustomers);
            customersTab.Controls.Add(btnDelete);
            customersTab.Controls.Add(btnEdit);
            customersTab.Location = new Point(4, 24);
            customersTab.Name = "customersTab";
            customersTab.Padding = new Padding(3);
            customersTab.Size = new Size(1196, 672);
            customersTab.TabIndex = 1;
            customersTab.Text = "Customers";
            customersTab.UseVisualStyleBackColor = true;
            customersTab.Click += customersTab_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(21, 96, 130);
            button1.ForeColor = Color.White;
            button1.Location = new Point(399, 71);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 43;
            button1.Text = "New Customer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1180, 377);
            dataGridView1.TabIndex = 42;
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.AutoSize = true;
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(399, 3);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(356, 45);
            lblGroomyCustomers.TabIndex = 39;
            lblGroomyCustomers.Text = "Groomy Customers";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(652, 71);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 23);
            btnDelete.TabIndex = 41;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(21, 96, 130);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(526, 71);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 23);
            btnEdit.TabIndex = 40;
            btnEdit.Text = "Edit Customer";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // appointmentsTab
            // 
            appointmentsTab.Location = new Point(4, 24);
            appointmentsTab.Name = "appointmentsTab";
            appointmentsTab.Size = new Size(1196, 672);
            appointmentsTab.TabIndex = 2;
            appointmentsTab.Text = "Appointments";
            appointmentsTab.UseVisualStyleBackColor = true;
            // 
            // Tabs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 700);
            Controls.Add(tabControl1);
            Name = "Tabs";
            Text = "Groomy";
            tabControl1.ResumeLayout(false);
            customersTab.ResumeLayout(false);
            customersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage welcomeTab;
        private TabPage customersTab;
        private TabPage appointmentsTab;
        private Button button1;
        private DataGridView dataGridView1;
        private Label lblGroomyCustomers;
        private Button btnDelete;
        private Button btnEdit;
    }
}