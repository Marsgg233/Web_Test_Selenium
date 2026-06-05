using System;
using System.Collections.Generic;
using System.Text;
using KT4_WebTest.Core;
using KT4_WebTest.Locators;
using OpenQA.Selenium;

namespace KT4_WebTest.UI.Pages
{
    public class RegisterPage : WebDriverHelper
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        public void RegisterUser(string first, string last, string email, string phone, string pass)
        {
            Type(RegisterLocators.FirstName, first);
            Type(RegisterLocators.LastName, last);
            Type(RegisterLocators.Email, email);
            Type(RegisterLocators.Telephone, phone);
            Type(RegisterLocators.Password, pass);
            Type(RegisterLocators.PasswordConfirm, pass);
            Click(RegisterLocators.AgreeCheckbox);
            Click(RegisterLocators.ContinueButton);
        }
    }
}
