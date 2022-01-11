using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.Pages
{
    class PatientFinderPage
    {
        private By _finFrameLocator = By.XPath("//*[@name='fin']");

        private IWebDriver _driver;

        public PatientFinderPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void ClickOnAddNewPatient()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(_finFrameLocator));
            _driver.FindElement(By.Id("create_patient_btn1")).Click();
            _driver.SwitchTo().DefaultContent();
        }
    }
}
