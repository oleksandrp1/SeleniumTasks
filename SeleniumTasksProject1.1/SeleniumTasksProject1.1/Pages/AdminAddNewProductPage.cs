using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTasksProject1;
using SeleniumTasksProject1.Records;

namespace SeleniumTasksProject1.Pages
{
    public class AdminAddNewProductPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AdminAddNewProductPage(IWebDriver driver1, WebDriverWait wait1)
        {
            driver = driver1;
            wait = wait1;
        }

        public Product CreateProduct(string name, 
                                    bool status, 
                                    string code,
                                    string category, 
                                    string defaultCategory,
                                    string productGroup,
                                    string quantity,
                                    string quantityUnit,
                                    string deliveryStatus,
                                    string soldOutStatus,
                                    string imagePath,
                                    string dateValidFrom,
                                    string dateValidTo,
                                    string manufacturer,
                                    string supplier,
                                    string keywords,
                                    string shortDescription,
                                    string description,
                                    string headTitle,
                                    string metaDescription,
                                    string purchasePrice,
                                    string currency,
                                    string taxClass,
                                    string price1,
                                    string priceInclTax1,
                                    string price2,
                                    string priceInclTax2)
        {
            Product product = new Product();
            FillAllFields(name, status, code, category, defaultCategory, productGroup, quantity, quantityUnit, deliveryStatus, soldOutStatus,
                            imagePath, dateValidFrom, dateValidTo, manufacturer, supplier, keywords, shortDescription, description, headTitle, metaDescription,
                            purchasePrice, currency, taxClass, price1, priceInclTax1, price2, priceInclTax2);
            ClickSave();
            return product;
        }

        public void FillAllFields(string name,
                                    bool status,
                                    string code,
                                    string category,
                                    string defaultCategory,
                                    string productGroup,
                                    string quantity,
                                    string quantityUnit,
                                    string deliveryStatus,
                                    string soldOutStatus,
                                    string imagePath,
                                    string dateValidFrom,
                                    string dateValidTo,
                                    string manufacturer,
                                    string supplier,
                                    string keywords,
                                    string shortDescription,
                                    string description,
                                    string headTitle,
                                    string metaDescription,
                                    string purchasePrice,
                                    string currency,
                                    string taxClass,
                                    string price1,
                                    string priceInclTax1,
                                    string price2,
                                    string priceInclTax2)
        {
            if (status)
            {
                driver.FindElement(By.CssSelector("input[value='1']")).Click();
            }
            else
            {
                driver.FindElement(By.CssSelector("input[value='0']")).Click();
            }
            driver.FindElement(By.Name("name[en]")).SendKeys(name);
            driver.FindElement(By.Name("code")).SendKeys(code);
            for (int i=0; i< driver.FindElements(By.Name("categories[]")).Count; i++)
            {
                if ((driver.FindElements(By.Name("categories[]"))[i].GetAttribute("data-name") == category) && (driver.FindElements(By.Name("categories[]"))[i].GetAttribute("checked")!= "checked"))
                {
                    driver.FindElements(By.Name("categories[]"))[i].Click();
                }
            }
            //driver.FindElement(By.XPath("//input[@data-name='Rubber Ducks']")).Click();

            SelectDefaultCategory(defaultCategory);

            switch (productGroup)
            {
                case "Male":
                    driver.FindElement(By.XPath("//input[@value='1-1']")).Click();
                    break;
                case "Female":
                    driver.FindElement(By.XPath("//input[@value='1-2']")).Click();
                    break;
                case "Unisex":
                    driver.FindElement(By.XPath("//input[@value='1-3']")).Click();
                    break;
            }

            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys(quantity);
            SelectQuantityUnit(quantityUnit);
            SelectDeliveryStatus(deliveryStatus);
            SelectSoldOutStatus(soldOutStatus);
            UploadImage(By.Name("new_images[]"), imagePath);
            driver.FindElement(By.Name("date_valid_from")).SendKeys(dateValidFrom);
            driver.FindElement(By.Name("date_valid_to")).SendKeys(dateValidTo);
            
            driver.FindElement(By.LinkText("Information")).Click();
            SelectManufacturer(manufacturer);
            SelectSupplier(supplier);
            driver.FindElement(By.Name("keywords")).SendKeys(keywords);
            driver.FindElement(By.Name("short_description[en]")).SendKeys(shortDescription);
            driver.FindElement(By.Name("description[en]")).SendKeys(description);
            //driver.FindElement(By.Name("trumbowyg-editor")).SendKeys(description);
            driver.FindElement(By.Name("head_title[en]")).SendKeys(headTitle);
            driver.FindElement(By.Name("meta_description[en]")).SendKeys(metaDescription);

            driver.FindElement(By.LinkText("Prices")).Click();
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys(purchasePrice);
            driver.FindElement(By.Name("purchase_price_currency_code")).SendKeys(currency);
            SelectTaxClass(taxClass);
            driver.FindElement(By.Name("prices[USD]")).Clear();
            driver.FindElement(By.Name("prices[USD]")).SendKeys(price1);
            //driver.FindElement(By.Name("gross_prices[USD]")).SendKeys(priceInclTax1);
            driver.FindElement(By.Name("prices[EUR]")).Clear();
            driver.FindElement(By.Name("prices[EUR]")).SendKeys(price2);
            //driver.FindElement(By.Name("gross_prices[EUR]")).SendKeys(priceInclTax2);
        }

