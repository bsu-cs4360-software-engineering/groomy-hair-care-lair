﻿using Groomy.Customers;
using Groomy.Relationships;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

namespace Groomy.Utilities
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
        public DatabaseManager(ManagerSingleton ms)
        {
            _fileService = ms.fs;
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
        public List<Dictionary<string, string>> LoadJsonsFromDB(string filePath)
        {
            var database = LoadDatabase(filePath);
            var jsons = new List<Dictionary<string, string>>();
            foreach (var item in database)
            {
                if (!item.ContainsKey(isDeletedKey))
                {
                    jsons.Add(item);
                }
            }
            return jsons;
        }
        public void CreateObjectInDB(IGenericObject genericObject)
        {
            var objectKey = genericObject.GetKey();
            var objectFields = genericObject.GetFields();
            var objectFilePaths = genericObject.GetDBFilePaths();
            foreach (var item in objectFilePaths)
            {
                var dataType = item.Key;
                var obj = objectFields[dataType];

                var filePath = item.Value;
                if (KeyExists(objectKey, filePath))
                {
                    UpdateObjectInDB(objectKey, objectFields[item.Key], item.Value);
                    return;
                }

                var database = LoadDatabase(filePath);
                database.Add(obj);
                SaveDatabase(database, filePath);
            }
        }
        public Dictionary<string, string> ReadObjectFromDB(string ID, string filePath)
        {
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                if (item.ContainsValue(ID) && !item.ContainsKey(isDeletedKey))
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateObjectInDB(string objectID, Dictionary<string, string> data, string filePath)
        {
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                if (item.ContainsValue(objectID))
                {
                    foreach (var key in data.Keys)
                    {
                        item[key] = data[key];
                    }
                    SaveDatabase(database, filePath);
                    return;
                }
            }
        }
        public void DeleteObjectFromDB(string key, string filePath)
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
        private List<Dictionary<string, string>> LoadRelationships(string filePath)
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
        private void SaveRelationships(List<Dictionary<string, string>> relationships, string filePath)
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
        public void CreateRelationshipEntry(IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationships(relationshipFilePath);
            Dictionary<string, string> newIDs = relationship.GetIDs();

            // Check if the relationship already exists to avoid duplicates
            bool exists = previousRelationshipData.Any(existingIDs =>
                existingIDs.Count == newIDs.Count &&
                !existingIDs.Except(newIDs).Any());

            if (!exists)
            {
                previousRelationshipData.Add(newIDs);
                SaveRelationships(previousRelationshipData, relationshipFilePath);
            }
        }
        public List<Dictionary<string, string>> ReadRelationshipEntry(string id, string filePath)
        {
            var relationships = LoadRelationships(filePath);
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
        public void UpdateRelationshipEntry(IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var allRelationshipData = LoadRelationships(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            if (IDs.Count < 2)
            {
                throw new ArgumentException("IDs dictionary must contain at least two values.");
            }

            var id_to_modify = IDs.ElementAt(0).Value;
            var id_to_keep = IDs.ElementAt(1).Value;

            // Find the relationship item containing the value id_to_keep
            var relationshipToModify = allRelationshipData.FirstOrDefault(r => r.ContainsValue(id_to_keep));

            if (relationshipToModify != null)
            {
                foreach (var key in relationshipToModify.Keys.ToList())
                {
                    if (relationshipToModify[key] != id_to_keep)
                    {
                        relationshipToModify[key] = id_to_modify;
                    }
                }
                SaveRelationships(allRelationshipData, relationshipFilePath);
            }
        }
        public void DeleteRelationshipEntry(IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationships(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            // Find the relationship to remove
            var relationshipToRemove = previousRelationshipData.FirstOrDefault(r => r.SequenceEqual(IDs));
            if (relationshipToRemove != null)
            {
                previousRelationshipData.Remove(relationshipToRemove);
                SaveRelationships(previousRelationshipData, relationshipFilePath);
            }
        }
        public void SoftDeleteRelationshipEntry(IRelationship relationship)
        {
            var relationshipFilePath = relationship.GetFilePath();
            var previousRelationshipData = LoadRelationships(relationshipFilePath);
            Dictionary<string, string> IDs = relationship.GetIDs();

            // Find the relationship to soft delete
            var relationshipToSoftDelete = previousRelationshipData.FirstOrDefault(r => r.SequenceEqual(IDs));
            if (relationshipToSoftDelete != null)
            {
                relationshipToSoftDelete[isDeletedKey] = "true";
                SaveRelationships(previousRelationshipData, relationshipFilePath);
            }
        }
        public List<Dictionary<string, string>> GetObjectsByKeyValue(string key, string value, string filePath)
        {
            var Jsons = new List<Dictionary<string, string>>();
            var database = LoadDatabase(filePath);
            foreach (var item in database)
            {
                bool deleted = false;
                bool found = false;
                if (item.ContainsKey(key) && item[key] == value)
                {
                    found = true;
                }
                if (item.ContainsKey(isDeletedKey))
                {
                    if (item[isDeletedKey] == "true")
                    {
                        deleted = true;
                    }
                }
                if (found && !deleted)
                {
                    Jsons.Add(item);
                }
            }

            return Jsons;
        }
    }
}


