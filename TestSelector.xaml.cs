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
    /// Interaction logic for TestSelector.xaml
    /// </summary>
    public partial class TestSelector : Window
    {
        public int course_id;

        public TestSelector()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string grid_query = "SELECT student_course_fk_course_id , student_course_grade FROM Student_Course WHERE student_course_fk_student_uid =" + StudentLogin.student_uid;
            LoadGrid loadGrid = new LoadGrid(grid_query);
            dtgrd_student_course.DataContext = loadGrid.FillGrid();
            try
            {
                dtgrd_student_course.Columns[0].Header = "Course Code";
                dtgrd_student_course.Columns[1].Header = "Grade";
                string combo_box_query = "SELECT * from Courses";
                LoadGrid loadComboBox = new LoadGrid(combo_box_query);
                cb_test.ItemsSource = loadComboBox.FillGrid().DefaultView;
            }                
            //https://blogs.msdn.microsoft.com/jaimer/2009/01/20/styling-microsofts-wpf-datagrid/ * 

            catch (ArgumentOutOfRangeException example)
            {
                MessageBox.Show("Please complete a course before doing the test.");
            }

                   
        }

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            course_id = Convert.ToInt32(cb_test.SelectedValue);

            ConnectionString connectionString = new ConnectionString();
            int check = Convert.ToInt32(connectionString.returnconnection_string("SELECT COUNT(1) FROM Student_Course WHERE student_course_fk_student_uid= "+ StudentLogin.student_uid + " AND student_course_fk_course_id="+ course_id));
            if(check == 1)
            {
                Exam exam = new Exam(course_id);
                exam.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete the course before doing the test.");
            }
            
            
            //https://stackoverflow.com/questions/2749842/how-to-bind-combobox-with-datatable
        }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            StudentMain studentMain = new StudentMain();
            studentMain.Show();
            this.Close();
        }

       
    }
}

