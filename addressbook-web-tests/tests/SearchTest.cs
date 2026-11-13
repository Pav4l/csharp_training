using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSearch() 
        {
            // 1. Число из надписи "Number of results: N"
            int countFromLabel = app.Contact.GetNumberOfSearchResults();

            // 2. Фактическое число строк (чекбоксов) на странице
            int countFromCheckboxes = app.Contact.GetContactCount();

            Assert.AreEqual(countFromLabel, countFromCheckboxes,
                $"Надпись 'Number of results' показывает {countFromLabel}, " +
                $"а фактически строк в таблице: {countFromCheckboxes}");
        }
    }
}
