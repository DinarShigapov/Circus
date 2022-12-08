using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using WH_Manager.Model;

namespace WH_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Page
    {
        Item contextItem;
        public ItemPage(Item item)
        {
            InitializeComponent();
            CBType.ItemsSource = App.DB.ItemType.ToList();
            contextItem = item;
            DataContext = contextItem;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextItem.Name) == true)
            {
                errorMessage += "Введите название\n";
            }
            if (contextItem.ItemType == null)
            {
                errorMessage += "Введите тип\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (contextItem.id == 0)
                App.DB.Item.Add(contextItem);
            App.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void BEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextItem.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextItem;
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}
