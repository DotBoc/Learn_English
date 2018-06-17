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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Learn_English.Learn_EnglishDataSet1 learn_EnglishDataSet1 = ((Learn_English.Learn_EnglishDataSet1)(this.FindResource("learn_EnglishDataSet1")));
            // Load data into the table Courses. You can modify this code as needed.
            Learn_English.Learn_EnglishDataSet1TableAdapters.CoursesTableAdapter learn_EnglishDataSet1CoursesTableAdapter = new Learn_English.Learn_EnglishDataSet1TableAdapters.CoursesTableAdapter();
            learn_EnglishDataSet1CoursesTableAdapter.Fill(learn_EnglishDataSet1.Courses);
            System.Windows.Data.CollectionViewSource coursesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("coursesViewSource1")));
            coursesViewSource1.View.MoveCurrentToFirst();
        }


        private void bt_Add_Click(object sender, RoutedEventArgs e)
        {
            QuestionProvider question = new QuestionProvider();
            question.question_title = txt_Title.Text;
            question.question_a = txt_Answer_a.Text;
            question.question_b = txt_Answer_b.Text;
            question.question_c = txt_Answer_c.Text;
            question.question_d = txt_Answer_d.Text;
            question.question_correct = txt_Answer_correct.Text;
            question.question_date = System.DateTime.Now;
            question.question_fk_teacher = TeacherLogin.teacher_uid;
            question.question_fk_course = cbox_Course.SelectedIndex + 1;

            AddQuestionHandler addQuestionHandler = new AddQuestionHandler();
            string user_message = addQuestionHandler.insert_Question(question);
            MessageBox.Show(user_message);
        }
    }
}
