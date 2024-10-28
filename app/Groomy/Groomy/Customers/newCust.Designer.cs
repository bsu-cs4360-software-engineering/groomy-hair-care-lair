namespace Groomy.Customers
{
    partial class newCust
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
            panel1 = new Panel();
            label8 = new Label();
            label9 = new Label();
            passConfirm = new TextBox();
            label7 = new Label();
            passInput = new TextBox();
            label6 = new Label();
            emailInput = new TextBox();
            label5 = new Label();
            lNameInput = new TextBox();
            fNameInput = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_submitNewUser = new Button();
            btn_Quit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 96, 130);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 566);
            panel1.TabIndex = 31;
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
            label9.Location = new Point(227, 8);
            label9.Name = "label9";
            label9.Size = new Size(468, 90);
            label9.TabIndex = 30;
            label9.Text = "Registration";
            // 
            // passConfirm
            // 
            passConfirm.Location = new Point(300, 316);
            passConfirm.Name = "passConfirm";
            passConfirm.PasswordChar = '*';
            passConfirm.Size = new Size(447, 23);
            passConfirm.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(21, 96, 130);
            label7.Location = new Point(227, 319);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 25;
            label7.Text = "Confirm:";
            // 
            // passInput
            // 
            passInput.Location = new Point(300, 288);
            passInput.Name = "passInput";
            passInput.PasswordChar = '*';
            passInput.Size = new Size(447, 23);
            passInput.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(21, 96, 130);
            label6.Location = new Point(227, 291);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 23;
            label6.Text = "Password:";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(300, 259);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(447, 23);
            emailInput.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(21, 96, 130);
            label5.Location = new Point(227, 262);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 21;
            label5.Text = "Email:";
            // 
            // lNameInput
            // 
            lNameInput.Location = new Point(299, 230);
            lNameInput.Name = "lNameInput";
            lNameInput.Size = new Size(448, 23);
            lNameInput.TabIndex = 18;
            // 
            // fNameInput
            // 
            fNameInput.Location = new Point(300, 201);
            fNameInput.Name = "fNameInput";
            fNameInput.Size = new Size(447, 23);
            fNameInput.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(21, 96, 130);
            label4.Location = new Point(227, 233);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 19;
            label4.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(21, 96, 130);
            label3.Location = new Point(227, 204);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 17;
            label3.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 86);
            label2.Name = "label2";
            label2.Size = new Size(209, 15);
            label2.TabIndex = 28;
            label2.Text = "Please enter the following information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(342, 43);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 29;
            label1.Text = "Create New User";
            // 
            // btn_Quit
            // 
            btn_Quit.BackColor = Color.FromArgb(21, 96, 130);
            btn_Quit.ForeColor = Color.White;
            btn_Quit.Location = new Point(624, 511);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(123, 41);
            btn_Quit.TabIndex = 27;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = false;
            // 
            // btn_submitNewUser
            // 
            btn_submitNewUser.BackColor = Color.FromArgb(21, 96, 130);
            btn_submitNewUser.ForeColor = Color.White;
            btn_submitNewUser.Location = new Point(495, 511);
            btn_submitNewUser.Name = "btn_submitNewUser";
            btn_submitNewUser.Size = new Size(123, 41);
            btn_submitNewUser.TabIndex = 26;
            btn_submitNewUser.Text = "Create New User";
            btn_submitNewUser.UseVisualStyleBackColor = false;
            // 
            // newCust
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
            MaximumSize = new Size(775, 604);
            MinimumSize = new Size(775, 604);
            Name = "newCust";
            Text = "newCust";
            Load += newCust_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label8;
        private Label label9;
        private TextBox passConfirm;
        private Label label7;
        private TextBox passInput;
        private Label label6;
        private TextBox emailInput;
        private Label label5;
        private TextBox lNameInput;
        private TextBox fNameInput;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_submitNewUser;
    }
}