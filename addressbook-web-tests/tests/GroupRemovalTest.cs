using addressbook_web_tests.model;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Group.Remove(1);
            app.Quit.Logout();
        }
    }
}
