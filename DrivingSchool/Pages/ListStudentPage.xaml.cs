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
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        public ListStudentPage()
        {
            InitializeComponent();
            StudentList.ItemsSource = ConnectionDB.db.Students.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StudentList.SelectedItem != null)
            {
                Students student = StudentList.SelectedItem as Students;
                if (cmbx.Text == "Фамилия")
                {
                    student.FirstName = txtBox.Text;
                }
                if (cmbx.Text == "Имя")
                {
                    student.LastName = txtBox.Text;
                }
                if (cmbx.Text == "Дата рождения")
                {
                    student.DateOfBirth = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Категория")
                {
                    student.DrivingCategory = txtBox.Text;
                }
                ConnectionDB.db.SaveChanges();
                StudentList.ItemsSource = ConnectionDB.db.Students.ToList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Students student = StudentList.SelectedItem as Students;
            ConnectionDB.db.Students.Remove(student);
            ConnectionDB.db.SaveChanges();
            StudentList.ItemsSource = ConnectionDB.db.Students.ToList();
        }
    }
}
