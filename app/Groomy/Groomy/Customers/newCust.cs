namespace Groomy.Customers
{
    public partial class newCust : Form
    {
        public newCust()
        {
            InitializeComponent();
        }

        private void newCust_Load(object sender, EventArgs e)
        {

        }

        private bool validateNewCustFields()
        {
            // First name check
            if (string.IsNullOrWhiteSpace(fNameInput.Text))
            {
                Helpers.messageBoxError("You did not enter a first name. Please try again.");
                return false;
            }

            // Last name check
            if (string.IsNullOrWhiteSpace(lNameInput.Text))
            {
                Helpers.messageBoxError("You did not enter a last name. Please try again.");
                return false;
            }

            // Valid email check using a simple regex for validation
            if (string.IsNullOrWhiteSpace(emailInput.Text) || !System.Text.RegularExpressions.Regex.IsMatch(emailInput.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Helpers.messageBoxError("You did not enter a valid email. Please try again.");
                return false;
            }

            // City input check
            if (string.IsNullOrWhiteSpace(addCity.Text))
            {
                Helpers.messageBoxError("You did not enter a city. Please try again.");
                return false;
            }

            // State selection check
            if (stateSelect.SelectedItem == null)
            {
                Helpers.messageBoxError("You did not select a state or province. Please try again.");
                return false;
            }

            // ZIP/Postal code check
            string country = countryTxtDisplay.Text;
            string postalCode = zipInput.Text;

            if (country == "United States")
            {
                // Validate ZIP code (5 digits or 5-4 format)
                if (!System.Text.RegularExpressions.Regex.IsMatch(postalCode, @"^\d{5}(-\d{4})?$"))
                {
                    Helpers.messageBoxError("You did not enter a valid ZIP code. Please try again.");
                    return false;
                }
            }
            else if (country == "Canada")
            {
                // Validate Postal Code (format A1A 1A1)
                if (!System.Text.RegularExpressions.Regex.IsMatch(postalCode, @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$"))
                {
                    Helpers.messageBoxError("You did not enter a valid Postal Code. Please try again.");
                    return false;
                }
            }

            // If all checks pass, return true
            return true;
        }

        private void stateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected state/province
            string selectedState = stateSelect.SelectedItem.ToString();

            // Check if the selected state/province is in the US or Canada
            if (IsUnitedStates(selectedState))
            {
                countryTxtDisplay.Text = "United States";
            }
            else if (IsCanada(selectedState))
            {
                countryTxtDisplay.Text = "Canada";
            }
            else
            {
                countryTxtDisplay.Text = ""; // Clear if no match
            }
        }

        private bool IsUnitedStates(string state)
        {
            // List of US states
            string[] usStates = {
        "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
        "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
        "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
        "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
        "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
        "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota",
        "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina",
        "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia",
        "Washington", "West Virginia", "Wisconsin", "Wyoming"
    };

            return usStates.Contains(state);
        }

        private bool IsCanada(string state)
        {
            // List of Canadian provinces and territories
            string[] canadaProvinces = {
        "Alberta", "British Columbia", "Manitoba", "New Brunswick",
        "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
        "Quebec", "Saskatchewan"
    };

            return canadaProvinces.Contains(state);
        }

        private void btn_submitNewUser_Click(object sender, EventArgs e)
        {
            if (validateNewCustFields() == true)
            {
                //create new user object + save new user object to database
                // to do
                Helpers.messageBoxSuccess("User Successfully Created");
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
