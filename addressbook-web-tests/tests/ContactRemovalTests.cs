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

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