        public void SelectEnabled()
        {
            if (!driver.FindElement(By.Name("status")).Selected)
            {
                driver.FindElement(By.Name("status")).Click();
            }
        }

        public void ClickSave()
        {
            driver.FindElement(By.Name("save")).Click();
            wait.Until(ExpectedConditions.TitleContains("Catalog"));
        }

        /*internal void SelectDefaultCategory(IWebDriver driver, WebDriverWait wait, string category)
        {
            wait.Until(d => d.FindElement(By.CssSelector(String.Format("select[name=default_category_id] option[value={0}]", category))));
            new SelectElement(driver.FindElement(By.Name("default_category_id"))).SelectByValue(category);
        }*/

        internal void SelectDefaultCategory(string category)
        {
            new SelectElement(driver.FindElement(By.Name("default_category_id"))).SelectByText(category);
        }

        internal void SelectQuantityUnit(string quanityUnit)
        {
            new SelectElement(driver.FindElement(By.Name("quantity_unit_id"))).SelectByText(quanityUnit);
        }

        internal void SelectDeliveryStatus(string deliveryStatus)
        {
            new SelectElement(driver.FindElement(By.Name("delivery_status_id"))).SelectByText(deliveryStatus);
        }

        internal void SelectSoldOutStatus(string soldOutStatus)
        {
            new SelectElement(driver.FindElement(By.Name("sold_out_status_id"))).SelectByText(soldOutStatus);
        }

        internal void SelectManufacturer(string manufacturer)
        {
            new SelectElement(driver.FindElement(By.Name("manufacturer_id"))).SelectByText(manufacturer);
        }

        internal void SelectSupplier(string supplier)
        {
            new SelectElement(driver.FindElement(By.Name("supplier_id"))).SelectByText(supplier);
        }

        internal void SelectTaxClass(string taxClass)
        {
            new SelectElement(driver.FindElement(By.Name("tax_class_id"))).SelectByText(taxClass);
        }

        public void SetDatepicker(string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }

        public void unhide(IWebElement element)
        {
            String script = "arguments[0].style.opacity=1;"
              + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
              + "return true;";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, element);
        }

        public void UploadImage(By locator, String file)
        {
            IWebElement input = driver.FindElement(locator);
            unhide(input);
            input.SendKeys(file);
        }
    }
}
