namespace Groomy.DialogBoxes
{
    partial class creNewAppt
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
            lblNewAppt = new Label();
            label1 = new Label();
            txtAppointmentID = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            txtLocation = new TextBox();
            cusDataView = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            dtpStartTime = new DateTimePicker();
            label7 = new Label();
            dtpEndTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)cusDataView).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(21, 96, 130);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(369, 57);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 71;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(21, 96, 130);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(12, 57);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 70;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblNewAppt
            // 
            lblNewAppt.AutoSize = true;
            lblNewAppt.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblNewAppt.ForeColor = Color.FromArgb(21, 96, 130);
            lblNewAppt.Location = new Point(12, 9);
            lblNewAppt.Name = "lblNewAppt";
            lblNewAppt.Size = new Size(370, 45);
            lblNewAppt.TabIndex = 69;
            lblNewAppt.Text = "Create Appointment";
            lblNewAppt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 92);
            label1.Name = "label1";
            label1.Size = new Size(262, 15);
            label1.TabIndex = 72;
            label1.Text = "Appointment ID (Generated, Change as Needed)";
            // 
            // txtAppointmentID
            // 
            txtAppointmentID.Location = new Point(12, 110);
            txtAppointmentID.Name = "txtAppointmentID";
            txtAppointmentID.Size = new Size(460, 23);
            txtAppointmentID.TabIndex = 73;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 74;
            label2.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 154);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(460, 23);
            txtTitle.TabIndex = 75;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 324);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 76;
            label3.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 342);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(460, 69);
            txtDescription.TabIndex = 77;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 414);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 78;
            label4.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(12, 432);
            txtLocation.Multiline = true;
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(460, 69);
            txtLocation.TabIndex = 79;
            // 
            // cusDataView
            // 
            cusDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cusDataView.Location = new Point(12, 198);
            cusDataView.Name = "cusDataView";
            cusDataView.Size = new Size(460, 123);
            cusDataView.TabIndex = 80;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 180);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 81;
            label5.Text = "Customer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 504);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 82;
            label6.Text = "Start Time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "MM/dd/yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(12, 522);
            dtpStartTime.MinDate = new DateTime(2024, 11, 1, 0, 0, 0, 0);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(460, 23);
            dtpStartTime.TabIndex = 83;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 548);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 84;
            label7.Text = "End Time";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "MM/dd/yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(12, 566);
            dtpEndTime.MinDate = new DateTime(2024, 11, 1, 0, 0, 0, 0);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(460, 23);
            dtpEndTime.TabIndex = 85;
            // 
            // creNewAppt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 611);
            Controls.Add(dtpEndTime);
            Controls.Add(label7);
            Controls.Add(dtpStartTime);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cusDataView);
            Controls.Add(txtLocation);
            Controls.Add(label4);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(txtAppointmentID);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(lblNewAppt);
            MaximizeBox = false;
            MaximumSize = new Size(500, 650);
            MinimizeBox = false;
            MinimumSize = new Size(500, 650);
            Name = "creNewAppt";
            ShowIcon = false;
            Text = "Creating a New Appointment";
            Load += creNewAppt_Load;
            ((System.ComponentModel.ISupportInitialize)cusDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnBack;
        private Label lblNewAppt;
        private Label label1;
        private TextBox txtAppointmentID;
        private Label label2;
        private TextBox txtTitle;
        private Label label3;
        private TextBox txtDescription;
        private Label label4;
        private TextBox txtLocation;
        private DataGridView cusDataView;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpStartTime;
        private Label label7;
        private DateTimePicker dtpEndTime;
    }
}