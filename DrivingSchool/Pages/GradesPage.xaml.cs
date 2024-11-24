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
using DocumentFormat.OpenXml.Office.CustomXsn;
using DrivingSchool.db;
using LiveCharts.Wpf;
using LiveCharts;
using OxyPlot;
using OxyPlot.Series;
using LineSeries = OxyPlot.Series.LineSeries;

namespace DrivingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradesPage.xaml
    /// </summary>
    public partial class GradesPage : Page
    {
        public GradesPage()
        {
            InitializeComponent();
            GradesList.ItemsSource = ConnectionDB.db.Grades.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var model = new PlotModel { Title = "Scores" };
            var series = new LineSeries { Title = "dsd"};

            var grades = new List<Grades>
            {
                new Grades {TheoreticalExamScore = 20, AttendancePercentage = 55, PracticalExamScore = 35},
                new Grades {TheoreticalExamScore = 20, AttendancePercentage = 30, PracticalExamScore = 50},
                new Grades {TheoreticalExamScore = 87, AttendancePercentage = 76, PracticalExamScore = 70},
            };
            for (int i = 0; i < grades.Count; i++)
            {
                series.Points.Add(new DataPoint(i, (double)grades[i].AttendancePercentage));
                series.Points.Add(new DataPoint(i, (double)grades[i].TheoreticalExamScore));
                series.Points.Add(new DataPoint(i, (double)grades[i].PracticalExamScore));
            }

            model.Series.Add(series);
            plotView.Model = model;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGrades());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (GradesList.SelectedItem != null)
            {
                Grades student = GradesList.SelectedItem as Grades;
                if (cmbx.Text == "Студент")
                {
                    student.StudentID = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Посещаемость")
                {
                    student.AttendancePercentage = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Теория")
                {
                    student.TheoreticalExamScore = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Практика")
                {
                    student.PracticalExamScore = Convert.ToInt32(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                GradesList.ItemsSource = ConnectionDB.db.Grades.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Grades kaktusi = GradesList.SelectedItem as Grades;
            ConnectionDB.db.Grades.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            GradesList.ItemsSource = ConnectionDB.db.Grades.ToList();
        }
    }
}
