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
    class AnswerHandler
    {
        public string insert_answer(AnswerProvider answer)
        {
            string user_message;
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                SqlCommand sqlCmd = new SqlCommand("[answered_question]", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@student_results_fk_student", SqlDbType.Int).Value = answer.student_results_fk_student;
                sqlCmd.Parameters.Add("@student_results_fk_question", SqlDbType.Int).Value = answer.student_results_fk_question;
                sqlCmd.Parameters.Add("@student_results_selected_answer", SqlDbType.NVarChar, 200).Value = answer.student_results_selected_answer;
                sqlCmd.Parameters.Add("@student_results_date", SqlDbType.DateTime).Value = answer.student_results_date;

                sqlConnection.Open();
                sqlCmd.ExecuteNonQuery();
                return user_message = "Answer Submitted!";


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
