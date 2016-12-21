using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumTasksProject1.Pages;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Tests
{
    [TestFixture]
    public class Chrome : Initialization
    {
        //GeneralPage general = null;
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void OpenAllElementsInChrome()
        {
            ////general = new GeneralPage();
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.OpenAllElements(driver, wait);
        }

        [Test]
        public void VerifyStickersInChrome()
        {
            //general = new GeneralPage();
            OnlineStorePage onlineStorePage = new OnlineStorePage();

            //general.GoToPage(driver, "http://localhost/litecart/en/");
            onlineStorePage.Open(driver, wait);
            onlineStorePage.VerifyStickers(driver);
        }

        [Test]
        public void VerifySortingCountriesInChrome()
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
        public void VerifySortingTimezonesInChrome()
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
        public void CompareProductsInChrome()
        {
            //general = new GeneralPage();
            OnlineStorePage onlineStorePage = new OnlineStorePage();
            ProductPage productPage = new ProductPage();
            Product product = new Product();

            //general.GoToPage(driver, "http://localhost/litecart/en/", wait, "Online Store | My Store");
            onlineStorePage.Open(driver, wait);
            product = onlineStorePage.ClickOnProduct(driver, wait, "Campaigns", 1);
            productPage.CompareProducts(driver, product);
        }

        [Test]
        public void RegisterUserInChrome()
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

        [Test]
        public void AddProductInChrome()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage();
            AdminCatalogPage adminCatalogPage = new AdminCatalogPage();
            AdminAddNewProductPage adminAddNewProductPage = new AdminAddNewProductPage();
            //general = new GeneralPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin", wait, "My Store");
            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminMyStorePage.GoToSection(driver, "Catalog", wait);
            adminCatalogPage.ClickAddNewProduct(driver, wait);
            adminAddNewProductPage.CreateProduct(driver, wait,
                                                    "Test name", 
                                                    true, 
                                                    "test code1234", 
                                                    "Subcategory", 
                                                    "Subcategory", 
                                                    "Male", 
                                                    "12", 
                                                    "pcs", 
                                                    "3-5 days", 
                                                    "Temporary sold out",
                                                    "D:\\Repository\\image.jpg",
                                                    "01/01/2016",
                                                    "02/02/2018",
                                                    "ACME Corp.",
                                                    "-- Select --",
                                                    "test keyword1, test keyword2",
                                                    "test short description",
                                                    "test description line1\ntest description line2",
                                                    "test head title",
                                                    "test meta description",
                                                    "13",
                                                    "Euros",
                                                    "-- Select --",
                                                    "14.99",
                                                    "15.88",
                                                    "16.77",
                                                    "17.66");
            adminCatalogPage.VerifyProductExists(driver, "Test name");
        }

        [Test]
        public void AddProductsToCartAndDeleteInCrome()
        {
            OnlineStorePage onlineStorePage = new OnlineStorePage();
            ProductPage productPage = new ProductPage();
            Product product = new Product();
            GeneralPage generalPage = new GeneralPage();
            CheckoutPage checkoutPage = new CheckoutPage();

            onlineStorePage.Open(driver, wait);
            onlineStorePage.AddProductsToCart(driver, wait, "Most Popular", 3);
            generalPage.ClickCheckout(driver, wait);
            checkoutPage.RemoveAllProducts(driver, wait);
        }

        [Test]
        public void OpenNewWindowsByClickOnLinkInChrome()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            AdminCountiresPage adminCoutriesPage = new AdminCountiresPage();
            AdminAddNewCountryPage adminAddNewCountryPage = new AdminAddNewCountryPage();

            adminLoginPage.Open(driver, wait);
            adminLoginPage.Login(driver, wait, "admin", "admin");
            adminCoutriesPage.Open(driver, wait);
            adminCoutriesPage.AddNewCountry(driver, wait);
            adminAddNewCountryPage.ClickAllExternalLinks(driver, wait);
        }
    }
}
