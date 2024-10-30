using Groomy.User;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Groomy
{
    public partial class Login : Form
    {
        IFileService fileService = new FileService();
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
            windowFx.OpenForm("Groomy.NewUser", true);  
        }
        private void switchToWelcomeForm(object sender, EventArgs e)
        {
            windowFx.OpenForm("Groomy.Welcome", false);
        }
        private bool checkIfKnownEmail(string emailHash)
        {
            return UserDatabase.Instance(fileService).IsUser(emailHash);
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string hashedEmail = Helpers.GenerateSHA256Hash(txt_email.Text);
            string hashedPassword = Helpers.GenerateSHA256Hash(txt_password.Text);


            if (checkIfKnownEmail(hashedEmail))
            {
                var userData = UserDatabase.Instance(fileService).GetUser(hashedEmail);
                var passwordData = UserDatabase.Instance(fileService).GetPassword(hashedEmail);
                if (passwordData.ContainsKey("Password") && passwordData["Password"].ToString() == hashedPassword.ToString())
                {
                    Helpers.messageBoxSuccess("Logged in Successfully.");
                    switchToWelcomeForm(sender, e);
                }
                else
                {
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

