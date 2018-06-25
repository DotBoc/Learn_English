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
    /// Interaction logic for AddTopic.xaml
    /// </summary>
    public partial class AddTopic : Window
    {
        public AddTopic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Learn_English.Learn_EnglishDataSet1 learn_EnglishDataSet1 = ((Learn_English.Learn_EnglishDataSet1)(this.FindResource("learn_EnglishDataSet1")));
            // Load data into the Courses.
            Learn_English.Learn_EnglishDataSet1TableAdapters.CoursesTableAdapter learn_EnglishDataSet1CoursesTableAdapter = new Learn_English.Learn_EnglishDataSet1TableAdapters.CoursesTableAdapter();
            learn_EnglishDataSet1CoursesTableAdapter.Fill(learn_EnglishDataSet1.Courses);
            System.Windows.Data.CollectionViewSource coursesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("coursesViewSource1")));
            coursesViewSource1.View.MoveCurrentToFirst();
        }

        private void bt_Add_Click(object sender, RoutedEventArgs e)
        {
            TopicProvider topic = new TopicProvider();
            topic.topic_title = txt_Title.Text;
            topic.topic_text = txt_Content.Text;
            topic.topic_date = System.DateTime.Now;
            topic.topic_fk_teacher = TeacherLogin.teacher_uid;
            topic.topic_fk_course = cbox_Course.SelectedIndex + 1;

            AddTopicHandler addTopicHandler = new AddTopicHandler();
            string user_message = addTopicHandler.insert_Topic(topic);
            MessageBox.Show(user_message);
        }
    }
}
