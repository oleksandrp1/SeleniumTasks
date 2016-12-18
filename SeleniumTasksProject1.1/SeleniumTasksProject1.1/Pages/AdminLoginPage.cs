using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    internal class AdminLoginPage : GeneralPage
    {
        public void Login(IWebDriver driver, WebDriverWait wait, string username, string password)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.notice.success")));
        }

        public void Open(IWebDriver driver, WebDriverWait wait)
        {
            driver.Url = "http://localhost/litecart/admin/";
            wait.Until(ExpectedConditions.TitleIs("My Store"));
        }
    }
}
