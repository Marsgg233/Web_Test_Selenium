using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace KT4_WebTest.Locators
{
    public static class CartLocators
    {
        public static readonly By PlaceOrderButton = By.XPath("//button[text()='Place Order']");
    }
}
