using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Pages;
using SeleniumTasksProject1.Records;


namespace SeleniumTasksProject1.Tests
{
    [TestFixture]
    public class FireFox
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //private General general;

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
            //general = new GeneralPage();
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.OpenAllElements(driver, wait);
        }

        [Test]
        public void VerifyStickersInFF()
        {
            //general = new GeneralPage();
            OnlineStorePage onlineStorePage = new OnlineStorePage();

            //general.GoToPage(driver, "http://localhost/litecart/en/");
            onlineStorePage.Open(driver, wait);
            onlineStorePage.VerifyStickers(driver);
        }

        [Test]
        public void VerifySortingCountriesInFF()
        {
            //general = new GeneralPage();
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminCountiresPage adminCountriesPage = new AdminCountiresPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminCountriesPage.Open(driver, wait);
            //general.GoToPage(driver, "http://localhost/litecart/admin/?app=countries&doc=countries", wait, "Countries");
            adminCountriesPage.VerifySortingCountries(driver, wait);
        }

        [Test]
        public void VerifySortingTimezonesInFF()
        {
            //general = new GeneralPage();
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminGeoZonesPage adminGeoZonesPage = new AdminGeoZonesPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            //general.GoToPage(driver, "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones", wait, "Geo Zones");
            adminGeoZonesPage.GoToEachCountryAndVerifySortingTimeZones(driver, wait);
        }

        [Test]
        public void CompareProductsInFF()
        {
            //general = new GeneralPage();
            OnlineStorePage onlineStorePage = new OnlineStorePage();
            SubcategoryPage subcategoryPage = new SubcategoryPage();
            Product product = new Product();

            //general.GoToPage(driver, "http://localhost/litecart/en/", wait, "Online Store | My Store");
            onlineStorePage.Open(driver, wait);
            product = onlineStorePage.ClickOnProduct(driver, wait, "Campaigns", 1);
            subcategoryPage.CompareProducts(driver, product);
        }

        [Test]
        public void RegisterUserInFF()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();
            AdminUsersPage adminUsersPage = new AdminUsersPage();
            AdminCreateNewUserPage adminCreateNewUserPage = new AdminCreateNewUserPage();
            ////general = new GeneralPage();
            User user = new User();

            //general.GoToPage(driver, "http://localhost/litecart/admin", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.GoToSection(driver, "Users", wait);
            adminUsersPage.ClickCreateNewUser(driver, wait);
            adminCreateNewUserPage.CreateUser(driver, wait, user, "user" + DateTime.Now.ToString("hhmmss"), "12345");
            adminMyStorePage.Logout(driver, wait);
            adminLoginPage.Login(driver, wait, user.username, user.password);
            adminMyStorePage.Logout(driver, wait);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
