using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTasksProject1._1
{
    public class OnlineStorePage
    {
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
    }
}
