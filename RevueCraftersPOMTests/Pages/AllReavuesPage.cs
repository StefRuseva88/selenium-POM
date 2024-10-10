using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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
    }
}
