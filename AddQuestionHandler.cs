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
    class AddQuestionHandler
    {
        public string insert_Question (QuestionProvider question)
        {
            string user_message;
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                SqlCommand sqlCmd = new SqlCommand("[insert_question]", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@question_title", SqlDbType.NVarChar).Value = question.question_title;
                sqlCmd.Parameters.Add("@question_a", SqlDbType.NVarChar, 200).Value = question.question_a;
                sqlCmd.Parameters.Add("@question_b", SqlDbType.NVarChar, 200).Value = question.question_b;
                sqlCmd.Parameters.Add("@question_c", SqlDbType.NVarChar, 200).Value = question.question_c;
                sqlCmd.Parameters.Add("@question_d", SqlDbType.NVarChar, 200).Value = question.question_d;
                sqlCmd.Parameters.Add("@question_correct", SqlDbType.NVarChar, 200).Value = question.question_correct;
                sqlCmd.Parameters.Add("@question_date", SqlDbType.DateTime).Value = question.question_date;
                sqlCmd.Parameters.Add("@question_fk_teacher", SqlDbType.Int).Value = question.question_fk_teacher;
                sqlCmd.Parameters.Add("@question_fk_course", SqlDbType.Int).Value = question.question_fk_course;

                sqlConnection.Open();
                sqlCmd.ExecuteNonQuery();
                return user_message = "Success!";
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return user_message = "Failure";
            }
            finally
            {
                sqlConnection.Close();

            }
        }

    }
}
