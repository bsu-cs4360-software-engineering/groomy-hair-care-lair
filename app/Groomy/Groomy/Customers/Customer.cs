using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Customers
{
    public interface IGenericObject
    {
        public Dictionary<string, object> GetFields();
        public string GetKey();
        public string GetDBFilePath();
    }
    public class Customer : IGenericObject
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string address;

        public const string CustomersFilePath = "customers.json";
        public Customer(string fName, string lName, string eMail, string pNumber, string addr)
        {
            firstName = fName;
            lastName = lName;
            email = eMail;
            phoneNumber = pNumber;
            address = addr;
        }
        public Dictionary<string, object> GetFields()
        {
            return new Dictionary<string, object>
            {
                { "FirstName", firstName },
                { "LastName", lastName },
                { "Email", email },
                { "PhoneNumber", phoneNumber },
                { "Address", address }
            };
        }
        public string GetKey()
        {
            return Helpers.GenerateSHA256Hash(email);
        }
        public string GetDBFilePath()
        {
            return CustomersFilePath;
        }
    }
}
