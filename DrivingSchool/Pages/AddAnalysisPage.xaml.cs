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
    /// Логика взаимодействия для AddAnalysisPage.xaml
    /// </summary>
    public partial class AddAnalysisPage : Page
    {
        public AddAnalysisPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tip = txtTip.Text;
            string name = txtName.Text;
            string count = txtCount.Text;

            var res = ConnectionDB.db.ResourceUtilization.AsEnumerable().FirstOrDefault(s =>
                s.ResourceType.ToString() == tip
                && s.ResourceName.ToString() == name
                && s.NumberOfSessions.ToString() == count
            );

            var tempRes = new ResourceUtilization()
            {
                ResourceType = tip,
                ResourceName = name,
                NumberOfSessions = Convert.ToInt32(count)
            };
            ConnectionDB.db.ResourceUtilization.Add(tempRes);
            ConnectionDB.db.SaveChanges();
            MessageBox.Show("Добавлен анализ");
            NavigationService.GoBack();
            return;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
