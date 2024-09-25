using OpenQA.Selenium;

namespace MovieCatalogPOMTests.Pages
{
    public class AddMoviePage : BasePage
    {
        public AddMoviePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Catalog/Add#add";

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement PosterUrlField => driver.FindElement(By.XPath("//input[@name='PosterUrl']"));
        public IWebElement TrailerLinkField => driver.FindElement(By.XPath("//input[@name='TrailerLink']"));
        public IWebElement MarkAsWatchedCheckBox => driver.FindElement(By.XPath("//input[@id='flexCheckDefault']"));
        public IWebElement AddMovieBtn => driver.FindElement(By.XPath("//button[text()='Add']"));
        public IWebElement ToastMsg => driver.FindElement(By.XPath("//div[@class='toast-message']"));

        public void AssertEmptyTitleMsg()
        {
            Assert.That(ToastMsg.Text.Trim, Is.EqualTo("The Title field is required."), "Error message was not as expected.");
        }

        public void AssertEmptyDescriptionMsg()
        {
            Assert.That(ToastMsg.Text.Trim, Is.EqualTo("The Description field is required."), "Error message was not as expected.");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
