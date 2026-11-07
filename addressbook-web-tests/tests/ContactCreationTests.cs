using addressbook_web_tests.model;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Petr", "Petrov");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);
            //app.Quit.Logout();

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newGroups = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldContacts, newGroups);
        }
    }
}
