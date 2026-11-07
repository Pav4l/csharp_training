using addressbook_web_tests.model;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            EnsureContactExists();

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(1);
            //app.Quit.Logout();

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
