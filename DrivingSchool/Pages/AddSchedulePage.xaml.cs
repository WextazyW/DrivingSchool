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
    /// Логика взаимодействия для AddSchedulePage.xaml
    /// </summary>
    public partial class AddSchedulePage : Page
    {
        public AddSchedulePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = txtStudentId.Text;
            string instructorId = txtInstructorId.Text;
            string startDate = txtStartTime.Text;
            string endDate = txtEndTime.Text;
            string status = txtStatus.Text;

            var schedule = ConnectionDB.db.Schedule.AsEnumerable().FirstOrDefault(s =>
                s.StudentID.ToString() == studentId
                && s.InstructorID.ToString() == instructorId
                && s.StartTime == DateTime.Parse(startDate)
                && s.EndTime == DateTime.Parse(endDate)
                && s.Status == status
            );

            var tempSchedule = new Schedule()
            {
                StudentID = Convert.ToInt32(studentId),
                InstructorID = Convert.ToInt32(instructorId),
                StartTime = DateTime.Parse(startDate),
                EndTime = DateTime.Parse(endDate),
                Status = status 
            };
            ConnectionDB.db.Schedule.Add(tempSchedule);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлено расписание");
            NavigationService.GoBack();
            return;
        }
    }
}
