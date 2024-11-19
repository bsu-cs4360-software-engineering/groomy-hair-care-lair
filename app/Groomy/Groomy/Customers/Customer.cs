namespace Groomy.Customers
{
    public interface IGenericObject
    {
        public Dictionary<string, Dictionary<string, string>> GetFields();
        public string GetKey();
        public Dictionary<string, string> GetDBFilePaths();
    }
    internal class Customer : IGenericObject
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string address;
        public string customerID => Helpers.GenerateSHA256Hash(email);

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "CustomerData", "customers.json" }
        };
        public Customer(string fName, string lName, string eMail, string pNumber, string addr)
        {
            firstName = fName;
            lastName = lName;
            email = eMail;
            phoneNumber = pNumber;
            address = addr;
        }
        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["CustomerData"] = new Dictionary<string, string>
            {
                {"CustomerID", GetKey() },
                { "FirstName", firstName.ToString() },
                { "LastName", lastName.ToString() },
                { "Email", email.ToString() },
                { "PhoneNumber", phoneNumber.ToString() },
                { "Address", address.ToString() }
            };
            return temp;
        }
        public string GetKey()
        {
            return customerID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}
