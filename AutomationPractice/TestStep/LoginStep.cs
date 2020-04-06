using AutomationPractice.Page;

namespace AutomationPractice.TestStep
{
    class LoginStep
    {
        LoginPage loginPage = new LoginPage();        

        public void launchvalidate()
        {
            loginPage.validateLaunch();
        }
        public void LoginDetails()
        {
            loginPage.clickLogin();
            loginPage.performLogin(BaseTest.config["user"], BaseTest.config["pass"]);
            loginPage.verifyLogin();
            
        }

        public void logout()
        {
            loginPage.logout();
        }
    }
}
