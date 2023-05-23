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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        //Переадресация на страницу "Регистрация"
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
        //Метод для кнопки "Войти"
        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на наличие пользователя в Базе Данных

            var currentUser = App.Context.Users.FirstOrDefault(p => p.Login == TBoxLogin.Text && p.Password == PBoxPassword.Password);
            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                NavigationService.Navigate(new NavigatePage());
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (currentUser.RoleId == 2)
            {
                NavigationService.Navigate(new TovarPage());
            }
        }
    }
}
