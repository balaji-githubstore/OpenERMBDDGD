using OpenEMRApplication.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.Pages
{
    class LoginPage : WebDriverUtils
    {

        private By _usernameLocator = By.Id("authUser");
        private By _passwordLocator = By.CssSelector("#clearPass");
        private By _languageLocator = By.XPath("//select[@name='languageChoice']");
        private By _loginLocator = By.CssSelector("[type='submit']");
        private By _errorLocator = By.XPath("//div[contains(text(),'Invalid')]");

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            TypeUsingLocator(_loginLocator, username);
        }

        public void EnterPassword(string password)
        {
            TypeUsingLocator(_passwordLocator, password);
        }

        public void SelectLanguageByText(string language)
        {
            SelectElement select = new SelectElement(_driver.FindElement(_languageLocator));
            select.SelectByText(language);
        }

        public void ClickOnLogin()
        {
            ClickUsingLocator(_loginLocator);
        }

        public string GetLoginPageTitle()
        {
            return _driver.Title;
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text.Trim();
        }
    }
}
