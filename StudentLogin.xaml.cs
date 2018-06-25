using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window
    {
        public static int student_uid;
        public static string student_username;

        public StudentLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                String query = "SELECT COUNT(1) FROM Students WHERE student_username=@Username AND student_password=@Password";                
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    String id_query = "SELECT student_uid FROM Students WHERE student_username=@Username AND student_password=@Password";
                    SqlCommand id_sqlCmd = new SqlCommand(id_query, sqlConnection);
                    id_sqlCmd.CommandType = CommandType.Text;
                    id_sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    id_sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    student_uid = Convert.ToInt32(id_sqlCmd.ExecuteScalar());
                    student_username = txtUsername.Text;
                    StudentMain studentMain = new StudentMain();
                    studentMain.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Username or password is incorrect. Please contact the admin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
