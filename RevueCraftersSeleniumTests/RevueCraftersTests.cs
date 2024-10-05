using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace RevueCraftersSeleniumTests
{
    public class Tests
    {
        private IWebDriver driver;
        private Actions actions;
        private static readonly string baseUrl = "https://d3s5nxhwblsjbi.cloudfront.net";
        private static string? lastCreatedRevueTitle;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize ChromeOptions
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArgument("--disable-search-engine-choice-screen");

            // Initialize WebDriver
            driver = new ChromeDriver(options);
            actions = new Actions(driver);

            // Navigate to the base URL
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Perform login
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            var loginForm = driver.FindElement(By.XPath("//section[@id='loginForm']"));
            actions.ScrollToElement(loginForm).Perform();

            driver.FindElement(By.Id("form3Example3")).SendKeys("stef88@test.bg");
            driver.FindElement(By.Id("form3Example4")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void CreateRevueWithInvalidDataTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/Create");
            var revueForm = driver.FindElement(By.CssSelector(".card-body"));
            actions.ScrollToElement(revueForm).Perform();

            driver.FindElement(By.XPath("//input[@id='form3Example1c']")).SendKeys("");
            driver.FindElement(By.XPath("//input[@id='form3Example3c']")).SendKeys("");
            driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']")).SendKeys("");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            // Fetch the error messages after attempting to submit the form
            var titleErrorMessage = driver.FindElements(By.XPath("//div[contains(@class, 'card-body')]//li"));
            bool isErrorMessagePresent = titleErrorMessage.Any(e => e.Text == "Unable to create new Revue!");

            Assert.That(isErrorMessagePresent, Is.True, "The error message 'Unable to create new Revue!' was not found.");
        }

        [Test, Order(2)]
        public void CreateRandomRevueTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/Create");
            var revueForm = driver.FindElement(By.XPath("//div[@class='row justify-content-center']"));
            actions.ScrollToElement(revueForm).Perform();

            var newRevueTitle = GenerateRandomString(6);

            driver.FindElement(By.XPath("//input[@id='form3Example1c']"))
                .SendKeys(newRevueTitle);

            var newRevueDescription = GenerateRandomString(10);

            driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"))
                .SendKeys(newRevueDescription);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            string currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{baseUrl}/Revue/MyRevues"), "The page should remain on the creation page.");

            var allRevues = driver.FindElements(By.XPath("//div[@class='col-md-4']"));
            lastCreatedRevueTitle = allRevues.Last().FindElement(By.CssSelector(".text-muted")).Text;
            Assert.That(lastCreatedRevueTitle, Is.EqualTo(newRevueTitle), "The last revue title should match the newly created revue title.");
        }

        [Test, Order(3)]
        public void SearchForRevueTitleTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/MyRevues");

            var searchField = driver.FindElement(By.XPath("//input[@id='keyword']"));
            actions.ScrollToElement(searchField).Perform();

            searchField.SendKeys(lastCreatedRevueTitle);
            driver.FindElement(By.XPath("//button[@id='search-button']")).Click();

            var searchResutRevueTitle = driver.FindElement(By.XPath("//div[@class='text-muted text-center']")).Text;
            Assert.That(searchResutRevueTitle, Is.EqualTo(lastCreatedRevueTitle), "The search resulting Revue is not present on the screen.");
        }

        [Test, Order(4)]
        public void EditLastCreatedRevueTitleTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/MyRevues");

            var allRevues = driver.FindElements(By.CssSelector(".card.mb-4"));
            Assert.IsTrue(allRevues.Count > 0, "No revues were found on the page.");

            var lastCreatedRevue = allRevues.Last();
            Actions actions = new Actions(driver);
            actions.MoveToElement(lastCreatedRevue).Perform();

            var editButton = lastCreatedRevue.FindElement(By.CssSelector("a[href*='/Revue/Edit']"));
            editButton.Click();

            var editForm = driver.FindElement(By.CssSelector("div.card-body.p-md-5"));
            actions.MoveToElement(editForm).Perform();

            var titleInput = driver.FindElement(By.Id("form3Example1c"));
            string newTitle = "Changed Title - " + lastCreatedRevueTitle;
            titleInput.Clear();
            titleInput.SendKeys(newTitle);

            var saveChangesButton = driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-lg"));
            saveChangesButton.Click();

            string currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{baseUrl}/Revue/MyRevues"), "The page should redirect to My Revues.");

            allRevues = driver.FindElements(By.CssSelector("div.card.mb-4.box-shadow"));
            var lastRevueTitleElement = allRevues.Last().FindElement(By.CssSelector("div.text-muted.text-center"));

            string actualRevueTitle = lastRevueTitleElement.Text.Trim();
            Assert.That(actualRevueTitle, Is.EqualTo(newTitle), "The last created revue title does not match the expected value.");
        }

        [Test, Order(5)]
        public void DeleteLastCreatedRevueTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/MyRevues");

            var revues = driver.FindElements(By.CssSelector("div.card.mb-4.box-shadow"));
            Assert.IsTrue(revues.Count > 0, "No revues were found on the page.");

            var lastRevueElement = revues.Last();
            Actions actions = new Actions(driver);
            actions.MoveToElement(lastRevueElement).Perform();

            var deleteButton = lastRevueElement.FindElement(By.CssSelector("a[href*='/Revue/Delete']"));
            deleteButton.Click();

            string currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{baseUrl}/Revue/MyRevues"), "The page should be My Revues.");

            revues = driver.FindElements(By.CssSelector("div.card.mb-4.box-shadow"));
            var lastRevueTitleElement = revues.Last().FindElement(By.CssSelector("div.text-muted.text-center"));

            string actualRevueTitle = lastRevueTitleElement.Text.Trim();
            Assert.That(actualRevueTitle, Is.Not.EqualTo(lastCreatedRevueTitle), "The last created revue title does not match the expected value.");
        }

        [Test, Order(6)]
        public void SearchForNonExistentRevueTest()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/Revue/MyRevues");
            var searchField = driver.FindElement(By.CssSelector(".input-group.mb-xl-5"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(searchField).Perform();

            var searchInput = driver.FindElement(By.Name("keyword"));
            searchInput.SendKeys(lastCreatedRevueTitle);
            var searchButton = driver.FindElement(By.Id("search-button"));
            searchButton.Click();

            var noRevuesMessage = driver.FindElement(By.CssSelector(".col-12.text-muted"));
            Assert.That(noRevuesMessage.Text.Trim(), Is.EqualTo("No Revues yet!"), "The 'No Revues yet!' message is not displayed as expected.");
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}