using OpenQA.Selenium;

namespace MovieCatalogPOMTests.Pages
{
    public class DeleteMoviePage : BasePage
    {
        public DeleteMoviePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement YesButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement ToastMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));
    }
}
