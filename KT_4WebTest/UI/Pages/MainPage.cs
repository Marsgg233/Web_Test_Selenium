using System;
using System.Collections.Generic;
using System.Text;
using global::KT4_WebTest.Core;
using KT4_WebTest.Locators;
using KT4_WebTest.Core;
using KT4_WebTest.Locators;
using OpenQA.Selenium;

namespace KT4_WebTest.UI.Pages
{
    public class MainPage : WebDriverHelper
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public void OpenCart() => Click(MainLocators.CartButton);
        public void OpenLogin() => Click(MainLocators.LoginButton);
    }
}
