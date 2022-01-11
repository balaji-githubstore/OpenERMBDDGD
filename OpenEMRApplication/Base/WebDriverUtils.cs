using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.Base
{
    public class WebDriverUtils
    {
        private IWebDriver driver;

        public WebDriverUtils(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickUsingLocator(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void TypeUsingLocator(By locator,string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }

    }
}
