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
using Trainer.Model;

namespace Trainer.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        Animal contextAnimal;

        public AnimalPage(Animal animal)
        {
            InitializeComponent();
            CBCage.ItemsSource = App.DB.Cage.ToList();
            CBType.ItemsSource = App.DB.AnimalType.ToList();
            contextAnimal = animal;
            DataContext = animal;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextAnimal.Name) == true)
            {
                errorMessage += "Введите имя\n";
            }
            if (contextAnimal.Age == 0 || contextAnimal.Age < 0)
            {
                errorMessage += "Введите корректный возраст\n";
            }
            if (contextAnimal.Cage == null)
            {
                errorMessage += "Введите клетку\n";
            }
            if (contextAnimal.AnimalType == null)
            {
                errorMessage += "Введите вид\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (contextAnimal.Id == 0)
                App.DB.Animal.Add(contextAnimal);
            App.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void BEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextAnimal.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextAnimal;
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
