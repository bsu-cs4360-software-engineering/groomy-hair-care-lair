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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            fNameInput = new TextBox();
            lNameInput = new TextBox();
            label5 = new Label();
            emailInput = new TextBox();
            label6 = new Label();
            passInput = new TextBox();
            label7 = new Label();
            passConfirm = new TextBox();
            btn_Quit = new Button();
            SuspendLayout();
            // 
            // btn_Quit
            // 
            btn_Quit.Location = new Point(238, 233);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(74, 41);
            btn_Quit.TabIndex = 2;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = true;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // btn_submitNewUser
            // 
            btn_submitNewUser.Location = new Point(318, 233);
            btn_submitNewUser.Name = "btn_submitNewUser";
            btn_submitNewUser.Size = new Size(74, 41);
            btn_submitNewUser.TabIndex = 1;
            btn_submitNewUser.Text = "Create New User";
            btn_submitNewUser.UseVisualStyleBackColor = true;
            btn_submitNewUser.Click += btn_submitNewUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 3;
            label1.Text = "Create New User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(209, 15);
            label2.TabIndex = 4;
            label2.Text = "Please enter the following information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 110);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 6;
            label4.Text = "Last Name:";
            // 
            // fNameInput
            // 
            fNameInput.Location = new Point(85, 78);
            fNameInput.Name = "fNameInput";
            fNameInput.Size = new Size(307, 23);
            fNameInput.TabIndex = 7;
            // 
            // lNameInput
            // 
            lNameInput.Location = new Point(85, 107);
            lNameInput.Name = "lNameInput";
            lNameInput.Size = new Size(307, 23);
            lNameInput.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 139);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Email:";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(85, 136);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(307, 23);
            emailInput.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 168);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 11;
            label6.Text = "Password:";
            // 
            // passInput
            // 
            passInput.Location = new Point(85, 165);
            passInput.Name = "passInput";
            passInput.PasswordChar = '*';
            passInput.Size = new Size(307, 23);
            passInput.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 196);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 13;
            label7.Text = "Confirm:";
            // 
            // passConfirm
            // 
            passConfirm.Location = new Point(85, 193);
            passConfirm.Name = "passConfirm";
            passConfirm.PasswordChar = '*';
            passConfirm.Size = new Size(307, 23);
            passConfirm.TabIndex = 14;
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 287);
            Controls.Add(passConfirm);
            Controls.Add(label7);
            Controls.Add(passInput);
            Controls.Add(label6);
            Controls.Add(emailInput);
            Controls.Add(label5);
            Controls.Add(lNameInput);
            Controls.Add(fNameInput);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Quit);
            Controls.Add(btn_submitNewUser);
            Name = "NewUser";
            Text = "NewUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_submitNewUser;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox fNameInput;
        private TextBox lNameInput;
        private Label label5;
        private TextBox emailInput;
        private Label label6;
        private TextBox passInput;
        private Label label7;
        private TextBox passConfirm;
    }
}