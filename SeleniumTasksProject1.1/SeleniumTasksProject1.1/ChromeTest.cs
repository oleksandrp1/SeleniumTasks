using System;
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
            general.GoToPage(driver, "http://localhost/litecart/admin/?app=countries&doc=countries", wait, "Countries");
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
        public void CompareProductsInChrome()
        {
            general = new General();
            OnlineStorePage onlineStorePage = new OnlineStorePage();
            SubcategoryPage subcategoryPage = new SubcategoryPage();
            Product product = new Product();

            general.GoToPage(driver, "http://localhost/litecart/en/", wait, "Online Store | My Store");
            product = onlineStorePage.ClickOnProduct(driver, wait, "Campaigns", 1);
            subcategoryPage.CompareProducts(driver, product);
        }

        [Test]
        public void RegisterUserInChrome()
        {
            LoginPage loginPage = new LoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();
            AdminUsersPage adminUsersPage = new AdminUsersPage();
            AdminCreateNewUserPage adminCreateNewUserPage = new AdminCreateNewUserPage();
            General general = new General();
            User user = new User();

            general.GoToPage(driver, "http://localhost/litecart/admin", wait, "My Store");
            loginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.GoToSection(driver, "Users", wait);
            adminUsersPage.ClickCreateNewUser(driver, wait);
            user = adminCreateNewUserPage.CreateUser(driver, wait, "user" + DateTime.Now.ToString("hhmmss"), "12345");
            adminMyStorePage.Logout(driver, wait);
            loginPage.Login(driver, wait, user.username, user.password);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
