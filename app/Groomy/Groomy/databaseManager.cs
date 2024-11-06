    using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Data;
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
        bool Exists(string path);
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
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
    public class DatabaseManager
    {
        private static readonly object _lock = new object(); // Lock for thread safety
        private readonly IFileService _fileService;
        private static DatabaseManager _instance;
        public static void ResetInstance()
        {
            _instance = null;
        }

        public DatabaseManager(IFileService fileService)
        {
            _fileService = fileService;
        }

        public static DatabaseManager GetInstance(IFileService fileService)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseManager(fileService);
                    }
                }
            }
            return _instance;
        }
        public Dictionary<string, object> LoadObjectFromDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            if (database.ContainsKey(key))
            {
                return database[key];
            }
            else
            {
                return null;
            }
        }
        private Dictionary<string, Dictionary<string, object>> LoadDatabase(string filePath)
        {
            try
            {
                if (!_fileService.Exists(filePath))
                {
                    return new Dictionary<string, Dictionary<string, object>>();
                }

                string json = _fileService.ReadAllText(filePath);
                var serializedJson = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(json);
                return serializedJson;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while loading database: {ex.Message}");
                return new Dictionary<string, Dictionary<string, object>>();
            }
        }
        private void SaveDatabase(Dictionary<string, Dictionary<string, object>> data, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                _fileService.WriteAllText(filePath, json);
                Debug.WriteLine($"Data saved to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while saving database: {ex.Message}");
            }
        }
        public void AddObjectsToDB(IGenericObject genericObject)
        {
            var objectFields = genericObject.GetFields();
            var objectFilePaths = genericObject.GetDBFilePaths();
            foreach (var item in objectFilePaths)
            {
                var dataType = item.Key;
                var filePath = item.Value;
                var database = LoadDatabase(filePath);
                database[genericObject.GetKey()] = objectFields[dataType];
                SaveDatabase(database, filePath);
            }
        }
        public bool KeyExists(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            return database.ContainsKey(key);
        }
        
        public void RemoveObjectFromDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            if (database.ContainsKey(key))
            {
                database.Remove(key);
                SaveDatabase(database, filePath);
            }
        }
        public void SoftDeleteObjectInDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            if (database.ContainsKey(key))
            {
                database[key]["isDeleted"] = true;
                SaveDatabase(database, filePath);
            }
        }

        public DataTable GetDataTable(string filePath, int numberOfFields)
        {
            Debug.WriteLine($"Reading {filePath}");
            DataTable dataTable = new DataTable();

            var data = LoadDatabase(filePath);

            if (data.Count == 0)
                return dataTable;

            // Add columns
            var firstItem = data.First().Value;
            var keys = firstItem.Keys.Take(numberOfFields);
            foreach (var key in keys)
            {
                dataTable.Columns.Add(key);
            }

            // Add rows
            foreach (var item in data)
            {
                if (item.Value.ContainsKey("IsDeleted"))
                {
                    continue;
                }
                DataRow row = dataTable.NewRow();
                foreach (var key in keys)
                {
                    row[key] = item.Value[key];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
