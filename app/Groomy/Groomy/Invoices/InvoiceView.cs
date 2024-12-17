using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groomy.Invoices
{
    public partial class InvoiceView : Form
    {
        Dictionary<string, string> invoiceData;
        List<Dictionary<string, string>> invoiceNotes;
        Menu parentForm;
        Size panelSize = new Size(419, 308);
        Point panelLoc = new Point(327, 90);
        ManagerSingleton ms;
        public InvoiceView(Dictionary<string, string> invoiceData, Menu parentForm)
        {
            this.ms = ManagerSingleton.GetInstance();
            this.invoiceData = invoiceData;
            this.parentForm = parentForm;
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        public void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(988, 493);
        }

        private void btnInvoiceServicesBack_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.reloadData();
            this.Close();
        }

        private void btnInvoiceEditSave_Click(object sender, EventArgs e)
        {
            if (btnInvoiceEditSave.Text == "Edit")
            {

            } 
            else if (btnInvoiceEditSave.Text == "Save")
            {

            }
        }
    }
}
