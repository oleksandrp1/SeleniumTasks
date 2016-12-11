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
        private General general;

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

        [Test]
        public void OpenAllElementsInFF()
        {
            general = new General();
            LoginPage loginPage = new LoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();

            general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.OpenAllElements(driver, wait);
        }

        [Test]
        public void VerifyStickersInFF()
        {
            general = new General();
            OnlineStorePage onlineStorePage = new OnlineStorePage();

            general.GoToPage(driver, "http://localhost/litecart/en/");
            onlineStorePage.VerifyStickers(driver);
        }

        [Test]
        public void VerifySortingCountriesInFF()
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
        public void VerifySortingTimezonesInFF()
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
