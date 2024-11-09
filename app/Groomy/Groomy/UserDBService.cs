namespace Groomy
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
            dbManager.AddObjectsToDB(user);
        }
        public Dictionary<string, string> ReadUserData(string userID)
        {
            return dbManager.LoadJsonFromDB(userID, User.FilePaths["UserData"]);
        }
        public Dictionary<string, string> ReadPasswordData(string userID)
        {
            return dbManager.LoadJsonFromDB(userID, User.FilePaths["PasswordData"]);
        }
        public void DeleteUser(string userID)
        {
            dbManager.RemoveObjectFromDB(userID, User.FilePaths["UserData"]);
            dbManager.RemoveObjectFromDB(userID, User.FilePaths["PasswordData"]);
        }
    }
}
