using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumWebDriver {
    class Comandos {

        public static IWebDriver GetLocalBrowser(IWebDriver driver, String browser) {
            
            if (browser.Equals("Chrome")) {
                driver = new ChromeDriver();
            } else {
                driver = new FirefoxDriver();
            }

            driver.Manage().Window.Maximize();            

            return driver;

        }

        public static IWebDriver GetRemoteBrowser(IWebDriver driver, String browser, String uri) {

            if (browser.Equals("Chrome")) {
                ChromeOptions chromeOptions = new ChromeOptions();
                driver = new RemoteWebDriver(new Uri(uri), chromeOptions);                
            } else {
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                driver = new RemoteWebDriver(new Uri(uri), firefoxOptions);
            }

            driver.Manage().Window.Maximize();

            return driver;

        }

    }
}
