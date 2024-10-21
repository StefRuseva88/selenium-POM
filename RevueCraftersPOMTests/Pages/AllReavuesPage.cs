using OpenQA.Selenium;

namespace RevueCraftersPOMTests.Pages
{
    public class AllReavuesPage : BasePage
    {
        public AllReavuesPage(IWebDriver driver) : base(driver)
        {
            
        }

        public virtual string Url => BaseUrl + "/Revue/MyRevues#myRevues";

        public IWebElement SearchRevueField => driver.FindElement(By.XPath("//input[@id='keyword']"));

        public IWebElement SearchBtn => driver.FindElement(By.XPath("//button[@id='search-button']"));

        public IWebElement EditBtn => driver.FindElement(By.XPath("//a[text()='Edit']"));

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));

        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));

        public IWebElement SaveBtn => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement DeleteBtn => driver.FindElement(By.XPath("//a[text()='Delete']"));

        public IWebElement NoRevuesMsg => driver.FindElement(By.XPath("//span[@class='col-12 text-muted']"));


        public void AssertNoRevues()
        {
            Assert.That(NoRevuesMsg.Text.Trim, Is.EqualTo("No Revues yet!"), "Error message was not as expected.");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
