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
    /// Логика взаимодействия для SotrPage.xaml
    /// </summary>
    public partial class SotrPage : Page
    {
        public SotrPage()
        {
            InitializeComponent();
            UpdateOzon();
            LViewSotr.ItemsSource = App.Context.Sotrydniks.ToList();
        }
        private void UpdateOzon()
        {
            var ozon = App.Context.Sotrydniks.ToList();
            LViewSotr.ItemsSource = ozon;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentSotr = (sender as Button).DataContext as Entities.Sotrydnik;

            if (MessageBox.Show($"Вы уверены, что хотите удалить сотрудника: " + $"{currentSotr.Familia} {currentSotr.Ima} {currentSotr.Otchestvo}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Sotrydniks.Remove(currentSotr);
                App.Context.SaveChanges();
                MessageBox.Show($"Сотрудник успешно удален", "Внимание", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UpdateOzon();
            }
        }

        private void BtnAddSotr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditSotrPage());
            UpdateOzon();
        }
    }
}
