using CourseManagementUITestAutomation.SetUp;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementUITestAutomation.Pages
{
    public class CourseFormPage
    {
        IWebDriver _driver;

        public CourseFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By courseNumberField = By.Id("CourseId");
        By courseTitleField = By.Id("CourseName");
        By courseCreditsField = By.Id("TotalCredits");
        By departmentIdField = By.Id("DepartmentId");
        By createButton = By.CssSelector("input[type='submit']");

        //By courseNumberErrorMsg = By.Id("input[id='CourseId']");
        //By courseTitleErrorMsg = By.Id("input[id='CourseName']");
        //By courseCreditsErrorMsg = By.Id("input[id='TotalCredits']");


        public void FillInCourseNumber(string courseNumberData)
        {
            _driver.ClearAndSendKeys(courseNumberField, courseNumberData);
        }

        public void FillInCourseTitle(string courseTitleData)
        {
            _driver.ClearAndSendKeys(courseTitleField, courseTitleData);
        }

        public void FillInCourseCredits(string courseCreditData)
        {
            _driver.ClearAndSendKeys(courseCreditsField, courseCreditData);
        }

        public void SelectDepartmentIdDropDownMenu(string DepartmentIdData)
        {
            _driver.SelectOptionByText(departmentIdField, DepartmentIdData);
        }
        public CoursePage ClickOnCreateButton()
        {
            _driver.Click(createButton);
            return new CoursePage(_driver);
        }
    }
}
