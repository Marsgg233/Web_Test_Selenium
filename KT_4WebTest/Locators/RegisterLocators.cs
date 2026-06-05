using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace KT4_WebTest.Locators
{
    public static class RegisterLocators
    {
        public static readonly By FirstName = By.Id("input-firstname");
        public static readonly By LastName = By.Id("input-lastname");
        public static readonly By Email = By.Id("input-email");
        public static readonly By Telephone = By.Id("input-telephone");
        public static readonly By Password = By.Id("input-password");
        public static readonly By PasswordConfirm = By.Id("input-confirm");
        public static readonly By AgreeCheckbox = By.Name("agree");
        public static readonly By ContinueButton = By.CssSelector("input[value='Continue']");
    }
}
