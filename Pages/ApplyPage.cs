using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace WebTestAutomation.Pages
{
    public class ApplyPage
    {
        private readonly IWebDriver _driver;

        // Define locators for Parent Information fields
        private readonly By _parentFirstName = By.XPath("//input[@elname='First' and @name='Name']");
        private readonly By _parentLastName = By.XPath("//input[@elname='Last' and @name='Name']");
        private readonly By _parentEmail = By.XPath("//input[@name='Email']");
        private readonly By _parentPhone = By.XPath("//input[@name='PhoneNumber']");
        private readonly By _secondParentDropdown = By.XPath("//span[@id='select2-Dropdown-arialabel-container']/following-sibling::span");
        private readonly By _secondParentDropdownOptionNo = By.XPath("(//ul[@id='select2-Dropdown-arialabel-results']/li)[3]");
        private readonly By _datePicker = By.XPath("//input[@id='Date-date']");


        private readonly By _nextButton = By.XPath("//em[contains(text(),'Next')]/..");
        private readonly By _studentInformationText = By.XPath("//div[.='Student Information']");
        public By StudentInformationTextLocator => _studentInformationText;

        public ApplyPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillParentInformation(string firstName, string lastName, string email, string phone)
        {
            _driver.FindElement(_parentFirstName).SendKeys(firstName);
            _driver.FindElement(_parentLastName).SendKeys(lastName);
            _driver.FindElement(_parentEmail).SendKeys(email);
            _driver.FindElement(_parentPhone).SendKeys(phone);
            _driver.FindElement(_secondParentDropdown).Click();
            _driver.FindElement(_secondParentDropdownOptionNo).Click();
        }

        public void ClickNextButton()
        {
            IReadOnlyCollection<IWebElement> elements = _driver.FindElements(_nextButton);

            
            // Iterate through the list of elements and try clicking each one
            foreach (IWebElement element in elements)
            {
                try
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();
                }
                catch (Exception ex)
                {
                Console.WriteLine($"Failed to click an element: {ex.Message}");
                }
            }
        }

        public void VerifyElementIsDisplayed(By elementLocator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            IWebElement element = _driver.FindElement(elementLocator);
            Assert.True(element.Displayed, $"Element {element.TagName} is not displayed.");
        }
        
        
        public void SelectDate(int day)
        {
            if (day < 1 || day > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 31.");
            }
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement datePickerInput = wait.Until(ExpectedConditions.ElementToBeClickable(_datePicker));
            datePickerInput.Click();
            string dayXPath = $"//td[normalize-space()='{day}']";
            IWebElement dayElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(dayXPath)));
            dayElement.Click();
        }
    }
}