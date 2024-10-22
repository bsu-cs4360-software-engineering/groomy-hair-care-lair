using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void switchToLogin (object sender, EventArgs e)
        {
            this.Hide();
            Login newLogin = new Login();
            newLogin.Show();
        }
    }
}
