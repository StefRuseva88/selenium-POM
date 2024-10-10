using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace RevueCraftersPOMTests.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected static string BaseUrl = "https://d3s5nxhwblsjbi.cloudfront.net";
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[text()='Home']"));

        public IWebElement AboutLink => driver.FindElement(By.XPath("//a[text()='About']"));

        public IWebElement ServicesLink => driver.FindElement(By.XPath("//a[text()='Services']"));

        public IWebElement RegisterLink => driver.FindElement(By.XPath("//a[text()='Register']"));

        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Login']"));

    }
}
