using NUnit.Framework;
using nunit_datadriven.pageobjects;
using OpenQA.Selenium;
using specflowdemo.commons;

using TechTalk.SpecFlow;

namespace specflowdemo.stepsdefinitions
{
    [Binding]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HomeSteps
    {
        public IWebDriver driver;
        public HomePage homePage;
        public LoginPage loginPage;

        public HomeSteps(IWebDriver _driver)
        {
            this.driver = _driver;
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        private string price = null;

        [Given(@"I am on the Homepage")]
        public void GivenIAmOnTheHomepage()
        {
            // HomePage home = new HomePage();
            // LoginPage login = new LoginPage();

            homePage.validateHome();
        }

        [When(@"Product ""(.*)"" is searched")]
        public void WhenProductIsSearched(string product)
        {
            homePage.searchprodonly(product);
        }

        [Then(@"Correct price '(.*)' is diplayed")]
        public void ThenCorrectPriceIsDiplayed(string priceRequired)
        {
            Assert.AreEqual(priceRequired, price);
        }

        [Then(@"Correct Productname ""(.*)"" is displayed")]
        public void ThenCorrectProductnameIsDisplayed(string productname)
        {
            price = homePage.searchProduct(productname);
        }
    }
}