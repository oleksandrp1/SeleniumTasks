using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    public class AdminEditCountryPage
    {
        public void VerifySortingTimezones(IWebDriver driver, WebDriverWait wait)
        {
            AdminCountiresPage adminCountiresPage = new AdminCountiresPage();
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

            adminCountiresPage.Open(driver, wait);
        }
    }
}
