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
        }
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
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.ShowDialog();
        }
        private bool checkIfKnownEmail(string emailHash)
        {
            return UserDatabase.Instance.IsUser(emailHash);
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string hashedEmail = Helpers.GenerateSHA256Hash(txt_email.Text);
            string hashedPassword = Helpers.GenerateSHA256Hash(txt_password.Text);

            if (checkIfKnownEmail(hashedEmail))
            {
                var userData = UserDatabase.Instance.GetUser(hashedEmail);
                var passwordData = UserDatabase.Instance.GetPassword(hashedEmail);
                if (passwordData["Password"].ToString() == hashedPassword.ToString())
                {
                    Helpers.messageBoxSuccess("Logged in Successfully.");
                }
                else
                {
                    Debug.WriteLine($"Inputted Password Hash: {hashedPassword}");
                    Debug.WriteLine($"Actual Password Hash: {userData["Password"]}");

                    Helpers.messageBoxError("Incorrect Email or Password.\nPlease try again.\nbad password");
                }
            } 
            else
            {
                Helpers.messageBoxError("Incorrect Email or Password.\nPlease try again.\nbad email");
            }
        }
    }
}
