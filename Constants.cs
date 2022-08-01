using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementUITestAutomation
{
    public static class Constants
    {
        public static string clearStudentRecord = @"Delete from Person where LastName like 'Tadar%' and FirstName like 'Eric%' and Discriminator = 'Student'";

        public static string clearInstructorRecord = @"Delete from Person where LastName like 'Ted%' and FirstName like 'Baker%' and Discriminator = 'Instructor'";

        public static string populateNewStudentRecord = @"Insert Into Person(LastName,FirstName,EnrollmentDate, Discriminator) Values('Tadar','Eric','2020-06-10','Student')";

        public static string clearAllStudentRecords = @"Delete from Person where Discriminator = 'Student'";

        public static string clearCourseRecordQuery = @"Delete from Course where CourseName = 'Mathematics for Physical Sciences' and CourseId = 202";

        public static string populateNewCourseRecordQuery = @"Insert Into Course(CourseId,CourseName,TotalCredits, DepartmentId) Values(202,'Mathematics for Physical Sciences',5,1005)";
    }
}
