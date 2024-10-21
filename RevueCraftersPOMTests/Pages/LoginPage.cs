using OpenQA.Selenium;

namespace RevueCraftersPOMTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public static string Url => BaseUrl + "/Users/Login#loginForm";
        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='form3Example3']"));
        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='form3Example4']"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mb-4']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string email, string password)
        {
            EmailField.Clear();
            EmailField.SendKeys(email);

            PasswordField.Clear();
            PasswordField.SendKeys(password);

            LoginBtn.Click();
        }
    }
}
