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
            updateUsers();
        }
        private Dictionary<string, Dictionary<string, object>> users;
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
            frm.UserCreated += updateUsers;
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.ShowDialog();
        }
        private bool checkIfKnownEmail(string emailHash)
        {
            return users.ContainsKey(emailHash);
        }
        private Dictionary<string, object> getUserData(string emailHash)
        {
            return users[emailHash];
        }
        private void updateUsers()
        {
            users = Program.Helpers.loadUsers("users.json");
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string hashedEmail = Program.Helpers.GenerateSHA256Hash(txt_email.Text);
            string hashedPassword = Program.Helpers.GenerateSHA256Hash(txt_password.Text);

            if (checkIfKnownEmail(hashedEmail))
            {
                var userData = getUserData(hashedEmail);
                if (userData["Password"].ToString() == hashedPassword.ToString())
                {
                    //successful login
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
