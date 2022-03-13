using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using SeleniumWebDriver.Page_Object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace ST01Contato {

    [TestFixture]
    public class CT01ValidarLayoutTela {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest() {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://livros.inoveteste.com.br/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest() {
            try {
                driver.Quit();
            } catch (Exception) {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCT01ValidarLayoutTelaTest() {
            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/contato/");
            // Acessa o menu Contato
            driver.FindElement(By.CssSelector("#menu-item-80 > a > span")).Click();
            // Valida o layout da tela            
            // Sem Page Object
            Assert.AreEqual("Envie uma mensagem", driver.FindElement(By.CssSelector("h1")).Text);
            /*Assert.IsTrue(IsElementPresent(By.Name("your-name")));
            Assert.IsTrue(IsElementPresent(By.Name("your-email")));
            Assert.IsTrue(IsElementPresent(By.Name("your-subject")));
            Assert.IsTrue(IsElementPresent(By.Name("your-message")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("input.wpcf7-form-control.wpcf7-submit")));*/

            // Page Object
            Contato contato = new Contato();
            PageFactory.InitElements(driver, contato);

            Assert.IsTrue(contato.Name.Enabled);
            Assert.IsTrue(contato.Email.Enabled);
            Assert.IsTrue(contato.Subject.Enabled);
            Assert.IsTrue(contato.Message.Enabled);
            Assert.IsTrue(contato.Submit.Enabled);

        }
        private bool IsElementPresent(By by) {
            try {
                driver.FindElement(by);
                return true;
            } catch (NoSuchElementException) {
                return false;
            }
        }

        private bool IsAlertPresent() {
            try {
                driver.SwitchTo().Alert();
                return true;
            } catch (NoAlertPresentException) {
                return false;
            }
        }

        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
