namespace Groomy
{
    partial class Cust
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
            custBtn = new Label();
            label2 = new Label();
            label9 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(custBtn);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 19;
            // 
            // custBtn
            // 
            custBtn.BackColor = Color.FromArgb(29, 129, 175);
            custBtn.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            custBtn.ForeColor = Color.White;
            custBtn.Location = new Point(0, 260);
            custBtn.Name = "custBtn";
            custBtn.Size = new Size(216, 44);
            custBtn.TabIndex = 21;
            custBtn.Text = "Customers";
            custBtn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(29, 129, 175);
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 200);
            label2.Name = "label2";
            label2.Size = new Size(216, 44);
            label2.TabIndex = 20;
            label2.Text = "Welcome";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 24F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(21, 96, 130);
            label9.Location = new Point(318, 9);
            label9.Name = "label9";
            label9.Size = new Size(356, 45);
            label9.TabIndex = 18;
            label9.Text = "Groomy Customers";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(226, 70);
            button1.Name = "button1";
            button1.Size = new Size(521, 23);
            button1.TabIndex = 20;
            button1.Text = "Create New Customer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Cust
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label9);
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "Cust";
            Text = "Customers";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label custBtn;
        private Label label2;
        private Label label9;
        private Button button1;
    }
}