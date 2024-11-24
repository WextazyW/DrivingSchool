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
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        public Groups()
        {
            InitializeComponent();
            StudentGroupList.ItemsSource = ConnectionDB.db.StudentsGroups.ToList();
            GroupList.ItemsSource = ConnectionDB.db.Groups.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGroup());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (StudentGroupList.SelectedItem != null)
            {
                StudentsGroups student = StudentGroupList.SelectedItem as StudentsGroups;
                if (cmbx.Text == "Студент")
                {
                    student.StudentId = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Группа")
                {
                    student.GroupId = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Дата начала")
                {
                    student.StartDate = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Дата окончания")
                {
                    student.EndDate = DateTime.Parse(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                StudentGroupList.ItemsSource = ConnectionDB.db.StudentsGroups.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            StudentsGroups kaktusi = StudentGroupList.SelectedItem as StudentsGroups;
            ConnectionDB.db.StudentsGroups.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            StudentGroupList.ItemsSource = ConnectionDB.db.StudentsGroups.ToList();
        }
    }
}