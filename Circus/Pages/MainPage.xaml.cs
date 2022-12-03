﻿using Circus.Model.ModelEnums;
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

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.LoggedEmployee.PostId == (int)CircusPosts.HR)
            {
                BEmployeeManagement.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new EmployeesPage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Trainer)
            {
                BAnimalManagement.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new AnimalsPage());
            }
            if (App.LoggedEmployee.PostId == (int)CircusPosts.Director)
            {
                BEmployeeManagement.Visibility = Visibility.Visible;
                BAnimalManagement.Visibility = Visibility.Visible;
                MenuFrame.Navigate(new AnimalsPage());
            }

        }

        private void BAnimalManagement_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new AnimalsPage());
        }

        private void BEmployeeManagement_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new EmployeesPage());

        }

    }
}
