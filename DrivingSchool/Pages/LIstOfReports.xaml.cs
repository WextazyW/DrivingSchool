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
    /// Логика взаимодействия для LIstOfReports.xaml
    /// </summary>
    public partial class LIstOfReports : Page
    {
        public LIstOfReports()
        {
            InitializeComponent();
        }

        private void StudentsPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ListStudentPage());
        }

        private void GragesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new GradesPage());
        }

        private void SchedulePage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SchedulePage());
        }

        private void CarPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CarPage());
        }

        private void InstructorPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InstructorPage());
        }

        private void PaymentPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PaymentPage());
        }

        private void ResultPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ResultPage());
        }

        private void AnalysisPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AnalysisPage());
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Groups());
        }

        private void SchedulePage2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Schedule2());
        }
    }
}
