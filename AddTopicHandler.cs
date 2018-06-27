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
    class AddTopicHandler
    {
        public string insert_Topic(TopicProvider topic)
        {
            string user_message;
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                SqlCommand sqlCmd = new SqlCommand("[insert_topic]", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@topic_title", SqlDbType.NVarChar).Value = topic.topic_title;
                sqlCmd.Parameters.Add("@topic_text", SqlDbType.NVarChar).Value = topic.topic_text;
                sqlCmd.Parameters.Add("@topic_date", SqlDbType.DateTime).Value = topic.topic_date;
                sqlCmd.Parameters.Add("@topic_fk_teacher", SqlDbType.Int).Value = topic.topic_fk_teacher;
                sqlCmd.Parameters.Add("@topic_fk_course", SqlDbType.Int).Value = topic.topic_fk_course;

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

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
