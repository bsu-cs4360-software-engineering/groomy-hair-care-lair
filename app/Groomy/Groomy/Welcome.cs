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
        private void activatePanel(Panel panel)
        {
            var panelWH = new Size(520, 550);
            var panelLoc = new Point(227, 9);
            panel.Size = panelWH;
            panel.Location = panelLoc;
            panel.BringToFront();
        }

        public Welcome()
        {
            InitializeComponent();
        }
        private void onLoad(object sender, EventArgs e)
        {
            activatePanel(panelWelcome);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            //windowFx.OpenForm("Groomy.Login", false);
            activatePanel(panelWelcome);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            activatePanel(panelNewCustomer);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            activatePanel(panelCustomers);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            activatePanel(panelNewCustomer);
        }
    }
}
