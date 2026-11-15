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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(20),
                    MobilePhone = GenerateRandomString(20),
                    WorkPhone = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource(nameof(RandomContactDataProvider))]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
