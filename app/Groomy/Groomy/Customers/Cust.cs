namespace Groomy
{
    public partial class Cust : Form
    {
        public Cust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            windowFx.OpenForm("Groomy.Customers.newCust", true);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            windowFx.OpenForm("Groomy.Welcome", false);
        }
    }
}
