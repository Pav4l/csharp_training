using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace addressbook_web_tests.appmanager
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected LogoutHelper logoutHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
             // 1. Указываем путь к папке, где лежит geckodriver.exe
            string geckoDriverDirectory = @"C:\Windows\SysWOW64";
            // 2. Создаём сервис с явным указанием директории драйвера
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
            driver = new FirefoxDriver(service);
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            contactHelper = new ContactHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            logoutHelper = new LogoutHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get {
                return loginHelper;
            }
        }

        public LogoutHelper Quit
        {
            get
            {
                return logoutHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get {
                return navigationHelper;
            }
        }

        public GroupHelper Group
        {
            get { 
                return groupHelper;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }

        public static void StopCurrentThread()
        {
            if (app.IsValueCreated)
            {
                try
                {
                    app.Value.Driver?.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                finally
                {
                    app = new ThreadLocal<ApplicationManager>();
                }
            }
        }
    }
}
