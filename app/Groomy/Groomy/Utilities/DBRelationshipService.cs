using Groomy.Customers;
using Groomy.Relationships;
using Groomy.Users;

namespace Groomy.Utilities
{
    public class DBRelationshipService
    {
        DatabaseManager dbm;
        UserAuth ua;

        public DBRelationshipService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.ua = ms.ua;
        }
        public DBRelationshipService(DatabaseManager dbm, UserAuth ua)
        {
            this.dbm = dbm;
            this.ua = ua;
        }
        public List<string> GetCustomerIDs()
        {
            var user_customer_relationships = dbm.ReadRelationshipEntry(ua.getID(), "users_customers.json");
            var customerIDs = new List<string>();
            foreach (var relationship in user_customer_relationships)
            {
                customerIDs.Add(relationship["customerID"]);
            }
            return customerIDs;
        }

        public List<string> GetInvoiceIDs()
        {
            var customerIDs = GetCustomerIDs();
            var invoiceIDs = new List<string>();
            foreach (var customerID in customerIDs)
            {
                var customer_invoice_relationships = dbm.ReadRelationshipEntry(customerID, "customers_invoices.json");
                foreach (var relationship in customer_invoice_relationships)
                {
                    invoiceIDs.Add(relationship["invoiceID"]);
                }
            }
            
            return invoiceIDs;
        }
        public List<string> GetServiceIDs()
        {
            var serviceIDs = new List<string>();
            var serviceDB = dbm.LoadJsonsFromDB("services.json");
            foreach (var service in serviceDB)
            {
                serviceIDs.Add(service["ServiceID"]);
            }
            return serviceIDs;
        }
        public List<string> GetForeignIDsFromPrimaryID(string primaryID, string relationshipPath)
        {
            //each primaryID can have multiple foreign IDs
            var object_relationships = dbm.ReadRelationshipEntry(primaryID, relationshipPath);

            var foreignIDs = new List<string>();

            //find the key that is not the primaryID, should be the foreign ID
            foreach (var relationship in object_relationships) 
            {
                foreach (var key in relationship.Keys)
                {
                    if (relationship[key] != primaryID)
                    {
                        //add the foreign ID to the list
                        foreignIDs.Add(relationship[key]);
                    }
                }
            }
            //return the list of foreign IDs
            return foreignIDs;
        }
        public string GetPrimaryIDFromForeignID(string foreignID, string relationshipPath)
        {
            //each foreignID should have only one primary ID
            var object_relationships = dbm.ReadRelationshipEntry(foreignID, relationshipPath);
            var relationship = object_relationships[0];

            //find the key that is not the foreignID, should be the primary ID
            foreach (var key in relationship.Keys)
            {
                if (relationship[key] != foreignID)
                {
                    //return the primary ID
                    return relationship[key];
                }
            }

            throw new Exception("Primary ID not found in the relationship entry.");
        }
    }
}
