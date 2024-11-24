using DrivingSchool.db;
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

namespace DrivingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddExamResult.xaml
    /// </summary>
    public partial class AddExamResult : Page
    {
        public AddExamResult()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string exam = txtExam.Text;
            string student = txtStudent.Text;
            string score = txtScore.Text;
            string passed = txtResult.Text;

            var car = ConnectionDB.db.Results.AsEnumerable().FirstOrDefault(s =>
                s.ExamID.ToString() == exam
                && s.StudentID.ToString() == student
                && s.Score.ToString() == score
                && s.Passed.ToString() == passed
            );

            var tempResult = new Results()
            {
                ExamID = Convert.ToInt32(exam),
                StudentID = Convert.ToInt32(student),
                Score = Convert.ToInt32(score),
                Passed = Convert.ToBoolean(passed)
            };
            ConnectionDB.db.Results.Add(tempResult);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлен экзамен");
            NavigationService.GoBack();
            return;
        }
    }
}
