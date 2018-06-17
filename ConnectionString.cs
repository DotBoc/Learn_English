using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace Learn_English
{
    class ConnectionString
    {
        private string connection_string = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public string returnconnection_string(string query)
        {
            string returning_string;
            SqlConnection sqlConnection = new SqlConnection(connection_string);
            sqlConnection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                returning_string = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                returning_string = "";
            }
            sqlConnection.Close();

            return returning_string;
        }
    }
}
