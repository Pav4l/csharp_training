using addressbook_web_tests;
using addressbook_web_tests.appmanager;
using addressbook_web_tests.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    public abstract class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public void EnsureGroupExists()
        {
            if (app.Group.GetGroupCount() == 0)
            {
                GroupData group = new GroupData("default");
                group.Header = "default";
                group.Footer = "default";
                app.Group.Create(group);
            }
        }

        public void EnsureContactExists()
        {
            if (app.Contact.GetContactCount() == 0)
            {
                ContactData contact = new ContactData("Default", "Contact");
                app.Contact.Create(contact);
            }
        }

        [SetUpFixture]
        public class GlobalTeardown
        {
            [TearDown] // закрытие браузера после всех тестов
            public void RunOnceAfterAllTests()
            {
                ApplicationManager.StopCurrentThread();
            }
        }
    }
}
