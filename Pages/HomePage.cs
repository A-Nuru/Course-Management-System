using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CourseManagementUITestAutomation.SetUp;
using CourseManagementUITestAutomation.Model;

namespace CourseManagementUITestAutomation.Pages
{
    public class HomePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By studentLink = By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[1]/a");
        //By allModules = By.CssSelector("a[href*='CourseManagementSystem']");
        By allModules = By.XPath("//*[@href]");


        // courseLink = By.XPath("/html/body/div[2]/p/a");
        By courseLink = By.XPath("//a[text()='Course']");

        public StudentPage ClickOnStudentLink()
        {    
            _driver.Click(studentLink);
            return new StudentPage(_driver);
        }       

        public CoursePage ClickOnCourseLink()
        {
            _driver.Click(courseLink);
            return new CoursePage(_driver);
        }

        public List<string> VerifyThatAllModulesExist()
        {
            List<string> modulesText = new List<string>();
            IList<IWebElement> modules = _driver.FindElements(allModules);
            foreach (var module in modules)
            {
                if (!string.IsNullOrEmpty(module.Text))
                {
                    modulesText.Add(module.Text);
                }
            }
            return modulesText;
        }

        public bool VerifyThatAModuleIsClickable(string expectedModule, int counter)
        {
            bool newPageAppears = false;
            IList<IWebElement> modules = _driver.FindElements(allModules);

            if (expectedModule.Equals("Teaching_Assign"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains("courseinstructor");
            }
            else if (expectedModule.Equals("Log in"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains("Account/Login");
            }
            else if (expectedModule.Equals("Course Management System"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains(_driver.GetUrl());
            }
            else if (modules[counter].Text.Equals(expectedModule))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().ToLower().Contains(expectedModule.ToLower());
            }

            return newPageAppears;
        }
    }
}
