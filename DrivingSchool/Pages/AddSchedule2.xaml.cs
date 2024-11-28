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
    /// Логика взаимодействия для AddSchedule2.xaml
    /// </summary>
    public partial class AddSchedule2 : Page
    {
        public AddSchedule2()
        {
            InitializeComponent();
            var students = ConnectionDB.db.Students.ToList();
            cmbx.ItemsSource = students.Select(x => x.StudentID);
            var instructor = ConnectionDB.db.Instructors.ToList();
            cmbx1.ItemsSource = instructor.Select(x => x.InstructorID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = cmbx.Text;
            string instructorId = cmbx1.Text;
            string startDate = datePicker1.Text;
            string endDate = datePicker2.Text;

            var schedule = ConnectionDB.db.Schedule2C.AsEnumerable().FirstOrDefault(s =>
                s.studentId.ToString() == studentId
                && s.teacherId.ToString() == instructorId
                && s.StartTime == DateTime.Parse(startDate)
                && s.EndTime == DateTime.Parse(endDate)
            );

            var tempSchedule = new Schedule2C()
            {
                studentId = Convert.ToInt32(studentId),
                teacherId = Convert.ToInt32(instructorId),
                StartTime = DateTime.Parse(startDate),
                EndTime = DateTime.Parse(endDate),
            };
            ConnectionDB.db.Schedule2C.Add(tempSchedule);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлено расписание");
            NavigationService.GoBack();
            return;
        }
    }
}
