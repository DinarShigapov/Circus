﻿using System;
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

namespace Cashier.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.DB.Employee.FirstOrDefault(x => x.Phone == TBPhone.Text);
            if (employee == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (employee.Password != PBPassword.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            if (employee.PostId != 2)
            {
                MessageBox.Show("Это приложение доступно только для HR-Manager'a");
                return;
            }
            App.LoggedEmployee = employee;
            NavigationService.Navigate(new MainPage());
        }
    }
}
