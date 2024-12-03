using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groomy.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groomy.Utilities;
using Groomy.Users;
using Moq;

namespace GroomyTests.Customers
{
    [TestClass()]
    public class CustomerDBServiceTests
    {
        [TestMethod()]
        public void CustomerDBServiceTest()
        {
            var managerSingleton = new ManagerSingleton();
            var dbService = new CustomerDBService(managerSingleton);
            Assert.IsNotNull(dbService);
            Assert.IsTrue(dbService is CustomerDBService);
        }

        [TestMethod()]
        public void CreateCustomerTest()
        {
            //initialize services
            var mockFileService = new Mock<IFileService>();
            var dbm = new DatabaseManager(mockFileService.Object);
            var userAuth = new UserAuth();
            //create new user
            var currentUser = new User("testFirst", "testLast", "testEmail", "testPassword");
            //get expected userID and user file path
            var expectedUserID = currentUser.GetKey();
            var expectedUserFilePath = User.FilePaths["UserData"];
            //set current userAuth user to new user
            userAuth.setUser(currentUser);
            //create new customerDBService
            var customerDBService = new CustomerDBService(dbm, userAuth);
            //create new customer
            var newCustomer = new Customer("John", "Doe", "john.doe@example.com", "1234567890", "123 Main St");
            //get expected customer fields and customerID
            var expectedCustomerID = newCustomer.GetKey();
            var expectedCustomerFilePath = Customer.FilePaths["CustomerData"];





            customerDBService.CreateCustomer(newCustomer);
        }

        [TestMethod()]
        public void ReadCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCustomerDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SoftDeleteCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomerIDByEmailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCustomerIDByFirstLastTest()
        {
            Assert.Fail();
        }
    }
}