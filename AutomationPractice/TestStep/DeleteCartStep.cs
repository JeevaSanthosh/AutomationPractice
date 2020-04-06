using AutomationPractice.Page;
using System.Threading.Tasks;

namespace AutomationPractice.TestStep
{
    class DeleteCartStep
    {
        DeleteCartPage deleteCartPage = new DeleteCartPage();
        public void deleteProduct()
        {
            deleteCartPage.deleteSecondProduct();
            Task.Delay(5000).Wait();
            deleteCartPage.verifyQuantityafterDelete();
        }
    }
}
