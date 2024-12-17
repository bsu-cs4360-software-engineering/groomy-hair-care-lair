namespace Groomy.Invoice
{
    partial class Invoice
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
            lblGroomyCustomers = new Label();
            invRichText = new RichTextBox();
            serviceOfferedBox = new GroupBox();
            btnSaveInv = new Button();
            btnPrint = new Button();
            btnGenInv = new Button();
            servicesTickBox = new CheckedListBox();
            saveInv = new SaveFileDialog();
            isPaidTick = new CheckBox();
            serviceOfferedBox.SuspendLayout();
            SuspendLayout();
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.AutoSize = true;
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(424, 9);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(312, 45);
            lblGroomyCustomers.TabIndex = 72;
            lblGroomyCustomers.Text = "Groomy Invoices";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // invRichText
            // 
            invRichText.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            invRichText.Location = new Point(600, 56);
            invRichText.Name = "invRichText";
            invRichText.ReadOnly = true;
            invRichText.Size = new Size(621, 386);
            invRichText.TabIndex = 73;
            invRichText.Text = "";
            // 
            // serviceOfferedBox
            // 
            serviceOfferedBox.Controls.Add(isPaidTick);
            serviceOfferedBox.Controls.Add(btnSaveInv);
            serviceOfferedBox.Controls.Add(btnPrint);
            serviceOfferedBox.Controls.Add(btnGenInv);
            serviceOfferedBox.Controls.Add(servicesTickBox);
            serviceOfferedBox.Location = new Point(12, 56);
            serviceOfferedBox.Name = "serviceOfferedBox";
            serviceOfferedBox.Size = new Size(582, 386);
            serviceOfferedBox.TabIndex = 74;
            serviceOfferedBox.TabStop = false;
            serviceOfferedBox.Text = "Services Offered";
            // 
            // btnSaveInv
            // 
            btnSaveInv.Enabled = false;
            btnSaveInv.Location = new Point(6, 330);
            btnSaveInv.Name = "btnSaveInv";
            btnSaveInv.Size = new Size(570, 23);
            btnSaveInv.TabIndex = 3;
            btnSaveInv.Text = "Save Invoice";
            btnSaveInv.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Enabled = false;
            btnPrint.Location = new Point(6, 357);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(570, 23);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print Invoice";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnGenInv
            // 
            btnGenInv.Location = new Point(6, 302);
            btnGenInv.Name = "btnGenInv";
            btnGenInv.Size = new Size(570, 23);
            btnGenInv.TabIndex = 1;
            btnGenInv.Text = "Generate Invoice";
            btnGenInv.UseVisualStyleBackColor = true;
            btnGenInv.Click += btnGenInv_Click;
            // 
            // servicesTickBox
            // 
            servicesTickBox.FormattingEnabled = true;
            servicesTickBox.Location = new Point(0, 22);
            servicesTickBox.Name = "servicesTickBox";
            servicesTickBox.Size = new Size(576, 238);
            servicesTickBox.TabIndex = 0;
            // 
            // isPaidTick
            // 
            isPaidTick.AutoSize = true;
            isPaidTick.Location = new Point(6, 266);
            isPaidTick.Name = "isPaidTick";
            isPaidTick.Size = new Size(101, 19);
            isPaidTick.TabIndex = 4;
            isPaidTick.Text = "Invoice is Paid";
            isPaidTick.UseVisualStyleBackColor = true;
            // 
            // Invoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 454);
            Controls.Add(serviceOfferedBox);
            Controls.Add(invRichText);
            Controls.Add(lblGroomyCustomers);
            Name = "Invoice";
            Text = "Invoices";
            serviceOfferedBox.ResumeLayout(false);
            serviceOfferedBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGroomyCustomers;
        private RichTextBox invRichText;
        private GroupBox serviceOfferedBox;
        private Button btnPrint;
        private Button btnGenInv;
        private CheckedListBox servicesTickBox;
        private Button btnSaveInv;
        private SaveFileDialog saveInv;
        private CheckBox isPaidTick;
    }
}