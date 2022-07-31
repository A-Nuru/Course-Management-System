using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CourseManagementUITestAutomation.Model;
using CourseManagementUITestAutomation.Pages;
using System.Collections.Generic;
using NUnit.Framework;

namespace CourseManagementUITestAutomation.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        HomePage _homePage;
        public HomePageSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [Then(@"All below modules are visible")]
        public void ThenAllBelowModulesAreVisible(Table table)
        {            
            var expectedModules = table.CreateSet<HomePageModel>();
            var actualModules = _homePage.VerifyThatAllModulesExist();

            foreach (var expectedModule in expectedModules)
            {
                Assert.IsTrue(actualModules[0].Equals(expectedModule.Module), $"Expected module {expectedModule.Module} is not equal to an actual module {actualModules[0]}");
                actualModules.Remove(actualModules[0]);
            }
        }

        [Then(@"All modules are clickable")]
        public void ThenAllModulesAreClickable(Table table)
        {
            int counter = 0;
            var expectedModules = table.CreateSet<HomePageModel>();        

            foreach (var expectedModule in expectedModules)
            {
                counter = counter + 1;
                Assert.IsTrue(_homePage.VerifyThatAModuleIsClickable(expectedModule.Module, counter));
            }
        }
    }
}
