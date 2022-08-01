using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagementUITestAutomation.SetUp;
using OpenQA.Selenium;

namespace CourseManagementUITestAutomation.Pages
{
    public class StudentPage
    {
        IWebDriver _driver;
        public StudentPage(IWebDriver driver)
        {
            _driver = driver;                
        }

        By createNewLink = By.XPath("//a[text()='Create New']");
        //By createNewLink = By.XPath("/html/body/div[2]/p/a");
        By studentTable = By.XPath("//table[@class='table']");
        By studentTableRow = By.TagName("tr");
        By editBtn = By.CssSelector("a[href*='Edit']");
        By deleteBtn = By.CssSelector("a[href*='Delete']");
            

        public StudentFormPage ClickOnCreateNewLink()
        {
            _driver.Click(createNewLink);
            return new StudentFormPage(_driver);
        }

        public string GetStudentPageUrl()
        {            
            return _driver.GetUrl();
        }

        public bool VerifyNewlyCreatedStudentRecord(string firstName)
        {            
            IList<IWebElement> studentTableDataRows = _driver.FindElement(studentTable).FindElements(studentTableRow);    
            IWebElement studentRecordExist = studentTableDataRows.FirstOrDefault(x => x.Text.Contains(firstName));        
            return (studentRecordExist != null);
        }

        public void ClickOnEditButton()
        {            
            _driver.RefreshWindow();
            _driver.FocusAndClick(editBtn);
        }

        public void ClickOnDeleteLink()
        {
            _driver.RefreshWindow();
            _driver.FocusAndClick(deleteBtn);
        }

        //public void ClickOnEditButton(string firstName)
        //{
        //    _driver.RefreshWindow();
        //    IList<IWebElement> studentTableDataRows = _driver.FindElement(studentTable).FindElements(studentTableRow); IWebElement studentRecordExist = studentTableDataRows.FirstOrDefault(x => x.Text.Contains(firstName));
        //    if (studentRecordExist.Text.Contains(firstName))
        //    {
        //        var recordList = studentRecordExist.FindElements(By.TagName("td"));
        //        foreach (var item in recordList)
        //        {
        //            if (item.Text.Contains("Edit"))
        //            {
        //                var newRecords = item.FindElements(By.TagName("td"));
        //                foreach (var record in newRecords)
        //                {
        //                    if (record.Text.Equals("Edit"))
        //                    {
        //                        record.Click();
        //                    }
        //                }                        
        //            }
        //        }
        //    }
        //}
    }
}
