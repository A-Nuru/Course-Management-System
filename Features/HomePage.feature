Feature: HomePage

Scenario: HomePage_01_Verify that all CMS modules are visible
	When Course Management System application is loaded
	Then All below modules are visible
	| Module                   |
	| Course Management System |
	| Students                 |
	| Course                   |
	| Enrollment               |
	| Instructor               |
	| Department               |
	| Teaching_Assign          |
	| Task                     |
	| Admin                    |
	| Register                 |
	| Log in                   |


Scenario: HomePage_02_Verify that all CMS modules are clickable
	When Course Management System application is loaded
	Then All modules are clickable
	| Module                   |
	| Course Management System |
	| Students                 |
	| Course                   |
	| Enrollment               |
	| Instructor               |
	| Department               |
	| Teaching_Assign          |
	| Task                     |
	| Admin                    |
	| Register                 |
	| Log in                   |	

#This is an option to the above scenarios
Scenario: HomePage_03_Verify that all CMS modules are visible and clickable
	When Course Management System application is loaded
	