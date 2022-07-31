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
    public class StudentSteps
    {
        HomePage _homePage;
        StudentFormPage _studentFormPage;
        StudentPage _studentPage;
        DatabaseHelper _databaseHelper;      
        

        public StudentSteps(HomePage homePage, StudentFormPage studentFormPage, 
            StudentPage studentPage, DatabaseHelper databaseHelper)
        {
            _homePage = homePage;
            _studentFormPage = studentFormPage;
            _studentPage = studentPage;
            _databaseHelper = databaseHelper;
        }
        
        
        [When(@"a user clicks on Students link")]
        public void WhenAUserClicksOnStudentsLink()
        {
            _databaseHelper.ClearOrPopulateATable(Constants.clearStudentRecord);
            _homePage.ClickOnStudentLink();            
        }
        
        [When(@"a user clicks on Create New link")]
        public void WhenAUserClicksOnCreateNewLink()
        {            
            _studentPage.ClickOnCreateNewLink();
        }
        
        [When(@"a user fills-in FamilyName field with (.*)")]
        public void WhenAUserFills_InFamilyNameFieldWithEric(string familyName)
        {
            _studentFormPage.FillInFamilyName(familyName);
        }
        
        [When(@"a user fills-in FirstName field with (.*)")]
        public void WhenAUserFills_InFirstNameFieldWithTadar(string firstName)
        {
            _studentFormPage.FillInFirstName(firstName);
        }
        
        [When(@"a user fills-in Enrollment Date field with (.*)")]
        public void WhenAUserFills_InEnrollmentDateFieldWith(string enrollmentDate)
        {
            _studentFormPage.FillInEnrollmentDate(enrollmentDate);            
        }

        [When(@"a user clicks on Delete button on the form page")]
        [When(@"a user clicks on Save button")]
        [When(@"a user clicks on Create button")]
        public void WhenAUserClicksOnCreateButton()
        {
            _studentFormPage.ClickOnCreateSaveOrDeleteButton();
        }
        
        [When(@"a user fills-in new student record form page with the data below")]
        public void WhenAUserFills_InNewStudentRecordFormPageWithTheDataBelow(Table table)
        {
            var tableData = table.CreateInstance<StudentModel>();
            _studentFormPage.FillInFamilyName(tableData.FamilyName);
            _studentFormPage.FillInFirstName(tableData.FirstName);
            _studentFormPage.FillInEnrollmentDate(tableData.EnrollmentDate);
        }
        
        [Then(@"a new Student record (.*) must be created")]
        public void ThenANewStudentRecordEricMustBeCreated(string firstName)
        {         
            Assert.IsTrue(_studentPage.VerifyNewlyCreatedStudentRecord(firstName));
        }

        [When(@"a user fills-in a new student form page with (.*), (.*), (.*) fields")]
        public void WhenAUserFills_InANewStudentFormPageWithTadarEricFields(string familyName, string firstName, string enrollmentDate )
        {
            _studentFormPage.FillInFamilyName(familyName);
            _studentFormPage.FillInFirstName(firstName);
            _studentFormPage.FillInEnrollmentDate(enrollmentDate);            
        }
        
        
        [Then(@"an error message (.*) should be displayed")]
        public void ThenAnErrorMessageFirstNameIsRequiredShouldBeDisplayed(string expectedErrorMessage)
        {
            string actualErrorMessage = string.Empty;

            if (expectedErrorMessage.Equals("First name is required"))
            {
                actualErrorMessage = _studentFormPage.GetFirstNameErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Last name is required"))
            {
                actualErrorMessage = _studentFormPage.GetLastNameErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Enrollment date is required"))
            {
                actualErrorMessage = _studentFormPage.GetEnrollmentDateErrorMessage();
            }

            //option 1
            Assert.IsTrue(actualErrorMessage.Equals(expectedErrorMessage));

            //option 2
            Assert.IsTrue(actualErrorMessage.Equals(expectedErrorMessage), $"Expected {expectedErrorMessage} is not equal to {actualErrorMessage}");

            //option 3
            Assert.AreEqual(actualErrorMessage, expectedErrorMessage, $"Expected {expectedErrorMessage} is not equal to {actualErrorMessage}");
        }

        [When(@"a user clicks on Edit link")]
        public void WhenAUserClicksOnEditLink()
        {
            _databaseHelper.ClearOrPopulateATable(Constants.clearAllStudentRecords);
            _databaseHelper.ClearOrPopulateATable(Constants.populateNewStudentRecord);
            _studentPage.ClickOnEditButton();
        }

        [When(@"a user clicks on Delete link")]
        public void WhenAUserClicksOnDeleteLink()
        {
            _databaseHelper.ClearOrPopulateATable(Constants.clearAllStudentRecords);
            _databaseHelper.ClearOrPopulateATable(Constants.populateNewStudentRecord);
            _studentPage.ClickOnDeleteLink();
        }        

        [Then(@"a student record (.*) should not be present")]
        public void ThenAStudentRecordTadarShouldNotBePresent(string firstName)
        {
            Assert.IsFalse(_studentPage.VerifyNewlyCreatedStudentRecord(firstName));
        }

    }
}
