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
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
            PaymentList.ItemsSource = ConnectionDB.db.Payments.ToList();
            CategoryList.ItemsSource = ConnectionDB.db.DrivingCategories.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPayments());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (PaymentList.SelectedItem != null)
            {
                Payments student = PaymentList.SelectedItem as Payments;
                if (cmbx.Text == "Студент")
                {
                    student.StudentID = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Цена")
                {
                    student.Amount = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Дата")
                {
                    student.PaymentDate = DateTime.Parse(txtBox.Text);
                }
                if (cmbx.Text == "Метод")
                {
                    student.PaymentMethod = txtBox.Text;
                }
                if (cmbx.Text == "Скидка")
                {
                    student.Discount = Convert.ToInt32(txtBox.Text);
                }
                if (cmbx.Text == "Категория")
                {
                    student.Category = Convert.ToInt32(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                PaymentList.ItemsSource = ConnectionDB.db.Payments.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Payments kaktusi = PaymentList.SelectedItem as Payments;
            ConnectionDB.db.Payments.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            PaymentList.ItemsSource = ConnectionDB.db.Payments.ToList();
        }
    }
}
