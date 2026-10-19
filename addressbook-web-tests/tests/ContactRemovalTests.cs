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
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            app.Contact.Remove();
            app.Quit.Logout();
        }
    }
}
