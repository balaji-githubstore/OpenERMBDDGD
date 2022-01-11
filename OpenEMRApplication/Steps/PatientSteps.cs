using NUnit.Framework;
using OpenEMRApplication.Hooks;
using OpenEMRApplication.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace OpenEMRApplication.Steps
{
    [Binding]
    public class PatientSteps
    {
        private AutomationHooks _hooks;
        private MainPage _main;
        private PatientFinderPage _finder;
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        public PatientSteps(ScenarioContext scenarioContext, FeatureContext featureContext, AutomationHooks hooks)
        {
            this._hooks = hooks;
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
            InitializePage();
            
        }
        public void InitializePage()
        {
            _main = new MainPage(_hooks.driver);
            _finder = new PatientFinderPage(_hooks.driver);
        }



        [When(@"I click on patient client")]
        public void WhenIClickOnPatientClient()
        {
            _main.ClickOnPatientClient();
        }
        
        [When(@"I click on patient")]
        public void WhenIClickOnPatient()
        {
            _main.ClickOnPatients();
        }
        
        [When(@"I click on add new patient")]
        public void WhenIClickOnAddNewPatient()
        {
            _finder.ClickOnAddNewPatient();
        }
        
        [When(@"I fill the form")]
        public void WhenIFillTheForm(Table table)
        {
            scenarioContext.Add("tb", table);
            Console.WriteLine(table.RowCount);
            Console.WriteLine(table.Rows[0][0]);
            Console.WriteLine(table.Rows[0]["firstname"]);

            _hooks.driver.SwitchTo().Frame("pat");
            _hooks.driver.FindElement(By.Id("form_fname")).SendKeys(table.Rows[0]["firstname"]);
            _hooks.driver.FindElement(By.Id("form_lname")).SendKeys(table.Rows[0]["lastname"]);
            _hooks.driver.FindElement(By.Id("form_DOB")).SendKeys(table.Rows[0]["dob"]);

            SelectElement select = new SelectElement(_hooks.driver.FindElement(By.Id("form_sex")));
            select.SelectByText(table.Rows[0]["gender"]);
          

        }
        
        [When(@"I click on create new patient")]
        public void WhenIClickOnCreateNewPatient()
        {
            _hooks.driver.FindElement(By.Id("create")).Click();
            _hooks.driver.SwitchTo().DefaultContent();

        }
        
        [When(@"I click on confirm create new patient")]
        public void WhenIClickOnConfirmCreateNewPatient()
        {
            _hooks.driver.SwitchTo().Frame("modalframe");
            _hooks.driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            _hooks.driver.SwitchTo().DefaultContent();
        }
        
        [When(@"I store alert text and handle it")]
        public void WhenIStoreAlertTextAndHandleIt()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_hooks.driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));

             string actualAlertText = wait.Until(x => x.SwitchTo().Alert()).Text;

            //loading key value pair scenarioContext
            scenarioContext.Add("alerttext", actualAlertText);

            wait.Until(x => x.SwitchTo().Alert()).Accept();
        }
        
        [When(@"I handle happy birthday pop up if any")]
        public void WhenIHandleHappyBirthdayPopUpIfAny()
        {
            if (_hooks.driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count > 0)
            {
                _hooks.driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }

        }

        [Then(@"I should verify the stored alert text as '(.*)'")]
        public void ThenIShouldVerifyTheStoredAlertTextAs(string expectedAlertText)
        {

            if(scenarioContext.TryGetValue("alerttext",out string actualValue))
            {
                Assert.IsTrue(actualValue.Contains(expectedAlertText));
            }
            else
            {
                Assert.Fail();
            }
            
        }
        
        [Then(@"I should verify the patient detail as '(.*)'")]
        public void ThenIShouldVerifyThePatientDetailAs(string expectedPatientName)
        {
            _hooks.driver.SwitchTo().Frame(_hooks.driver.FindElement(By.XPath("//iframe[@name='pat']")));
            string actualValue = _hooks.driver.FindElement(By.XPath("//h2[contains(text(),'Medical Record')]")).Text;
            Console.WriteLine(actualValue);
            Assert.AreEqual(expectedPatientName, actualValue);
        }


       

    }
}
