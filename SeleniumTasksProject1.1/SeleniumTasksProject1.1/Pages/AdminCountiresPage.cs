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
    public class AdminCountiresPage
    {
        public void Open(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            wait.Until(ExpectedConditions.TitleContains("Countries"));
        }

        public void VerifySortingCountries(IWebDriver driver, WebDriverWait wait)
        {
            IList<IWebElement> countries = null;
            IList<IWebElement> countOfTimezones = null;
            List<string> countryNames = new List<string>();
            List<string> countriesWithTimezones = new List<string>();
            int countOfCountries = 0;
            AdminEditCountryPage adminEditCountryPage = new AdminEditCountryPage();

            countries = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[5]/a"));
            countOfTimezones = driver.FindElements(By.XPath(".//*[@id='content']/form/table/tbody/tr/td[6]"));
            countOfCountries = countries.Count;

            for (int i = 0; i < countOfCountries; i++)
            {
                countryNames.Add(countries[i].GetAttribute("text"));
                if (Convert.ToInt16(countOfTimezones[i].GetAttribute("textContent")) != 0)
                {
                    countriesWithTimezones.Add(countries[i].GetAttribute("text"));
                }
            }

            countryNames.Sort();

            //check order of countries
            for (int i = 0; i < countOfCountries; i++)
            {
                countryNames[i].CompareTo(countries[i].Text);
            }

            //check order of time zones
            foreach (string a in countriesWithTimezones)
            {
                driver.FindElement(By.LinkText(a)).Click();
                wait.Until(ExpectedConditions.TitleContains("Edit Country"));
                adminEditCountryPage.VerifySortingTimezones(driver, wait);     
            }
        }
    }
}
