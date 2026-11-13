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
            ContactData newData = new ContactData("Sidr", "Sidorov");

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contact.Modify(newData, 0);
            //app.Quit.Logout();

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
 
            ContactData toUpdate = oldContacts.Find(c => c.Id == oldData.Id);
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
