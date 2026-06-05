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
    public class OrderPage : WebDriverHelper
    {
        public OrderPage(IWebDriver driver) : base(driver) { }

        public void FillOrderDetails(string name, string country, string city, string card, string month, string year)
        {
            Type(OrderModalLocators.NameField, name);
            Type(OrderModalLocators.CountryField, country);
            Type(OrderModalLocators.CityField, city);
            Type(OrderModalLocators.CardField, card);
            Type(OrderModalLocators.MonthField, month);
            Type(OrderModalLocators.YearField, year);
        }

        public void ConfirmOrder() => Click(OrderModalLocators.PurchaseButton);
    }
}
