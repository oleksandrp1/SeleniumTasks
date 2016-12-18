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
    public class AdminUsersPage
    {
        public void ClickCreateNewUser(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.ClassName("button")).Click();
            wait.Until(ExpectedConditions.TitleContains("Create New User"));
        }
    }
}
