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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            TeacherList.ItemsSource = ConnectionDB.db.Teacher.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacher());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TeacherList.SelectedItem != null)
            {
                Teacher student = TeacherList.SelectedItem as Teacher;
                if (cmbx.Text == "Группа")
                {
                    student.GroupId = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Фамилия")
                {
                    student.FName = txtBox.Text;
                }
                if (cmbx.Text == "Имя")
                {
                    student.LName = txtBox.Text;
                }
                if (cmbx.Text == "Телефон")
                {
                    student.Phone = txtBox.Text;
                }
                ConnectionDB.db.SaveChanges();
                TeacherList.ItemsSource = ConnectionDB.db.Teacher.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Teacher kaktusi = TeacherList.SelectedItem as Teacher;
            ConnectionDB.db.Teacher.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            TeacherList.ItemsSource = ConnectionDB.db.Teacher.ToList();
        }
    }
}
