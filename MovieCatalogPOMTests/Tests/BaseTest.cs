using MovieCatalogPOMTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MovieCatalogPOMTests.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public LoginPage loginPage;

        public AddMoviePage addMoviePage;

        public AllMoviesPage allMoviesPage;

        public DeleteMoviePage deleteMoviePage;

        public EditMoviePage editMoviePage;

        public WatchedMoviesPage watchedMoviesPage;

        public Actions actions;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            actions = new Actions(driver);

            loginPage = new LoginPage(driver);
            addMoviePage = new AddMoviePage(driver);
            allMoviesPage = new AllMoviesPage(driver);
            deleteMoviePage = new DeleteMoviePage(driver);
            editMoviePage = new EditMoviePage(driver);
            watchedMoviesPage = new WatchedMoviesPage(driver);

            loginPage.OpenPage();
            loginPage.PerformLogin("stef88@test.bg", "123456");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        public string GenerateRandomTitle()
        {
            var random = new Random();
            return "TITLE: " + random.Next(10000, 100000);
        }

        public string GenerateRandomDescription()
        {
            var random = new Random();
            return "DESCRIPTION: " + random.Next(10000, 100000);
        }
    }
}
