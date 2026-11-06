using addressbook_web_tests.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            EnsureContactExists();
            ContactData contact = new ContactData("Sidr", "Sidorov");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(contact,1);
            //app.Quit.Logout();

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
