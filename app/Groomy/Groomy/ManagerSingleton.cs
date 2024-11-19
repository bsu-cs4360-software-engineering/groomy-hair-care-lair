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
        public Appointments.AppointmentDBService aDBS;
        public NotesDBService nDBS;

        private ManagerSingleton()
        {
            fs = new FileService();
            dbm = DatabaseManager.GetInstance(fs);
            ua = UserAuth.GetInstance();
            dbrs = new DBRelationshipService(this);
            cDBS = new CustomerDBService(this);
            aDBS = new Appointments.AppointmentDBService(this);
            nDBS = new NotesDBService(this);
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
