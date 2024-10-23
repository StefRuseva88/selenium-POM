using OpenQA.Selenium;

namespace StorySpoilPOMTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public static string Url => BaseUrl + "/User/Login";

        public IWebElement UsernameField => driver.FindElement(By.XPath("//input[@id='username']"));

        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='password']"));

        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[@type='submit']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string email, string password)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(email);

            PasswordField.Clear();
            PasswordField.SendKeys(password);

            LoginBtn.Click();
        }
    }
}
