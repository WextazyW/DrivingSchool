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
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            Students student = ConnectionDB.students;
            txtFName.Text = ConnectionDB.students.FirstName.ToString();
            txtLName.Text = ConnectionDB.students.LastName.ToString();
            txtDateBirth.Text = ConnectionDB.students.DateOfBirth.ToString();
            txtCategory.Text = ConnectionDB.students.DrivingCategory.ToString();
            NotificationList.ItemsSource = ConnectionDB.db.Notifications.Where(n => n.StudentID == student.StudentID).ToList();
        }
    }
}
