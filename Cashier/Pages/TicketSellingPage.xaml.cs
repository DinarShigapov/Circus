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
using Cashier.Model;

namespace Cashier.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketSellingPage.xaml
    /// </summary>
    public partial class TicketSellingPage : Page
    {
        public TicketSellingPage()
        {
            InitializeComponent();
        }

        private void BTicket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TicketPage(new TicketSale()));
        }
    }
}
