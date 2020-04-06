using AutomationPractice.TestStep;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomationPractice.Page
{
    class AddToCartPage
    {
        private IWebDriver _driver;

        public AddToCartPage()
        {
            this._driver = BaseTest.driver;
        }

        IWebElement AddedProduct => _driver.FindElement(By.Id("summary_products_quantity"));

       // IWebElement allProductList => _driver.FindElement(By.XPath("//div[@class='product-image-container']/descendant::a[@class='quick-view']"));

        IWebElement productList => _driver.FindElement(By.XPath("//a[@class='product_img_link']/descendant::img"));

        IWebElement SelectedFrame => _driver.FindElement(By.XPath("//*[contains(@class,'fancybox-iframe')]"));

        IWebElement addToCart => _driver.FindElement(By.Name("Submit"));

        IWebElement Continue => _driver.FindElement(By.ClassName("continue"));

        IWebElement proceedToPurchase => _driver.FindElement(By.ClassName("button-medium"));

       // IWebElement quantity => _driver.FindElement(By.ClassName("ajax_cart_quantity"));

        public void AddtoCart()
        {
            //BaseTest.WaitUntilElementExists(allProductList);

            IList<IWebElement> list = _driver.FindElements(By.XPath("//div[@class='product-image-container']/descendant::a[@class='quick-view']")); ;

            for (int i = 0; i < 2; i++)
            {
                Task.Delay(3000).Wait();

                if (i == 0)
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("var mouseEvent = document.createEvent('MouseEvents');mouseEvent.initEvent('mouseover', true, true); arguments[0].dispatchEvent(mouseEvent);", productList);
                }
                else
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", productList);
                }


                Actions action = new Actions(_driver);
                action.MoveToElement(list[i]).Click(list[i]).Build().Perform();
                _driver.SwitchTo().Frame(SelectedFrame);
                if (BaseTest.WaitUntilElementExists(addToCart))
                {
                    string screenShotPath = BaseTest.Capture("ProductViewLoad_"+i);
                    ExtentTestManager.GetTest().Log(Status.Pass, "Product Quick View loaded");
                    ExtentTestManager.GetTest().Log(Status.Pass, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                }
                else
                {
                    string screenShotPath = BaseTest.Capture("ProductViewLoad_Failed_" + i);
                    ExtentTestManager.GetTest().Log(Status.Fail, "Product Quick View is not loaded");
                    ExtentTestManager.GetTest().Log(Status.Fail, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                }
                addToCart.Click();
                _driver.SwitchTo().DefaultContent();

                if (i == 0)
                {
                    if (BaseTest.WaitUntilElementExists(Continue))
                    {
                        string screenShotPath = BaseTest.Capture("First_Product_Added" + i);
                        ExtentTestManager.GetTest().Log(Status.Pass, "first product add to cart");
                        ExtentTestManager.GetTest().Log(Status.Pass, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                    }
                    else
                    {
                        string screenShotPath = BaseTest.Capture("First_Product_Added_Failed" + i);
                        ExtentTestManager.GetTest().Log(Status.Fail, "unable to add first product to cart");
                        ExtentTestManager.GetTest().Log(Status.Fail, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                    }
                    Task.Delay(5000).Wait();
                    Continue.Click();
                }
                else
                {
                    if (BaseTest.WaitUntilElementExists(proceedToPurchase))
                    {
                        string screenShotPath = BaseTest.Capture("Second_Product_Added_Failed" + i);
                        ExtentTestManager.GetTest().Log(Status.Pass, "Second Product Added to cart");
                        ExtentTestManager.GetTest().Log(Status.Pass, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                    }
                    else
                    {
                        string screenShotPath = BaseTest.Capture("Second_Product_Added_Failed" + i);
                        ExtentTestManager.GetTest().Log(Status.Fail, "unable to add second product to cart");
                        ExtentTestManager.GetTest().Log(Status.Fail, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
                    }
                    Task.Delay(5000).Wait();
                    proceedToPurchase.Click();
                }

            }

        }

        public void finalverifyQuantity()
        {
            if ((AddedProduct.Text).Contains("2"))
            {
                ExtentTestManager.GetTest().Log(Status.Pass, "Two products are added to cart");
            }
            else
            {
                ExtentTestManager.GetTest().Log(Status.Fail, "Cart is empty; need to add again");
            }
        }
    }
}
