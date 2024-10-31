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
        private IDatabase db;

        public string FirstName => f;
        public string LastName => l;
        public string Email => e;
        public string userID => Helpers.GenerateSHA256Hash(e);
        public string HashedPassword => p;
        public IDatabase Database => db;

        public User(string fName, string lName, string eMail, string password, IDatabase database)
        {
            f = fName;
            l = lName;
            e = eMail;
            p = Helpers.GenerateSHA256Hash(password);
            db = database;

            AddUser();
        }
        public string GetKey()
        {
            return userID;
        }
        private void AddUser()
        {
            Database.AddUser(this);
        }

        public Dictionary<string, object> GetFields()
        {
            return new Dictionary<string, object>
            {
                { "FirstName", f },
                { "LastName", l },
                { "Email", e },
                { "Password", p }
            };
        }

        public string GetDBFilePath()
        {
            return "users.json";
        }
    }
}