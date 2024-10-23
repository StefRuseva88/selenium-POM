using OpenQA.Selenium;

namespace StorySpoilPOMTests.Pages
{
    public class CreateStoryPage : BasePage
    {
        public CreateStoryPage(IWebDriver driver) : base(driver)
        {
            
        }

        public static string Url => BaseUrl + "/Story/Add";

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@id='title']"));

        public IWebElement DescriptionField => driver.FindElement(By.XPath("//input[@id='description']"));

        public IWebElement ImageField => driver.FindElement(By.XPath("//input[@id='url']"));

        public IWebElement CreateBtn => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement LastCreatedStory => driver.FindElement(By.XPath("//h2[@class='display-4']"));

        public IWebElement EditBtn => driver.FindElement(By.XPath("//a[text()='Edit']"));

        public IWebElement DeleteBtn => driver.FindElement(By.XPath("//a[text()='Delete']"));

        public IWebElement ErrorMsg => driver.FindElement(By.XPath("//span[@class='text-info field-validation-error']"));


        public void AssertEmptyTitleMsg()
        {
            Assert.That(ErrorMsg.Text.Trim, Is.EqualTo("The Title field is required."), "Error message was not as expected.");
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
