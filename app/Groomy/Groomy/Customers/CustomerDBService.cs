

using System.Data;

namespace Groomy.Customers
{
    internal class CustomerDBService
    {
        private databaseManager dbManager;
        public CustomerDBService(databaseManager dbm)
        {
            dbManager = dbm;
        }
        public void CreateCustomer(Customer customer)
        {
            dbManager.AddObjectsToDB(customer);
        }
        public Dictionary<string, object> ReadCustomer(string customerID)
        {
            return dbManager.LoadObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void DeleteCustomer(string customerID)
        {
            dbManager.RemoveObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }

        public DataTable GetCustomerDataTable()
        {
           return dbManager.GetDataTable(Customer.FilePaths["CustomerData"], 4);
        }
    }
}
