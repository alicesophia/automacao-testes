using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;

        }

        public static IWebDriver GetMobileBrowser(IWebDriver driver, String platform, String deviceName, String browserName, String uri) {

            if (platform.Equals("Android")) {
                DesiredCapabilities cap = new DesiredCapabilities();
                cap.SetCapability("deviceName", deviceName);
                cap.SetCapability("browserName", browserName);
                driver = new AndroidDriver<IWebElement>(new Uri(uri), cap);
            }

            return driver;

        }

    }
}
