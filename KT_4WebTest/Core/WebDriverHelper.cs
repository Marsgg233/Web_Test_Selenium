using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace KT4_WebTest.Core
{
    public class WebDriverHelper
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public WebDriverHelper(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        protected void Click(By locator)
        {
            Wait.Until(d => {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed && element.Enabled ? element : null;
                }
                catch
                {
                    return null;
                }
            }).Click();
        }

        protected void Type(By locator, string text)
        {
            var element = Wait.Until(d => {
                try
                {
                    var el = d.FindElement(locator);
                    return el.Displayed && el.Enabled ? el : null;
                }
                catch
                {
                    return null;
                }
            });
            element.Clear();
            element.SendKeys(text);
        }
    }
}