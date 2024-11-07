using Groomy.Users;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Groomy
{
    public partial class Login : Form
    {
        UserDBService userDBService = new UserDBService(DatabaseManager.GetInstance(new FileService()));
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
        private void switchToMainMenu(object sender, EventArgs e)
        {
            windowFx.OpenForm("Groomy.Tabs", false);
        }
        private bool IsUser(string userID)
        {
            return userDBService.IsUser(userID);
        }
        private bool IsCorrectPassword(string userID, string hashedPassword)
        {
            return userDBService.IsCorrectPassword(userID, hashedPassword);
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string userID = Helpers.GenerateSHA256Hash(txt_email.Text);
            string hashedPassword = Helpers.GenerateSHA256Hash(txt_password.Text);


            if (IsUser(userID))
            {
                if (IsCorrectPassword(userID, hashedPassword))
                {
                    Helpers.messageBoxSuccess("Logged in Successfully.");
                    switchToMainMenu(sender, e);
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

