

using System.Data;

namespace Groomy
{
    internal class UserDBService
    {
        private databaseManager dbManager;
        public UserDBService(databaseManager dbm)
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
            } else
            {
                return false;
            }
        }
        public void CreateUser(User user)
        {
            dbManager.AddObjectsToDB(user);
        }
        public Dictionary<string, object> ReadUserData(string userID)
        {
            return dbManager.LoadObjectFromDB(userID, User.FilePaths["UserData"]);
        }
        public Dictionary<string, object> ReadPasswordData(string userID)
        {
            return dbManager.LoadObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
        public void DeleteUser(string userID)
        {
            dbManager.RemoveObjectFromDB(userID, User.FilePaths["UserData"]);
            dbManager.RemoveObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
    }
}
