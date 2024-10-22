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
            Button btn_Quit;
            btn_submitNewUser = new Button();
            btn_Quit = new Button();
            SuspendLayout();
            // 
            // btn_Quit
            // 
            btn_Quit.Location = new Point(238, 388);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(74, 41);
            btn_Quit.TabIndex = 2;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = true;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // btn_submitNewUser
            // 
            btn_submitNewUser.Enabled = false;
            btn_submitNewUser.Location = new Point(318, 388);
            btn_submitNewUser.Name = "btn_submitNewUser";
            btn_submitNewUser.Size = new Size(74, 41);
            btn_submitNewUser.TabIndex = 1;
            btn_submitNewUser.Text = "Create New User";
            btn_submitNewUser.UseVisualStyleBackColor = true;
            btn_submitNewUser.Click += btn_submitNewUser_Click;
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 441);
            Controls.Add(btn_Quit);
            Controls.Add(btn_submitNewUser);
            Name = "NewUser";
            Text = "NewUser";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_submitNewUser;
    }
}