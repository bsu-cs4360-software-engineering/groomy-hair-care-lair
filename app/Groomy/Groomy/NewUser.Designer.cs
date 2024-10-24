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
            panel1 = new Panel();
            label8 = new Label();
            label9 = new Label();
            btn_Quit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Quit
            // 
            btn_Quit.Location = new Point(673, 512);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(74, 41);
            btn_Quit.TabIndex = 11;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = true;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // btn_submitNewUser
            // 
            btn_submitNewUser.Location = new Point(593, 512);
            btn_submitNewUser.Name = "btn_submitNewUser";
            btn_submitNewUser.Size = new Size(74, 41);
            btn_submitNewUser.TabIndex = 10;
            btn_submitNewUser.Text = "Create New User";
            btn_submitNewUser.UseVisualStyleBackColor = true;
            btn_submitNewUser.Click += btn_submitNewUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(342, 44);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 13;
            label1.Text = "Create New User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 87);
            label2.Name = "label2";
            label2.Size = new Size(209, 15);
            label2.TabIndex = 12;
            label2.Text = "Please enter the following information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(21, 96, 130);
            label3.Location = new Point(227, 205);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 1;
            label3.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(21, 96, 130);
            label4.Location = new Point(227, 234);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 3;
            label4.Text = "Last Name:";
            // 
            // fNameInput
            // 
            fNameInput.Location = new Point(300, 202);
            fNameInput.Name = "fNameInput";
            fNameInput.Size = new Size(447, 23);
            fNameInput.TabIndex = 0;
            // 
            // lNameInput
            // 
            lNameInput.Location = new Point(299, 231);
            lNameInput.Name = "lNameInput";
            lNameInput.Size = new Size(448, 23);
            lNameInput.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(21, 96, 130);
            label5.Location = new Point(227, 263);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Email:";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(300, 260);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(447, 23);
            emailInput.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(21, 96, 130);
            label6.Location = new Point(227, 292);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 7;
            label6.Text = "Password:";
            // 
            // passInput
            // 
            passInput.Location = new Point(300, 289);
            passInput.Name = "passInput";
            passInput.PasswordChar = '*';
            passInput.Size = new Size(447, 23);
            passInput.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(21, 96, 130);
            label7.Location = new Point(227, 320);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 9;
            label7.Text = "Confirm:";
            // 
            // passConfirm
            // 
            passConfirm.Location = new Point(300, 317);
            passConfirm.Name = "passConfirm";
            passConfirm.PasswordChar = '*';
            passConfirm.Size = new Size(447, 23);
            passConfirm.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 15;
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
            label8.Text = "New User";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(21, 96, 130);
            label9.Location = new Point(227, 9);
            label9.Name = "label9";
            label9.Size = new Size(468, 90);
            label9.TabIndex = 14;
            label9.Text = "Registration";
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 565);
            Controls.Add(panel1);
            Controls.Add(label9);
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
            MaximizeBox = false;
            MaximumSize = new Size(775, 604);
            MinimizeBox = false;
            MinimumSize = new Size(775, 604);
            Name = "NewUser";
            Text = "NewUser";
            panel1.ResumeLayout(false);
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
        private Panel panel1;
        private Label label8;
        private Label label9;
    }
}