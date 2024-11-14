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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleList.ItemsSource = ConnectionDB.db.Schedule.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSchedulePage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ScheduleList.SelectedItem != null)
            {
                Schedule schedule = ScheduleList.SelectedItem as Schedule;
                if (cmbx.Text == "Студент")
                {
                    schedule.StudentID = int.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Инструктор")
                {
                    schedule.InstructorID = int.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Начало")
                {
                    schedule.StartTime = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Конец")
                {
                    schedule.StartTime = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Результат")
                {
                    schedule.Status = txtBox.Text;
                }
                ConnectionDB.db.SaveChanges();
                ScheduleList.ItemsSource = ConnectionDB.db.Schedule.ToList();
            }
        }
    }
}
