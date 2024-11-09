using Groomy.Customers;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

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
        public string isDeletedKey = "IsDeleted";
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
        public void AddRelationshipToDB(Relationships.IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationship(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            // Check if the relationship already exists to avoid duplicates
            if (!previousRelationshipData.Any(r => r.SequenceEqual(IDs)))
            {
                previousRelationshipData.Add(IDs);
                SaveRelationship(previousRelationshipData, relationshipFilePath);
            }
        }
        public void DeleteRelationshipFromDB(Relationships.IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationship(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            // Find the relationship to remove
            var relationshipToRemove = previousRelationshipData.FirstOrDefault(r => r.SequenceEqual(IDs));
            if (relationshipToRemove != null)
            {
                previousRelationshipData.Remove(relationshipToRemove);
                SaveRelationship(previousRelationshipData, relationshipFilePath);
            }
        }
        public void SoftDeleteRelationshipFromDB(Relationships.IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationship(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            // Find the relationship to soft delete
            var relationshipToSoftDelete = previousRelationshipData.FirstOrDefault(r => r.SequenceEqual(IDs));
            if (relationshipToSoftDelete != null)
            {
                relationshipToSoftDelete[isDeletedKey] = "true";
                SaveRelationship(previousRelationshipData, relationshipFilePath);
            }
        }
        public Dictionary<string, string> LoadJsonFromDB(string ID, string filePath)
        {
            var database = LoadDatabase(filePath);
            foreach(var item in database)
            {
                if (item.ContainsValue(ID) && !item.ContainsKey(isDeletedKey))
                {
                    return item;
                }
            }
            return null;
        }

        //returns non-deleted items
        public List<Dictionary<string, string>> GetJsonsByKeyValue(string key, string value, string filePath)
        {
            var Jsons = new List<Dictionary<string, string>>();
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                bool deleted = false;
                bool found = false;
                if (item.ContainsKey(key) && item[key] != null) {
                    found = true;
                }
                if (item.ContainsKey(isDeletedKey))
                {
                    if (item[isDeletedKey] == "true")
                    {
                        deleted = true;
                    }
                }
                if(found && !deleted)
                {
                    Jsons.Add(item);
                }
            }

            return Jsons;
        }
        public List<string> GetValuesFromJsons(string key, List<Dictionary<string, string>> jsons)
        {
            var items = new List<string>();
            foreach (var item in jsons)
            {
                if (item.ContainsKey(key))
                {
                    items.Add(item[key]);
                }
            }
            return items;
        }
        public List<Dictionary<string, string>> GetRelationshipsByID(string id, string filePath)
        {
            var relationships = LoadRelationship(filePath);
            var matchingRelationships = new List<Dictionary<string, string>>();
            foreach (var relationship in relationships)
            {
                if (relationship.ContainsValue(id) && !relationship.ContainsKey(isDeletedKey))
                {
                    matchingRelationships.Add(relationship);
                }
            }
            return matchingRelationships;
        }
        private List<Dictionary<string, string>> LoadRelationship(string filePath)
        {
            try
            {
                if (!_fileService.Exists(filePath))
                {
                    return new List<Dictionary<string, string>>();
                }

                string JsonList = _fileService.ReadAllText(filePath);
                List<Dictionary<string, string>> serializedList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(JsonList);
                return serializedList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while loading database: {ex.Message}");
                return new List<Dictionary<string, string>>();
            }
        }
        private void SaveRelationship(List<Dictionary<string, string>> relationships, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(relationships, new JsonSerializerOptions { WriteIndented = true });
                _fileService.WriteAllText(filePath, json);
                Debug.WriteLine($"Data saved to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while saving database: {ex.Message}");
            }
        }
        private List<Dictionary<string, string>> LoadDatabase(string filePath)
        {
            try
            {
                if (!_fileService.Exists(filePath))
                {
                    return new List<Dictionary<string, string>>();
                }

                string json = _fileService.ReadAllText(filePath);
                var serializedJson = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
                return serializedJson;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occurred while loading database: {ex.Message}");
                return new List<Dictionary<string, string>>();
            }
        }
        private void SaveDatabase(List<Dictionary<string, string>> data, string filePath)
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
                database.Add(objectFields[dataType]);
                SaveDatabase(database, filePath);
            }
        }
        public bool KeyExists(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                if (item.ContainsValue(key) && !item.ContainsKey(isDeletedKey))
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveObjectFromDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                if (item.ContainsValue(key))
                {
                    database.Remove(item);
                    SaveDatabase(database, filePath);
                    return;
                }
            }
        }
        public void SoftDeleteObjectInDB(string key, string filePath)
        {
            var database = LoadDatabase(filePath);

            foreach (var item in database)
            {
                if (item.ContainsValue(key))
                {
                    item[isDeletedKey] = "true";
                    SaveDatabase(database, filePath);
                    return;
                }
                else
                {
                    Helpers.messageBoxError("No Key");
                }
            }
        }
        public DataTable GetDataTableSpecificKeys(string filePath, List<string> keys)
        {
            DataTable dataTable = new DataTable();

            var data = LoadDatabase(filePath);

            if (data.Count == 0)
                return dataTable;

            // Add columns
            foreach (var key in keys)
            {
                dataTable.Columns.Add(key);
            }

            // Add rows
            foreach (var item in data)
            {
                if (item.ContainsKey(isDeletedKey))
                {
                    continue;
                }
                DataRow row = dataTable.NewRow();
                foreach (var key in keys)
                {
                    row[key] = item[key];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}


