using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System;

namespace KT3_WebTest
{
    public class OpenCartWorkflowTests : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public OpenCartWorkflowTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void VerifyAccountCreation()
        {
            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");

            driver.FindElement(By.Id("input-firstname")).SendKeys("Test");
            driver.FindElement(By.Id("input-lastname")).SendKeys("User");
            driver.FindElement(By.Id("input-email")).SendKeys($"test_{Guid.NewGuid().ToString().Substring(0, 5)}@example.com");
            driver.FindElement(By.Id("input-telephone")).SendKeys("1234567890");
            driver.FindElement(By.Id("input-password")).SendKeys("password123");
            driver.FindElement(By.Id("input-confirm")).SendKeys("password123");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();

            var successHeading = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Contains("Created", successHeading.Text);
        }

        [Fact]
        public void VerifyRegistrationValidation()
        {
            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");

            var emailField = driver.FindElement(By.Id("input-email"));
            emailField.Clear();
            emailField.SendKeys("test@test.com");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();

            var errorAlert = wait.Until(d => d.FindElement(By.ClassName("alert-danger")));
            Assert.Contains("Warning", errorAlert.Text);
        }

        [Fact]
        public void CheckValidUserLogin()
        {
            string email = $"user_{Guid.NewGuid().ToString().Substring(0, 5)}@test.com";

            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");
            driver.FindElement(By.Id("input-firstname")).SendKeys("Test");
            driver.FindElement(By.Id("input-lastname")).SendKeys("User");
            driver.FindElement(By.Id("input-email")).SendKeys(email);
            driver.FindElement(By.Id("input-telephone")).SendKeys("1234567890");
            driver.FindElement(By.Id("input-password")).SendKeys("password123");
            driver.FindElement(By.Id("input-confirm")).SendKeys("password123");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();

            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/logout");

            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/login");

            var emailField = wait.Until(d => d.FindElement(By.Id("input-email")));
            emailField.Clear();
            emailField.SendKeys(email);

            var passField = wait.Until(d => d.FindElement(By.Id("input-password")));
            passField.Clear();
            passField.SendKeys("password123");

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

            var myAccountHeading = wait.Until(d => d.FindElement(By.TagName("h2")));
            Assert.Contains("Account", myAccountHeading.Text);
        }

        [Fact]
        public void CheckInvalidUserLogin()
        {
            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/login");

            var emailField = driver.FindElement(By.Id("input-email"));
            emailField.Clear();
            emailField.SendKeys("nonexistent@mail.com");

            var passField = driver.FindElement(By.Id("input-password"));
            passField.Clear();
            passField.SendKeys("wrongpass");

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

            var alert = wait.Until(d => d.FindElement(By.ClassName("alert-danger")));
            Assert.Contains("Warning", alert.Text);
        }

        [Fact]
        public void VerifyProductCartFunctionality()
        {
            driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            var addBtn = wait.Until(d => d.FindElement(By.XPath("(//button[contains(@onclick, 'cart.add')])[1]")));
            js.ExecuteScript("arguments[0].click();", addBtn);

            wait.Until(d => d.FindElement(By.ClassName("alert-success")));

            var cartBtn = wait.Until(d => d.FindElement(By.Id("cart")));
            js.ExecuteScript("arguments[0].click();", cartBtn);

            var checkoutLink = wait.Until(d => d.FindElement(By.XPath("//strong[text()=' View Cart']")));
            js.ExecuteScript("arguments[0].click();", checkoutLink);

            var cartTitle = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Contains("Shopping Cart", cartTitle.Text);
        }
    }
}