using OpenQA.Selenium;

namespace MovieCatalogPOMTests.Pages
{
    public class WatchedMoviesPage : AllMoviesPage
    {
        public WatchedMoviesPage(IWebDriver driver) : base(driver)
        {
            
        }

        public override string Url => BaseUrl + "/Catalog/Watched#watched";

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
