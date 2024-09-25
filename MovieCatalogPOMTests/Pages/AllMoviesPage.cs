using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MovieCatalogPOMTests.Pages
{
    public class AllMoviesPage : BasePage
    {
        public AllMoviesPage(IWebDriver driver) : base(driver)
        {

        }

        public virtual string Url => BaseUrl + "/Catalog/All#all";

        public IReadOnlyCollection<IWebElement> PageIndexes => driver.FindElements(By.XPath("//a[@class='page-link']"));

        public IReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

        public IWebElement LastMovieTitle => AllMovies.Last().FindElement(By.XPath(".//h2"));

        public IWebElement LastMovieEditButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-outline-success']"));

        public IWebElement LastMovieDeleteButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-danger']"));

        public IWebElement LastMovieMarkAsWatchedButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-info']"));

        public virtual void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void NavigateToLastPage()
        {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(PageIndexes.Last()).Perform();
            PageIndexes.Last().Click();
        }
    }
}
