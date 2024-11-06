namespace Groomy.Customers
{
    public interface IGenericObject
    {
        public Dictionary< string, Dictionary<string, object>> GetFields();
        public string GetKey();
        public Dictionary<string, string> GetDBFilePaths();
        public IGenericObject FromDictionary(Dictionary<string, object> dict);
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
        public IGenericObject FromDictionary(Dictionary<string, object> dict)
        {
            firstName = dict["FirstName"].ToString();
            lastName = dict["LastName"].ToString();
            email = dict["Email"].ToString();
            phoneNumber = dict["PhoneNumber"].ToString();
            address = dict["Address"].ToString();
            return this;
        }
        public Customer(string fName, string lName, string eMail, string pNumber, string addr)
        {
            firstName = fName;
            lastName = lName;
            email = eMail;
            phoneNumber = pNumber;
            address = addr;
        }
        public Dictionary<string, Dictionary<string, object>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, object>>();
            temp["CustomerData"] = new Dictionary<string, object>
            {
                { "FirstName", firstName },
                { "LastName", lastName },
                { "Email", email },
                { "PhoneNumber", phoneNumber },
                { "Address", address }
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
