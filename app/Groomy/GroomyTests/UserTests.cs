namespace Groomy.Tests
{
    [TestClass()]
    public class UserTests
    {
        /*
        [TestMethod()]
        public void User_is_User()
        {
            // Arrange
            string setFirst = "first";
            string setLast = "last";
            string setEmail = "email";
            string setPassword = "password";

            var newUser = new Users.User(setFirst, setLast, setEmail, setPassword);

            // Assert
            Assert.IsInstanceOfType(newUser, typeof(Users.User));
        }
        [TestMethod()]
        public void User_SetProperties()
        {
            // Arrange
            string setFirst = "first";
            string setLast = "last";
            string setEmail = "email";
            string setPassword = "password";
            string hashedPassword = Helpers.GenerateSHA256Hash(setPassword);

            var newUser = new Users.User(setFirst, setLast, setEmail, setPassword);

            // Assert
            Assert.AreEqual(setFirst, newUser.FirstName);
            Assert.AreEqual(setLast, newUser.LastName);
            Assert.AreEqual(setEmail, newUser.Email);
            Assert.AreEqual(Helpers.GenerateSHA256Hash(setEmail), newUser.userID);
            Assert.AreEqual(Helpers.GenerateSHA256Hash(setPassword), newUser.HashedPassword);
            Assert.AreEqual(database, newUser.Database);
        }
        */
    }
}