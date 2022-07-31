using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseManagementUITestAutomation.SetUp
{
    public class DatabaseHelper
    {     
        string connectionString = EnvironmentData.connectionString;

        public void ClearOrPopulateATable(string query)
        {            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
