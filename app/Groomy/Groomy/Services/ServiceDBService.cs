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
    internal class ServiceDBService
    {
        private ManagerSingleton ms;
        public ServiceDBService(ManagerSingleton ms)
        {
            this.ms = ms;
        }
        public void CreateService(Service service)
        {
            ms.dbm.AddObjectsToDB(service);
        }
        public Dictionary<string, string> ReadServiceData(string serviceID)
        {
            return ms.dbm.LoadJsonFromDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public void UpdateServiceData(Service service)
        {
            var serviceID = service.GetKey();
            var serviceData = service.GetFields()["ServiceData"];

            ms.dbm.UpdateObjectInDB(serviceID, serviceData, Service.FilePaths["ServiceData"]);
        }
        public void DeleteService(string serviceID)
        {
            ms.dbm.RemoveObjectFromDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public void SoftDeleteService(string serviceID)
        {
            ms.dbm.SoftDeleteObjectInDB(serviceID, Service.FilePaths["ServiceData"]);
        }
        public List<Dictionary<string, string>> GetServices()
        {
            Debug.WriteLine("Getting services");
            var services = new List<Dictionary<string, string>>();
            var serviceIDs = ms.dbrs.GetServiceIDs();
            foreach (var customerID in serviceIDs)
            {
                services.Add(ReadServiceData(customerID));
            }
            return services;
        }
    }
}
