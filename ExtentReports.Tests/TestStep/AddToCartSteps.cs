using AutomationPractice.Page;

namespace AutomationPractice.TestStep
{
    class AddToCartSteps
    {
        AddToCartPage addToCartPage = new AddToCartPage();
        public void addAllTwoProductToCart()
        {
            addToCartPage.AddtoCart();
            addToCartPage.finalverifyQuantity();
        }
    }
}
