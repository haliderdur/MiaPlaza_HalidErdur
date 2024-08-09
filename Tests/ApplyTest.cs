using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebTestAutomation.Pages;

namespace WebTestAutomation.Tests
{
    [TestFixture]
    public class ApplyTest
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private MiaPrepPage _miaPrepPage;
        private ApplyPage _applyPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _miaPrepPage = new MiaPrepPage(_driver);
            _applyPage = new ApplyPage(_driver);
        }

        [Test]
        public void ApplyToSchool()
        {
            _homePage.GoToPage();
            _homePage.ClickOnMiaPrepBannerLink();
            _miaPrepPage.ClickOnApplyLink();
            _applyPage.ClickNextButton();
            _applyPage.FillParentInformation("John", "Doe", "john.doe@example.com", "1234567890");
            _applyPage.SelectDate(30);
            _applyPage.ClickNextButton();
            _applyPage.VerifyElementIsDisplayed(_applyPage.StudentInformationTextLocator);
            // Here I stop the test as per the instructions
        }


        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
