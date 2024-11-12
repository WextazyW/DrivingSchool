﻿using DrivingSchool.db;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        static MainWindow _mainWindow;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            QRCode.Source = GenerateQrCodeBitmapImage("https://dom.mck-ktits.ru/");
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "1" && txtPassword.Password == "1")
            {
                _mainWindow.MainFrame.NavigationService.Navigate(new ListStudentPage());
            }
            else
            {
                string login = txtLogin.Text;
                string password = txtPassword.Password;

                var student = ConnectionDB.db.Students.FirstOrDefault(log => log.login == login && log.password == password);
    
                if (student == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
                ConnectionDB.students = student;
                _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage());
            }
        }
        private BitmapImage GenerateQrCodeBitmapImage(string text)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q); using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrBitmap.Save(ms, ImageFormat.Png);
                            ms.Position = 0;
                            BitmapImage bitmapImage = new BitmapImage(); bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad; bitmapImage.StreamSource = ms;
                            bitmapImage.EndInit();
                            return bitmapImage;
                        }
                    }
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new SignUpPage());
        }
    }
}