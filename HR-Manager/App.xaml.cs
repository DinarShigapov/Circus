using System.Windows;
using HR_Manager.Model;

namespace HR_Manager
{
    public partial class App : Application
    {
        public static CircusEntities DB = new CircusEntities();
        public static Employee LoggedEmployee;
    }
}
