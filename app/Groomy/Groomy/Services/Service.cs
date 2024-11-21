using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Services
{
    internal class Service : IGenericObject
    {
        public string serviceID;
        public string serviceName;
        public string serviceDescription;
        public string servicePrice;
        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            { "ServiceData", "services.json" }
        };
        public Service(string sn, string sd, string sp, string sID)
        {
            this.serviceID = sID;
            this.serviceName = sn;
            this.serviceDescription = sd;
            this.servicePrice = sp;
        }
        public Service(string sn, string sd, string sp) : this(sn, sd, sp, Helpers.RandomSHA256Hash())
        {
        }
        public Dictionary<string, Dictionary<string, string>> GetFields()
        {
            var temp = new Dictionary<string, Dictionary<string, string>>();
            temp["ServiceData"] = new Dictionary<string, string>
                {
                    { "ServiceID", serviceID.ToString() },
                    { "ServiceName", serviceName.ToString() },
                    { "ServiceDescription", serviceDescription.ToString() },
                    { "ServicePrice", servicePrice.ToString() }
                };
            return temp;
        }
        public string GetKey()
        {
            return serviceID;
        }
        public Dictionary<string, string> GetDBFilePaths()
        {
            return FilePaths;
        }
    }
}
