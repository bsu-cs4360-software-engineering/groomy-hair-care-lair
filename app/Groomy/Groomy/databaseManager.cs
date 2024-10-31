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
 
    internal class databaseManager
    {
        private static readonly object _lock = new object(); // Lock for thread safety
        private readonly IFileService _fileService;
        private static databaseManager _instance;

        private databaseManager(IFileService fileService)
        {
            _fileService = fileService;
        }

        public static databaseManager GetInstance(IFileService fileService)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new databaseManager(fileService);
                    }
                }
            }
            return _instance;
        }

        private Dictionary<string, Dictionary<string, object>> LoadDatabase(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
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
        private void SaveDatabase(Dictionary<string, Dictionary<string, object>> data,string filePath)
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
        public void AddObjectToDB(IGenericObject genericObject)
        {
            var objectData = genericObject.GetFields();
            var database = LoadDatabase(genericObject.GetDBFilePath());
            database[genericObject.GetKey()] = objectData;
            SaveDatabase(database, genericObject.GetDBFilePath());
        }
        public Dictionary<string, object> LoadObjectFromDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            if (database.ContainsKey(key))
            {
                return database[key];
            }
            return null;
        }
        public void RemoveObjectFromDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            database.Remove(key);
            SaveDatabase(database, filePath);
        }
        public Dictionary<string, Dictionary<string, object>> Load(IGenericObject genericObject)
        {
            return LoadDatabase(genericObject.GetDBFilePath());
        }
        public DataTable GetDataTable(string filePath, int numberOfFields)
        {
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
