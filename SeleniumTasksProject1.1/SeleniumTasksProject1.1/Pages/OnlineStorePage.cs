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
    public class OnlineStorePage
    {
        public void Open(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.TitleContains("Online Store | My Store"));
        }

        public void VerifyStickers(IWebDriver driver)
        {
            IList<IWebElement> categories = null;
            IList<IWebElement> products = null;
            IList<IWebElement> stickers = null;
            int countOfCategories = 0;
            int countOfProducts = 0;
            int countOfStickers = 0;

            categories = driver.FindElements(By.CssSelector("ul.listing-wrapper.products"));
            countOfCategories = categories.Count;
            for (int i = 0; i < countOfCategories; i++)
            {
                products = categories[i].FindElements(By.CssSelector("li[class*='product']"));
                countOfProducts = products.Count;
                for (int a = 0; a < countOfProducts; a++)
                {
                    stickers = products[a].FindElements(By.CssSelector("div.sticker"));
                    countOfStickers = stickers.Count;
                    Assert.IsTrue(countOfStickers == 1);
                }
            }
        }

        public Product ClickOnProduct(IWebDriver driver, WebDriverWait wait, string category, int order)
        {
            IWebElement productOnMainPage = null;
            Product product = new Product();
            
            category = category.ToLower().Replace(" ", "-");
            productOnMainPage = driver.FindElement(By.XPath(".//*[@id='box-" + category + "']//li[" + order + "]/a[1]"));

            //product.price1 = productOnMainPage.FindElement(By.ClassName("regular-price")).GetAttribute("textContent");
            if (productOnMainPage.FindElements(By.ClassName("campaign-price")).Count > 0)
            {
                product.price2 = productOnMainPage.FindElement(By.ClassName("campaign-price")).GetAttribute("textContent");
            }
            else
            {
                product.price2 = productOnMainPage.FindElement(By.ClassName("price")).GetAttribute("textContent");
            }
            /*product.className1 = productOnMainPage.FindElement(By.ClassName("regular-price")).GetAttribute("className");
            product.className2 = productOnMainPage.FindElement(By.ClassName("campaign-price")).GetAttribute("className");
            product.title = productOnMainPage.GetAttribute("title");
            product.fontStyle1 = productOnMainPage.FindElement(By.ClassName("regular-price")).GetCssValue("font-weight");
            product.fontStyle2 = productOnMainPage.FindElement(By.ClassName("campaign-price")).GetCssValue("font-weight");
            product.fontDecoration1 = productOnMainPage.FindElement(By.ClassName("regular-price")).GetCssValue("text-decoration");
            product.fontDecoration2 = productOnMainPage.FindElement(By.ClassName("campaign-price")).GetCssValue("text-decoration");*/

            productOnMainPage.Click();
            wait.Until(ExpectedConditions.TitleContains(product.title));
            return product;
        }

        public void ClickCheckout(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Checkout »"));
            wait.Until(ExpectedConditions.TitleContains("Checkout"));
        }
    }
}
