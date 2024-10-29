using Groomy;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Groomy
{
    public interface IFileService
    {
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
    }
    public class FileService : IFileService
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
    public interface IDatabase
    {
        public bool IsUser(string userID);
        public void AddUser(User user);
        public Dictionary<string, object> GetUser(string userID);
    }
    public class UserDatabase : IDatabase
    {
        private static UserDatabase _instance;
        private static readonly object _lock = new object(); // Lock for thread safety
        private readonly IFileService _fileService;
        private const string UsersFilePath = "users.json";
        private const string PasswordsFilePath = "passwords.json";

        private UserDatabase(IFileService fileService)
        {
            _fileService = fileService;
        }
        private UserDatabase()
        {
        }

        public static UserDatabase Instance(IFileService fileService)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UserDatabase(fileService);
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
        private void AddUserData(User user)
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
        private void AddPassword(User user)
        {
            var passwordData = new Dictionary<string, object>
            {
                { "Password", user.HashedPassword }
            };
            var passwords = LoadPasswords();
            passwords[user.userID] = passwordData;
            SavePasswords(passwords);
        }
        public Dictionary<string, object> GetUser(string userID)
        {
            return LoadUsers()[userID];
        }
        public Dictionary<string, object> GetPassword(string userID)
        {
            var passwords = LoadPasswords();
            if (passwords.ContainsKey(userID))
            {
                return passwords[userID];
            }
            var existingKeys = string.Join(", ", passwords.Keys);
            throw new KeyNotFoundException($"The given key '{userID}' was not present in the dictionary. Existing keys: {existingKeys}");
        }

        private Dictionary<string, Dictionary<string, object>> LoadUsers()
        {
            return LoadDatabase(UsersFilePath);
        }
        private Dictionary<string, Dictionary<string, object>> LoadPasswords()
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

                string json = this._fileService.ReadAllText(filePath);
                var serializedJson = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(json);
                return serializedJson;
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
