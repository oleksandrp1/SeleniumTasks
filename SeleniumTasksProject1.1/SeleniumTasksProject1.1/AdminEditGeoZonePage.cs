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
    public class AdminEditGeoZonePage
    {
        public void VerifySortingTimezones(IWebDriver driver, WebDriverWait wait)
        {
            IList<IWebElement> timezones = null;
            List<string> sortedTimezones = null;
            General general = new General();

            timezones = driver.FindElements(By.XPath(".//*[@id='table-zones']/tbody/tr/td[3]/select"));
            sortedTimezones = new List<string>(timezones.Count);
            for (int a = 0; a < timezones.Count; a++)
            {
                sortedTimezones.Add(timezones[a].FindElement(By.CssSelector("[selected='selected']")).GetAttribute("text"));
            }

            sortedTimezones.Sort();

            for (int a = 0; a < timezones.Count; a++)
            {
                sortedTimezones[a].CompareTo(timezones[a].FindElement(By.CssSelector("[selected='selected']")).GetAttribute("text"));
            }

            general.GoToPage(driver, "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones", wait, "Geo Zones");
        }
    }
}
