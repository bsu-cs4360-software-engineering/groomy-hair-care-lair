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
            btnCustomers = new Label();
            btnWelcome = new Label();
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
            panel1.SuspendLayout();
            panelWelcome.SuspendLayout();
            panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelNewCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(btnCustomers);
            panel1.Controls.Add(btnWelcome);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
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
            btnDelete.Location = new Point(320, 87);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 23);
            btnDelete.TabIndex = 35;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(211, 87);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 23);
            btnEdit.TabIndex = 34;
            btnEdit.Text = "Edit Customer";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(102, 87);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(103, 23);
            btnNew.TabIndex = 22;
            btnNew.Text = "New Customer";
            btnNew.UseVisualStyleBackColor = true;
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
            btnSave.Location = new Point(266, 72);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 53;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(157, 74);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 52;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
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
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(panelCustomers);
            Controls.Add(panelNewCustomer);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "Menu";
            Text = "Groomy";
            panel1.ResumeLayout(false);
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
    }
}