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
    public class ProductPage
    {
        public void CompareProducts(IWebDriver driver, Product product)
        {
            Assert.AreEqual(product.title, driver.FindElement(By.TagName("h1")).GetAttribute("textContent"));
            Assert.AreEqual(product.price1, driver.FindElement(By.ClassName("regular-price")).GetAttribute("textContent"));
            Assert.AreEqual(product.price2, driver.FindElement(By.ClassName("campaign-price")).GetAttribute("textContent"));
            Assert.AreEqual(product.className1, driver.FindElement(By.ClassName("regular-price")).GetAttribute("className"));
            Assert.AreEqual(product.className2, driver.FindElement(By.ClassName("campaign-price")).GetAttribute("className"));
            Assert.AreEqual(product.fontDecoration1, driver.FindElement(By.ClassName("regular-price")).GetCssValue("text-decoration"));
            Assert.AreEqual(product.fontDecoration2, driver.FindElement(By.ClassName("campaign-price")).GetCssValue("text-decoration"));
            Assert.AreEqual(product.fontStyle1, driver.FindElement(By.ClassName("regular-price")).GetCssValue("font-weight"));
            Assert.AreEqual(product.fontStyle2, driver.FindElement(By.ClassName("campaign-price")).GetCssValue("font-weight"));
            
            int priceFont1 = Convert.ToInt16(driver.FindElement(By.ClassName("regular-price")).GetCssValue("font-size").Replace("px", ""));
            int priceFont2 = Convert.ToInt16(driver.FindElement(By.ClassName("campaign-price")).GetCssValue("font-size").Replace("px", ""));
            Assert.IsTrue(priceFont1 < priceFont2);
        }

        public void AddToChart(IWebDriver driver, WebDriverWait wait, Product product)
        {
            int quantity = Convert.ToInt16(driver.FindElement(By.ClassName("quantity")).GetAttribute("textContent"));

            if (driver.FindElements(By.Name("options[Size]")).Count > 0)
            {
                new SelectElement(driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
            }
            driver.FindElement(By.Name("add_cart_product")).Click();
            wait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.ClassName("quantity")), Convert.ToString(quantity+1)));
        }

        public void ClickCheckout(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Checkout »"));
            wait.Until(ExpectedConditions.TitleContains("Checkout"));
        }
    }
}
