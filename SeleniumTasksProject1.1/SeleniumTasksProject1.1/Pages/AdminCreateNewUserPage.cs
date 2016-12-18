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
    public class AdminCreateNewUserPage
    {
        public User CreateUser(IWebDriver driver, WebDriverWait wait, User user, string username, string password)
        {
            FillAllFields(driver, username, password);
            user.username = username;
            user.password = password;
            SelectEnabled(driver);
            user.enabled = true;
            ClickSave(driver, wait);
            return user;
        }

        public void FillAllFields(IWebDriver driver, string username, string password)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("confirmed_password")).SendKeys(password);
        }

        public void SelectEnabled(IWebDriver driver)
        {
            if (!driver.FindElement(By.Name("status")).Selected)
            {
                driver.FindElement(By.Name("status")).Click();
            }
        }

        public void ClickSave(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.Name("save")).Click();
            wait.Until(ExpectedConditions.TitleContains("Users"));
        }
    }
}
