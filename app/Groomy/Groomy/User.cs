using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Groomy
{
    public class User
    {
        private string f;
        private string l;
        private string e;
        private string p;
        private UserDatabase db;

        public string FirstName => f;
        public string LastName => l;
        public string Email => e;
        public string userID => Helpers.GenerateSHA256Hash(e);
        public string HashedPassword => p;
        public UserDatabase Database => db;

        public User(string fName, string lName, string eMail, string password, UserDatabase db)
        {
            f = fName;
            l = lName;
            e = eMail;
            p = Helpers.GenerateSHA256Hash(password);

            AddUser();
        }

        private void AddUser()
        {
            this.Database.AddUser(this);
        }
    }
}