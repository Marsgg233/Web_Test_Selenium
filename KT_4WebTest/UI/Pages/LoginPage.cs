using KT4_WebTest.Core;
using KT4_WebTest.Locators;
using OpenQA.Selenium;

namespace KT4_WebTest.UI.Pages
{
    public class LoginPage : WebDriverHelper
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(string email, string password)
        {
            Type(LoginLocators.EmailField, email);
            Type(LoginLocators.PasswordField, password);
            Click(LoginLocators.LoginButton);
        }
    }
}