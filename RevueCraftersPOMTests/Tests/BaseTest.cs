using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RevueCraftersPOMTests.Pages;

namespace RevueCraftersPOMTests.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public Actions actions;

        public LoginPage loginPage;

        public AllReavuesPage allReavuesPage;

        public EditRevuePage editRevuePage;

        public CreateRevuePage createRevuePage;

        public DeleteRevuePage deleteRevuePage;


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
            allReavuesPage = new AllReavuesPage(driver);
            editRevuePage = new EditRevuePage(driver);
            createRevuePage = new CreateRevuePage(driver);
            deleteRevuePage = new DeleteRevuePage(driver);

            loginPage.OpenPage();
            loginPage.PerformLogin("revuetest@test.com", "123456");
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