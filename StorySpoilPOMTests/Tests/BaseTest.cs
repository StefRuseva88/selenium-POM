using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using StorySpoilPOMTests.Pages;

namespace StorySpoilPOMTests.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public Actions actions;

        public LoginPage loginPage;

        public CreateStoryPage createStoryPage;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            actions = new Actions(driver);

            loginPage = new LoginPage(driver);
            createStoryPage = new CreateStoryPage(driver);

            loginPage.OpenPage();
            loginPage.PerformLogin("stef88", "123456");
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