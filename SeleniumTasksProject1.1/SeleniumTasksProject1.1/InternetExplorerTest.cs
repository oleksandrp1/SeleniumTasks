using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTasksProject1._1
{
    [TestFixture]
    public class InternetExplorer
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private General general;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void OpenAllElementsInIE()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.OpenAllElements(driver, wait);
        }

        [Test]
        public void VerifyStickersInIE()
        {
            general = new General();
            OnlineStorePage onlineStorePage = new OnlineStorePage();

            general.GoToPage(driver, "http://localhost/litecart/en/");
            onlineStorePage.VerifyStickers(driver);
        }

        [Test]
        public void VerifySortingCountriesInIE()
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
        public void VerifySortingTimezonesInIE()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminGeoZonesPage adminGeoZonesPage = new AdminGeoZonesPage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            general.GoToPage(driver, "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones", wait, "Geo Zones");
            adminGeoZonesPage.GoToEachCountryAndVerifySortingTimeZones(driver, wait);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
