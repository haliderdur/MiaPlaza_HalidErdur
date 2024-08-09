using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebTestAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _miaPrepBannerLink = By.XPath("//a[contains(.,'Online High School')]");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://miacademy.co/#/");
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            Assert.IsTrue(_driver.Title.Contains("Miacademy - Engaging Online Curriculum"));
        }

        public void ClickOnMiaPrepBannerLink()
        {
             WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
             wait.Until(ExpectedConditions.ElementToBeClickable(_miaPrepBannerLink));
            _driver.FindElement(_miaPrepBannerLink).Click();
        }
    }
}
