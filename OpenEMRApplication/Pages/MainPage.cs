using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.Pages
{
    class MainPage
    {
        private By _patientClientLocator = By.XPath("//div[text()='Patient/Client']");
        private By _patientLocator = By.XPath("//*[text()='Patients']");

        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void ClickOnPatientClient()
        {
            _driver.FindElement(_patientClientLocator).Click();
        }

        public void WaitForPresenceOfPatientElement()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(x => x.FindElement(_patientLocator));
        }

       public string GetMainPageTitle()
        {
            return _driver.Title;
        }

        public void ClickOnPatients()
        {
            _driver.FindElement(_patientLocator).Click();
        }

    }
}
