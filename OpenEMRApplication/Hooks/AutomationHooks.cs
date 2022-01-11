using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OpenEMRApplication.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public IWebDriver driver;

        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private ISpecFlowOutputHelper _helper;



        public AutomationHooks(ScenarioContext scenarioContext, FeatureContext featureContext, ISpecFlowOutputHelper helper)
        {
            this._helper = helper;
        }

        public void LaunchBrowser(string browser="ch")
        {
            if(browser.ToLower().Equals("ch"))
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                _helper.WriteLine("Browser launched with Chrome");
            }
            else if(browser.ToLower().Equals("ff"))
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                _helper.WriteLine("Browser launched with Firefox");
            }
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://demo.openemr.io/b/openemr";
            _helper.WriteLine("navigated to url");
        }

        public void TakeScreenShot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot= ts.GetScreenshot();
            screenshot.SaveAsFile("error.png");
            _helper.AddAttachment("D:\\error.png");
        }


        [AfterScenario]
        public void EndScenario()
        {
           
            if(driver !=null)
            {
                driver.Quit();
            }

            _helper.AddAttachment("D:\\error.png");
        }

        //public static ExtentReports extent;

        //private static ExtentTest feature;
        //public static ExtentTest scenario;
        //private static string featureTitle;

        ////setup the report starts
        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
        //    string reportPath = @"D:\Report\"; //where to save
        //    ExtentSparkReporter report = new ExtentSparkReporter(reportPath);

        //    extent = new ExtentReports();
        //    extent.AttachReporter(report); //accumulate the html while running the scenarios
        //}

        ////generate the report
        //[AfterTestRun]
        //public static void AfterTestRun()
        //{
            
        //    extent.Flush(); //generate html with accumulated html
        //}


        ////log the feature name and logging the scenario name
        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    //log the feature name
        //    if (featureTitle != featureContext.FeatureInfo.Title)
        //    {
        //        feature = extent.CreateTest(new GherkinKeyword("Feature"), "Feature: " + featureContext.FeatureInfo.Title);
        //    }
        //    //log the scenario name 
        //    featureTitle = featureContext.FeatureInfo.Title;
        //    scenario = feature.CreateNode(new GherkinKeyword("Scenario"), "Scenario: " + scenarioContext.ScenarioInfo.Title);
        //}

        //[AfterStep]
        //public void AfterStep()
        //{
        //    //Console.WriteLine(scenarioContext.StepContext.StepInfo.Text);

        //    //tells whether given or when or then 
        //    var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        //    if (scenarioContext.TestError == null)
        //    {
        //        scenario.CreateNode(new GherkinKeyword(stepType), scenarioContext.StepContext.StepInfo.Text);
        //    }
        //    else if (scenarioContext.TestError != null)
        //    {
        //        scenario.CreateNode(new GherkinKeyword(stepType), scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
        //    }
        //}

       
        //[AfterScenario]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}

    }
}
