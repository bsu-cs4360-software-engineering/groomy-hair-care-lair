namespace Groomy.Customers
{
    partial class CustomerView
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
            fieldCustomerID = new Label();
            lblCustomerID = new Label();
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
            lblGroomyCustomers = new Label();
            panelNotesCustomerNewEdit = new Panel();
            fieldNotesCustomersNoteID = new Label();
            lblNotesCustomersNoteID = new Label();
            timeNotesCustomersCreateDate = new DateTimePicker();
            btnCustomerNotesEditSave = new Button();
            btnCustomerNotesBack = new Button();
            lblNotesCustomerCreateDate = new Label();
            txtNotesCustomerPayload = new TextBox();
            lblNotesCustomerPayload = new Label();
            txtNotesCustomerTitle = new TextBox();
            lblNotesCustomerTitle = new Label();
            btnNotesCustomerDelete = new Button();
            btnNotesCustomerView = new Button();
            btnNotesCustomerNew = new Button();
            customerNotesDataGridView = new DataGridView();
            lblNotes = new Label();
            btnCustomerEditSave = new Button();
            btnBack = new Button();
            panelNotesCustomerAll = new Panel();
            panelNotesCustomerNewEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customerNotesDataGridView).BeginInit();
            panelNotesCustomerAll.SuspendLayout();
            SuspendLayout();
            // 
            // fieldCustomerID
            // 
            fieldCustomerID.AutoSize = true;
            fieldCustomerID.Location = new Point(45, 407);
            fieldCustomerID.Name = "fieldCustomerID";
            fieldCustomerID.Size = new Size(68, 15);
            fieldCustomerID.TabIndex = 70;
            fieldCustomerID.Text = "customerID";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(45, 392);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(76, 15);
            lblCustomerID.TabIndex = 69;
            lblCustomerID.Text = "Customer ID:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(45, 322);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(247, 67);
            txtAddress.TabIndex = 66;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(45, 304);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 65;
            lblAddress.Text = "Address:";
            // 
            // txtPN
            // 
            txtPN.Location = new Point(45, 278);
            txtPN.Name = "txtPN";
            txtPN.ReadOnly = true;
            txtPN.Size = new Size(247, 23);
            txtPN.TabIndex = 64;
            // 
            // lblPN
            // 
            lblPN.AutoSize = true;
            lblPN.Location = new Point(45, 260);
            lblPN.Name = "lblPN";
            lblPN.Size = new Size(91, 15);
            lblPN.TabIndex = 63;
            lblPN.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(45, 234);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(247, 23);
            txtEmail.TabIndex = 62;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(45, 216);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 61;
            lblEmail.Text = "Email:";
            // 
            // txtLast
            // 
            txtLast.Location = new Point(45, 190);
            txtLast.Name = "txtLast";
            txtLast.ReadOnly = true;
            txtLast.Size = new Size(247, 23);
            txtLast.TabIndex = 60;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(45, 172);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(66, 15);
            lblLast.TabIndex = 59;
            lblLast.Text = "Last Name:";
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(45, 146);
            txtFirst.Name = "txtFirst";
            txtFirst.ReadOnly = true;
            txtFirst.Size = new Size(247, 23);
            txtFirst.TabIndex = 58;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(45, 128);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(67, 15);
            lblFirst.TabIndex = 57;
            lblFirst.Text = "First Name:";
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.AutoSize = true;
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(202, 20);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(335, 45);
            lblGroomyCustomers.TabIndex = 71;
            lblGroomyCustomers.Text = "Groomy Customer";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelNotesCustomerNewEdit
            // 
            panelNotesCustomerNewEdit.Controls.Add(fieldNotesCustomersNoteID);
            panelNotesCustomerNewEdit.Controls.Add(lblNotesCustomersNoteID);
            panelNotesCustomerNewEdit.Controls.Add(timeNotesCustomersCreateDate);
            panelNotesCustomerNewEdit.Controls.Add(btnCustomerNotesEditSave);
            panelNotesCustomerNewEdit.Controls.Add(btnCustomerNotesBack);
            panelNotesCustomerNewEdit.Controls.Add(lblNotesCustomerCreateDate);
            panelNotesCustomerNewEdit.Controls.Add(txtNotesCustomerPayload);
            panelNotesCustomerNewEdit.Controls.Add(lblNotesCustomerPayload);
            panelNotesCustomerNewEdit.Controls.Add(txtNotesCustomerTitle);
            panelNotesCustomerNewEdit.Controls.Add(lblNotesCustomerTitle);
            panelNotesCustomerNewEdit.Location = new Point(766, 87);
            panelNotesCustomerNewEdit.Name = "panelNotesCustomerNewEdit";
            panelNotesCustomerNewEdit.Size = new Size(420, 308);
            panelNotesCustomerNewEdit.TabIndex = 72;
            // 
            // fieldNotesCustomersNoteID
            // 
            fieldNotesCustomersNoteID.AutoSize = true;
            fieldNotesCustomersNoteID.Location = new Point(84, 253);
            fieldNotesCustomersNoteID.Name = "fieldNotesCustomersNoteID";
            fieldNotesCustomersNoteID.Size = new Size(42, 15);
            fieldNotesCustomersNoteID.TabIndex = 81;
            fieldNotesCustomersNoteID.Text = "noteID";
            // 
            // lblNotesCustomersNoteID
            // 
            lblNotesCustomersNoteID.AutoSize = true;
            lblNotesCustomersNoteID.Location = new Point(82, 238);
            lblNotesCustomersNoteID.Name = "lblNotesCustomersNoteID";
            lblNotesCustomersNoteID.Size = new Size(50, 15);
            lblNotesCustomersNoteID.TabIndex = 80;
            lblNotesCustomersNoteID.Text = "Note ID:";
            // 
            // timeNotesCustomersCreateDate
            // 
            timeNotesCustomersCreateDate.Enabled = false;
            timeNotesCustomersCreateDate.Format = DateTimePickerFormat.Time;
            timeNotesCustomersCreateDate.Location = new Point(82, 59);
            timeNotesCustomersCreateDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            timeNotesCustomersCreateDate.Name = "timeNotesCustomersCreateDate";
            timeNotesCustomersCreateDate.Size = new Size(247, 23);
            timeNotesCustomersCreateDate.TabIndex = 79;
            // 
            // btnCustomerNotesEditSave
            // 
            btnCustomerNotesEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerNotesEditSave.ForeColor = Color.White;
            btnCustomerNotesEditSave.Location = new Point(216, 14);
            btnCustomerNotesEditSave.Name = "btnCustomerNotesEditSave";
            btnCustomerNotesEditSave.Size = new Size(113, 23);
            btnCustomerNotesEditSave.TabIndex = 75;
            btnCustomerNotesEditSave.Text = "Edit";
            btnCustomerNotesEditSave.UseVisualStyleBackColor = false;
            btnCustomerNotesEditSave.Click += btnCustomerNotesEditSave_Click;
            // 
            // btnCustomerNotesBack
            // 
            btnCustomerNotesBack.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerNotesBack.ForeColor = Color.White;
            btnCustomerNotesBack.Location = new Point(82, 14);
            btnCustomerNotesBack.Name = "btnCustomerNotesBack";
            btnCustomerNotesBack.Size = new Size(113, 23);
            btnCustomerNotesBack.TabIndex = 74;
            btnCustomerNotesBack.Text = "Back";
            btnCustomerNotesBack.UseVisualStyleBackColor = false;
            btnCustomerNotesBack.Click += btnCustomerNotesBack_Click;
            // 
            // lblNotesCustomerCreateDate
            // 
            lblNotesCustomerCreateDate.AutoSize = true;
            lblNotesCustomerCreateDate.Location = new Point(82, 41);
            lblNotesCustomerCreateDate.Name = "lblNotesCustomerCreateDate";
            lblNotesCustomerCreateDate.Size = new Size(71, 15);
            lblNotesCustomerCreateDate.TabIndex = 63;
            lblNotesCustomerCreateDate.Text = "Create Date:";
            // 
            // txtNotesCustomerPayload
            // 
            txtNotesCustomerPayload.Location = new Point(82, 147);
            txtNotesCustomerPayload.Multiline = true;
            txtNotesCustomerPayload.Name = "txtNotesCustomerPayload";
            txtNotesCustomerPayload.ReadOnly = true;
            txtNotesCustomerPayload.Size = new Size(247, 85);
            txtNotesCustomerPayload.TabIndex = 62;
            // 
            // lblNotesCustomerPayload
            // 
            lblNotesCustomerPayload.AutoSize = true;
            lblNotesCustomerPayload.Location = new Point(82, 129);
            lblNotesCustomerPayload.Name = "lblNotesCustomerPayload";
            lblNotesCustomerPayload.Size = new Size(52, 15);
            lblNotesCustomerPayload.TabIndex = 61;
            lblNotesCustomerPayload.Text = "Payload:";
            // 
            // txtNotesCustomerTitle
            // 
            txtNotesCustomerTitle.Location = new Point(82, 103);
            txtNotesCustomerTitle.Name = "txtNotesCustomerTitle";
            txtNotesCustomerTitle.ReadOnly = true;
            txtNotesCustomerTitle.Size = new Size(247, 23);
            txtNotesCustomerTitle.TabIndex = 60;
            // 
            // lblNotesCustomerTitle
            // 
            lblNotesCustomerTitle.AutoSize = true;
            lblNotesCustomerTitle.Location = new Point(82, 85);
            lblNotesCustomerTitle.Name = "lblNotesCustomerTitle";
            lblNotesCustomerTitle.Size = new Size(33, 15);
            lblNotesCustomerTitle.TabIndex = 59;
            lblNotesCustomerTitle.Text = "Title:";
            // 
            // btnNotesCustomerDelete
            // 
            btnNotesCustomerDelete.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesCustomerDelete.ForeColor = Color.White;
            btnNotesCustomerDelete.Location = new Point(260, 37);
            btnNotesCustomerDelete.Name = "btnNotesCustomerDelete";
            btnNotesCustomerDelete.Size = new Size(87, 23);
            btnNotesCustomerDelete.TabIndex = 77;
            btnNotesCustomerDelete.Text = "Delete";
            btnNotesCustomerDelete.UseVisualStyleBackColor = false;
            btnNotesCustomerDelete.Click += btnNotesCustomerDelete_Click;
            // 
            // btnNotesCustomerView
            // 
            btnNotesCustomerView.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesCustomerView.ForeColor = Color.White;
            btnNotesCustomerView.Location = new Point(167, 37);
            btnNotesCustomerView.Name = "btnNotesCustomerView";
            btnNotesCustomerView.Size = new Size(87, 23);
            btnNotesCustomerView.TabIndex = 76;
            btnNotesCustomerView.Text = "View";
            btnNotesCustomerView.UseVisualStyleBackColor = false;
            btnNotesCustomerView.Click += btnNotesCustomerView_Click;
            // 
            // btnNotesCustomerNew
            // 
            btnNotesCustomerNew.BackColor = Color.FromArgb(21, 96, 130);
            btnNotesCustomerNew.ForeColor = Color.White;
            btnNotesCustomerNew.Location = new Point(74, 37);
            btnNotesCustomerNew.Name = "btnNotesCustomerNew";
            btnNotesCustomerNew.Size = new Size(87, 23);
            btnNotesCustomerNew.TabIndex = 74;
            btnNotesCustomerNew.Text = "New";
            btnNotesCustomerNew.UseVisualStyleBackColor = false;
            btnNotesCustomerNew.Click += btnNotesCustomerNew_Click;
            // 
            // customerNotesDataGridView
            // 
            customerNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerNotesDataGridView.Location = new Point(9, 66);
            customerNotesDataGridView.Name = "customerNotesDataGridView";
            customerNotesDataGridView.Size = new Size(404, 221);
            customerNotesDataGridView.TabIndex = 73;
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
            // btnCustomerEditSave
            // 
            btnCustomerEditSave.BackColor = Color.FromArgb(21, 96, 130);
            btnCustomerEditSave.ForeColor = Color.White;
            btnCustomerEditSave.Location = new Point(177, 87);
            btnCustomerEditSave.Name = "btnCustomerEditSave";
            btnCustomerEditSave.Size = new Size(103, 23);
            btnCustomerEditSave.TabIndex = 74;
            btnCustomerEditSave.Text = "Edit";
            btnCustomerEditSave.UseVisualStyleBackColor = false;
            btnCustomerEditSave.Click += btnCustomerEditSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(68, 87);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 73;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelNotesCustomerAll
            // 
            panelNotesCustomerAll.Controls.Add(btnNotesCustomerDelete);
            panelNotesCustomerAll.Controls.Add(btnNotesCustomerView);
            panelNotesCustomerAll.Controls.Add(btnNotesCustomerNew);
            panelNotesCustomerAll.Controls.Add(customerNotesDataGridView);
            panelNotesCustomerAll.Controls.Add(lblNotes);
            panelNotesCustomerAll.Location = new Point(327, 87);
            panelNotesCustomerAll.Name = "panelNotesCustomerAll";
            panelNotesCustomerAll.Size = new Size(419, 308);
            panelNotesCustomerAll.TabIndex = 78;
            // 
            // CustomerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 454);
            Controls.Add(panelNotesCustomerAll);
            Controls.Add(btnCustomerEditSave);
            Controls.Add(btnBack);
            Controls.Add(panelNotesCustomerNewEdit);
            Controls.Add(lblGroomyCustomers);
            Controls.Add(fieldCustomerID);
            Controls.Add(lblCustomerID);
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
            Name = "CustomerView";
            Text = "CustomerView";
            panelNotesCustomerNewEdit.ResumeLayout(false);
            panelNotesCustomerNewEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customerNotesDataGridView).EndInit();
            panelNotesCustomerAll.ResumeLayout(false);
            panelNotesCustomerAll.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fieldCustomerID;
        private Label lblCustomerID;
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
        private Label lblGroomyCustomers;
        private Panel panelNotesCustomerNewEdit;
        private Label lblNotes;
        private DataGridView customerNotesDataGridView;
        private Button btnNotesCustomerDelete;
        private Button btnNotesCustomerView;
        private Button btnNotesCustomerNew;
        private Button btnCustomerEditSave;
        private Button btnBack;
        private Panel panelNotesCustomerAll;
        private TextBox txtNotesCustomerPayload;
        private Label lblNotesCustomerPayload;
        private TextBox txtNotesCustomerTitle;
        private Label lblNotesCustomerTitle;
        private Label lblNotesCustomerCreateDate;
        private Button btnCustomerNotesEditSave;
        private Button btnCustomerNotesBack;
        private DateTimePicker timeNotesCustomersCreateDate;
        private Label fieldNotesCustomersNoteID;
        private Label lblNotesCustomersNoteID;
    }
}