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
    /// Логика взаимодействия для AddGrades.xaml
    /// </summary>
    public partial class AddGrades : Page
    {
        public AddGrades()
        {
            InitializeComponent();
            var students = ConnectionDB.db.Students.ToList();
            cmbx.ItemsSource = students.Select(x => x.StudentID);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = cmbx.Text;
            string poseshaem = txtPoseshaem.Text;
            string teoriya = txtTeoriya.Text;
            string praktika = txtPraktika.Text;

            var grades = ConnectionDB.db.Grades.AsEnumerable().FirstOrDefault(s =>
                s.StudentID.ToString() == studentId
                && s.AttendancePercentage.ToString() == poseshaem
                && s.TheoreticalExamScore.ToString() == teoriya
                && s.PracticalExamScore.ToString() == praktika
            );

            var tempGrade = new Grades()
            {
                StudentID = Convert.ToInt32(studentId),
                AttendancePercentage = Convert.ToInt32(poseshaem),
                TheoreticalExamScore = Convert.ToInt32(teoriya),
                PracticalExamScore = Convert.ToInt32(praktika)
            };
            ConnectionDB.db.Grades.Add(tempGrade);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлена успеваемость");
            NavigationService.GoBack();
            return;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
