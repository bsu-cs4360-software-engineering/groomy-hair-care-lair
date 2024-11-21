

using System.Data;
using System.Diagnostics;
using Groomy.Users;
using Groomy.Utilities;

namespace Groomy.Customers
{
    internal class CustomerDBService
    {
        private DatabaseManager dbManager;
        private UserAuth userAuth;
        private ManagerSingleton ms;
        public CustomerDBService(ManagerSingleton ms)
        {

            this.ms = ms;
            dbManager = ms.dbm;  
            userAuth = ms.ua;
        }
        public void CreateCustomer(Customer customer)
        {
            dbManager.AddObjectsToDB(customer);
            dbManager.AddRelationshipToDB(new Relationships.User_Customer_Relationship(userAuth.getID(), customer.GetKey()));
        }
        public Dictionary<string, string> ReadCustomer(string customerID)
        {
            return dbManager.LoadJsonFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void UpdateCustomerData(Customer customer)
        {
            var customerID = customer.GetKey();
            var customerData = customer.GetFields()["CustomerData"];
            //update customer
            dbManager.UpdateObjectInDB(customerID, customerData, Customer.FilePaths["CustomerData"]);
            //update relationship
            dbManager.UpdateRelationshipInDB(new Relationships.User_Customer_Relationship(userAuth.getID(), customerID));
        }
        public void DeleteCustomer(string customerID)
        {
            dbManager.RemoveObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
            dbManager.DeleteRelationshipFromDB(new Relationships.User_Customer_Relationship(userAuth.getID(), customerID));
        }
        public void SoftDeleteCustomer(string customerID)
        {
            dbManager.SoftDeleteObjectInDB(customerID, Customer.FilePaths["CustomerData"]);
            var relationship = new Relationships.User_Customer_Relationship(userAuth.getID(), customerID);
            dbManager.SoftDeleteRelationshipFromDB(relationship);
        }
        public DataTable GetCustomerDataTable(List<string> keys = null)
        {
            keys ??= new List<string>();
            var customers = GetCustomers();
            var dataTable = new DataTable();
            if (customers.Count() > 0)
            {
                if (keys.Count == 0)
                {
                    // Add default columns if no keys are provided
                    foreach (var key in customers.First().Keys)
                    {
                        dataTable.Columns.Add(key);
                    }
                }
                else
                {
                    foreach (var key in keys)
                    {
                        dataTable.Columns.Add(key);
                    }
                }
                foreach (var customer in customers)
                {
                    if (customer != null)
                    {
                        var row = dataTable.NewRow();
                        foreach (var key in keys)
                        {
                            if (customer.ContainsKey(key))
                            {
                                row[key] = customer[key];
                            }
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }
            return dataTable;
        }
        public List<Dictionary<string, string>> GetCustomers()
        {
            Debug.WriteLine("Getting customers");
            var customers = new List<Dictionary<string, string>>();
            var customerIDs = ms.dbrs.GetCustomerIDs();
            foreach (var customerID in customerIDs)
            {
                customers.Add(ReadCustomer(customerID));
            }
            return customers;
        }
        public string GetCustomerIDByEmail(string email)
        {
            var customers = dbManager.GetJsonsByKeyValue("Email", email, Customer.FilePaths["CustomerData"]);

            if (customers == null || customers.Count == 0)
            {
                return null;
            }

            var customerIDs = dbManager.GetValuesFromJsons("CustomerID", customers);

            return customerIDs?.FirstOrDefault();
        }
        public string GetCustomerIDByFirstLast((string, string) name)
        {
            var customers = dbManager.GetJsonsByKeyValue("FirstName", name.Item1, Customer.FilePaths["CustomerData"]);
            var customerIDs = dbManager.GetValuesFromJsons("CustomerID", customers);

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
