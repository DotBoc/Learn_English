using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Learn_English
{
    class LoadGrid
    {

       
        string query;

        public LoadGrid(string q)
        {
            this.query = q;
        }

        public DataTable FillGrid()
        {
            DataTable data_table = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            try
            {
                MessageBox.Show("Searching.");
                sqlConnection.Open();
                SqlDataReader data_reader = cmd.ExecuteReader();
                if (data_reader.HasRows)
                {
                    data_table.Load(data_reader);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("There are no data in the database.");
            }

            finally
            {
                sqlConnection.Close();
            }
            return data_table;
        }


    }
}
