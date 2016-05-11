using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactApp.Services;

namespace ContactApp.Tests
{
    [TestClass]
    public class ContactAppTests
    {
        [TestMethod]
        public void TestContactInsert()
        {
            var contactManager = new ContactManager();
            string message;
            var result = contactManager.Insert(new Models.Contact
            {
                FirstName = "Jim",
                LastName = "Kirk",
                Email = "jim.kirk@gmail.com",
                Phone = "1234",
                Message = "Hello World"
            }, out message);

            Assert.IsTrue(result);
            Assert.IsNull(message);
        }

        [TestMethod]
        public void TestContactInsertInvalid()
        {
            var contactManager = new ContactManager();
            string message;
            var result = contactManager.Insert(new Models.Contact
            {
                FirstName = "Jim",
                LastName = "Kirk",
                Email = null,
                Phone = "1234",
                Message = "Hello World"
            }, out message);

            Assert.IsFalse(result);
            Assert.IsNotNull(message);
        }
    }
}
