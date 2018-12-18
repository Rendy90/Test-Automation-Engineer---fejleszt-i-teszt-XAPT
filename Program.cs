using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsValid = false;

            // Start a google crome webdriver
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Navigate to the Wikipedia site: https://www.wikipedia.org
            driver.Navigate().GoToUrl("https://www.wikipedia.org/"); 
            driver.Navigate().Refresh();

            // Choose the English language
            IWebElement query = driver.FindElement(By.Id("js-link-box-en"));
            query.Click();

            // Search for „Test Automation”
            query = driver.FindElement(By.Name("search"));
            query.SendKeys("Test Automation");
            query.Submit();

            // Find the Unit testing part in the list and click it
            query = driver.FindElement(By.XPath("html/body/div[3]/div[3]/div[4]/div[1]/div[2]/ul/li[2]/a/span[2]"));
            query.Click();
            IsValid = query.Displayed && query.Enabled;

            if (IsValid)
            {
                IsValid = false;
                // Find the Test automation interface part in the list and click it
                query = driver.FindElement(By.XPath("html/body/div[3]/div[3]/div[4]/div[1]/div[2]/ul/li[7]/ul/li[1]/a/span[2]"));
                query.Click();

                // Find the Test Automation Interface Model image
                query = driver.FindElement(By.XPath("html/body/div[3]/div[3]/div[4]/div[1]/div[5]/div[1]/a/img"));
                query.Click();

                // Close the Test Automation Interface Model image
                Thread.Sleep(5000);
                IWebElement image = driver.FindElement(By.XPath("html/body/div[9]/div/div[1]/button[1]"));
                image.Click();

                // Check if the image is displayed and enabled
                IsValid = query.Displayed && query.Enabled;
                if (!IsValid)
                {
                    driver.Quit();
                }

                // Search for the link of Behavior driven development and navigate to there html/body/div[3]/div[3]/div[4]/div[1]/ol[3]/li[7]/a
                query = driver.FindElement(By.XPath("html/body/div[3]/div[3]/div[4]/div[1]/ol[3]/li[7]/a"));
                query.Click();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            driver.Quit();
        }
    }
}
