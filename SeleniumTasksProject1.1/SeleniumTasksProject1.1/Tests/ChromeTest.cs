﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumTasksProject1.Pages;
using SeleniumTasksProject1.Records;
using OpenQA.Selenium.Support.Events;

namespace SeleniumTasksProject1.Tests
{
    [TestFixture]
    public class Chrome : Initialization
    {
        //GeneralPage general = null;
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new EventFiringWebDriver(new ChromeDriver());
            driver.FindingElement += (sender, e) => Console.WriteLine(DateTime.Now.ToString("ddmmyy hh:mm:ss ") + e.FindMethod);
            driver.FindElementCompleted += (sender, e) => Console.WriteLine(DateTime.Now.ToString("ddmmyy hh:mm:ss ") + e.FindMethod + " found");
            driver.ExceptionThrown += (sender, e) => Console.WriteLine(DateTime.Now.ToString("ddmmyy hh:mm:ss ") + e.ThrownException);
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
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage(driver, wait);

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminMyStorePage.OpenAllElements();
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
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminCountiresPage adminCountriesPage = new AdminCountiresPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminCountriesPage.Open(driver, wait);
            //general.GoToPage(driver, "http://localhost/litecart/admin/?app=countries&doc=countries", wait, "Countries");
            adminCountriesPage.VerifySortingCountries(driver, wait);
        }

        [Test]
        public void VerifySortingTimezonesInChrome()
        {
            //general = new GeneralPage();
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminGeoZonesPage adminGeoZonesPage = new AdminGeoZonesPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin/", wait, "My Store");
            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
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
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage(driver, wait);
            AdminUsersPage adminUsersPage = new AdminUsersPage();
            AdminCreateNewUserPage adminCreateNewUserPage = new AdminCreateNewUserPage();
            ////general = new GeneralPage();
            User user = new User();

            //general.GoToPage(driver, "http://localhost/litecart/admin", wait, "My Store");
            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminMyStorePage.GoToSection("Users");
            adminUsersPage.ClickCreateNewUser(driver, wait);
            adminCreateNewUserPage.CreateUser(driver, wait, user, "user" + DateTime.Now.ToString("hhmmss"), "12345");
            adminMyStorePage.Logout();
            adminLoginPage.Login(user.username, user.password);
            adminMyStorePage.Logout();
        }

        [Test]
        public void AddProductInChrome()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminMyStorePage adminMyStorePage = new AdminMyStorePage(driver, wait);
            AdminCatalogPage adminCatalogPage = new AdminCatalogPage(driver, wait);
            AdminAddNewProductPage adminAddNewProductPage = new AdminAddNewProductPage(driver, wait);
            //general = new GeneralPage();

            //general.GoToPage(driver, "http://localhost/litecart/admin", wait, "My Store");
            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminMyStorePage.GoToSection("Catalog");
            adminCatalogPage.ClickAddNewProduct();
            adminAddNewProductPage.CreateProduct("Test name", 
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
            adminCatalogPage.VerifyProductExists("Test name");
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
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminCountiresPage adminCoutriesPage = new AdminCountiresPage();
            AdminAddNewCountryPage adminAddNewCountryPage = new AdminAddNewCountryPage();

            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminCoutriesPage.Open(driver, wait);
            adminCoutriesPage.AddNewCountry(driver, wait);
            adminAddNewCountryPage.ClickAllExternalLinks(driver, wait);
        }

        [Test]
        public void VerifyLogsInChrome()
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver, wait);
            AdminCatalogPage adminCatalogPage = new AdminCatalogPage(driver, wait);
            AdminOrdersPage adminOrdersPage = new AdminOrdersPage();

            adminLoginPage.Open();
            adminLoginPage.Login("admin", "admin");
            adminCatalogPage.Open(driver, wait);
            adminCatalogPage.OpenEachProduct();
            adminOrdersPage.Open(driver, wait);
            adminOrdersPage.CreateNewOrder(driver, wait);
        }
    }
}
