namespace Groomy.Relationships
{
    public interface IRelationship
    {
        string GetFilePath();
        Dictionary<string, string> GetIDs();
    }
    internal class User_Customer_Relationship : IRelationship
    {
        string userID;
        string customerID;
        public static string relationshipFilePath = "users_customers.json";
        public User_Customer_Relationship(string uID, string cID)
        {
            userID = uID;
            customerID = cID;
        }
        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("userID", userID);
            ids.Add("customerID", customerID);
            return ids;
        }
    }
}

