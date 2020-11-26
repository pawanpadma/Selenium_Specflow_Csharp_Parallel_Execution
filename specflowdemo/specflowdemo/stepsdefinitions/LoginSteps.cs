using NUnit.Framework;
using nunit_datadriven.commons;
using nunit_datadriven.pageobjects;
using OpenQA.Selenium;
using specflowdemo.commons;

using TechTalk.SpecFlow;

namespace specflowdemo.stepsdefinitions
{
    [Binding]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginSteps
    {
        public IWebDriver driver;
        public HomePage homePage;
        public LoginPage loginPage;

        public LoginSteps(IWebDriver _driver)
        {
            this.driver = _driver;
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        [Given(@"I provide invalid credentials")]
        public void GivenIProvideInvalidCredentials(Table table)
        {
            homePage.logout();
            loginPage.loginToApplication(table.Rows[0]["email"], table.Rows[0]["password"]);
            //foreach (var item in data.Rows)
            //{
            //   driver.FindElement(By.Id("EmailLocator")).SendKeys(item["email"]);
            //   ClickLoanPurposeAddButton();
            //}

            //public void ValidateConsolidationTooltips(Table table)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        //div[contains(@class,'calc-card')]//a[@class='tooltip-info']
            //        DriverFactory.driver.FindElements(By.XPath("//div[@class='mt-label']//a[@class='tooltip-info']"))[i].Click();
            //        //div[contains(@class,'calc-card')]//div[text()='Fees paid to an organization of homeowners of a particular subdivision, condominium, or planned unit development.']
            //        Assert.IsTrue(DriverFactory.driver.FindElement(By.XPath("//div[@class='mt-label']//div[text()='" + table.Rows[i]["Tool_Tip_Texts"] + "']")).Displayed);
            //    }
        }

        [When(@"I submit the login form")]
        public void WhenISubmitTheLoginForm()
        {
            loginPage.tapSubmit();
        }

        [Then(@"""(.*)"" message should be displayed")]
        public void ThenMessageShouldBeDisplayed(string error)
        {
            Assert.AreEqual(error, loginPage.validateLoginError());

            loginPage.loginToApplication(ReadEnv.ReadData("base", "username"), ReadEnv.ReadData("base", "password"));
            loginPage.tapSubmit();
        }
    }
}