using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTasksProject1.Pages
{
    public class AdminAddNewCountryPage
    {
        public void ClickAllExternalLinks(IWebDriver driver, WebDriverWait wait)
        {
            IList<IWebElement> externalLinks = null;
            string mainWindowHandle = "";

            externalLinks = driver.FindElements(By.CssSelector("i.fa-external-link"));
            mainWindowHandle = driver.CurrentWindowHandle;
            var originalWindow = driver.WindowHandles;

            for (int i=0; i< externalLinks.Count; i++)
            {
                externalLinks[i].Click();
                wait.Until(x => { return driver.WindowHandles.Count == 2;});
                foreach(string handle in driver.WindowHandles)
                {
                    if (handle != mainWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);
                        driver.Close();
                        driver.SwitchTo().Window(mainWindowHandle);
                    }
                }
            }

            /*internal ExpectedConditions<string> ThereIsWindowOtherThan(ICollection<string> oldWindow)
        {
            return new ExpectedConditions<string>();
            {
                public string apply(IWebDriver driver)
        {

        }
            }
        }*/
        }
    }
}
