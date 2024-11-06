using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Tests
{
    /*
    [TestClass()]
    /*
    public class UserTests
    {
        [TestMethod()]
        public void User_is_User()
        {
            // Arrange
            string setFirst = "first";
            string setLast = "last";
            string setEmail = "email";
            string setPassword = "password";
            var database = UserDatabase.Instance(new FileService());

            User newUser = new User(setFirst, setLast, setEmail, setPassword, database);

            // Assert
            Assert.IsInstanceOfType(newUser, typeof(User));
        }
        [TestMethod()]
        public void User_SetProperties()
        {
            // Arrange
            string setFirst = "first";
            string setLast = "last";
            string setEmail = "email";
            string setPassword = "password";
            var database = UserDatabase.Instance(new FileService());

            User newUser = new User(setFirst, setLast, setEmail, setPassword, database);

            // Assert
            Assert.AreEqual(setFirst, newUser.FirstName);
            Assert.AreEqual(setLast, newUser.LastName);
            Assert.AreEqual(setEmail, newUser.Email);
            Assert.AreEqual(Helpers.GenerateSHA256Hash(setEmail), newUser.userID);
            Assert.AreEqual(Helpers.GenerateSHA256Hash(setPassword), newUser.HashedPassword);
            Assert.AreEqual(database, newUser.Database);
        }
    }
    */
    
}