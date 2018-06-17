﻿using System;
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
    /// Interaction logic for TeacherMain.xaml
    /// </summary>
    public partial class TeacherMain : Window
    {
        public TeacherMain()
        {
            InitializeComponent();
            lb_welcome.Content = "Welcome , " + TeacherLogin.teacher_username + " .";
        }

        private void bt_add_exam_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion addQuestion = new AddQuestion();
            addQuestion.Show();
            this.Close();
        }
    }
}
