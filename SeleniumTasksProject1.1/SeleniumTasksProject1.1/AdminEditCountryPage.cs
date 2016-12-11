using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTasksProject1._1
{
    public class AdminEditCountryPage
    {
        public void VerifySortingTimezones(IWebDriver driver, WebDriverWait wait)
        {
            General general = new General();
            List<string> timezoneNames = new List<string>();
            IList<IWebElement> timezones = driver.FindElements(By.XPath(".//*[@id='table-zones']/tbody/tr/td[3]"));
            for (int i = 0; i < timezones.Count; i++)
            {
                timezoneNames.Add(timezones[i].GetAttribute("textContent"));
            }

            timezoneNames.Sort();

            for (int i = 0; i < timezones.Count; i++)
            {
                timezoneNames[i].CompareTo(timezones[i].GetAttribute("textContent"));
            }

            general.GoToPage(driver, "http://localhost/litecart/admin/?app=countries&doc=countries", wait, "Countries");
        }
    }
}
