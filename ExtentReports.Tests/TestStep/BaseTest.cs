using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;

namespace AutomationPractice.TestStep
{
    class BaseTest
    {
        public static IWebDriver driver { get; set; }
        public static IConfigurationRoot config;


        public static Boolean WaitUntilElementExists(IWebElement element, int timeout = 60)
        {
            try
            {                
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                return wait.Until(driver => element.Displayed);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + element + "' was not found in current context page.");
                throw;
            }
        }

        public static string Capture(string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

    }
}
