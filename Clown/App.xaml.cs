using System.Windows;
using Clown.Model;

namespace Clown
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CircusEntities DB = new CircusEntities();
        public static Employee LoggedEmployee;
    }
}
