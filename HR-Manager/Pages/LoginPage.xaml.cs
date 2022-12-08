using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HR_Manager.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        
        }
        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.DB.Employee.FirstOrDefault(x => x.Phone == TBPhone.Text);
            if (employee == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (employee.Password != PBPassword.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            if (employee.PostId != 5)
            {
                MessageBox.Show("Это приложение доступно только для HR-Manager'a");
                return;
            }
            App.LoggedEmployee = employee;
            NavigationService.Navigate(new MainPage());
        }
    }
}
