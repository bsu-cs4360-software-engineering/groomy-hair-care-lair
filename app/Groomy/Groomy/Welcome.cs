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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            var frm = new Login();
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.Show();
            this.Hide();
        }

        private void custBtn_Click(object sender, EventArgs e)
        {
            var frm = new Cust();
            frm.StartPosition = FormStartPosition.CenterParent; // Optional: Center the dialog
            frm.Show();
            this.Hide();
        }
    }
}
