using addressbook_web_tests.model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            EnsureContactExists();
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationFromDetailsPage()
        {
            EnsureContactExists();

            ContactData fromForm = app.Contact.GetContactInformationEditForm(0);
            string fromDetails = app.Contact.GetContactInformationFromDetailsPage(0);

            // Каждое значение из формы редактирования должно присутствовать в тексте страницы деталей
            if (!string.IsNullOrEmpty(fromForm.Firstname))
                StringAssert.Contains(fromForm.Firstname, fromDetails);

            if (!string.IsNullOrEmpty(fromForm.Lastname))
                StringAssert.Contains(fromForm.Lastname, fromDetails);

            if (!string.IsNullOrEmpty(fromForm.Address))
                StringAssert.Contains(fromForm.Address, fromDetails);

            if (!string.IsNullOrEmpty(fromForm.HomePhone))
                StringAssert.Contains(fromForm.HomePhone, fromDetails);

            if (!string.IsNullOrEmpty(fromForm.MobilePhone))
                StringAssert.Contains(fromForm.MobilePhone, fromDetails);

            if (!string.IsNullOrEmpty(fromForm.WorkPhone))
                StringAssert.Contains(fromForm.WorkPhone, fromDetails);
        }
    }
}
