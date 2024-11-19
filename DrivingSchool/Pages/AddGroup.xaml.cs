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
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Page
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = txtStudentId.Text;
            string groupId = txtInstructorId.Text;
            string startDate = txtStartTime.Text;
            string endDate = txtEndTime.Text;

            var groups = ConnectionDB.db.StudentsGroups.AsEnumerable().FirstOrDefault(s =>
                s.StudentId.ToString() == studentId
                && s.GroupId.ToString() == groupId
                && s.StartDate == DateTime.Parse(startDate)
                && s.EndDate == DateTime.Parse(endDate)
            );

            var tempgroup = new StudentsGroups()
            {
                StudentId = Convert.ToInt32(studentId),
                GroupId = Convert.ToInt32(groupId),
                EndDate = DateTime.Parse(endDate),
                StartDate = DateTime.Parse(startDate)
            };
            ConnectionDB.db.StudentsGroups.Add(tempgroup);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлена группа");
            NavigationService.GoBack();
            return;
        }
    }
}
