using Groomy.Appointments;
using Groomy.Customers;
using Groomy.Invoices;
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
        public UserDBService uDBS;
        public CustomerDBService cDBS;
        public AppointmentDBService aDBS;
        public NotesDBService nDBS;
        public ServiceDBService sDBS;
        public InvoiceDBService iDBS;

        public ManagerSingleton()
        {
            fs = new FileService();
            dbm = DatabaseManager.GetInstance(fs);
            ua = UserAuth.GetInstance();
            dbrs = new DBRelationshipService(this);
            uDBS = new UserDBService(this);
            cDBS = new CustomerDBService(this);
            aDBS = new AppointmentDBService(this);
            nDBS = new NotesDBService(this);
            sDBS = new ServiceDBService(this);
            iDBS = new InvoiceDBService(this);
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
