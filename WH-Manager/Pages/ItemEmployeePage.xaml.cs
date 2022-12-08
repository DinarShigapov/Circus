using Microsoft.Win32;
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
using WH_Manager.Model;

namespace WH_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для ItemEmployeePage.xaml
    /// </summary>
    public partial class ItemEmployeePage : Page
    {
        ItemEmployee contextItemEmployee;
        public ItemEmployeePage(ItemEmployee item)
        {
            InitializeComponent();
            CBEmployee.ItemsSource = App.DB.Employee.ToList();
            contextItemEmployee = item;
            DataContext = contextItemEmployee;
           
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (contextItemEmployee.Employee == null)
            {
                errorMessage += "Введите сотрудника\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (contextItemEmployee.Id == 0)
                App.DB.ItemEmployee.Add(contextItemEmployee);
            App.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
