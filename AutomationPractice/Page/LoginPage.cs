using AutomationPractice.TestStep;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests;
using OpenQA.Selenium;


namespace AutomationPractice.Page
{
    class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage()
        {
            this._driver = BaseTest.driver;
        }

        IWebElement email => _driver.FindElement(By.Id("email"));

        IWebElement loggedon => _driver.FindElement(By.ClassName("account"));
        IWebElement login => _driver.FindElement(By.ClassName("login"));

        IWebElement password => _driver.FindElement(By.Id("passwd"));

        IWebElement loginSubmit => _driver.FindElement(By.Id("SubmitLogin"));

        IWebElement signOut => _driver.FindElement(By.ClassName("logout"));

        public void validateLaunch()
        {
            if (BaseTest.WaitUntilElementExists(login))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Application Launched properly");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Application is not Launched properly");
            }

        }
        public void clickLogin()
        {  
            login.Click();
        }

        public void performLogin(string name,string value)
        {
            if (BaseTest.WaitUntilElementExists(loginSubmit))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Navigated to Login Page");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Login page is not loaded");
            }
            email.SendKeys(name);
            password.SendKeys(value);            
            loginSubmit.Click();

        }
        public void verifyLogin()
        {
            if (BaseTest.WaitUntilElementExists(loggedon))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "User Logged On");
            }else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "User is not Logged On");

            }

        }

        public void logout()
        {
            if (BaseTest.WaitUntilElementExists(signOut))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Logout Properly");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Logout not Properly");
            }
            signOut.Click();
        }
    }
}
