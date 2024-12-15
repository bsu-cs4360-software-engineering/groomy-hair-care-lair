

using System.Data;
using System.Diagnostics;
using Groomy.Users;
using Groomy.Utilities;

namespace Groomy.Customers
{
    public class CustomerDBService
    {
        private DatabaseManager dbm;
        private UserAuth ua;
        private DBRelationshipService dbrs;
        public CustomerDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;  
            this.ua = ms.ua;
            this.dbrs = ms.dbrs;
        }
        public CustomerDBService(DatabaseManager dbManager, UserAuth ua, DBRelationshipService dbrs)
        {
            this.dbm = dbManager;
            this.ua = ua;
            this.dbrs = dbrs;
        }

        public void CreateCustomer(Customer customer)
        {
            dbm.CreateObjectInDB(customer);
            dbm.CreateRelationshipEntry(new Relationships.User_Customer_Relationship(ua.getID(), customer.GetKey()));
        }
        public Dictionary<string, string> ReadCustomer(string customerID)
        {
            return dbm.ReadObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
        }
        public void UpdateCustomerData(Customer customer)
        {
            var customerID = customer.GetKey();
            var customerData = customer.GetFields()["CustomerData"];
            //update customer
            dbm.UpdateObjectInDB(customerID, customerData, Customer.FilePaths["CustomerData"]);
            //update relationship
            dbm.UpdateRelationshipEntry(new Relationships.User_Customer_Relationship(ua.getID(), customerID));
        }
        public void DeleteCustomer(string customerID)
        {
            dbm.DeleteObjectFromDB(customerID, Customer.FilePaths["CustomerData"]);
            dbm.DeleteRelationshipEntry(new Relationships.User_Customer_Relationship(ua.getID(), customerID));
        }
        public void SoftDeleteCustomer(string customerID)
        {
            dbm.SoftDeleteObjectInDB(customerID, Customer.FilePaths["CustomerData"]);
            var relationship = new Relationships.User_Customer_Relationship(ua.getID(), customerID);
            dbm.SoftDeleteRelationshipEntry(relationship);
        }
        public List<Dictionary<string, string>> GetCustomers()
        {
            Debug.WriteLine("Getting customers");
            var customers = new List<Dictionary<string, string>>();
            var customerIDs = dbrs.GetCustomerIDs();
            foreach (var customerID in customerIDs)
            {
                customers.Add(ReadCustomer(customerID));
            }
            Debug.WriteLine($"{customers.Count}");
            return customers;
        }
        public string GetCustomerIDByEmail(string email)
        {
            var customers = dbm.GetObjectsByKeyValue("Email", email, Customer.FilePaths["CustomerData"]);

            if (customers == null || customers.Count == 0)
            {
                return null;
            }

            var customerIDs = Helpers.ExtractValuesFromJson("CustomerID", customers);

            return customerIDs?.FirstOrDefault();
        }
        public string GetCustomerIDByFirstLast((string, string) name)
        {
            var customers = dbm.GetObjectsByKeyValue("FirstName", name.Item1, Customer.FilePaths["CustomerData"]);
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
