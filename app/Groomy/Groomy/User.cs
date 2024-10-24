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
            // Call method to add user to JSON
            addUser_toJson();
        }
        public User((string fName, string lName, string eMail, string password) userData)
        {
            f = userData.fName;
            l = userData.lName;
            e = userData.eMail;
            p = Program.Helpers.GenerateSHA256Hash(userData.password);
            addUser_toJson();
        }

        private void addUser_toJson()
        {
            string userId = Program.Helpers.GenerateSHA256Hash(e);
            var userData = new Dictionary<string, object>
            {
                { "FirstName", f },
                { "LastName", l },
                { "Email", e },
                { "Password", p }
            };

            string jsonFilePath = "users.json";
            Dictionary<string, Dictionary<string, object>> users;

            try
            {
                //tries to load users
                users = Program.Helpers.loadUsers(jsonFilePath);

                // Add new user to the dictionary
                users[userId] = userData;

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