using Groomy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Groomy
{
    public struct UserData
    {
        Dictionary<string, object> data;

        public static implicit operator UserData(Dictionary<string, object> dictionary)
        {
            return new UserData { data = dictionary };
        }
        public object this[string key]
        {
            get => data.TryGetValue(key, out var value) ? value : null;
            set => data[key] = value;
        }
    }
    public struct UserPassword
    {
        Dictionary<string, object> password;

        public static implicit operator UserPassword(Dictionary<string, object> password)
        {
            return new UserPassword { password = password };
        }
        public object this[string key]
        {
            get => password.TryGetValue(key, out var value) ? value: null;
            set => password[key] = value;
        }
    }
    public class UserDatabase
    {
        private static UserDatabase _instance;
        private static readonly object _lock = new object(); // Lock for thread safety
        private const string UsersFilePath = "users.json";
        private const string PasswordsFilePath = "passwords.json";

        // Private constructor to prevent instantiation from outside
        private UserDatabase() { }

        // Public static property to get the instance
        public static UserDatabase Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserDatabase();
                        }
                    }
                }
                return _instance;
            }
        }
        public bool IsUser(string userID)
        {
            return LoadUsers().Keys.Contains(userID);
        }
        public void AddUser(User user)
        {
            AddUserData(user);
            AddPassword(user);
        }
        public void AddUserData(User user)
        {
            var userData = new Dictionary<string, object>
            {
                { "FirstName", user.FirstName },
                { "LastName", user.LastName },
                { "Email", user.Email }
            };
            var users = LoadUsers();
            users[user.userID] = userData;
            SaveUsers(users);
        }
        public void AddPassword(User user)
        {
            var passwordData = new Dictionary<string, object>
            {
                { "Password", user.HashedPassword }
            };
            var passwords = LoadPasswords();
            passwords[user.userID] = passwordData;
            SavePasswords(passwords);
        }
        public UserData GetUser(string userID)
        {
            return LoadUsers()[userID];
        }
        public UserPassword GetPassword(string userID)
        {
            return LoadPasswords()[userID];
        }
        public Dictionary<string, Dictionary<string, object>> LoadUsers()
        {
            return LoadDatabase(UsersFilePath);
        }
        public Dictionary<string, Dictionary<string, object>> LoadPasswords()
        {
            return LoadDatabase(PasswordsFilePath);
        }
        private Dictionary<string, Dictionary<string, object>> LoadDatabase(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new Dictionary<string, Dictionary<string, object>>();
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while loading database: {ex.Message}");
                return new Dictionary<string, Dictionary<string, object>>();
            }
        }
        private void SaveUsers(Dictionary<string, Dictionary<string, object>> users)
        {
            SaveDatabase(UsersFilePath, users);
        }
        private void SavePasswords(Dictionary<string, Dictionary<string, object>> passwords)
        {
            SaveDatabase(PasswordsFilePath, passwords);
        }
        private void SaveDatabase(string filePath, Dictionary<string, Dictionary<string, object>> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                Debug.WriteLine($"Data saved to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while saving database: {ex.Message}");
            }
        }
    }
}
