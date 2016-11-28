﻿using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTasksProject1._1
{
    [TestFixture]
    public class Chrome
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void LoginInChrome()
        {
            driver.Url = "http://localhost:8082/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.notice.success")));
        }

        [Test]
        public void OpenAllElementsInChrome()
        {
            string titleOfMainMenu = null;
            string titleOfSubMenu = null;
            IList<IWebElement> mainMenus = null;
            IList<IWebElement> subMenus = null;
            int counfOfMainMenus = 0;
            int counfOfSubMenus = 0;

            LoginInChrome();
            mainMenus = driver.FindElements(By.Id("app-"));
            counfOfMainMenus = mainMenus.Count;
            for (int i = 0; i < counfOfMainMenus; i++)
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

        [Test]
        public void VerifyStickersInChrome()
        {
            IList<IWebElement> categories = null;
            IList<IWebElement> products = null;
            IList<IWebElement> stickers = null;
            int countOfCategories = 0;
            int countOfProducts = 0;
            int countOfStickers = 0;

            driver.Url = "http://localhost:8082/litecart/en/";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

            categories = driver.FindElements(By.CssSelector("ul.listing-wrapper.products"));
            countOfCategories = categories.Count;
            for (int i = 0; i < countOfCategories; i++)
            {
                products = categories[i].FindElements(By.CssSelector("li[class*='product']"));
                countOfProducts = products.Count;
                for (int a=0; a<countOfProducts; a++)
                {
                    stickers = products[a].FindElements(By.CssSelector("div.sticker"));
                    countOfStickers = stickers.Count;
                    Assert.IsTrue(countOfStickers == 1);
                }
            }
        }

        [Test]
        public void VerifySortingCountries()
        {
            IList<IWebElement> countries = null;
            IList<IWebElement> countOfTimezones = null;
            IList<IWebElement> timezones = null;
            List<string> countryNames = new List<string>();
            List<string> countriesWithTimezones = new List<string>();
            List<string> timezoneNames = null;
            int countOfCountries = 0;

            LoginInChrome();
            driver.Url = "http://localhost:8082/litecart/admin/?app=countries&doc=countries";
            wait.Until(ExpectedConditions.TitleContains("Countires"));
            countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[5]/a"));
            countOfTimezones = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[6]"));
            countOfCountries = countries.Count;

            for (int i=0; i<countOfCountries; i++)
            {
                countryNames.Add(countries[i].GetAttribute("text"));
                //countryNames.Add(countries[i].Text);
                if (Convert.ToInt16(countOfTimezones[i].GetAttribute("textContent")) != 0)
                {
                    countriesWithTimezones.Add(countries[i].GetAttribute("text"));
                }
            }

            countryNames.Sort();

            //check order of countries
            for (int i = 0; i < countOfCountries; i++)
            {
                countryNames[i].CompareTo(countries[i].Text);
            }

            //check order of time zones
            foreach(string a in countriesWithTimezones)
            {
                timezoneNames = new List<string>();
                driver.FindElement(By.LinkText(a)).Click();
                wait.Until(ExpectedConditions.TitleContains("Edit Country"));
                timezones = driver.FindElements(By.XPath(".//*[@id='table-zones']/tbody/tr/td[3]"));
                for (int i=0; i<timezones.Count; i++)
                {
                    timezoneNames.Add(timezones[i].GetAttribute("textContent"));
                }

                timezoneNames.Sort();

                for (int i=0; i<timezones.Count;i++)
                {
                    timezoneNames[i].CompareTo(timezones[i].GetAttribute("textContent"));
                }

                driver.Url = "http://localhost:8082/litecart/admin/?app=countries&doc=countries";
                wait.Until(ExpectedConditions.TitleContains("Countires"));
            }
        }

        [Test]
        public void VerifySortingTimezones()
        {
            IList<IWebElement> countries = null;
            IList<IWebElement> timezones = null;
            //List<SelectElement> selectedValues = null;
            List<string> sortedTimezones = null;
            LoginInChrome();
            driver.Url = "http://localhost:8082/litecart/admin/?app=geo_zones&doc=geo_zones";
            wait.Until(ExpectedConditions.TitleContains("Geo Zones"));

            countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[3]/a"));
            for (int i=0; i<countries.Count; i++)
            {
                countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[3]/a"));
                countries[i].Click();
                wait.Until(ExpectedConditions.TitleContains("Edit Geo Zone"));

                timezones = driver.FindElements(By.XPath(".//*[@id='table-zones']/tbody/tr/td[3]/select"));
                //selectedValues = new SelectElement(timezones);
                sortedTimezones = new List<string>(timezones.Count);
                for (int a=0; a<timezones.Count; a++)
                {
                    sortedTimezones.Add(timezones[a].FindElement(By.CssSelector("[selected='selected']")).GetAttribute("text"));
                }

                sortedTimezones.Sort();

                for (int a = 0; a < timezones.Count; a++)
                {
                    sortedTimezones[a].CompareTo(timezones[a].FindElement(By.CssSelector("[selected='selected']")).GetAttribute("text"));
                }

                driver.Url = "http://localhost:8082/litecart/admin/?app=geo_zones&doc=geo_zones";
                wait.Until(ExpectedConditions.TitleContains("Geo Zones"));
            }
        }

        [Test]
        public void VerifyGoodsPages()
        {
            driver.Url = "http://localhost:8082/litecart/en/";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
