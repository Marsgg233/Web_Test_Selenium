using System;
using System.Collections.Generic;
using System.Text;
using KT4_WebTest.Core;
using KT4_WebTest.Locators;
using KT4_WebTest.Core;
using KT4_WebTest.Locators;
using OpenQA.Selenium;

namespace KT4_WebTest.UI.Pages

{
    public class CartPage : WebDriverHelper
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        public void ClickPlaceOrder() => Click(CartLocators.PlaceOrderButton);
    }
}