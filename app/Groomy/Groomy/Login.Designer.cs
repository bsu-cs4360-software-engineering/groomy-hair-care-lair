﻿

namespace Groomy
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_login = new Button();
            btn_newUsr = new Button();
            txt_email = new TextBox();
            txt_password = new TextBox();
            lbl_email = new Label();
            lbl_password = new Label();
            closeBtn = new Button();
            panel1 = new Panel();
            label8 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.FromArgb(21, 96, 130);
            btn_login.Enabled = false;
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(366, 512);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(123, 41);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // btn_newUsr
            // 
            btn_newUsr.BackColor = Color.FromArgb(21, 96, 130);
            btn_newUsr.ForeColor = Color.White;
            btn_newUsr.Location = new Point(495, 512);
            btn_newUsr.Name = "btn_newUsr";
            btn_newUsr.Size = new Size(123, 41);
            btn_newUsr.TabIndex = 5;
            btn_newUsr.Text = "New User";
            btn_newUsr.UseVisualStyleBackColor = false;
            btn_newUsr.Click += switchToNewUserForm;
            // 
            // txt_email
            // 
            txt_email.ForeColor = SystemColors.ControlText;
            txt_email.Location = new Point(324, 237);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(423, 23);
            txt_email.TabIndex = 0;
            txt_email.TextChanged += updateLoginButton;
            txt_email.Enter += updateLoginButton;
            txt_email.Leave += updateLoginButton;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(324, 266);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(423, 23);
            txt_password.TabIndex = 2;
            txt_password.TextChanged += updateLoginButton;
            txt_password.Enter += updateLoginButton;
            txt_password.Leave += updateLoginButton;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.ForeColor = Color.FromArgb(21, 96, 130);
            lbl_email.Location = new Point(229, 240);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(89, 15);
            lbl_email.TabIndex = 1;
            lbl_email.Text = "E-Mail Address:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.ForeColor = Color.FromArgb(21, 96, 130);
            lbl_password.Location = new Point(229, 269);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(60, 15);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password:";
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.FromArgb(21, 96, 130);
            closeBtn.ForeColor = Color.White;
            closeBtn.Location = new Point(624, 512);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(123, 41);
            closeBtn.TabIndex = 6;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 17;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(29, 129, 175);
            label8.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 245);
            label8.Name = "label8";
            label8.Size = new Size(216, 44);
            label8.TabIndex = 9;
            label8.Text = "Login";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(21, 96, 130);
            label9.Location = new Point(229, 9);
            label9.Name = "label9";
            label9.Size = new Size(309, 90);
            label9.TabIndex = 16;
            label9.Text = "Groomy";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(panel1);
            Controls.Add(label9);
            Controls.Add(closeBtn);
            Controls.Add(lbl_password);
            Controls.Add(lbl_email);
            Controls.Add(txt_password);
            Controls.Add(txt_email);
            Controls.Add(btn_newUsr);
            Controls.Add(btn_login);
            MaximizeBox = false;
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "Login";
            Text = "Login to Groomy";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_login;
        private Button btn_newUsr;
        private TextBox txt_email;
        private TextBox txt_password;
        private Label lbl_email;
        private Label lbl_password;
        private Button closeBtn;
        private Panel panel1;
        private Label label8;
        private Label label9;
    }
}
