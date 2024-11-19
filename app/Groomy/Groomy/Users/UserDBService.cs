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
            return dbManager.KeyExists(userID, Users.User.FilePaths["PasswordData"]);
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
        public void CreateUser(Users.User user)
        {
            dbManager.AddObjectsToDB(user);
        }
        public Dictionary<string, string> ReadUserData(string userID)
        {
            return dbManager.LoadJsonFromDB(userID, Users.User.FilePaths["UserData"]);
        }
        public Dictionary<string, string> ReadPasswordData(string userID)
        {
            return dbManager.LoadJsonFromDB(userID, Users.User.FilePaths["PasswordData"]);
        }
        public void DeleteUser(string userID)
        {
            dbManager.RemoveObjectFromDB(userID, Users.User.FilePaths["UserData"]);
            dbManager.RemoveObjectFromDB(userID, Users.User.FilePaths["PasswordData"]);
        }
    }
}
