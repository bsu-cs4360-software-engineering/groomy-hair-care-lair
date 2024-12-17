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
            groupBox1 = new GroupBox();
            btnPrint = new Button();
            btnGenInv = new Button();
            servicesTickBox = new CheckedListBox();
            button1 = new Button();
            saveInv = new SaveFileDialog();
            groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnPrint);
            groupBox1.Controls.Add(btnGenInv);
            groupBox1.Controls.Add(servicesTickBox);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(582, 386);
            groupBox1.TabIndex = 74;
            groupBox1.TabStop = false;
            groupBox1.Text = "Services Offered";
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
            servicesTickBox.Size = new Size(576, 274);
            servicesTickBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(6, 330);
            button1.Name = "button1";
            button1.Size = new Size(570, 23);
            button1.TabIndex = 3;
            button1.Text = "Save Invoice";
            button1.UseVisualStyleBackColor = true;
            // 
            // Invoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 454);
            Controls.Add(groupBox1);
            Controls.Add(invRichText);
            Controls.Add(lblGroomyCustomers);
            Name = "Invoice";
            Text = "Invoices";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGroomyCustomers;
        private RichTextBox invRichText;
        private GroupBox groupBox1;
        private Button btnPrint;
        private Button btnGenInv;
        private CheckedListBox servicesTickBox;
        private Button button1;
        private SaveFileDialog saveInv;
    }
}