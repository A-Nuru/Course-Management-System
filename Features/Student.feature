Feature: Student
As a Course Management System (CMS) user
I should be able to Create, Modify, View and Delete
A Student record

Background: 
	Given that the CMS application is loaded
	When a user clicks on Students link

#Prerequisite: A student record Eric Tadar should be deleted
Scenario: Student_01_Verify that a user can create a new student record
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Create New link
	And a user fills-in FamilyName field with Tadar
	And a user fills-in FirstName field with Eric
	And a user fills-in Enrollment Date field with 04/07/2018
	And a user clicks on Create button
	Then a new Student record Eric must be created


#Prerequisite: A student record Eric Tadar should be deleted
Scenario: Student_02_TableFormat_Verify that a user can create a new student record
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Create New link
	And a user fills-in new student record form page with the data below
	| FamilyName | FirstName | EnrollmentDate |
	| Tadar      | Eric      | 04/07/2020     |	
	And a user clicks on Create button
	Then a new Student record Eric must be created

#Prerequisite: All student records in the table below should be deleted
Scenario Outline: Student_03_Verify that multiple student records can be created
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Create New link
	And a user fills-in a new student form page with <FamilyName>, <FirstName>, <EnrollmentDate> fields
	And a user clicks on Create button
	Then a new Student record <ExpectedResult> must be created
	Examples: 
	| FamilyName | FirstName | EnrollmentDate | ExpectedResult |
	| Tadar3     | Eric3     | 2019/10/10     | Tadar3         |
	| Tadar4     | Eric4     | 2019/10/10     | Tadar4         |
	| Tadar5     | Eric5     | 2019/10/10     | Tadar5         |
	| Tadar6     | Eric6     | 2019/10/10     | Tadar6         |
	| Tadar7     | Eric7     | 2019/10/10     | Tadar7         |

#@deleteExistingStudentRecord
Scenario Outline: Student_04_Verify that a new student record cannot be created with incorrect input data
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Create New link
	And a user fills-in a new student form page with <FamilyName>, <FirstName>, <EnrollmentDate> fields
	And a user clicks on Create button	
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples: 
	| FamilyName | FirstName | EnrollmentDate | ExpectedErrorMessage        |
	| Tadar8     |           | 2019/10/10     | First name is required      |
	|            | Eric9     | 2019/10/10     | Last name is required       |
	| Tadar10    | Eric10    |                | Enrollment date is required |

#Prerequisite: student records Eric Tadar should be deleted
#Prerequisite: student record Eric Tadar should be added to the Person table
Scenario: Student_05_Verify that a user can modify an existing student record
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Edit link
	And a user fills-in FamilyName field with Sutton
	And a user fills-in FirstName field with Femi
	And a user fills-in Enrollment Date field with 01/06/2019
	And a user clicks on Save button
	Then a new Student record Femi must be created

#Prerequisite: student records Eric Tadar should be deleted
#Prerequisite: student record Eric Tadar should be added to the Person table
Scenario: Student_06_Verify that a user can delete an existing student record
	#Given that the CMS application is loaded
	#When a user clicks on Students link
	When a user clicks on Delete link
	And a user clicks on Delete button on the form page	
	Then a student record Eric should not be present 
