using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Groomy
{
    internal class User
    {
        private string f;
        private string l;
        private string e;
        private string p;

        public User(string fName, string lName, string eMail, string password)
        {
            f = fName;
            l = lName;
            e = eMail;
            //hash password right away
            p = Program.Helpers.GenerateSHA256Hash(password);

            string userID = Program.Helpers.GenerateSHA256Hash(e);

            addUser_toJson(userID);
            addPassword_toJson(userID);
        }
        public User((string fName, string lName, string eMail, string password) userData)
        {
            f = userData.fName;
            l = userData.lName;
            e = userData.eMail;
            p = Program.Helpers.GenerateSHA256Hash(userData.password);

            string userID = Program.Helpers.GenerateSHA256Hash(e);

            addUser_toJson(userID);
            addPassword_toJson(userID);
        }

        private void addPassword_toJson(string userID)
        {
            var passwordData = new Dictionary<string, object>
            {
                { "Password", p }
            };

            string jsonFilePath = "passwords.json";
            Dictionary<string, Dictionary<string, object>> passwords;

            try
            {
                //tries to load passwords
                passwords = Program.Helpers.loadDB(jsonFilePath);

                //add new password to db
                passwords[userID] = passwordData;

                //Write updated password data bac to passwords.json
                string newDB = JsonSerializer.Serialize(passwords, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, newDB);
                Debug.WriteLine("Password Added Successsfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while adding user: {ex.Message}");
            }
        }

        private void addUser_toJson(string userID)
        {
            var userData = new Dictionary<string, object>
            {
                { "FirstName", f },
                { "LastName", l },
                { "Email", e }
            };

            string jsonFilePath = "users.json";
            Dictionary<string, Dictionary<string, object>> users;

            try
            {
                //tries to load users
                users = Program.Helpers.loadDB(jsonFilePath);

                // Add new user to the dictionary
                users[userID] = userData;

                // Write updated user data back to users.json
                string newJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, newJson);
                Debug.WriteLine("User added successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while adding user: {ex.Message}");
            }
        }
    }
}