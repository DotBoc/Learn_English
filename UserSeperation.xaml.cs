using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserSeperation.xaml
    /// </summary>
    public partial class UserSeperation : Window
    {
        public UserSeperation()
        {
            InitializeComponent();
        }

        private void bt_student_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin studentLogin = new StudentLogin();
            studentLogin.Show();
            this.Close();
        }

        private void bt_teacher_Click(object sender, RoutedEventArgs e)
        {
            TeacherLogin teacherLogin = new TeacherLogin();
            teacherLogin.Show();
            this.Close();

        }
    }
}
