using HR_Manager.Model;
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

namespace HR_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage(new Employee() { Birthday = DateTime.Now.Date }));
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = LVEmployees.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            NavigationService.Navigate(new EmployeePage(selectedEmployee));

        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(TBSearch.Text))
            {
                LVEmployees.ItemsSource = App.DB.Employee.ToList();
            }
            else
            {
                LVEmployees.ItemsSource = App.DB.Employee.Where(a => a.Salary.ToString().Contains(TBSearch.Text.ToLower())).ToList();
            }

        }
    }
}
