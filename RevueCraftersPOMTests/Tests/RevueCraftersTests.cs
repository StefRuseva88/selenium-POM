using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RevueCraftersPOMTests.Pages;
using System;

namespace RevueCraftersPOMTests.Tests
{
    public class RevueCraftersTests : BaseTest
    {
        private static string? lastCreatedRevueTitle;
        private static string? lastCreatedRevueDescription;

        [Test]
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
        [Test]
        public void CreateRevueWithValidDataTest()
        {
            CreateRevuePage createRevuePage = new CreateRevuePage(driver);

            createRevuePage.OpenPage();

            createRevuePage.TitleField.Clear();

            createRevuePage.TitleField.SendKeys(GenerateRandomTitle());

            createRevuePage.DescriptionField.Clear();

            createRevuePage.DescriptionField.SendKeys(GenerateRandomDescription());

            actions.ScrollToElement(createRevuePage.CreateBtn).Perform();

            createRevuePage.CreateBtn.Click();

        }
    }
}