using Groomy.Notes;
using Groomy.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Services
{
    public class ServiceDBService
    {
        private DatabaseManager dbm;
        private DBRelationshipService dbrs;
        public ServiceDBService(ManagerSingleton ms)
        {
            this.dbm = ms.dbm;
            this.dbrs = ms.dbrs;
        }
        public ServiceDBService(DatabaseManager dbm, DBRelationshipService dbrs)
        {
            this.dbm = dbm;
            this.dbrs = dbrs;
        }

        public void CreateService(Service service)
        {
            dbm.CreateObjectInDB(service);
        }
        public Dictionary<string, string> ReadServiceData(string serviceID)
        {
            return dbm.ReadObjectFromDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public void UpdateServiceData(Service service)
        {
            var serviceID = service.GetKey();
            var serviceData = service.GetFields()["ServiceData"];

            dbm.UpdateObjectInDB(serviceID, serviceData, Service.FilePaths["ServiceData"]);
        }
        public void DeleteService(string serviceID)
        {
            dbm.DeleteObjectFromDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public void SoftDeleteService(string serviceID)
        {
            dbm.SoftDeleteObjectInDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public List<Dictionary<string, string>> GetServices()
        {
            Debug.WriteLine("Getting services");
            var services = new List<Dictionary<string, string>>();
            var serviceIDs = dbrs.GetServiceIDs();
            foreach (var customerID in serviceIDs)
            {
                services.Add(ReadServiceData(customerID));
            }
            return services;
        }
        public string GetServiceIDByName(string name)
        {
            var services = dbm.GetObjectsByKeyValue("ServiceName", name, Service.FilePaths["ServiceData"]);
            if (services.Count == 0)
            {
                return null;
            }
            if (services.Count > 1)
            {
                throw new Exception("Multiple services with the same name");
            }
            return services[0]["ServiceID"];

        }
    }
}
