using AutomationPractice.TestStep;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.Page
{
    class SummerDressessPage
    {
        private IWebDriver _driver;
        public SummerDressessPage() => this._driver = BaseTest.driver;

        IWebElement mouseHoverOnDressess => _driver.FindElement(By.XPath("//*[contains(@class, 'sf-with-ul') and contains(text(), 'Dresses') and following-sibling::ul[@class]]"));

        IWebElement chooseSummerDressess => _driver.FindElement(By.XPath("((//*[contains(@class,'submenu-container')])[2]/li)[3]"));

        public void MouseHoverDressess()
        {
            if (BaseTest.WaitUntilElementExists(mouseHoverOnDressess))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "User Logged In Successfully");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Login was unsuccessful");
            }
            Actions action = new Actions(_driver);
            action.MoveToElement(mouseHoverOnDressess).Perform();
            if (BaseTest.WaitUntilElementExists(chooseSummerDressess))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Summer Dressess page loaded");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Summer Dressess page not loaded");
            }
            chooseSummerDressess.Click();
        }

        
    }
}
