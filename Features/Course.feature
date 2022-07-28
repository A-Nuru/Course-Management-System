Feature: Course
As a Course Management System (CMS) user
I should be able to Create, Modify, View and Delete
A Course record

#Do not forget to write scenarios for Course module
#Use SQL query to cater for all Prerequisites
#Create a new Course
#Department record must exist
#Instructor record must exist


Background: 
	Given that the CMS application is loaded
	When a user clicks on Course link
#Prerequisite: Person table should have an Instructor  record (PersonId)
#Prerequisite: Department table should have a Department record (DepartmentId)
#Prerequisite: A course record Mathematics for Physical Sciences should be deleted
Scenario: Course_01_Verify that a user can create a new course record
	#Given that the CMS application is loaded
	#When a user clicks on Course link
	When a user clicks on the Create New link
	And a user fills-in CourseNumber field with 202
	And a user fills-in Title field with Mathematics for Physical Sciences
	And a user fills-in Credits field with 5
	#And a user selects Physical Sciences from the DepartmentId dropdown menu
	And a user clicks on the Create button
	#And a user clicks on Create button
	Then a new course record Mathematics for Physical Sciences must be created


#Prerequisite: Person table should have an Instructor  record (PersonId)
#Prerequisite: Department table should have a Department record (DepartmentId)
#Prerequisite: A course record Mathematics for Physical Sciences should be deleted
Scenario: Course_02_TableFormat_Verify that a user can create a new course record
	#Given that the CMS application is loaded
	#When a user clicks on Course link
	When a user clicks on the Create New link
	And a user fills-in course record form page with the data below
	| CourseNumber | Title | Credits |
	| 202 | Mathematics for Physical Sciences | 5 |
	And a user clicks on Create button
	Then a new course record Mathematics for Physical Sciences must be created


#Prerequisite: Person table should have an Instructor  record (PersonId)
#Prerequisite: Department table should have a Department record (DepartmentId)
#Prerequisite: All course records in the table below for Physical Sciences should be deleted
Scenario Outline: Course_03_Verify that multiple course records can be created
	#Given that the CMS application is loaded
	#When a user clicks on Course link
	When a user clicks on the Create New link
	And a user fills-in a new course form page with <CourseNumber>, <Title>, <Credits> fields
	And a user clicks on Create button
	Then a new Course record <ExpectedResult> must be created
	Examples: 
	| CourseNumber | Title                             | Credits | ExpectedResult                    |
	| 202          | Mathematics for Physical Sciences | 5       | Mathematics for Physical Sciences |
	| 203          | Chemistry for Physical Sciences   | 4       | Chemistry for Physical Sciences   |
	| 204          | Physics for Physical Sciences     | 4       | Physics for Physical Sciences     |

#@deleteExistingCourseRecord
Scenario Outline: Course_04_Verify that a new course record cannot be created with incorrect input data
	#Given that the CMS application is loaded
	#When a user clicks on Course link
	When a user clicks on Create New link
	And a user fills-in a new student form page with <CourseNumber>, <Title>, <Credits> fields
	And a user clicks on Create button	
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples: 
	| CourseNumber | Title                         | Credits | ExpectedErrorMessage       |
	| 205          |                               | 5       | Course title is required   |
	|              | English for Physical Sciences | 4       | Course number is required  |
	| 207          | Biology for Physical Sciences |         | Course credits is required |


#Prerequisite: Person table should have an Instructor  record (PersonId)
#Prerequisite: Department table should have a Department record (DepartmentId)
#Prerequisite: A course record Mathematics for Physical Sciences should be deleted
#Prerequisite: A course record Mathematics for Physical Sciences should be added to the Person table
Scenario: Student_05_Verify that a user can modify an existing student record
	#Given that the CMS application is loaded
	#When a user clicks on Course link
	When a user clicks on Edit link
	And a user fills-in CourseNumber field with 210
	And a user fills-in Title field with General Studies
	And a user fills-in Credits field with 2
	And a user clicks on Save button
	Then a new Student record General Studies must be created


Scenario: Student_06_Verify that a user can delete an existing student record
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Delete link
	And a user clicks on Delete button on the form page	
	Then a course record Mathematics for Physical Sciences should not be present 
