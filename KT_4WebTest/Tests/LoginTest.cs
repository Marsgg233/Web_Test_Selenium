using KT4_WebTest.Core;
using KT4_WebTest.UI.Pages;
using OpenQA.Selenium;
using Xunit;
using System;

namespace KT4_WebTest.Tests
{
    public class LoginTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public LoginTest()
        {
            _driver = WebDriverFactory.CreateDriver();
        }

        [Fact]
        public void SuccessfulRegistrationAndLogin_Test()
        {
            var registerPage = new RegisterPage(_driver);
            var loginPage = new LoginPage(_driver);

            string uniqueEmail = $"testuser{DateTime.Now.Ticks}@example.com";
            string password = "Password123";

            _driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");
            registerPage.RegisterUser("Ivan", "Ivanov", uniqueEmail, "123456789", password);

            _driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/logout");

            _driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/login");
            loginPage.Login(uniqueEmail, password);

            Assert.Contains("My Account", _driver.Title);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}