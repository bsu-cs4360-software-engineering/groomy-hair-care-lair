﻿using Groomy.Appointments;
using Groomy.Customers;
using Groomy.Utilities;
using System.Data;
using System.Diagnostics;

namespace Groomy
{
    public partial class Menu : Form
    {
        ManagerSingleton ms;
        Size panelWH = new Size(520, 550);
        Point panelLoc = new Point(227, 9);
        public bool editing;
        public Menu()
        {
            InitializeComponent();
            this.Load += new EventHandler(onLoad);
        }
        private void onLoad(object sender, EventArgs e)
        {
            this.Size = new Size(750, 550);
            ms = ManagerSingleton.GetInstance();
            editing = false; // Use the class-level 'editing' variable
            Helpers.activatePanel(panelWelcome, panelWH, panelLoc);
            loadAppointmentData();
            loadCustomerData();
        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            loadCustomerData();
            Helpers.activatePanel(panelCustomers, panelWH, panelLoc);
        }
        private void btnWelcome_Click(object sender, EventArgs e)
        {
            //windowFx.OpenForm("Groomy.Login", false);
            Helpers.activatePanel(panelWelcome, panelWH, panelLoc);
        }
        private void btnServices_Click(object sender, EventArgs e)
        {
            loadServiceData();
            Helpers.activatePanel(panelServices, panelWH, panelLoc);
        }


        private void btnAppointment_Click(object sender, EventArgs e)
        {
            loadAppointmentData();
            Helpers.activatePanel(apptPanel, panelWH, panelLoc);
        }
        private void btnCustomerNew_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer("", "", "", "", "", "");
            var customerData = newCustomer.GetFields()["CustomerData"];
            Form customerView = new CustomerView(customerData, this);
            customerView.Show();
        }
        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            var newAppointment = new Appointments.Appointment("", "", DateTime.Now, DateTime.Now, "", "");
            var appointmentData = newAppointment.GetFields()["AppointmentData"];
            Form appointmentView = new Appointments.AppointmentView(appointmentData, this);
            appointmentView.Show();
        }
        private void btnServiceNew_Click(object sender, EventArgs e)
        {
            var newService = new Services.Service("", "", "", "");
            var serviceData = newService.GetFields()["ServiceData"];
            Form serviceView = new Services.ServiceView(serviceData, this);
            serviceView.Show();
        }
        private void btnBackToCustomers_Click(object sender, EventArgs e)
        {
            Helpers.activatePanel(panelCustomers, panelWH, panelLoc);
        }
        public void reloadData()
        {
            loadAppointmentData();
            loadCustomerData();
            loadServiceData();
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var email = Helpers.GetFieldFromSelection("Email", dataCustomers);
            var customerID = ms.cDBS.GetCustomerIDByEmail(email);

            if (!string.IsNullOrEmpty(email))
            {
                if (Helpers.messageBoxConfirm("Are you sure you want to delete this customer?"))
                {
                    var noteIDs = ms.dbrs.GetNotesIDFromCustomerID(customerID);
                    foreach (var noteID in noteIDs)
                    {
                        ms.nDBS.SoftDeleteCustomerNotes(noteID);
                    }
                    ms.cDBS.SoftDeleteCustomer(customerID);
                    loadCustomerData();
                }
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer to delete.");
            }
        }
        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            var appointmentID = Helpers.GetFieldFromSelection("AppointmentID", dataAppointments);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this appointment?"))
            {
                var noteIDs = ms.dbrs.GetNotesIDFromAppointmentID(appointmentID);
                foreach (var noteID in noteIDs)
                {
                    ms.nDBS.SoftDeleteAppointmentNotes(noteID);
                }

                ms.aDBS.SoftDeleteAppointment(appointmentID);
                loadAppointmentData();
            }
        }

        private void btnServiceDelete_Click(object sender, EventArgs e)
        {
            var serviceID = Helpers.GetFieldFromSelection("ServiceID", dataServices);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this service?"))
            {
                var noteIDs = ms.dbrs.GetNotesIDFromServiceID(serviceID);
                foreach (var noteID in noteIDs)
                {
                    ms.nDBS.SoftDeleteServiceNotes(noteID);
                }
                ms.sDBS.SoftDeleteService(serviceID);
                loadServiceData();
            }
        }

        private void apptDel_Click(object sender, EventArgs e)
        {
            var appointmentID = Helpers.GetFieldFromSelection("AppointmentID", dataAppointments);
            if (Helpers.messageBoxConfirm("Are you sure you want to delete this appointment?"))
            {
                var noteIDs = ms.dbrs.GetNotesIDFromAppointmentID(appointmentID);
                foreach (var noteID in noteIDs)
                {
                    ms.nDBS.SoftDeleteAppointmentNotes(noteID);
                }
                ms.aDBS.SoftDeleteAppointment(appointmentID);
                loadAppointmentData();
            }

        }
        private void loadAppointmentData()
        {
            var appointments = ms.aDBS.GetAppointments();
            dataAppointments.DataSource = Helpers.ConvertToDataTable(appointments);
            if (dataAppointments.Columns["AppointmentID"] != null)
            {
                dataAppointments.Columns["AppointmentID"].Visible = false;
            }
            if (dataAppointments.Columns["Description"] != null)
            {
                dataAppointments.Columns["Description"].Visible = false;
            }
        }
        private void loadServiceData()
        {
            var services = ms.sDBS.GetServices();
            dataServices.DataSource = Helpers.ConvertToDataTable(services);
            if (dataServices.Columns["ServiceID"] != null)
            {
                dataServices.Columns["ServiceID"].Visible = false;
            }
        }
        private void loadCustomerData()
        {
            var customers = ms.cDBS.GetCustomers();
            dataCustomers.DataSource = Helpers.ConvertToDataTable(customers);
            if (dataCustomers.Columns["CustomerID"] != null)
            {
                dataCustomers.Columns["CustomerID"].Visible = false;
            }
            if (dataCustomers.Columns["Address"] != null)
            {
                dataCustomers.Columns["Address"].Visible = false;
            }
        }
        private void btnAppointmentView_Click(object sender, EventArgs e)
        {
            var appointmentID = Helpers.GetFieldFromSelection("AppointmentID", dataAppointments);
            if (!string.IsNullOrEmpty(appointmentID))
            {
                var appointmentData = ms.aDBS.ReadAppointmentData(appointmentID);
                Form appointmentView = new Appointments.AppointmentView(appointmentData, this);
                appointmentView.Show();
            }
            else
            {
                Helpers.messageBoxError("No appointment selected. Please select an appointment.");
            }
        }

        private void btnServiceView_Click(object sender, EventArgs e)
        {
            var serviceID = Helpers.GetFieldFromSelection("ServiceID", dataServices);
            if (!string.IsNullOrEmpty(serviceID))
            {
                var serviceData = ms.sDBS.ReadServiceData(serviceID);
                Form serviceView = new Services.ServiceView(serviceData, this);
                serviceView.Show();
            }
            else
            {
                Helpers.messageBoxError("No service selected. Please select a service.");
            }

        }

        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            var customerID = Helpers.GetFieldFromSelection("CustomerID", dataCustomers);
            if (!string.IsNullOrEmpty(customerID))
            {
                var customerData = ms.cDBS.ReadCustomer(customerID);
                Form customerView = new CustomerView(customerData, this);
                customerView.Show();
            }
            else
            {
                Helpers.messageBoxError("No customer selected. Please select a customer.");
            }
        }

    }
}
