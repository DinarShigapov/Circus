using Circus.Model;
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
            NavigationService.Navigate(new AnimalPage(selectedAnimal));
        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
