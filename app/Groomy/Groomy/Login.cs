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
        private void switchToNewUserForm(object sender, EventArgs e)
        {
            var frm = new NewUser();
            // frm.Size = new Size(420, this.Size.Height); // Set the size of NewUser  to match the current form
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
