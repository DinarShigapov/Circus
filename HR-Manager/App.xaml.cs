using System.Windows;
using HR_Manager.Model;

namespace HR_Manager
{
    public partial class App : Application
    {
        public static Shigapov326CircusEntities DB = new Shigapov326CircusEntities();
        public static Employee LoggedEmployee;
    }
}
