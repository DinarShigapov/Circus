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
        public TicketPage()
        {
            InitializeComponent();
            CBPosts.ItemsSource = App.DB.Performance.ToList();
        }

        List<TicketSale> ticketSales = new List<TicketSale>();
       
        private void BSave_Click(object sender, RoutedEventArgs e)
        {

            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(TLastName.Text) == true)
            {
                errorMessage += "Введите Фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(TFirstName.Text) == true)
            {
                errorMessage += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(TPatronymic.Text) == true)
            {
                errorMessage += "Введите Отчество\n";
            }
            if (string.IsNullOrWhiteSpace(TPhone.Text) == true)
            {
                errorMessage += "Введите Телефон\n";
            }
            if (string.IsNullOrWhiteSpace(TAmountTicket.Text) == true)
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
            contextTicket.LastNameClient = TLastName.Text;
            contextTicket.FirstNameClient = TFirstName.Text;
            contextTicket.PatronymicClient = TPatronymic.Text;
            contextTicket.PhoneClient = TPhone.Text;
            contextTicket.Performance = CBPosts.SelectedItem as Performance;
            contextTicket.TicketAmount = int.Parse(TAmountTicket.Text);


            App.DB.TicketSale.Add(contextTicket);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
