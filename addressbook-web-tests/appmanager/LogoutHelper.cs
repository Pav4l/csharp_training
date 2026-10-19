using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.appmanager
{
    public class LogoutHelper : HelperBase
    {
        public LogoutHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
