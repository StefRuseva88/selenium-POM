using OpenQA.Selenium;

namespace MovieCatalogPOMTests.Pages
{
    public class EditMoviePage : BasePage
    {
        public EditMoviePage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Movie/Edit";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement PosterUrlInput => driver.FindElement(By.XPath("//input[@name='PosterUrl']"));

        public IWebElement TrailerLinkInput => driver.FindElement(By.XPath("//input[@name='TrailerLink']"));

        public IWebElement MarkAsWatchedCheckBox => driver.FindElement(By.XPath("//input[@class='form-check-input']"));

        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement ToastMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

        public void AssertRecordEdited()
        {
            Assert.That(ToastMessage.Text.Trim(), Is.EqualTo("The Movie is edited successfully!"), "The movie was not edited");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
