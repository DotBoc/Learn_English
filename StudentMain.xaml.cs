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
    /// Interaction logic for StudentMain.xaml
    /// </summary>
    public partial class StudentMain : Window
    {
        public StudentMain()
        {
            InitializeComponent();
            lb_welcome.Content = "Welcome , " + StudentLogin.student_username + " .";
        }

        private void bt_test_Click(object sender, RoutedEventArgs e)
        {
            TestSelector testSelector = new TestSelector();
            testSelector.Show();
            this.Close();
            
        }

        private void bt_study_Click(object sender, RoutedEventArgs e)
        {
            TopicSelector topicSelector = new TopicSelector();
            topicSelector.Show();
            this.Close();
        }
    }
}
