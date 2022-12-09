﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cashier.Model;

namespace Cashier
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
