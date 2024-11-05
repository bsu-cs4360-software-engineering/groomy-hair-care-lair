namespace Groomy.Customers
{
    public interface IGenericObject
    {
        public Dictionary< string, Dictionary<string, object>> GetFields();
        public string GetKey();
        public Dictionary<string, string> GetDBFilePaths();
    }
    public class Customer : IGenericObject
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string address;

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
        public Dictionary<string, Dictionary<string, object>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, object>>();
            var CustomerData = new Dictionary<string, object>();
            CustomerData[this.GetKey()] = new Dictionary<string, object>
            {
                { "FirstName", firstName },
                { "LastName", lastName },
                { "Email", email },
                { "PhoneNumber", phoneNumber },
                { "Address", address }
            };
            temp["CustomerData"] = CustomerData;
            return temp;
        }
        public string GetKey()
        {
            return Helpers.GenerateSHA256Hash(email);
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}
