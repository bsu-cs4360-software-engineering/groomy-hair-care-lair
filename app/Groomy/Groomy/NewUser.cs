namespace Groomy
{
    public partial class NewUser : Form
    {
        private bool userCreatedSuccessfully = false; // Flag to track user creation

        public NewUser()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(NewUser_FormClosing);
        }

        public delegate void UserCreatedEventHandler();
        public event UserCreatedEventHandler UserCreated;

        private bool validateNewUserFields()
        {
            // First name check
            if (fNameInput.Text == "")
            {
                Program.Helpers.messageBoxError("You did not enter a first name. Please try again.");
                return false;
            }
            // Last name check
            if (lNameInput.Text == "")
            {
                Program.Helpers.messageBoxError("You did not enter a last name. Please try again.");
                return false;
            }
            // Valid email check
            if (string.IsNullOrWhiteSpace(emailInput.Text) || !emailInput.Text.Contains("@")) // Replace with RegEx expression
            {
                Program.Helpers.messageBoxError("You did not enter a valid email. Please try again.");
                return false;
            }
            // Password match check
            if (passInput.Text != passConfirm.Text)
            {
                Program.Helpers.messageBoxError("The passwords do not match. Please reenter your passwords and try again.");
                passInput.Text = "";
                passConfirm.Text = "";
                return false;
            }
            // If checks pass, return true
            return true;
        }

        private void NewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show confirmation only if the user hasn't been created
            if (!userCreatedSuccessfully)
            {
                var result = MessageBox.Show("Are you sure you want to close? All progress will be lost.", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Prevent the form from closing
                }
            }
        }

        private (string, string, string, string) getNewUserFields()
        {
            return (fNameInput.Text, lNameInput.Text, emailInput.Text, passInput.Text);
        }

        private void btn_submitNewUser_Click(object sender, EventArgs e)
        {
            if (validateNewUserFields())
            {
                // Create new user object + save new user object to database
                User newUser = new User(getNewUserFields());
                // Display success message box and close NewUser form
                Program.Helpers.messageBoxSuccess("User Successfully Created");

                userCreatedSuccessfully = true; // Set flag to true
                UserCreated?.Invoke();
                this.Close();
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
