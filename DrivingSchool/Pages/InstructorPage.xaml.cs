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
    /// Логика взаимодействия для InstructorPage.xaml
    /// </summary>
    public partial class InstructorPage : Page
    {
        public InstructorPage()
        {
            InitializeComponent();
            InstructorList.ItemsSource = ConnectionDB.db.Instructors.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FeedBackPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddInstructor());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (InstructorList.SelectedItem != null)
            {
                Instructors student = InstructorList.SelectedItem as Instructors;
                if (cmbx.Text == "Фамилия")
                {
                    student.FirstName = txtBox.Text;
                }
                if (cmbx.Text == "Имя")
                {
                    student.LastName = txtBox.Text;
                }
                if (cmbx.Text == "Рейтинг")
                {
                    student.Rating = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Емайл")
                {
                    student.Email = txtBox.Text;
                }
                if (cmbx.Text == "Телефон")
                {
                    student.Phone = txtBox.Text;
                }
                ConnectionDB.db.SaveChanges();
                InstructorList.ItemsSource = ConnectionDB.db.Instructors.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Instructors kaktusi = InstructorList.SelectedItem as Instructors;
            ConnectionDB.db.Instructors.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            InstructorList.ItemsSource = ConnectionDB.db.Instructors.ToList();
        }
    }
}
