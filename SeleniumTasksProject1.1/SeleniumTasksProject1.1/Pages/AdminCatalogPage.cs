using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    public class AdminCatalogPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AdminCatalogPage(IWebDriver driver1, WebDriverWait wait1)
        {
            driver = driver1;
            wait = wait1;
        }

        public void ClickAddNewProduct()
        {
            driver.FindElement(By.LinkText("Add New Product")).Click();
            wait.Until(ExpectedConditions.TitleContains("Add New Product"));
        }

        public void VerifyProductExists(string product)
        {
            Assert.AreEqual(product, driver.FindElement(By.LinkText(product)).GetAttribute("textContent"));
        }

        public void Open(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url= "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            wait.Until(ExpectedConditions.TitleContains("Catalog"));
        }

        public void OpenEachProduct()
        {
            int numberOfProducts = 0;
            numberOfProducts = driver.FindElements(By.XPath(".//td[3]/a[contains(@href, 'product_id')]")).Count;
            for (int i=0; i< numberOfProducts; i++)
            {
                driver.FindElements(By.XPath(".//td[3]/a[contains(@href, 'product_id')]"))[i].Click();
                wait.Until(ExpectedConditions.TitleContains("Edit Product"));
                Assert.IsTrue(driver.Manage().Logs.GetLog("browser").Count==0, "Log is not empty");
                Open(driver, wait);
            }
        }
    }
}
