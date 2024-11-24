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
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            CarList.ItemsSource = ConnectionDB.db.Cars.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCar());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedItem != null)
            {
                Cars student = CarList.SelectedItem as Cars;
                if (cmbx.Text == "Номер")
                {
                    student.LicensePlate = txtBox.Text; 
                }
                if (cmbx.Text == "Статус")
                {
                    student.Status = txtBox.Text;
                }
                if (cmbx.Text == "Инструктор")
                {
                    student.InstructorID = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Модель")
                {
                    student.Model = txtBox.Text;
                }
                if (cmbx.Text == "Год")
                {
                    student.Year = Convert.ToInt32(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                CarList.ItemsSource = ConnectionDB.db.Cars.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Cars kaktusi = CarList.SelectedItem as Cars;
            ConnectionDB.db.Cars.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            CarList.ItemsSource = ConnectionDB.db.Cars.ToList();
        }
    }
}
