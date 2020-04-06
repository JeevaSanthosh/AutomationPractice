using AutomationPractice.Page;


namespace AutomationPractice.TestStep
{
    class SummerDressessSteps
    {
        SummerDressessPage summerDressessPage = new SummerDressessPage();

        public void NavigateToSummerDressess()
        {
            summerDressessPage.MouseHoverDressess();
        }
    }
}
