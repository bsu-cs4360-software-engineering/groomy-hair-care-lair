using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Groomy
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }
        private void messageBoxError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool validateNewUserFields()
        {
            //first name check
            if (fNameInput.Text == "")
            {
                messageBoxError("You did not enter a first name. Please try again.");
                return false;
            }
            //last name check
            if (lNameInput.Text == "")
            {
                messageBoxError("You did not enter a last name. Please try again.");
                return false;
            }
            //valid email check
            if (string.IsNullOrWhiteSpace(emailInput.Text) || !emailInput.Text.Contains("@")) //replace with RegEx expression
            {
                messageBoxError("You did not enter a valid email. Please try again.");
                return false;
            }
            //password match check
            if (passInput.Text != passConfirm.Text)
            {
                messageBoxError("The passwords do not match. Please reenter your passwords and try again.");
                passInput.Text = "";
                passConfirm.Text = "";
                return false;
            }
            //if checks pass, return true
            return true;
        }
        private void btn_submitNewUser_Click(object sender, EventArgs e)
        {
           if (validateNewUserFields() == true)
            {
                //create new user object + save new user object to database
                MessageBox.Show("User Successfully Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
