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
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : Window
    {
        public static int teacher_uid;
        public static string teacher_username;

        public TeacherLogin()
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
                String query = "SELECT COUNT(1) FROM Teachers WHERE teacher_username=@Username AND teacher_password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    String id_query = "SELECT teacher_uid FROM Teachers WHERE teacher_username=@Username AND teacher_password=@Password";
                    SqlCommand id_sqlCmd = new SqlCommand(id_query, sqlConnection);
                    id_sqlCmd.CommandType = CommandType.Text;
                    id_sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    id_sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    teacher_uid = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    teacher_username = txtUsername.Text;
                    TeacherMain teacherMain = new TeacherMain();
                    teacherMain.Show();
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
