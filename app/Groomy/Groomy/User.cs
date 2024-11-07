using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Groomy
{

    public class User: IGenericObject
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
        public Dictionary<string, Dictionary<string, object>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, object>>();
            temp["UserData"] = new Dictionary<string, object>
            {
                { "FirstName", f },
                { "LastName", l },
                { "Email", e }
            };
            temp["PasswordData"] = new Dictionary<string, object>
            {
                { "Password", p }
            };
            return temp;
        }

        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}