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
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            string fName = txtlName.Text;
            string lName = txtfName.Text;
            string dateBirth = txtdateOfBirth.Text;
            string startDate = txtstartDate.Text;
            string endDate = txtendDate.Text;
            string category = txtcategory.Text;

            //var user = ConnectionDB.db.logins.FirstOrDefault(log => log.login == login && log.password == password);
            var student = ConnectionDB.db.Students.AsEnumerable().FirstOrDefault(s => 
                s.login == login 
                && s.password == password 
                && s.FirstName == fName
                && s.LastName == lName
                && s.DateOfBirth == DateTime.Parse(dateBirth)
                && s.DrivingCategory == category
            );

            var tempUser = new users() { Name = login };
            var tempLogin = new Students()
            {
                login = login,
                password = password,
                FirstName = fName,
                LastName = lName,
                DateOfBirth = Convert.ToDateTime(dateBirth),
                DrivingCategory = category,
                users = tempUser,
            };
            ConnectionDB.db.users.Add(tempUser);
            ConnectionDB.db.Students.Add(tempLogin);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            NavigationService.GoBack();
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
