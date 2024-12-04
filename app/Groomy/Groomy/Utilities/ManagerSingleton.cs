using Groomy.Appointments;
using Groomy.Customers;
using Groomy.Notes;
using Groomy.Services;
using Groomy.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Utilities
{
    public class ManagerSingleton
    {
        private static ManagerSingleton instance;
        public FileService fs;
        public DatabaseManager dbm;
        public UserAuth ua;
        public DBRelationshipService dbrs;
        public CustomerDBService cDBS;
        public AppointmentDBService aDBS;
        public NotesDBService nDBS;
        public ServiceDBService sDBS;

        public ManagerSingleton()
        {
            fs = new FileService();
            dbm = DatabaseManager.GetInstance(fs);
            ua = UserAuth.GetInstance();
            dbrs = new DBRelationshipService(this);
            cDBS = new CustomerDBService(this);
            aDBS = new AppointmentDBService(this);
            nDBS = new NotesDBService(this);
            sDBS = new ServiceDBService(this);
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
