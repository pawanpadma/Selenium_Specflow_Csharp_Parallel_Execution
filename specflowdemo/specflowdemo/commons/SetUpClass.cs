using nunit_datadriven.commons;
using nunit_datadriven.pageobjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System.IO;
using TechTalk.SpecFlow.Bindings;
using NUnit.Framework;
using specflowdemo.stepsdefinitions;
using BoDi;
using AventStack.ExtentReports.Reporter;

namespace specflowdemo.commons
{
    [Binding]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SetUpClass : InitBrowser
    {
        public IWebDriver _driver;
        private readonly IObjectContainer objectContainer;

        public HomePage home;
        public LoginPage login;
        public Read_ini read;
        public ScenarioContext _scenarioContext;
        public static FeatureContext _featureContext;
        private static long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        public SetUpClass(IObjectContainer _objectContainer)
        {
            objectContainer = _objectContainer;
        }

        [BeforeTestRun]
        public static void initApplication()
        {
        }

        [BeforeFeature]
        public static void InvokeURl(FeatureContext featureContext)
        {
        }

        [AfterFeature]
        public static void RefreshPage()
        {
        }

        [BeforeScenario]
        public void loginToApp(ScenarioContext scenarioContext)
        {
            read = new Read_ini();
            _driver = Getbrowser();
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Navigate().GoToUrl(ReadEnv.ReadData("base", "appUrl"));
            _driver.Manage().Window.Maximize();
            home = new HomePage(_driver);
            login = new LoginPage(_driver);

            home.TapLoginLink();
            login.AssertLogin();
            login.loginToApplication(ReadEnv.ReadData("base", "username"), ReadEnv.ReadData("base", "password"));
            login.tapSubmit();
        }

        [AfterScenario]
        public void closeBrowser()
        {
            // home.logout();
            _driver.Quit();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            System.Console.WriteLine("BeforeStep- Start Timer");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
        }

        // [BeforeScenarioBlock]

        /// [AfterScenarioBlock]
        [AfterTestRun]
        public static void CloseApplication()
        {
        }
    }
}