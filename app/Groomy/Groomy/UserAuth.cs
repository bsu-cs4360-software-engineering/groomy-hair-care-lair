namespace Groomy
{
    internal class UserAuth
    {
        private static readonly object _lock = new object(); // Lock for thread safety
        private static UserAuth _instance;
        private static Users.User user;
        public static UserAuth GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserAuth();
                    }
                }
            }
            return _instance;
        }
        public void setUser(Users.User user)
        {
            UserAuth.user = user;
        }
        public string getID()
        {
            return user.userID;
        }
    }
}
