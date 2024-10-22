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

        private void btn_submitNewUser_Click(object sender, EventArgs e)
        {
            if (fNameInput.Text == "")
            {
                MessageBox.Show("You did not enter a first name. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lNameInput.Text == "")
            {
                MessageBox.Show("You did not enter a last name. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(emailInput.Text) || !emailInput.Text.Contains("@"))

            {
                MessageBox.Show("You did not enter a valid email. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (passInput.Text == passConfirm.Text)

            {
                // Do something when passwords match
            }

            else

            {
                MessageBox.Show("The passwords do not match. Please reenter your passwords and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passInput.Text = "";
                passConfirm.Text = "";
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
