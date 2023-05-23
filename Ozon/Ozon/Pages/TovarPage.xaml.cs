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
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        public TovarPage()
        {
            InitializeComponent();
            UpdateOzon();
            LViewTovar.ItemsSource = App.Context.Tovars.ToList();
            if (App.CurrentUser.RoleId == 1)
            {
                BtnAddTovar.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAddTovar.Visibility = Visibility.Collapsed;
            }
        }
        //Метод для кнопки "Редактировать"
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentOzon = (sender as Button).DataContext as Entities.Tovar;
            NavigationService.Navigate(new AddEditPage(currentOzon));
        }
        //Метод кнопки "Удалить"
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentOzon = (sender as Button).DataContext as Entities.Tovar;

            if (MessageBox.Show($"Вы уверены, что хотите удалить товар: " + $"{currentOzon.Nazvanie}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Tovars.Remove(currentOzon);
                App.Context.SaveChanges();
                MessageBox.Show($"Товар успешно удален", "Внимание", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UpdateOzon();
            }
        }
        //Обработчик события для ComboBox, который срабатывает при выборе элевента в нем
        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOzon();
        }
        //Обработчик события для ТextBox, который срабатывает при вводе текста в него
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOzon();
        }
        //Обработчик события Loaded, которое срабатывает каждый раз, когда страница будет загружена
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOzon();
        }
        //Метод UpdateOzon, внутри которого все необходимые записи проходят условия отбора и затем выводятся в List
        private void UpdateOzon()
        {
            var ozon = App.Context.Tovars.ToList();
            if (ComboSortyBy.SelectedIndex == 0)
                ozon = ozon.OrderBy(p => p.Cena).ToList();
            else
                ozon = ozon.OrderByDescending(p => p.Cena).ToList();

            ozon = ozon.Where(p => p.Nazvanie.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewTovar.ItemsSource = ozon;
        }
        //Метод для кнопки "Сделать заказ"
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            var info = MessageBox.Show("Для оформления заказа, необходимо внести дополнительную информацию\n Желаете ее заполнить?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (info == MessageBoxResult.Yes)               
            NavigationService.Navigate(new AdditionalInformationPage());
        }

        //Переадресация на страницу "Добавить товар"
        private void BtnAddTovar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage());
        }
    }
}
