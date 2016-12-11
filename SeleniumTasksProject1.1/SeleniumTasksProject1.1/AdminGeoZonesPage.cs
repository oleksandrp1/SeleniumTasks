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
    public class AdminGeoZonesPage
    {
        public void GoToEachCountryAndVerifySortingTimeZones(IWebDriver driver, WebDriverWait wait)
        {
            IList<IWebElement> countries = null;
            AdminEditGeoZonePage adminEditGeoZonePage = new AdminEditGeoZonePage();

            countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[3]/a"));
            for (int i = 0; i < countries.Count; i++)
            {
                countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[3]/a"));
                countries[i].Click();
                wait.Until(ExpectedConditions.TitleContains("Edit Geo Zone"));
                adminEditGeoZonePage.VerifySortingTimezones(driver, wait);
            }
        }
    }
}
