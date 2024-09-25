using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MovieCatalogPOMTests.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected static string BaseUrl = "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Login']"));
        public IWebElement LoginHereBtn => driver.FindElement(By.XPath("//a[@id='loginBtn']"));
        public IWebElement AddMovieLink => driver.FindElement(By.XPath("//a[text()='Add Movie']"));
        public IWebElement AllMoviesLink => driver.FindElement(By.XPath("//a[text()='All Movies']"));
        public IWebElement WatchedMoviesLink => driver.FindElement(By.XPath("//a[text()='Watched Movies']"));
        public IWebElement UnwatchedMoviesLink => driver.FindElement(By.XPath("//a[text()='Unwatched Movies']"));
        public IWebElement LogoutBtn => driver.FindElement(By.XPath("//button[text()='Logout']"));
    }
}
