using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("NewGroup1");
            group.Header = "NewGroup1";
            group.Footer = "NewGroup1";
            FillGroupForm(group);
            SubmintGroupCreation();
            GoToGroupsPage();
            Logout();
        }
    }
}
