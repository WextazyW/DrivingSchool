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
using DrivingSchool.db;

namespace DrivingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
            ResultList.ItemsSource = ConnectionDB.db.Results.ToList();
            ExamsList.ItemsSource = ConnectionDB.db.Exams.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ResultList.SelectedItem != null)
            {
                Results student = ResultList.SelectedItem as Results;
                if (cmbx.Text == "Экзамен")
                {
                    student.ExamID = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Студент")
                {
                    student.StudentID = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Баллы")
                {
                    student.Score = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Результат")
                {
                    student.ResultID = Convert.ToInt32(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                ResultList.ItemsSource = ConnectionDB.db.Results.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExamResult());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Results kaktusi = ResultList.SelectedItem as Results;
            ConnectionDB.db.Results.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            ResultList.ItemsSource = ConnectionDB.db.Results.ToList();
        }
    }
}
