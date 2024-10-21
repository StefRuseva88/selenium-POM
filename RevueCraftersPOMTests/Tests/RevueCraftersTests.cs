using RevueCraftersPOMTests.Pages;

namespace RevueCraftersPOMTests.Tests
{
    public class RevueCraftersTests : BaseTest
    {
        private static string? lastCreatedRevueTitle;

        [Test, Order(1)]
        public void CreateRevueWithInvalidDataTest()
        {
            CreateRevuePage createRevuePage = new CreateRevuePage(driver);

            createRevuePage.OpenPage();

            createRevuePage.TitleField.Clear();

            createRevuePage.DescriptionField.SendKeys("Test Description");

            actions.ScrollToElement(createRevuePage.CreateBtn).Perform();

            createRevuePage.CreateBtn.Click();

            createRevuePage.AssertEmptyTitleMsg();
        }
        [Test, Order(2)]
        public void CreateRevueWithValidDataTest()
        {
            CreateRevuePage createRevuePage = new CreateRevuePage(driver);

            createRevuePage.OpenPage();

            createRevuePage.TitleField.Clear();
            string generatedTitle = GenerateRandomTitle();
            createRevuePage.TitleField.SendKeys(generatedTitle);

            createRevuePage.DescriptionField.Clear();
            createRevuePage.DescriptionField.SendKeys(GenerateRandomDescription());
            actions.ScrollToElement(createRevuePage.CreateBtn).Perform();

            createRevuePage.CreateBtn.Click();

            Assert.That(driver.Url.Contains("/Revue/MyRevues"), Is.True, "Navigation to My Revues page failed.");

            // Set the lastCreatedRevueTitle to the generated title
            lastCreatedRevueTitle = generatedTitle;
        }

        [Test, Order(3)]
        public void SearchForRevueTitleTest()
        {
            AllReavuesPage allReavuesPage = new AllReavuesPage(driver);

            allReavuesPage.OpenPage();

            allReavuesPage.SearchRevueField.SendKeys(lastCreatedRevueTitle);

            actions.ScrollToElement(allReavuesPage.SearchBtn).Perform();

            allReavuesPage.SearchBtn.Click();

            Assert.That(driver.PageSource, Does.Contain(lastCreatedRevueTitle), "Revue title was not found.");
        }

        [Test, Order(4)]
        public void EditRevueTest()
        {
            AllReavuesPage allReavuesPage = new AllReavuesPage(driver);

            allReavuesPage.OpenPage();

            allReavuesPage.SearchRevueField.SendKeys(lastCreatedRevueTitle);
            actions.ScrollToElement(allReavuesPage.SearchBtn).Perform();
            allReavuesPage.SearchBtn.Click();

            actions.ScrollToElement(allReavuesPage.EditBtn).Perform();
            allReavuesPage.EditBtn.Click();

            string updatedTitle = GenerateRandomTitle();

            allReavuesPage.TitleField.Clear();
            allReavuesPage.TitleField.SendKeys(updatedTitle);

            actions.ScrollToElement(allReavuesPage.SaveBtn).Perform();
            allReavuesPage.SaveBtn.Click();

            Assert.That(driver.Url.Contains("/Revue/MyRevues"), Is.True, "Navigation to My Revues page failed.");
            Assert.That(driver.PageSource, Does.Contain(updatedTitle), "Revue title was not updated.");
            lastCreatedRevueTitle = updatedTitle;
        }

        [Test, Order(5)]
        public void DeleteRevueTest()
        {
            AllReavuesPage allReavuesPage = new AllReavuesPage(driver);

            allReavuesPage.OpenPage();

            allReavuesPage.SearchRevueField.SendKeys(lastCreatedRevueTitle);
            actions.ScrollToElement(allReavuesPage.SearchBtn).Perform();
            allReavuesPage.SearchBtn.Click();

            actions.ScrollToElement(allReavuesPage.DeleteBtn).Perform();
            allReavuesPage.DeleteBtn.Click();

            Assert.That(driver.Url.Contains("/Revue/MyRevues"), Is.True, "Navigation to My Revues page failed.");
        }

        [Test, Order(6)]
        public void SearchForNonExistentTitleTest()
        {
            AllReavuesPage allReavuesPage = new AllReavuesPage(driver);

            allReavuesPage.OpenPage();

            allReavuesPage.SearchRevueField.SendKeys(lastCreatedRevueTitle);

            actions.ScrollToElement(allReavuesPage.SearchBtn).Perform();

            allReavuesPage.SearchBtn.Click();

            allReavuesPage.AssertNoRevues();
        }
    }
}