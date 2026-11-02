using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.DevTools.V117.Page;

namespace addressbook_web_tests.appmanager
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        
        public HelperBase(ApplicationManager manager) {
            this.manager = manager;
            driver = manager.Driver;
         }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);

            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}