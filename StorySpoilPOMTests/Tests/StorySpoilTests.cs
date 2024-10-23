using StorySpoilPOMTests.Pages;

namespace StorySpoilPOMTests.Tests
{
    public class StorySpoilTests : BaseTest
    {
        private static string? lastCreatedStoryTitle;

        [Test, Order(1)]
        public void CreateStoryWithInvalidDataTest()
        {
            CreateStoryPage createStoryPage = new CreateStoryPage(driver);

            createStoryPage.OpenPage();

            createStoryPage.TitleField.Clear();

            createStoryPage.DescriptionField.SendKeys("Test Description");

            createStoryPage.CreateBtn.Click();

            Assert.That(driver.Url, Does.Contain("/Story/Add"), "Navigation to Home Page page failed.");

            createStoryPage.AssertEmptyTitleMsg();
        }

        [Test, Order(2)]
        public void CreateStoryWithValidDataTest()
        {
            CreateStoryPage createStoryPage = new CreateStoryPage(driver);

            createStoryPage.OpenPage();

            string title = GenerateRandomTitle();
            string description = GenerateRandomDescription();

            createStoryPage.TitleField.SendKeys(title);
            createStoryPage.DescriptionField.SendKeys(description);

            createStoryPage.CreateBtn.Click();

            lastCreatedStoryTitle = title;

            Assert.That(createStoryPage.LastCreatedStory.Text.Trim,Is.EqualTo(lastCreatedStoryTitle), "Story title was not found.");
        }

        [Test, Order(3)]
        public void EditLastCreatedStoryTest()
        {
            actions.ScrollToElement(createStoryPage.EditBtn).Perform();
            createStoryPage.EditBtn.Click();

            string newTitle = GenerateRandomTitle();
            string newDescription = GenerateRandomDescription();

            createStoryPage.TitleField.Clear();
            createStoryPage.TitleField.SendKeys(newTitle);

            createStoryPage.DescriptionField.Clear();
            createStoryPage.DescriptionField.SendKeys(newDescription);

            createStoryPage.CreateBtn.Click();

            lastCreatedStoryTitle = newTitle;

            Assert.That(createStoryPage.LastCreatedStory.Text.Trim, Is.EqualTo(lastCreatedStoryTitle), "Story title was not found.");
        }

        [Test, Order(4)]
        public void DeleteLastCreatedStoryTest()
        {
            actions.ScrollToElement(createStoryPage.DeleteBtn).Perform();
            createStoryPage.DeleteBtn.Click();

            Assert.That(createStoryPage.LastCreatedStory.Text.Trim, Is.Not.EqualTo(lastCreatedStoryTitle), "Story was not deleted.");
        }

        [Test, Order(5)]
        public void TryToDeleteNonExistentStoryTest()
        {
            Assert.That(createStoryPage.NoSpoilersMsg.Text.Trim, Is.EqualTo("🚨 No Spoilers Yet! 🚨"), "No spoilers message was not found.");
        }
    }
}
