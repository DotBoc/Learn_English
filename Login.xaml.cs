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

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"SERVER=37.6.228.90; DATABASE= Learn_English; USER ID = TestUser; PASSWORD = TestPassword ;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM Users WHERE username=@Username AND password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);                
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    String rolequery = "SELECT usertype FROM Users WHERE username=@Username AND password=@Password";
                    SqlCommand rolesqlCmd = new SqlCommand(rolequery, sqlCon);
                    rolesqlCmd.CommandType = CommandType.Text;
                    rolesqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    rolesqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    SqlDataReader reader = rolesqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var roleString = reader.GetString(0);
                        if (roleString == "student")
                        {
                            StudentMain studentMain = new StudentMain();
                            studentMain.Show();
                            this.Close();
                            break;
                        }
                        if (roleString == "teacher")
                        {
                            TeacherMain teacherMain = new TeacherMain();
                            teacherMain.Show();
                            this.Close();
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Error in database. Please contact the admin.");
                        }
                    }                      
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
                sqlCon.Close();
            }
        }

    }
}
