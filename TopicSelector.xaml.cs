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
    /// Interaction logic for TopicSelector.xaml
    /// </summary>
    public partial class TopicSelector : Window
    {
        public int course_id;

        public TopicSelector()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string combo_box_query = "SELECT * from Courses";
            LoadGrid loadComboBox = new LoadGrid(combo_box_query);
            cb_course.ItemsSource = loadComboBox.FillGrid().DefaultView;
        }

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            course_id = Convert.ToInt32(cb_course.SelectedValue);

            Study study = new Study(course_id);
            study.Show();
            this.Close();

        }

            private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            StudentMain studentMain = new StudentMain();
            studentMain.Show();
            this.Close();
        }
    }
}
