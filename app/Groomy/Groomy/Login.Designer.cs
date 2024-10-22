

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
            SuspendLayout();
            // 
            // btn_login
            // 
            btn_login.Enabled = false;
            btn_login.Location = new Point(665, 397);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(123, 41);
            btn_login.TabIndex = 0;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // btn_newUsr
            // 
            btn_newUsr.Location = new Point(536, 397);
            btn_newUsr.Name = "btn_newUsr";
            btn_newUsr.Size = new Size(123, 41);
            btn_newUsr.TabIndex = 1;
            btn_newUsr.Text = "New User";
            btn_newUsr.UseVisualStyleBackColor = true;
            btn_newUsr.Click += switchToNewUserForm;
            // 
            // txt_email
            // 
            txt_email.Location = new Point(12, 415);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(249, 23);
            txt_email.TabIndex = 2;
            txt_email.TextChanged += updateLoginButton;
            txt_email.Enter += updateLoginButton;
            txt_email.Leave += updateLoginButton;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(300, 415);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(123, 23);
            txt_password.TabIndex = 3;
            txt_password.TextChanged += updateLoginButton;
            txt_password.Enter += updateLoginButton;
            txt_password.Leave += updateLoginButton;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(12, 397);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(89, 15);
            lbl_email.TabIndex = 4;
            lbl_email.Text = "E-Mail Address:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(300, 397);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(60, 15);
            lbl_password.TabIndex = 5;
            lbl_password.Text = "Password:";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_password);
            Controls.Add(lbl_email);
            Controls.Add(txt_password);
            Controls.Add(txt_email);
            Controls.Add(btn_newUsr);
            Controls.Add(btn_login);
            Name = "Login";
            Text = "Groomy Login";
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
    }
}
