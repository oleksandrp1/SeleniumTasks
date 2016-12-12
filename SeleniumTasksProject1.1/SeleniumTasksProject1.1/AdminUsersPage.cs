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
    public class AdminUsersPage
    {
        public void ClickCreateNewUser(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.ClassName("button")).Click();
            wait.Until(ExpectedConditions.TitleContains("Create New User"));
        }
    }
}
