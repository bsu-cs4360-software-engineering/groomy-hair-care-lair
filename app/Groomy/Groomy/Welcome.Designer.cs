namespace Groomy
{
    partial class Welcome
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
            label2 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(29, 129, 175);
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 248);
            label2.Name = "label2";
            label2.Size = new Size(216, 44);
            label2.TabIndex = 20;
            label2.Text = "Welcome";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(21, 96, 130);
            label9.Location = new Point(270, 9);
            label9.Name = "label9";
            label9.Size = new Size(449, 180);
            label9.TabIndex = 16;
            label9.Text = "Welcome to\r\n Groomy!";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(panel1);
            Controls.Add(label9);
            MaximizeBox = false;
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "Welcome";
            Text = "Groomy";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label9;
        private Label label2;
    }
}