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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Page
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string groupid = txtGroup.Text;
            string fname = txtFName.Text;
            string lname = txtLName.Text;
            string phone = txtPhone.Text;

            var teacher = ConnectionDB.db.Teacher.AsEnumerable().FirstOrDefault(s =>
                s.GroupId.ToString() == groupid
                && s.FName.ToString() == fname
                && s.LName.ToString() == lname
                && s.Phone.ToString() == phone
            );

            var tempTeacher = new Teacher()
            {
                GroupId = Convert.ToInt32(groupid),
                FName = fname,
                LName = lname,
                Phone = phone
            };
            ConnectionDB.db.Teacher.Add(tempTeacher);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлен учитель");
            NavigationService.GoBack();
            return;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
