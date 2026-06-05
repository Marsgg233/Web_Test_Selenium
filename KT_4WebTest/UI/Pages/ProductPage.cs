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
    public class ProductPage : WebDriverHelper
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public void AddToCart() => Click(ProductLocators.AddToCartButton);
    }
}
