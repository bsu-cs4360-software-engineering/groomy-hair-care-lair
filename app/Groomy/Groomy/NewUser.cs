namespace Groomy
{
    public partial class NewUser : Form
    {
        UserDBService userDBService = new UserDBService(DatabaseManager.GetInstance(new FileService()));
        public NewUser()
        {
            InitializeComponent();
        }

        private bool validateNewUserFields()
        {
            //first name check
            if (fNameInput.Text == "")
            {
                Helpers.messageBoxError("You did not enter a first name. Please try again.");
                return false;
            }
            //last name check
            if (lNameInput.Text == "")
            {
                Helpers.messageBoxError("You did not enter a last name. Please try again.");
                return false;
            }
            //valid email check
            if (string.IsNullOrWhiteSpace(emailInput.Text) || !emailInput.Text.Contains("@")) //replace with RegEx expression
            {
                Helpers.messageBoxError("You did not enter a valid email. Please try again.");
                return false;
            }
            //password match check
            if (passInput.Text != passConfirm.Text)
            {
                Helpers.messageBoxError("The passwords do not match. Please reenter your passwords and try again.");
                passInput.Text = "";
                passConfirm.Text = "";
                return false;
            }
            //if checks pass, return true
            return true;
        }
        private (string, string, string, string) getNewUserFields()
        {
            return (fNameInput.Text, lNameInput.Text, emailInput.Text, passInput.Text);
        }
        private void btn_submitNewUser_Click(object sender, EventArgs e)
        {
            if (validateNewUserFields() == true)
            {
                //create new user object + save new user object to database
                var (fName, lName, eMail, password) = getNewUserFields();
                User newUser = new User(fName, lName, eMail, password);
                userDBService.CreateUser(newUser);
                Helpers.messageBoxSuccess("User Successfully Created");
                this.Close();
            }
            else
            {
                //do nothing
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
