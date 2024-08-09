using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebTestAutomation.Pages
{
    public class MiaPrepPage
    {
        private readonly IWebDriver _driver;
        private readonly By _applyLink = By.XPath("//a[contains(.,'Apply to Our School')]");

        public MiaPrepPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickOnApplyLink()
        {
             WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
             wait.Until(ExpectedConditions.ElementToBeClickable(_applyLink));
            _driver.FindElement(_applyLink).Click();
        }
    }
}
