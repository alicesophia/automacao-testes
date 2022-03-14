using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


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

    }
}
