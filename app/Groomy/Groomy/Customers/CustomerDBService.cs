

using System.Data;

namespace Groomy.Customers
{
    internal class CustomerDBService
    {
        private DatabaseManager dbManager;
        private UserAuth userAuth;
        public CustomerDBService(DatabaseManager dbm, UserAuth ua)
        {
            dbManager = dbm;
            userAuth = ua;
        }
        public void CreateCustomer(Customer customer)
        {
            dbManager.AddObjectsToDB(customer);
            dbManager.AddRelationshipToDB(new Relationships.User_Customer_Relationship(userAuth.getID(), customer.GetKey()));
        }
        public Dictionary<string, object> ReadCustomer(string customerID)
        {
            return dbManager.LoadJsonFromDB(customerID, Customer.FilePaths["CustomerData"]);
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
        public DataTable GetCustomerDataTable()
        {
            return dbManager.GetDataTableSpecificKeys(Customer.FilePaths["CustomerData"], ["FirstName", "LastName", "Email", "PhoneNumber", "Address"]);
        }
        public List<Dictionary<string, string>> GetCustomers()
        {
            var customers = new List<Dictionary<string, string>>();
            var relationships = dbManager.GetRelationshipsByID(userAuth.getID(), Relationships.User_Customer_Relationship.relationshipFilePath);
            foreach (var relationship in relationships)
            {
                var customerID = relationship["customerID"];
                var customerData = ReadCustomer(customerID);
                Dictionary<string, string> customer = new Dictionary<string, string>();
                customer.Add("FirstName", customerData["FirstName"].ToString());
                customer.Add("LastName", customerData["LastName"].ToString());
                customer.Add("customerID", customerID);
                customers.Add(customer);
            }
            return customers;
        }
        public string GetCustomerIDByFirstLast((string, string) name)
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
