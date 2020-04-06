using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutomationPractice.TestStep
{
    class Launch
    {

        public void Initialize()
        {
            BaseTest.driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            BaseTest.config = new ConfigurationBuilder()
             .AddJsonFile("TestData/Config.json")
             .Build();

        }
        public void NavigateToURL()
        {
            BaseTest.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            BaseTest.driver.Navigate().GoToUrl(BaseTest.config["url"]);
            BaseTest.driver.Manage().Window.Maximize();
        }

        public void closeBrowser()
        {
            BaseTest.driver.Close();
            BaseTest.driver.Quit();
        }

    }
}
