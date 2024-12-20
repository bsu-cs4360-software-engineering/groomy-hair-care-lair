﻿using Groomy.Customers;

namespace Groomy.Users
{

    public class User : IGenericObject
    {
        private string f;
        private string l;
        private string e;
        private string p;

        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "UserData", "users.json" },
            { "PasswordData", "passwords.json" }
        };


        public string FirstName => f;
        public string LastName => l;
        public string Email => e;
        public string userID => Helpers.GenerateSHA256Hash(e);
        public string HashedPassword => p;
        public IGenericObject FromDictionary(Dictionary<string, object> dict)
        {
            f = dict["FirstName"].ToString();
            l = dict["LastName"].ToString();
            e = dict["Email"].ToString();
            p = dict["Password"].ToString();
            return this;
        }
        public User()
        {

        }
        public User(string fName, string lName, string eMail, string password)
        {
            f = fName;
            l = lName;
            e = eMail;
            p = Helpers.GenerateSHA256Hash(password);
        }
        public User createWithHashedPassword(string fName, string lName, string eMail, string hashedPassword)
        {
            f = fName;
            l = lName;
            e = eMail;
            p = hashedPassword;
            return this;
        }
        public string GetKey()
        {
            return userID;
        }
        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["UserData"] = new Dictionary<string, string>
            {
                { "UserID", GetKey()},
                { "FirstName", f.ToString() },
                { "LastName", l.ToString() },
                { "Email", e.ToString() }
            };
            temp["PasswordData"] = new Dictionary<string, string>
            {
                { "UserID", GetKey()},
                { "Password", p.ToString()  }
            };
            return temp;
        }

        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}