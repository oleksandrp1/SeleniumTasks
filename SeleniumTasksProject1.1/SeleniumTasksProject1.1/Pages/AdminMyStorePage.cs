﻿using System;
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
    public class AdminMyStorePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AdminMyStorePage(IWebDriver driver1, WebDriverWait wait1)
        {
            driver = driver1;
            wait = wait1;
        }

        public void OpenAllElements()
        {
            string titleOfMainMenu = null;
            string titleOfSubMenu = null;
            IList<IWebElement> mainMenus = null;
            IList<IWebElement> subMenus = null;
            int counfOfMainMenus = 0;
            int counfOfSubMenus = 0;

            mainMenus = driver.FindElements(By.Id("app-"));
            counfOfMainMenus = mainMenus.Count;
            for (int i = 0; i < counfOfMainMenus; i++)
            {
                mainMenus = driver.FindElements(By.Id("app-"));
                titleOfMainMenu = mainMenus[i].Text;
                mainMenus[i].Click();
                wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
                mainMenus = driver.FindElements(By.Id("app-"));
                counfOfSubMenus = mainMenus[i].FindElements(By.CssSelector("li[id*='doc-']")).Count;
                for (int a = 0; a < counfOfSubMenus; a++)
                {
                    mainMenus = driver.FindElements(By.Id("app-"));
                    subMenus = mainMenus[i].FindElements(By.CssSelector("li[id*='doc-']"));
                    titleOfSubMenu = subMenus[a].Text;
                    subMenus[a].Click();
                    wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
                }
            }
        }

        public void GoToSection(string section)
        {
            IList<IWebElement> sections = driver.FindElements(By.ClassName("name"));
            for (int i=0; i<sections.Count; i++)
            {
                if (sections[i].GetAttribute("textContent")==section)
                {
                    sections[i].Click();
                    wait.Until(ExpectedConditions.TitleContains(section));
                    break;
                }
            }
        }

        public void Logout()
        {
            driver.FindElement(By.CssSelector("a[title='Logout']")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
        }
    }
}
