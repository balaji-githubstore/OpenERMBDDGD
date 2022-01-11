using AventStack.ExtentReports;
using NUnit.Framework;
using OpenEMRApplication.Hooks;
using OpenEMRApplication.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OpenEMRApplication.Steps
{
    [Binding]
    public class LoginSteps
    {
        private AutomationHooks _hooks;
        private LoginPage _login;
        private MainPage _main;
        private ISpecFlowOutputHelper _helper;
        public LoginSteps(AutomationHooks hooks, ISpecFlowOutputHelper helper)
        {
            this._hooks = hooks;
            this._helper = helper;
        }

        public void InitializePage()
        {
            _login = new LoginPage(_hooks.driver);
            _main = new MainPage(_hooks.driver);

        }

        [Given(@"I have browser with openemr page")]
        public void GivenIHaveBrowserWithOpenemrPage()
        {
            _hooks.LaunchBrowser();
            InitializePage();
        }

        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            _login.EnterUsername(username);
            _helper.WriteLine("Enter Username");

        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            _login.EnterPassword(password);
        }

        [When(@"I select language as '(.*)'")]
        public void WhenISelectLanguageAs(string language)
        {
            _login.SelectLanguageByText(language);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            _login.ClickOnLogin();

        }

        [Then(@"I should get access to portal with title as '(.*)'")]
        public void ThenIShouldGetAccessToPortalWithTitleAs(string expectedTitle)
        {
            //make sure portal page is loaded
            _main.WaitForPresenceOfPatientElement();
            Assert.AreEqual(expectedTitle, _main.GetMainPageTitle());
            AutomationHooks.scenario.Log(Status.Info, "completed title validation " + _main.GetMainPageTitle()); 
        }

        [Then(@"I should get error message as '(.*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedError)
        {
            string actualError = _login.GetErrorMessage();

            
            Assert.Multiple(() =>
            {
                Assert.IsTrue(actualError.Contains(expectedError));
                Assert.AreEqual(expectedError, actualError);
            });
        }

    }
}
