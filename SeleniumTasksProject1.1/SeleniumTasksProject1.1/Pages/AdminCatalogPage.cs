using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    public class AdminCatalogPage
    {
        public void ClickAddNewProduct(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Add New Product")).Click();
            wait.Until(ExpectedConditions.TitleContains("Add New Product"));
        }

        public void VerifyProductExists(IWebDriver driver, string product)
        {
            Assert.AreEqual(product, driver.FindElement(By.LinkText(product)).GetAttribute("textContent"));
        }
    }
}
