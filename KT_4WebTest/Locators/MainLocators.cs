using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace KT4_WebTest.Locators
{
    public static class MainLocators
    {
        public static readonly By CartButton = By.Id("cartur");
        public static readonly By LoginButton = By.Id("login2");
        public static readonly By SignUpButton = By.Id("signin2");
        public static readonly By LogoutButton = By.Id("logout2");
        public static readonly By WelcomeUser = By.Id("nameofuser");
    }
}
