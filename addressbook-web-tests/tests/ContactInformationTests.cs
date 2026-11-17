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
            string[] fromDetails = app.Contact.GetContactInformationFromDetailsPage(0)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim())
                .ToArray();

            // Ожидаемые поля в правильном порядке; пустые — пропускаем
            var expected = new[]
            {
                $"{fromForm.Firstname} {fromForm.Lastname}".Trim(),
                fromForm.Address,
                fromForm.HomePhone,
                fromForm.MobilePhone,
                fromForm.WorkPhone
            }.Where(s => !string.IsNullOrEmpty(s));

            // Каждое значение — отдельной строкой, в правильном порядке
            int lastIdx = -1;
            foreach (var value in expected)
            {
                int idx = Array.FindIndex(fromDetails, lastIdx + 1,
                    line => line == value || line.EndsWith(value));

                Assert.IsTrue(idx > lastIdx,
                    $"'{value}' не найдено в правильном порядке.\n" +
                    $"Строки деталей:\n  {string.Join("\n  ", fromDetails)}");

                lastIdx = idx;
            }
        }
    }
}
