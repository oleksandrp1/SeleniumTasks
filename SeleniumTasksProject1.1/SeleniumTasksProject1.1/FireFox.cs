using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTasksProject1._1
{
    [TestFixture]
    public class FireFox
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            /*FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox Nightly\\firefox.exe";
            options.UseLegacyImplementation = false;
            driver = new FirefoxDriver(options);*/
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void LoginInFirefox()
        {
            driver.Url = "http://localhost:8082/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            //wait.Until(ExpectedConditions.TitleIs("My Store"));
        }

        [Test]
        public void OpenAllElements()
        {
            LoginInFirefox();
            wait.Until(ExpectedConditions.TitleIs("Template | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Logotype | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Product Groups | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Option Groups | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Manufactures | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Suppliers | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Delivery Statuses | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Sold Out Statuses | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Quantity Units | My Store"));
            wait.Until(ExpectedConditions.TitleIs("CSV Import/Export | My Store"));
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
