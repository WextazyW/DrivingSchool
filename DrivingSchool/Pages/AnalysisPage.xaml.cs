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
using ClosedXML.Excel;
using DrivingSchool.db;
using Wpf.Ui.Controls;
using GridView = System.Windows.Controls.GridView;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.MessageBox;

namespace DrivingSchool.Pages
{
    public partial class AnalysisPage : Page
    {
        public AnalysisPage()
        {
            InitializeComponent();
            AnalysisList.ItemsSource = ConnectionDB.db.ResourceUtilization.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }
        public void ExportToExcel(ListView listView, string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");

            var headers = listView.View as GridView;
            if (headers != null)
            {
                for (int i = 0; i < headers.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = (string)headers.Columns[i].Header;
                }
            }

            for (int i = 0; i < listView.Items.Count; i++)
            {
                var values = listView.Items[i] as ResourceUtilization;
                if (values != null)
                {
                    worksheet.Cell(i + 2, 1).Value = values.ResourceID; 
                    worksheet.Cell(i + 2, 2).Value = values.ResourceType;
                    worksheet.Cell(i + 2, 3).Value = values.ResourceName;
                    worksheet.Cell(i + 2, 4).Value = values.NumberOfSessions;
                }
            }

            workbook.SaveAs(filePath);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string filePath = "C:\\Users\\Emil\\Downloads\\Otchet.xlsx";

            ExportToExcel(AnalysisList, filePath);
            MessageBox.Show("Данные экспортированы");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAnalysisPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (AnalysisList.SelectedItem != null)
            {
                ResourceUtilization student = AnalysisList.SelectedItem as ResourceUtilization;
                if (cmbx.Text == "Тип")
                {
                    student.ResourceType = txtBox.Text;
                }
                if (cmbx.Text == "Название")
                {
                    student.ResourceName = txtBox.Text;
                }
                if (cmbx.Text == "Количество")
                {
                    student.NumberOfSessions = Convert.ToInt32(txtBox.Text);
                }
                ConnectionDB.db.SaveChanges();
                AnalysisList.ItemsSource = ConnectionDB.db.ResourceUtilization.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ResourceUtilization kaktusi = AnalysisList.SelectedItem as ResourceUtilization;
            ConnectionDB.db.ResourceUtilization.Remove(kaktusi);
            ConnectionDB.db.SaveChanges();
            AnalysisList.ItemsSource = ConnectionDB.db.ResourceUtilization.ToList();
        }
    }
}
