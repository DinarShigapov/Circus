using Cashier.Model;
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


namespace Cashier.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        TicketSale contextTicket;
        public TicketPage(TicketSale ticketSale)
        {
            InitializeComponent();
            CBPosts.ItemsSource = App.DB.Performance.ToList();
            contextTicket = ticketSale;
            DataContext = contextTicket;
        }

        List<TicketSale> ticketSales = new List<TicketSale>();
       
        private void BSave_Click(object sender, RoutedEventArgs e)
        {

            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextTicket.LastNameClient) == true)
            {
                errorMessage += "Введите Фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(contextTicket.FirstNameClient) == true)
            {
                errorMessage += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(contextTicket.PatronymicClient) == true)
            {
                errorMessage += "Введите Отчество\n";
            }
            if (string.IsNullOrWhiteSpace(contextTicket.PhoneClient) == true)
            {
                errorMessage += "Введите Телефон\n";
            }
            if (contextTicket.TicketAmount == 0 || contextTicket.TicketAmount < 0 || contextTicket.TicketAmount == null)
            {
                errorMessage += "Введите кол-во билетов\n";
            }
            if (CBPosts.SelectedItem == null)
            {
                errorMessage += "Выберите шоу\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (contextTicket.Id == 0)
                App.DB.TicketSale.Add(contextTicket);

            App.DB.TicketSale.Add(contextTicket);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
