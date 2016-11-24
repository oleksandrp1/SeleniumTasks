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
        public void OpenAllElements()
        {
            string titleOfMainMenu, titleOfSubMenu = null;
            LoginInFirefox();
            var mainMenus = driver.FindElements(By.ClassName("name"));
            for(int i=0; i< mainMenus.Count; i++)
            {
                titleOfMainMenu = mainMenus[i].Text;
                mainMenus[i].Click();
                wait.Until(ExpectedConditions.TitleIs(titleOfSubMenu + " | My Store"));
                mainMenus = driver.FindElements(By.ClassName("name"));
                var subMenus = mainMenus[i].FindElements(By.ClassName("name"));
                if (subMenus.Count > 0)
                {
                    for (int a=0; a<subMenus.Count; a++)
                    {
                        titleOfSubMenu = subMenus[a].Text;
                        subMenus[a].Click();
                        wait.Until(ExpectedConditions.TitleIs(titleOfSubMenu + " | My Store"));
                    }
                }
                //wait.Until(ExpectedConditions.TitleIs(title + " | My Store"));
            }
            
            //wait.Until(ExpectedConditions.TitleIs("Template | My Store"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
