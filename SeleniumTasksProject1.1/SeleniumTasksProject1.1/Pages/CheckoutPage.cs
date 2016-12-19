using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTasksProject1.Pages
{
    public class CheckoutPage
    {
        public void SelectActiveProduct(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.XPath(".//li[1]/a/img")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("remove_cart_item")));
        }

        public void RemoveAllProducts(IWebDriver driver, WebDriverWait wait)
        {
            IWebElement productNameElement = null;
            IList<IWebElement> productsInTable = driver.FindElements(By.XPath(".//*[@id='order_confirmation-wrapper']/table/tbody/tr/td[2]"));
            IWebElement product = null;
            int numberOfProducts = 0;

            //SelectActiveProduct(driver, wait);
            productNameElement = driver.FindElement(By.XPath(".//a/strong"));
            for (int i=0; i< productsInTable.Count; i++)
            {
                if (productsInTable[i].GetAttribute("textContent")== productNameElement.GetAttribute("textContent"))
                {
                    product = productsInTable[i];
                }
            }
            numberOfProducts = CheckNumberOfProducts(driver);

            for (int i = 0; i < numberOfProducts; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("remove_cart_item")));
                driver.FindElement(By.Name("remove_cart_item")).Click();
                wait.Until(ExpectedConditions.StalenessOf(product));
            }
        }

        public int CheckNumberOfProducts(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//li/a/img")).Count;
        }
    }
}