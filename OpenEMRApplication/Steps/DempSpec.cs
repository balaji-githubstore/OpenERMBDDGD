using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace OpenEMRApplication.Steps
{
    //[Scope(Feature ="Demo")]
    [Binding]
    public class DempSpec
    {
        ScenarioContext scenarioContext;
        public DempSpec(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Then(@"I should get added table")]
        public void ThenIShouldGetAddedTable()
        {
            Console.WriteLine("Final then");
            if (scenarioContext.TryGetValue("tb", out Table table))
            {
                Console.WriteLine(table.RowCount);
                Console.WriteLine(table.Rows[0][0]);
                Console.WriteLine(table.Rows[0]["firstname"]);
            }
        }

        //[Scope(Feature ="Demo",Scenario ="")]
        [Scope(Tag = "@mytag")]
        [When(@"I click on create new patient")]
        public void WhenIClickOnCreateNewPatient()
        {
      

        }
    }
}
