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
    /// Interaction logic for Exam.xaml
    /// </summary>
    public partial class Exam : Window
    {
        public Exam(int course_id)
        {
            InitializeComponent();
            Container.Content = new ExamQuestions(course_id);

        }       
    }
}
