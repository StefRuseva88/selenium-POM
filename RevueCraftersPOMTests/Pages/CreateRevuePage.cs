using OpenQA.Selenium;

namespace RevueCraftersPOMTests.Pages
{
    public class CreateRevuePage : BasePage
    {
        public CreateRevuePage(IWebDriver driver) : base(driver)
        {

        }
        public static string Url => BaseUrl + "/Revue/Create#createRevue";

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        public IWebElement PictureUrlField => driver.FindElement(By.XPath("//input[@id='form3Example3c']"));
        public IWebElement CreateBtn => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
        public IWebElement ErrorMsg => driver.FindElement(By.XPath("//li[text()='Unable to create new Revue!']"));

        public void AssertEmptyTitleMsg()
        {
            Assert.That(ErrorMsg.Text.Trim, Is.EqualTo("Unable to create new Revue!"), "Error message was not as expected.");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
