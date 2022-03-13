using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWebDriver.Page_Object {
    class Contato {

        [FindsBy(How = How.Name, Using = "your-name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Name, Using = "your-email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "your-subject")]
        public IWebElement Subject { get; set; }

        [FindsBy(How = How.Name, Using = "your-message")]
        public IWebElement Message { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.wpcf7-form-control.wpcf7-submit")]
        public IWebElement Submit { get; set; }

        public void ButtonEnviarClick() {

            Submit.Click();

        }

    }
}
