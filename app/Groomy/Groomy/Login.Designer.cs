

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
            label1 = new Label();
            closeBtn = new Button();
            SuspendLayout();
            // 
            // btn_login
            // 
            btn_login.Enabled = false;
            btn_login.Location = new Point(107, 131);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(123, 41);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // btn_newUsr
            // 
            btn_newUsr.Location = new Point(236, 131);
            btn_newUsr.Name = "btn_newUsr";
            btn_newUsr.Size = new Size(123, 41);
            btn_newUsr.TabIndex = 5;
            btn_newUsr.Text = "New User";
            btn_newUsr.UseVisualStyleBackColor = true;
            btn_newUsr.Click += switchToNewUserForm;
            // 
            // txt_email
            // 
            txt_email.Location = new Point(107, 73);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(381, 23);
            txt_email.TabIndex = 0;
            txt_email.TextChanged += updateLoginButton;
            txt_email.Enter += updateLoginButton;
            txt_email.Leave += updateLoginButton;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(107, 102);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(381, 23);
            txt_password.TabIndex = 2;
            txt_password.TextChanged += updateLoginButton;
            txt_password.Enter += updateLoginButton;
            txt_password.Leave += updateLoginButton;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(12, 76);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(89, 15);
            lbl_email.TabIndex = 1;
            lbl_email.Text = "E-Mail Address:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(12, 105);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(60, 15);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(430, 25);
            label1.TabIndex = 7;
            label1.Text = "Welcome to Groomy! Please sign in to get started.";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(365, 131);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(123, 41);
            closeBtn.TabIndex = 6;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 187);
            Controls.Add(closeBtn);
            Controls.Add(label1);
            Controls.Add(lbl_password);
            Controls.Add(lbl_email);
            Controls.Add(txt_password);
            Controls.Add(txt_email);
            Controls.Add(btn_newUsr);
            Controls.Add(btn_login);
            MaximizeBox = false;
            MaximumSize = new Size(519, 226);
            MinimumSize = new Size(519, 226);
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
        private Label label1;
        private Button closeBtn;
    }
}
