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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for ExamQuestions.xaml
    /// </summary>
    public partial class ExamQuestions : UserControl
    {
        int question_key = 0;
        string next_question_number;
        float total_questions = 0;
        int current_course_id;
        string correct_answer;
        string selected_answer;
        float current_score=0;
        



        public ExamQuestions(int course_id)
        {
            InitializeComponent();
            load_page(course_id);
        }
        
        ConnectionString connect = new ConnectionString();

        public void load_page(int course_id)
        {
            total_questions++;
            current_course_id = course_id;
            question_key = Convert.ToInt32(connect.returnconnection_string("SELECT min(question_id) FROM Questions WHERE question_fk_course ="+ course_id +" AND question_id > "+ question_key));            
            lbl_course_name.Content = connect.returnconnection_string("SELECT course_name FROM Courses WHERE course_id =" + course_id);
            lbl_question_title.Content = connect.returnconnection_string("SELECT question_title FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);
            rbt_answer_a.Content = connect.returnconnection_string("SELECT question_a FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);
            rbt_answer_b.Content = connect.returnconnection_string("SELECT question_b FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);
            rbt_answer_c.Content = connect.returnconnection_string("SELECT question_c FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);
            rbt_answer_d.Content = connect.returnconnection_string("SELECT question_d FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);
            correct_answer = connect.returnconnection_string("SELECT question_correct FROM Questions WHERE question_fk_course =" + course_id + " AND question_id = " + question_key);                     
        }

        private void bt_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbt_answer_a.IsChecked == true)
                {
                    selected_answer = Convert.ToString(rbt_answer_a.Content);
                }
                else if (rbt_answer_b.IsChecked == true)
                {
                    selected_answer = Convert.ToString(rbt_answer_b.Content);
                }
                else if (rbt_answer_c.IsChecked == true)
                {
                    selected_answer = Convert.ToString(rbt_answer_c.Content);
                }
                else if (rbt_answer_d.IsChecked == true)
                {
                    selected_answer = Convert.ToString(rbt_answer_d.Content);
                }
                

                if (selected_answer.Equals(correct_answer))
                {
                    current_score++;
                    lbl_score.Content = "Score : " + Convert.ToString(current_score);
                }


                next_question_number = connect.returnconnection_string("SELECT min(question_id) FROM Questions WHERE question_fk_course =" + current_course_id + " AND question_id > " + question_key);
                if (next_question_number.Equals(""))
                {
                    AnswerProvider answer = new AnswerProvider();
                    answer.student_results_fk_student = StudentLogin.student_uid;
                    answer.student_results_fk_question = question_key;
                    answer.student_results_selected_answer = selected_answer;
                    answer.student_results_date = System.DateTime.Now;

                    AnswerHandler answerHandler = new AnswerHandler();
                    string user_message = answerHandler.insert_answer(answer);

                    ScoreProvider score = new ScoreProvider();
                    score.student_course_fk_student_uid = StudentLogin.student_uid;
                    score.student_course_fk_course_id = current_course_id;
                    score.student_course_grade = Convert.ToDecimal(current_score / total_questions);

                    ScoreHandler scoreHandler = new ScoreHandler();
                    string use_message = scoreHandler.insert_score(score);

                    MessageBox.Show(user_message);
                    MessageBox.Show("Exam is over. Please wait.");

                    TestSelector testSelector = new TestSelector();
                    testSelector.Show();
                    
                }
                else
                {
                    AnswerProvider answer = new AnswerProvider();
                    answer.student_results_fk_student = StudentLogin.student_uid;
                    answer.student_results_fk_question = question_key;
                    answer.student_results_selected_answer = selected_answer;
                    answer.student_results_date = System.DateTime.Now;                    

                    AnswerHandler answerHandler = new AnswerHandler();
                    string user_message = answerHandler.insert_answer(answer);
                    MessageBox.Show(user_message);

                    load_page(current_course_id);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select an answer.");
            }


        }
    }
}
