using AutomationPractice.TestStep;
using AventStack.ExtentReports.Tests;
using NUnit.Framework;

namespace AutomationPractice.Runner
{
    class SummerDress : BaseFixture
    {
        Launch launch = new Launch();
        LoginStep loginStep;
        SummerDressessSteps summerDressessSteps;
        AddToCartSteps addToCartSteps;
        DeleteCartStep deleteCartStep;


        //test case 1 - launch the application 
        [Test, Order(0)]
        [Category("Launch")]
        public void AutomationPractice()
        {
            launch.Initialize();
            launch.NavigateToURL();
            loginStep = new LoginStep();
            loginStep.launchvalidate();
        }

        //test case 2 - login to application
        [Test, Order(1)]
        [Category("Login")]
        public void Login()
        {
            loginStep.LoginDetails();
        }

        //test case 3 - navigate to SummerDressess page
        [Test, Order(2)]
        [Category("Summer Dressess")]
        public void Dressess()
        {
            summerDressessSteps = new SummerDressessSteps();
            summerDressessSteps.NavigateToSummerDressess();
        }

        //test case 4 - add products to cart
        [Test, Order(3)]
        [Category("AddToCart")]
        public void Cart()
        {
            addToCartSteps = new AddToCartSteps();
            addToCartSteps.addAllTwoProductToCart();
        }

        //test case 5 - deleting second product from cart
        [Test, Order(4)]
        [Category("DeleteSecondCart")]
        public void DeleteCart()
        {
            deleteCartStep = new DeleteCartStep();
            deleteCartStep.deleteProduct();
        }

        //test case 6 - logout and close the application
        [Test]
        public void CloseApplication()
        {
            loginStep.logout();

        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            launch.closeBrowser();
            ExtentService.Instance.Flush();
        }



    }
}
