

using System.Data;
using System.Diagnostics;

namespace Groomy.Customers
{
    internal class CustomerDBService
    {
        private DatabaseManager dbManager;
        public CustomerDBService(DatabaseManager dbm)
        {
            dbManager = dbm;
        }
        public void CreateCustomer(Customer customer)
        {
            dbManager.AddObjectsToDB(customer);
        }
        public Dictionary<string, object> ReadCustomer(string customerID)
        {
            return dbManager.LoadJsonFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void DeleteCustomer(string customerID)
        {
            dbManager.RemoveObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void SoftDeleteCustomer(string customerID)
        {
            dbManager.SoftDeleteObjectInDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public DataTable GetCustomerDataTable()
        {
           return dbManager.GetDataTable(Customer.FilePaths["CustomerData"], 4);
        }
        public List<(string, string)> GetCustomersByUserID(string userID)
        {
            var customers = new List<(string, string)>();
            var customerIDs = dbManager.GetIDsByKeyValue("UserID", userID, Customer.FilePaths["CustomerData"]);
            Debug.WriteLine(customerIDs.Count);
            foreach (var customerID in customerIDs)
            {
                var customerData = ReadCustomer(customerID);
                var firstName = customerData["FirstName"]?.ToString() ?? string.Empty;
                var lastName = customerData["LastName"]?.ToString() ?? string.Empty;
                customers.Add((firstName, lastName));
            }
            return customers;
        }
        public string GetCustomerIDByFirstLast( (string, string) name)
        {
            var customerIDs = dbManager.GetIDsByKeyValue("FirstName", name.Item1, Customer.FilePaths["CustomerData"]);
            foreach (var customerID in customerIDs)
            {
                var customerData = ReadCustomer(customerID);
                if (customerData["LastName"].ToString() == name.Item2)
                {
                    return customerID;
                }
            }
            return null;
        }
    }
}
