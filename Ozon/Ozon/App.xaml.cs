using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ozon
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.OzonEntities Context
        { get; } = new Entities.OzonEntities();

        public static Entities.User CurrentUser = null;
        public static Entities.Buyer CurrentBuyer = null;
    }
}
