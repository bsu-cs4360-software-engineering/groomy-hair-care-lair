namespace Groomy.Invoices
{
    partial class InvoicePrint
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
            lblGroomyInvoice = new Label();
            invRichText = new RichTextBox();
            btnPrint = new Button();
            isPaidTick = new CheckBox();
            btnSaveInv = new Button();
            SuspendLayout();
            // 
            // lblGroomyInvoice
            // 
            lblGroomyInvoice.AutoSize = true;
            lblGroomyInvoice.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            lblGroomyInvoice.ForeColor = Color.FromArgb(21, 96, 130);
            lblGroomyInvoice.Location = new Point(147, 26);
            lblGroomyInvoice.Name = "lblGroomyInvoice";
            lblGroomyInvoice.Size = new Size(292, 45);
            lblGroomyInvoice.TabIndex = 73;
            lblGroomyInvoice.Text = "Groomy Invoice";
            lblGroomyInvoice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // invRichText
            // 
            invRichText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            invRichText.Location = new Point(43, 111);
            invRichText.Name = "invRichText";
            invRichText.ReadOnly = true;
            invRichText.Size = new Size(504, 386);
            invRichText.TabIndex = 74;
            invRichText.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(329, 503);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(218, 23);
            btnPrint.TabIndex = 76;
            btnPrint.Text = "Print Invoice";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // isPaidTick
            // 
            isPaidTick.AutoSize = true;
            isPaidTick.Location = new Point(43, 86);
            isPaidTick.Name = "isPaidTick";
            isPaidTick.Size = new Size(101, 19);
            isPaidTick.TabIndex = 75;
            isPaidTick.Text = "Invoice is Paid";
            isPaidTick.UseVisualStyleBackColor = true;
            isPaidTick.CheckedChanged += isPaidTick_CheckedChanged;
            // 
            // btnSaveInv
            // 
            btnSaveInv.Location = new Point(43, 503);
            btnSaveInv.Name = "btnSaveInv";
            btnSaveInv.Size = new Size(218, 23);
            btnSaveInv.TabIndex = 77;
            btnSaveInv.Text = "Save Invoice as File";
            btnSaveInv.UseVisualStyleBackColor = true;
            btnSaveInv.Click += btnSaveInv_Click;
            // 
            // InvoicePrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 573);
            Controls.Add(btnSaveInv);
            Controls.Add(btnPrint);
            Controls.Add(isPaidTick);
            Controls.Add(invRichText);
            Controls.Add(lblGroomyInvoice);
            Name = "InvoicePrint";
            Text = "InvoicePrint";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGroomyInvoice;
        private RichTextBox invRichText;
        private Button btnPrint;
        private CheckBox isPaidTick;
        private Button btnSaveInv;
    }
}