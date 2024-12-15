using Groomy.Utilities;

namespace Groomy.Users
{
    internal class UserDBService
    {
        private DatabaseManager dbm;
        public UserDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
        }
        public UserDBService(DatabaseManager dbm)
        {
            this.dbm = dbm;
        }
        public bool IsUser(string userID)
        {
            return dbm.KeyExists(userID, User.FilePaths["PasswordData"]);
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
            dbm.CreateObjectInDB(user);
        }
        public Dictionary<string, string> ReadUserData(string userID)
        {
            return dbm.ReadObjectFromDB(userID, User.FilePaths["UserData"]);
        }
        public Dictionary<string, string> ReadPasswordData(string userID)
        {
            return dbm.ReadObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
        public void DeleteUser(string userID)
        {
            dbm.DeleteObjectFromDB(userID, User.FilePaths["UserData"]);
            dbm.DeleteObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
    }
}
