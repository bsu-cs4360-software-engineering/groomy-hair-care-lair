using Groomy.Utilities;

namespace Groomy.Users
{
    internal class UserDBService
    {
        private DatabaseManager dbManager;
        public UserDBService(DatabaseManager dbm)
        {
            dbManager = dbm;
        }
        public bool IsUser(string userID)
        {
            return dbManager.KeyExists(userID, User.FilePaths["PasswordData"]);
        }
        public bool IsCorrectPassword(string userID, string hashedPassword)
        {
            var passwordData = ReadPasswordData(userID);
            var userData = ReadUserData(userID);
            if (passwordData.ContainsKey("Password") && passwordData["Password"].ToString() == hashedPassword.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CreateUser(User user)
        {
            dbManager.CreateObjectInDB(user);
        }
        public Dictionary<string, string> ReadUserData(string userID)
        {
            return dbManager.ReadObjectFromDB(userID, User.FilePaths["UserData"]);
        }
        public Dictionary<string, string> ReadPasswordData(string userID)
        {
            return dbManager.ReadObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
        public void DeleteUser(string userID)
        {
            dbManager.DeleteObjectFromDB(userID, User.FilePaths["UserData"]);
            dbManager.DeleteObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
    }
}
