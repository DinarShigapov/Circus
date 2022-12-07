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
using Trainer.Model;

namespace Trainer.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public AnimalsPage()
        {
            InitializeComponent();
            LVAnimals.ItemsSource = App.DB.Animal.ToList();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalPage(new Animal()));
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = LVAnimals.SelectedItem as Animal;
            if (selectedAnimal == null)
            {
                MessageBox.Show("Выберите животное");
                return;
            }
            NavigationService.Navigate(new AnimalPage(selectedAnimal));
        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = LVAnimals.SelectedItem as Animal;
            if (selectedAnimal == null)
            {
                MessageBox.Show("Выберите животное");
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
                LVAnimals.ItemsSource = App.DB.Animal.ToList();
            }
            else
            {
                LVAnimals.ItemsSource = App.DB.Animal.Where(a => a.Name.ToLower().Contains(TBSearch.Text.ToLower())
                || a.AnimalType.Name.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            }
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
