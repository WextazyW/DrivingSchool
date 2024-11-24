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
    public partial class Schedule2 : Page
    {
        public Schedule2()
        {
            InitializeComponent();
            Schedule2List.ItemsSource = ConnectionDB.db.Schedule2C.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSchedule2());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Schedule2List.SelectedItem != null)
            {
                Schedule2C schedule = Schedule2List.SelectedItem as Schedule2C;
                if (cmbx.Text == "Студент")
                {
                    schedule.studentId = int.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Инструктор")
                {
                    schedule.teacherId = int.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Начало")
                {
                    schedule.StartTime = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Конец")
                {
                    schedule.StartTime = DateTime.Parse(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                Schedule2List.ItemsSource = ConnectionDB.db.Schedule2C.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Schedule2C kaktusi = Schedule2List.SelectedItem as Schedule2C;
            ConnectionDB.db.Schedule2C.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            Schedule2List.ItemsSource = ConnectionDB.db.Schedule2C.ToList();
        }
    }
}
