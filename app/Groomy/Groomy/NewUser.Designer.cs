namespace Groomy
{
    partial class NewUser
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
            btn_submitNewUser = new Button();
            btn_Back = new Button();
            SuspendLayout();
            // 
            // btn_submitNewUser
            // 
            btn_submitNewUser.Enabled = false;
            btn_submitNewUser.Location = new Point(665, 397);
            btn_submitNewUser.Name = "btn_submitNewUser";
            btn_submitNewUser.Size = new Size(123, 41);
            btn_submitNewUser.TabIndex = 1;
            btn_submitNewUser.Text = "Create New User";
            btn_submitNewUser.UseVisualStyleBackColor = true;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(536, 397);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(123, 41);
            btn_Back.TabIndex = 2;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += switchToLogin;
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Back);
            Controls.Add(btn_submitNewUser);
            Name = "NewUser";
            Text = "NewUser";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_submitNewUser;
        private Button btn_Back;
    }
}