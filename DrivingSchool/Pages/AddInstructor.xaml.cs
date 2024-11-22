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
    /// Логика взаимодействия для AddInstructor.xaml
    /// </summary>
    public partial class AddInstructor : Page
    {
        public AddInstructor()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fname = txtFName.Text;
            string lname = txtLName.Text;
            string rating = txtRating.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            var instructor = ConnectionDB.db.Instructors.AsEnumerable().FirstOrDefault(s =>
                s.FirstName.ToString() == fname
                && s.LastName.ToString() == lname
                && s.Rating.ToString() == rating
                && s.Email.ToString() == email
                && s.Phone.ToString() == phone
            );

            var tempInstructor = new Instructors()
            {
                FirstName = fname,
                LastName = lname,
                Rating = Convert.ToDouble(rating),
                Email = email,
                Phone = phone
            };
            ConnectionDB.db.Instructors.Add(tempInstructor);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлен инструктор");
            NavigationService.GoBack();
            return;
        }
    }
}
