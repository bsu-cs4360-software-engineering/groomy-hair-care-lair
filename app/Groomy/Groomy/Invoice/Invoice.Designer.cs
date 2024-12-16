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
            SuspendLayout();
            // 
            // lblGroomyCustomers
            // 
            lblGroomyCustomers.AutoSize = true;
            lblGroomyCustomers.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyCustomers.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyCustomers.Location = new Point(192, 9);
            lblGroomyCustomers.Name = "lblGroomyCustomers";
            lblGroomyCustomers.Size = new Size(312, 45);
            lblGroomyCustomers.TabIndex = 72;
            lblGroomyCustomers.Text = "Groomy Invoices";
            lblGroomyCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // invRichText
            // 
            invRichText.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            invRichText.Location = new Point(12, 66);
            invRichText.Name = "invRichText";
            invRichText.ReadOnly = true;
            invRichText.Size = new Size(674, 582);
            invRichText.TabIndex = 73;
            invRichText.Text = "";
            // 
            // Invoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 660);
            Controls.Add(invRichText);
            Controls.Add(lblGroomyCustomers);
            Name = "Invoice";
            Text = "Invoices";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGroomyCustomers;
        private RichTextBox invRichText;
    }
}