using System;
using NUnit.Framework;

namespace CourseManagementUITestAutomation
{
    public static class EnvironmentData
    {
        public static string baseUrl { get; } = TestContext.Parameters["baseUrl"];
        public static string browser { get; } = TestContext.Parameters["browser"];
        public static string connectionString { get; } = TestContext.Parameters["connectionString"];
    }
}
