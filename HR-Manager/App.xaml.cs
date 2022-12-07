using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HR_Manager.Model;

namespace HR_Manager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Shigapov326Entities1 DB = new Shigapov326Entities1();
        public static Employee LoggedEmployee;
    }
}
