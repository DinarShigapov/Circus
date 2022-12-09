using System.Windows;
using Clown.Model;

namespace Clown
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Shigapov326CircusEntities DB = new Shigapov326CircusEntities();
        public static Employee LoggedEmployee;
    }
}
