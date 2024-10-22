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
        private void switchToNewUserForm (object sender, EventArgs e)
        {
            this.Hide();
            NewUser newUserMenu = new NewUser();
            newUserMenu.Show();
        }
    }
}
