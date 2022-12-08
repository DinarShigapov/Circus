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
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        public ItemsPage()
        {
            InitializeComponent();
            LVItems.ItemsSource = App.DB.Item.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ItemPage(new Item()));
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = LVItems.SelectedItem as Item;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            NavigationService.Navigate(new ItemPage(selectedItem));
        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = LVItems.SelectedItem as Animal;
            if (selectedAnimal == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            App.DB.Animal.Remove(selectedAnimal);
            App.DB.SaveChanges();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(TBSearch.Text))
            {
                LVItems.ItemsSource = App.DB.Item.ToList();
            }
            else
            {
                LVItems.ItemsSource = App.DB.Item.Where(a => a.Name.ToLower().Contains(TBSearch.Text.ToLower())
                || a.ItemType.Name.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            }
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BIssue_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = LVItems.SelectedItem as Item;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            NavigationService.Navigate(new ItemEmployeePage(selectedItem));
        }
    }
}
