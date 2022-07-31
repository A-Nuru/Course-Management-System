using System;
using TechTalk.SpecFlow;
using CourseManagementUITestAutomation.Pages;
using NUnit.Framework;
using CourseManagementUITestAutomation.SetUp;
using CourseManagementUITestAutomation.Model;
using TechTalk.SpecFlow.Assist;

namespace CourseManagementUITestAutomation.StepDefinitions
{
    [Binding]
    public class CourseSteps
    {
        HomePage _homePage;
        CoursePage _coursePage;
        CourseFormPage _courseFormPage;
        DatabaseHelper _databaseHelper;
        string title = "Mathematics for Physical Sciences";

        public CourseSteps(HomePage homePage, CoursePage coursePage, CourseFormPage courseFormPage, DatabaseHelper databaseHelper)
        {
            _homePage = homePage;
            _coursePage = coursePage;
            _courseFormPage = courseFormPage;
            _databaseHelper = databaseHelper;
        }
        [When(@"a user clicks on Course link")]
        public void WhenAUserClicksOnCourseLink()
        {
            _homePage.ClickOnCourseLink();
        }


        [When(@"a user clicks on the Create New link")]
        public void WhenAUserClicksOnTheCreateNewLink()
        {
            _databaseHelper.ClearOrPopulateATable(Constants.clearCourseRecordQuery);
            _coursePage.ClickCreateNewLink();
        }


        [When(@"a user fills-in CourseNumber field with (.*)")]
        public void WhenAUserFills_InCourseNumberFieldWith(string courseNumber)
        {
            //_databaseHelper.ClearOrPopulateATable(Constants.clearCourseRecordQuery); can also put databaseHelper here
            _courseFormPage.FillInCourseNumber(courseNumber);
        }
        
        [When(@"a user fills-in Title field with (.*)")]
        public void WhenAUserFills_InTitleFieldWithMathematicsForPhysicalSciences(string courseTitle)
        {
            _courseFormPage.FillInCourseTitle(courseTitle);
        }
        
        [When(@"a user fills-in Credits field with (.*)")]
        public void WhenAUserFills_InCreditsFieldWith(string courseCredits)
        {
            _courseFormPage.FillInCourseCredits(courseCredits);
        }

        //[When(@"a user selects (.*) from the DepartmentId dropdown menu")]
        //public void WhenAUserSelectsPhysicalSciencesFromTheDepartmentIdDropdownMenu(string DepartmentId)
        //{
        //    _courseFormPage.SelectDepartmentIdDropDownMenu(DepartmentId);
        //}

        [When(@"a user clicks on the Create button")]
        public void WhenAUserClicksOnTheCreateButton()
        {
            _courseFormPage.ClickOnCreateButton();
        }

        
        [Then(@"a new course record (.*) must be created")]
        public void ThenANewCourseRecordMathematicsForPhysicalSciencesMustBeCreated(string courseTitle)
        {
            //string expectedUrl = "http://localhost/CourseManagementSystem/course";
            //string actualUrl = _coursePage.GetCoursePageUrl();
            //Assert.IsTrue(expectedUrl.Equals(actualUrl));

            Assert.IsTrue(_coursePage.VerifyNewlyCreatedCourseRecord(courseTitle));
        }



        [When(@"a user fills-in course record form page with the data below")]
        public void WhenAUserFills_InCourseRecordFormPageWithTheDataBelow(Table table)
        {
            var tableData = table.CreateInstance<CourseModel>();
            _courseFormPage.FillInCourseNumber(tableData.CourseNumber);
            _courseFormPage.FillInCourseTitle(tableData.Title);
            _courseFormPage.FillInCourseCredits(tableData.Credits);
            //_courseFormPage.SelectDepartmentIdDropDownMenu(tableData.DepartmentId);
        }

        [When(@"a user fills-in a new course form page with (.*), (.*), (.*) fields")]
        public void WhenAUserFills_InANewCourseFormPageWithFields(string courseNumber, string courseTitle, string courseCredits)
        {
            _courseFormPage.FillInCourseNumber(courseNumber);
            _courseFormPage.FillInCourseTitle(courseTitle);
            _courseFormPage.FillInCourseCredits(courseCredits);
        }


        [Then(@"a course record Mathematics for Physical Science should not be present")]
        public void ThenACourseRecordMathematicsForPhysicalSciencesShouldNotBePresent(string title)
        {
            Assert.IsTrue(_coursePage.VerifyNewlyCreatedCourseRecord(title));
        }

    }
}
