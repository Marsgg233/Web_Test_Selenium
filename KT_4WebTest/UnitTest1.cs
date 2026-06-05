using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace KT4_WebTest_Clean
{
    public class UnitTest1
    {
        [Fact]
        public void TestEnvironment()
        {
            // Используем IWebDriver, чтобы проверить, видит ли проект Selenium
            IWebDriver driver = new ChromeDriver();

            // Навигация
            driver.Navigate().GoToUrl("https://www.google.com");

            // Простая проверка заголовка
            Assert.Contains("Google", driver.Title);

            // Закрытие
            driver.Quit();
        }
    }
}