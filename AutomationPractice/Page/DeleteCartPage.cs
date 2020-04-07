using AutomationPractice.TestStep;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests;
using OpenQA.Selenium;


namespace AutomationPractice.Page
{
    class DeleteCartPage
    {
        private IWebDriver _driver;
        public DeleteCartPage()
        {
            this._driver = BaseTest.driver;
        }

        IWebElement deleteSecondItem => _driver.FindElement(By.XPath("(//*[contains(@class,'cart_quantity_delete')])[2]"));

        IWebElement TotalProduct => _driver.FindElement(By.Id("summary_products_quantity"));

        public void deleteSecondProduct()
        {

            if (BaseTest.WaitUntilElementExists(deleteSecondItem))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Navigated to Summary page");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Summary page is not loaded");
            }
            deleteSecondItem.Click();
        }

        public void verifyQuantityafterDelete()
        {
            if ((TotalProduct.Text).Contains("1"))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Second Product is deleted successfully");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Deletion operation is not performed");
            }
        }
    }
}
