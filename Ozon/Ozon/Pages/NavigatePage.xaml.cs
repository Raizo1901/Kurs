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

namespace Ozon.Pages
{
    /// <summary>
    /// Логика взаимодействия для NavigatePage.xaml
    /// </summary>
    public partial class NavigatePage : Page
    {
        public NavigatePage()
        {
            InitializeComponent();
            if (App.CurrentUser.RoleId == 1)
            {
                BtnAddZakaz.Visibility = Visibility.Visible;
                BtnAddSotr.Visibility = Visibility.Visible;
                BtnAddRashet.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAddZakaz.Visibility = Visibility.Collapsed;
                BtnAddSotr.Visibility = Visibility.Collapsed;
                BtnAddRashet.Visibility = Visibility.Collapsed;
            }
        }
        //Переадресация на страницу "Сотрудники"
        private void BtnAddSotr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SotrPage());
        }
        //Переадресация на страницу "Зарплата"
        private void BtnAddRashet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SalaryPage());
        }
        //Переадресация на страницу "Заказы"
        private void BtnCheckZakaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuyerPage());
        }
        //Переадресация на страницу "Товары"
        private void BtnTovar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarPage());
        }
    }
}
