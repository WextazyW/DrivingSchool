﻿using DrivingSchool.db;
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
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        public ListStudentPage()
        {
            InitializeComponent();
            StudentList.ItemsSource = ConnectionDB.db.Students.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LIstOfReports());
        }
    }
}
