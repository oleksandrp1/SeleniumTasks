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
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.notice.success")));
        }

        [Test]
        public void OpenAllElementsInFirefox()
        {
            string titleOfMainMenu = null;
            string titleOfSubMenu = null;
            IList<IWebElement> mainMenus = null;
            IList<IWebElement> subMenus = null;
            int counfOfMainMenus = 0;
            int counfOfSubMenus = 0;

            LoginInFirefox();
            mainMenus = driver.FindElements(By.Id("app-"));
            counfOfMainMenus = mainMenus.Count;
            for(int i=0; i< counfOfMainMenus; i++)
            {
                mainMenus = driver.FindElements(By.Id("app-"));
                titleOfMainMenu = mainMenus[i].Text;
                mainMenus[i].Click();
                wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
                mainMenus = driver.FindElements(By.Id("app-"));
                counfOfSubMenus = mainMenus[i].FindElements(By.CssSelector("li[id*='doc-']")).Count;
                for (int a = 0; a < counfOfSubMenus; a++)
                {
                    mainMenus = driver.FindElements(By.Id("app-"));
                    subMenus = mainMenus[i].FindElements(By.CssSelector("li[id*='doc-']"));
                    titleOfSubMenu = subMenus[a].Text;
                    subMenus[a].Click();
                    wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
                    //wait.Until(ExpectedConditions.TitleIs(titleOfSubMenu + " | My Store"));
                }
            }
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
