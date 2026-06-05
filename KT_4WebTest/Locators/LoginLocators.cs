using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace KT4_WebTest.Locators
{
    public static class LoginLocators
    {
        public static readonly By EmailField = By.Id("input-email");
        public static readonly By PasswordField = By.Id("input-password");
        public static readonly By LoginButton = By.CssSelector("input[value='Login']");
    }
}