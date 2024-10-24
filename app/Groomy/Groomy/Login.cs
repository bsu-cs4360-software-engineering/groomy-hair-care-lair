using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Text.Json;

namespace Groomy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            updateDBs();
        }
        private Dictionary<string, Dictionary<string, object>> users;
        private Dictionary<string, Dictionary<string, object>> passwords;
        private void updateLoginButton(object sender, EventArgs e)
        {
            if (this.txt_email.Text != "" & this.txt_password.Text != "")
            {
                this.btn_login.Enabled = true;
            }
            else
            {
                this.btn_login.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void switchToNewUserForm(object sender, EventArgs e)
        {
            var frm = new NewUser();
            frm.UserCreated += updateDBs;
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.ShowDialog();
        }
        private bool checkIfKnownEmail(string emailHash)
        {
            return passwords.ContainsKey(emailHash);
        }
        private Dictionary<string, object> getUserData(string emailHash)
        {
            return users[emailHash];
        }
        private Dictionary<string, object> getPasswordData(string emailHash)
        {
            return passwords[emailHash];
        }
        private void updateDBs()
        {
            users = Program.Helpers.loadDB("users.json");
            passwords = Program.Helpers.loadDB("passwords.json");
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string hashedEmail = Program.Helpers.GenerateSHA256Hash(txt_email.Text);
            string hashedPassword = Program.Helpers.GenerateSHA256Hash(txt_password.Text);

            if (checkIfKnownEmail(hashedEmail))
            {
                var userData = getUserData(hashedEmail);
                var passwordData = getPasswordData(hashedEmail);
                if (passwordData["Password"].ToString() == hashedPassword.ToString())
                {
                    Program.Helpers.messageBoxSuccess("Logged in Successfully.");
                }
                else
                {
                    Debug.WriteLine($"Inputted Password Hash: {hashedPassword}");
                    Debug.WriteLine($"Actual Password Hash: {userData["Password"]}");

                    Program.Helpers.messageBoxError("Incorrect Email or Password.\nPlease try again.\nbad password");
                }
            } 
            else
            {
                Program.Helpers.messageBoxError("Incorrect Email or Password.\nPlease try again.\nbad email");
            }
        }
    }
}
