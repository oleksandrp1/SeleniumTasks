using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    public class AdminOrdersPage
    {
        public void Open(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url = "http://localhost/litecart/admin/?app=orders&doc=orders";
            wait.Until(ExpectedConditions.TitleContains("Orders"));
        }

        public void CreateNewOrder(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.LinkText("Create New Order")).Click();
            wait.Until(ExpectedConditions.TitleContains("Create New Order"));
            Assert.IsTrue(driver.Manage().Logs.GetLog("browser").Count == 0, "Log is not empty");
            /*foreach (LogEntry l in driver.Manage().Logs.GetLog("browser"))
            {
                Console.WriteLine(l);
            }*/
        }
    }
}
