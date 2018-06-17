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
    class ScoreHandler
    {
        public string insert_score(ScoreProvider score)
        {
            string user_message;
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                SqlCommand sqlCmd = new SqlCommand("[insert_score]", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@student_course_fk_student_uid", SqlDbType.Int).Value = score.student_course_fk_student_uid;
                sqlCmd.Parameters.Add("@student_course_fk_course_id", SqlDbType.Int).Value = score.student_course_fk_course_id;
                sqlCmd.Parameters.Add("@student_course_grade", SqlDbType.Decimal).Value = score.student_course_grade;
              

                sqlConnection.Open();
                sqlCmd.ExecuteNonQuery();
                return user_message = "Score Submitted!";


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
