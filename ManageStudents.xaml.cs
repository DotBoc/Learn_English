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
using System.Data.SqlClient;

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for ManageStudents.xaml
    /// </summary>
    public partial class ManageStudents : Window
    {
        public ManageStudents()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Learn_English.Learn_EnglishDataSet2 learn_EnglishDataSet2 = ((Learn_English.Learn_EnglishDataSet2)(this.FindResource("learn_EnglishDataSet2")));
            // Load data into the table Students. You can modify this code as needed.
            Learn_English.Learn_EnglishDataSet2TableAdapters.StudentsTableAdapter learn_EnglishDataSet2StudentsTableAdapter = new Learn_English.Learn_EnglishDataSet2TableAdapters.StudentsTableAdapter();
            learn_EnglishDataSet2StudentsTableAdapter.Fill(learn_EnglishDataSet2.Students);
            System.Windows.Data.CollectionViewSource studentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentsViewSource")));
            studentsViewSource.View.MoveCurrentToFirst();

            dtgrd_students.Columns[0].Header = "Student ID";
            dtgrd_students.Columns[1].Header = "Username";
            dtgrd_students.Columns[2].Header = "Password";
            dtgrd_students.Columns[3].Header = "Lastname";
            dtgrd_students.Columns[4].Header = "Grade";

            dtgrd_students.IsReadOnly = false;

        }
    }
}
