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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for StudyTopics.xaml
    /// </summary>
    public partial class StudyTopics : Page
    {
        int current_course_id;
        int topic_id = 0;
        string next_topic_id;

        public StudyTopics(int course_id)
        {
            InitializeComponent();
            load_page(course_id);
        }

        ConnectionString connect = new ConnectionString();

        public void load_page(int course_id)
        {
            current_course_id = course_id;
            topic_id = Convert.ToInt32(connect.returnconnection_string("SELECT min(topic_id) FROM Topics WHERE topic_fk_course =" + course_id + " AND topic_id > " + topic_id));
            lbl_course_name.Content = connect.returnconnection_string("SELECT course_name FROM Courses WHERE course_id =" + course_id);
            lbl_topic_title.Content = connect.returnconnection_string("SELECT topic_title FROM Topics WHERE topic_id = " + topic_id);
            txt_blk.Text = connect.returnconnection_string("SELECT topic_text FROM Topics WHERE topic_id = " + topic_id);
        }

        private void bt_main_Click(object sender, RoutedEventArgs e)
        {
            StudentMain studentMain = new StudentMain();
            studentMain.Show();
            
        }

        private void bt_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                next_topic_id = connect.returnconnection_string("SELECT min(topic_id) FROM Topics WHERE topic_fk_course =" + current_course_id + " AND topic_id > " + topic_id);
                if (next_topic_id.Equals(""))
                {
                    int check = Convert.ToInt32(connect.returnconnection_string("SELECT COUNT(1) FROM Student_Course WHERE student_course_fk_student_uid= " + StudentLogin.student_uid + " AND student_course_fk_course_id=" + current_course_id));
                    if (check == 0)
                    {
                        StudentCourseProvider studentCourseProvider = new StudentCourseProvider();
                        studentCourseProvider.student_course_fk_student_uid = StudentLogin.student_uid;
                        studentCourseProvider.student_course_fk_course_id = current_course_id;
                        MessageBox.Show("provider");                        

                        StudentCourseHandler studentCourseHandler = new StudentCourseHandler();
                        string user_message = studentCourseHandler.enroll_student(studentCourseProvider);
                        MessageBox.Show(user_message);
                    }                  
                    
                    TopicSelector topicSelector = new TopicSelector();
                    topicSelector.Show();
                    
                }
                else
                {
                    
                    load_page(current_course_id);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

