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
        private General general;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void OpenAllElementsInChrome()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.OpenAllElements(driver, wait);
        }

        [Test]
        public void VerifyStickersInChrome()
        {
            general = new General();
            OnlineStorePage onlineStorePage = new OnlineStorePage();

            general.GoToPage(driver, "http://localhost/litecart/en/");
            onlineStorePage.VerifyStickers(driver);
        }

        [Test]
        public void VerifySortingCountriesInChrome()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminCountiresPage adminCountriesPage = new AdminCountiresPage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            general.GoToPage(driver, "http://localhost/litecart/admin/?app=countries&doc=countries", wait, "Countires");
            adminCountriesPage.VerifySortingCountries(driver, wait);
        }

        [Test]
        public void VerifySortingTimezonesInChrome()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminGeoZonesPage adminGeoZonesPage = new AdminGeoZonesPage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            general.GoToPage(driver, "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones", wait, "Geo Zones");
            adminGeoZonesPage.GoToEachCountryAndVerifySortingTimeZones(driver, wait);
        }

        [Test]
        public void VerifyGoodsPagesInChrome()
        {
            general = new General();

            general.GoToPage(driver, "http://localhost/litecart/en/", wait, "Online Store | My Store");

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}