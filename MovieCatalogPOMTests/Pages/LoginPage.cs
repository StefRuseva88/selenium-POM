using OpenQA.Selenium;

namespace MovieCatalogPOMTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/User/Login";
        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='form2Example17']"));
        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='form2Example27']"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//button[@class='btn warning']"));
        
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
