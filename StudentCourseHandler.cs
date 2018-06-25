using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Learn_English
{
    class StudentCourseHandler
    {
        public string enroll_student(StudentCourseProvider studentCourseProvider)
        {
            string user_message;
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                SqlCommand sqlCmd = new SqlCommand("[enroll_student]", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@student_course_fk_student_uid", SqlDbType.Int).Value = studentCourseProvider.student_course_fk_student_uid;
                sqlCmd.Parameters.Add("@student_course_fk_course_id", SqlDbType.Int).Value = studentCourseProvider.student_course_fk_course_id;
                
                

                sqlConnection.Open();                
                sqlCmd.ExecuteNonQuery();
                return user_message = "You can now take the test for this Course!";

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return user_message = "Failure!";
            }
            finally
            {
                sqlConnection.Close();

            }
        }
    }
}
