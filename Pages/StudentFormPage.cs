using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CourseManagementUITestAutomation.SetUp;

namespace CourseManagementUITestAutomation.Pages
{
    public class StudentFormPage
    {
        IWebDriver _driver;
        public StudentFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By familyNameField = By.Id("LastName");
        By firstNameField = By.Id("FirstName");
        By enrollmentDate = By.Id("EnrollmentDate");
        By createSaveAndDeleteBtn = By.CssSelector("input[type='submit']");
        By familyNameErrorMsg = By.CssSelector("[data-valmsg-for=LastName]");
        By firstNameErrorMsg = By.CssSelector("[data-valmsg-for=FirstName]");
        By enrollmentDateErrorMsg = By.CssSelector("[data-valmsg-for=EnrollmentDate]");        
      

        public void FillInFamilyName(string familyNameData)
        {
            _driver.ClearAndSendKeys(familyNameField, familyNameData);
        }

        public void FillInFirstName(string firstNameData)
        {
            _driver.ClearAndSendKeys(firstNameField, firstNameData);
        }

        public void FillInEnrollmentDate(string enrollmentDateData)
        {
            _driver.ClearAndSendKeys(enrollmentDate, enrollmentDateData);
        }

        public StudentPage ClickOnCreateSaveOrDeleteButton()
        {
            _driver.Click(createSaveAndDeleteBtn);
            return new StudentPage(_driver);
        } 

        public string GetLastNameErrorMessage()
        {
            //IWebElement errorMsg = _driver.FindElement(familyNameErrorMsg);
            //string errorMsgText = errorMsg.Text;
            //return errorMsgText;

            return _driver.GetElementText(familyNameErrorMsg);
        }

        public string GetFirstNameErrorMessage()
        {
            return _driver.GetElementText(firstNameErrorMsg);
        }

        public string GetEnrollmentDateErrorMessage()
        {
            return _driver.GetElementText(enrollmentDateErrorMsg);
        }        
    }
}
