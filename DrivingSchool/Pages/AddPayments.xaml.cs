using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
using DocumentFormat.OpenXml.Wordprocessing;
using DrivingSchool.db;

namespace DrivingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPayments.xaml
    /// </summary>
    public partial class AddPayments : Page
    {
        public AddPayments()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentId = txtStudentId.Text;
            string amount = txtAmount.Text;
            string date = txtDate.Text;
            string metod = txtMetod.Text;
            string discount = txtDiscount.Text;
            string category = txtCategory.Text;

            var payment = ConnectionDB.db.Payments.AsEnumerable().FirstOrDefault(s =>
                s.StudentID.ToString() == studentId
                && s.Amount.ToString() == amount
                && s.PaymentDate.ToString() == date
                && s.PaymentMethod.ToString() == metod
                && s.Discount.ToString() == discount
                && s.Category.ToString() == category
            );

            var tempPayment = new Payments
            {
                StudentID = Convert.ToInt32(studentId),
                Amount = Convert.ToInt32(amount),
                PaymentDate = DateTime.Parse(date),
                PaymentMethod = metod,
                Discount = Convert.ToInt32(discount),
                Category = Convert.ToInt32(category)
            };
            ConnectionDB.db.Payments.Add(tempPayment);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлена платежка");
            NavigationService.GoBack();
            return;
        }
    }
}
