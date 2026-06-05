using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KT2_TestWeb
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunRegistrationTest();
            RunDuplicateEmailTest();
            RunLoginTest();
            RunBadLoginTest();
            RunCartTest();
        }

        static void RunRegistrationTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");

                driver.FindElement(By.Id("input-firstname")).SendKeys("Test");
                driver.FindElement(By.Id("input-lastname")).SendKeys("User");
                driver.FindElement(By.Id("input-email")).SendKeys($"user_{Guid.NewGuid().ToString().Substring(0, 5)}@test.com");
                driver.FindElement(By.Id("input-telephone")).SendKeys("1234567890");
                driver.FindElement(By.Id("input-password")).SendKeys("password123");
                driver.FindElement(By.Id("input-confirm")).SendKeys("password123");
                driver.FindElement(By.Name("agree")).Click();
                driver.FindElement(By.XPath("//input[@value='Continue']")).Click();

                Console.WriteLine("Регистрация прошла");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка регистрации: " + ex.Message); }
            finally { driver.Quit(); }
        }

        static void RunDuplicateEmailTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/register");

                driver.FindElement(By.Id("input-email")).SendKeys("test@test.com");
                driver.FindElement(By.XPath("//input[@value='Continue']")).Click();

                Console.WriteLine("Тест дубликата выполнен");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
            finally { driver.Quit(); }
        }

        static void RunLoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/login");

                driver.FindElement(By.Id("input-email")).SendKeys("test@test.com");
                driver.FindElement(By.Id("input-password")).SendKeys("password123");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();

                Console.WriteLine("Вход выполнен");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка входа: " + ex.Message); }
            finally { driver.Quit(); }
        }

        static void RunBadLoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/index.php?route=account/login");

                driver.FindElement(By.Id("input-email")).SendKeys("wrong@mail.com");
                driver.FindElement(By.Id("input-password")).SendKeys("wrongpass");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();

                Console.WriteLine("Тест ошибки входа выполнен");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка входа: " + ex.Message); }
            finally { driver.Quit(); }
        }

        static void RunCartTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://naveenautomationlabs.com/opencart/");

                driver.FindElement(By.XPath("(//button[contains(@onclick, 'cart.add')])[1]")).Click();

                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.Id("cart")).Click();

                Console.WriteLine("Тест корзины выполнен");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка корзины: " + ex.Message); }
            finally { driver.Quit(); }
        }
    }
}