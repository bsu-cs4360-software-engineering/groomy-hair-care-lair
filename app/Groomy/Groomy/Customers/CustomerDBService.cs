

using System.Data;
using System.Diagnostics;
using Groomy.Users;
using Groomy.Utilities;

namespace Groomy.Customers
{
    public class CustomerDBService
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
        public CustomerDBService(DatabaseManager dbManager, UserAuth ua)
        {
            this.dbManager = dbManager;
            userAuth = ms.ua;
        }

        public void CreateCustomer(Customer customer)
        {
            dbManager.CreateObjectInDB(customer);
            dbManager.CreateRelationshipEntry(new Relationships.User_Customer_Relationship(userAuth.getID(), customer.GetKey()));
        }
        public Dictionary<string, string> ReadCustomer(string customerID)
        {
            return dbManager.ReadObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void UpdateCustomerData(Customer customer)
        {
            var customerID = customer.GetKey();
            var customerData = customer.GetFields()["CustomerData"];
            //update customer
            dbManager.UpdateObjectInDB(customerID, customerData, Customer.FilePaths["CustomerData"]);
            //update relationship
            dbManager.UpdateRelationshipEntry(new Relationships.User_Customer_Relationship(userAuth.getID(), customerID));
        }
        public void DeleteCustomer(string customerID)
        {
            dbManager.DeleteObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
            dbManager.DeleteRelationshipEntry(new Relationships.User_Customer_Relationship(userAuth.getID(), customerID));
        }
        public void SoftDeleteCustomer(string customerID)
        {
            dbManager.SoftDeleteObjectInDB(customerID, Customer.FilePaths["CustomerData"]);
            var relationship = new Relationships.User_Customer_Relationship(userAuth.getID(), customerID);
            dbManager.SoftDeleteRelationshipEntry(relationship);
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
            Debug.WriteLine($"{customers.Count}");
            return customers;
        }
        public string GetCustomerIDByEmail(string email)
        {
            var customers = dbManager.GetObjectsByKeyValue("Email", email, Customer.FilePaths["CustomerData"]);

            if (customers == null || customers.Count == 0)
            {
                return null;
            }

            var customerIDs = Helpers.ExtractValuesFromJson("CustomerID", customers);

            return customerIDs?.FirstOrDefault();
        }
        public string GetCustomerIDByFirstLast((string, string) name)
        {
            var customers = dbManager.GetObjectsByKeyValue("FirstName", name.Item1, Customer.FilePaths["CustomerData"]);
            var customerIDs = Helpers.ExtractValuesFromJson("CustomerID", customers);

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
