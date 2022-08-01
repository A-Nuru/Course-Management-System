using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagementUITestAutomation.SetUp;
using OpenQA.Selenium;

//using CourseManagementUITestAutomation.SetUp;
//using OpenQA.Selenium;

namespace CourseManagementUITestAutomation.Pages
{
    public class CoursePage
    {
        IWebDriver _driver;
        public CoursePage(IWebDriver driver)
        {
            _driver = driver;

        }

        //By createNewLink = By.CssSelector("a[href='/CourseManagementSystem/Course/Create']");
        By createNewLink = By.XPath("//a[text()='Create New']");
        By courseTable = By.CssSelector("table[class='table']");
        By courseTableRow = By.TagName("tr");

        public CourseFormPage ClickCreateNewLink()
        {
            _driver.Click(createNewLink);
            return new CourseFormPage(_driver);
        }

        public string GetCoursePageUrl()
        {
            return _driver.GetUrl();
        }


        public bool VerifyNewlyCreatedCourseRecord(string courseTiTle)
        {
            IList<IWebElement> courseTableDataRows = _driver.FindElement(courseTable).FindElements(courseTableRow);
            IWebElement courseRecordExist = courseTableDataRows.FirstOrDefault(x => x.Text.Contains(courseTiTle));
            return (courseRecordExist != null);

        }
    }
}
