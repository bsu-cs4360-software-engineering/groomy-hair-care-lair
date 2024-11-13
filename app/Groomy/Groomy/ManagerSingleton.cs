using Groomy.Customers;
using Groomy.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy
{
    internal class ManagerSingleton
    {
        private static ManagerSingleton instance;
        public FileService fs;
        public DatabaseManager dbm;
        public UserAuth ua;
        public DBRelationshipService dbrs;
        public CustomerDBService cDBS;
        public AppointmentDBService aDBS;
        public NotesDBService nDBS;

        private ManagerSingleton()
        {
            fs = new FileService();
            dbm = DatabaseManager.GetInstance(fs);
            ua = UserAuth.GetInstance();
            dbrs = new DBRelationshipService(instance);
            cDBS = new CustomerDBService(instance);
            aDBS = new AppointmentDBService(instance);
            nDBS = new NotesDBService(instance);
        }

        public static ManagerSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ManagerSingleton();
            }
            return instance;
        }
    }
}
