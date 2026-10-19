using addressbook_web_tests.model;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Petr", "Petrov");
            app.Contact.Create(contact);
            app.Quit.Logout();
        }
    }
}
