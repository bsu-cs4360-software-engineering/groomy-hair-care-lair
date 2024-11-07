namespace Groomy.DialogBoxes
{
    partial class creNewCus
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
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(21, 96, 130);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(195, 57);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 68;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(86, 59);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 67;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // lblNewCustomer
            // 
            lblNewCustomer.AutoSize = true;
            lblNewCustomer.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblNewCustomer.ForeColor = Color.FromArgb(21, 96, 130);
            lblNewCustomer.Location = new Point(12, 9);
            lblNewCustomer.Name = "lblNewCustomer";
            lblNewCustomer.Size = new Size(393, 45);
            lblNewCustomer.TabIndex = 66;
            lblNewCustomer.Text = "Create/Edit Customer";
            lblNewCustomer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(37, 383);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(321, 70);
            txtNotes.TabIndex = 65;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(37, 365);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(41, 15);
            lblNotes.TabIndex = 64;
            lblNotes.Text = "Notes:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(37, 292);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(321, 70);
            txtAddress.TabIndex = 63;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(37, 274);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 62;
            lblAddress.Text = "Address:";
            // 
            // txtPN
            // 
            txtPN.Location = new Point(37, 248);
            txtPN.Name = "txtPN";
            txtPN.Size = new Size(321, 23);
            txtPN.TabIndex = 61;
            // 
            // lblPN
            // 
            lblPN.AutoSize = true;
            lblPN.Location = new Point(37, 230);
            lblPN.Name = "lblPN";
            lblPN.Size = new Size(91, 15);
            lblPN.TabIndex = 60;
            lblPN.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(37, 204);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(321, 23);
            txtEmail.TabIndex = 59;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(37, 186);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 58;
            lblEmail.Text = "Email:";
            // 
            // txtLast
            // 
            txtLast.Location = new Point(37, 160);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(321, 23);
            txtLast.TabIndex = 57;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(37, 142);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(66, 15);
            lblLast.TabIndex = 56;
            lblLast.Text = "Last Name:";
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(37, 116);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(321, 23);
            txtFirst.TabIndex = 55;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(37, 98);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(67, 15);
            lblFirst.TabIndex = 54;
            lblFirst.Text = "First Name:";
            // 
            // creNewCus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 473);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(lblNewCustomer);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPN);
            Controls.Add(lblPN);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtLast);
            Controls.Add(lblLast);
            Controls.Add(txtFirst);
            Controls.Add(lblFirst);
            Name = "creNewCus";
            Text = "Creating a New Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnBack;
        private Label lblNewCustomer;
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
    }
}