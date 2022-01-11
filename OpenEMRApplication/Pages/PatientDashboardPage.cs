using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.Pages
{
    class PatientDashboardPage
    {
        private IWebDriver _driver;

        public PatientDashboardPage(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}
