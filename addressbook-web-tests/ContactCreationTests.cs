using addressbook_web_tests;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToNewContactPage();
            ContactData contact = new ContactData("Petr","Petrov");
            FillContactForm(contact);
            GoToHomePage();
            Logout();
        }
    }
}
