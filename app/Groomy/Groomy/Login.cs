using Groomy.Users;
using Groomy.Utilities;

namespace Groomy
{
    public partial class Login : Form
    {
        UserDBService userDBService = new UserDBService(DatabaseManager.GetInstance(new FileService()));
        DatabaseManager dbM = DatabaseManager.GetInstance(new FileService());
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
            windowFx.OpenForm("Groomy.Menu", false);
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
                    var userData = dbM.ReadObjectFromDB(userID, User.FilePaths["UserData"]);
                    var passwordData = dbM.ReadObjectFromDB(userID, User.FilePaths["PasswordData"]);
                    User user = new User().createWithHashedPassword(userData["FirstName"].ToString(), userData["LastName"].ToString(), userData["Email"].ToString(), hashedPassword);
                    UserAuth.GetInstance().setUser(user);

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

