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
        public Dictionary<string, string> LoadJsonFromDBString(string key, string filePath)
        {

            var database = LoadDatabase(filePath);
            if (database.ContainsKey(key))
            {
                return database[key].ToDictionary(x => x.Key, x => x.Value.ToString());
            }
            else
            {
                return null;
            }
        }
        public Dictionary<string, object> LoadJsonFromDB(string key, string filePath)
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

        //returns non-deleted items
        public List<string> GetIDsByKeyValue(string key, string value, string filePath)
        {
            var database = LoadDatabase(filePath);
            var matchingIDs = new List<string>();
            foreach (var genericObject in database)
            {
                bool deleted = false;
                bool foundKey = false;
                foreach (var genericItem in genericObject.Value)
                {
                    if (genericItem.Key == key && genericItem.Value?.ToString() == value)
                    {
                        foundKey = true;
                    }
                    if (genericItem.Key == isDeletedKey)
                    {
                        deleted = genericItem.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.True;
                        if (deleted) break;
                    }
                }
                if (foundKey && !deleted)
                {
                    matchingIDs.Add(genericObject.Key);
                }
            }
            return matchingIDs;
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
        public IGenericObject LoadObjectFromDB(string key, IGenericObject objectType)
        {
            var filePaths = objectType.GetDBFilePaths();
            var firstKey = filePaths.Keys.First();
            var database = objectType.GetFields()[filePaths[firstKey]];
            if (database.ContainsKey(key))
            {
                return objectType.FromDictionary(database);
            }
            else
            {
                return null;
            }

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
                database[key][isDeletedKey] = true;
                SaveDatabase(database, filePath);
            }
            else
            {
                Helpers.messageBoxError("No Key");
            }
        }
        public DataTable GetDataTableSpecificKeys(string filePath, List<string> keys)
        {
            DataTable dataTable = new DataTable();


            var data = LoadDatabase(filePath);

            if (data.Count == 0)
                return dataTable;

            // Add columns
            var firstItem = data.First().Value;
            foreach (var key in keys)
            {
                dataTable.Columns.Add(key);
            }

            // Add rows
            foreach (var item in data)
            {
                if (item.Value.ContainsKey(isDeletedKey))
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


