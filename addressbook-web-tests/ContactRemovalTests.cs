using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            SelectContact();
            RemoveContact();
            GoToHomePage();
            Logout();
        }
    }
}
