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
    public class General
    {
        public void GoToPage(IWebDriver driver, string url, WebDriverWait wait = null, string title=null)
        {
            driver.Url = url;
            if (title != null && wait !=null)
            {
                wait.Until(ExpectedConditions.TitleContains(title));
            }
        }
    }
}
