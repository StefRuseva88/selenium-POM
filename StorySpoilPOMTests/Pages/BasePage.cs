using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StorySpoilPOMTests.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected const string BaseUrl = "https://d24hkho2ozf732.cloudfront.net";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement RegisterLink => driver.FindElement(By.XPath("//a[text()='Sign Up']"));

        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Log In']"));

        public IWebElement CreateStoryLink => driver.FindElement(By.XPath("//a[text()='Create Spoiler']"));

        public IWebElement NoSpoilersMsg => driver.FindElement(By.XPath("//h2[@class='display-4']"));

        public IWebElement LogoutLink => driver.FindElement(By.XPath("//a[text()='Logout']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }
    }

}
