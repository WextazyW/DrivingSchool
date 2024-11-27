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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Page
    {
        public AddCar()
        {
            InitializeComponent();
            var car = ConnectionDB.db.Cars.ToList();
            cmbx.ItemsSource = car.Select(x => x.InstructorID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nomer = txtNomer.Text;
            string status = txtStatus.Text;
            string instructorId = cmbx.Text;
            string model = txtModel.Text;
            string year = txtYear.Text;

            var car = ConnectionDB.db.Cars.AsEnumerable().FirstOrDefault(s =>
                s.LicensePlate.ToString() == nomer
                && s.Status.ToString() == status
                && s.InstructorID.ToString() == instructorId
                && s.Model.ToString() == model
                && s.Year.ToString() == year
            );

            var tempCars = new Cars()
            {
                LicensePlate = nomer,
                Status = status,
                InstructorID = Convert.ToInt32(instructorId),
                Model = model,
                Year = Convert.ToInt32(year)
            };
            ConnectionDB.db.Cars.Add(tempCars);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлена машина");
            NavigationService.GoBack();
            return;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
