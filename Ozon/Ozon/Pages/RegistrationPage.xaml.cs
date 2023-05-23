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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private Entities.User _currentUser = null;
        public RegistrationPage()
        {
            InitializeComponent();
        }
        public RegistrationPage(Entities.User user1)
        {
            InitializeComponent();
            _currentUser = user1;
            TBoxLogin.Text = _currentUser.Login;
        }
        //Метод, в котором указаны условия для проверки введенных данных, при добавлении информации в регистрации
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxLogin.Text)) errorBuilder.AppendLine("Поле Логин обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(PBoxPassword1.Password)) errorBuilder.AppendLine("Поле Пароль обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(PBoxPassword2.Password)) errorBuilder.AppendLine("Поле Повторите Пароль обязателен к заполнению;");

            var userFromDB = App.Context.Users.ToList().FirstOrDefault(p => p.Login.ToLower() == TBoxLogin.Text.ToLower());
            if (_currentUser != userFromDB && userFromDB != null)
            {
                errorBuilder.AppendLine("Такой пользователь уже есть в базе данных");
            }

            if (PBoxPassword1.Password.Length < 5 && PBoxPassword2.Password.Length < 5)
            {
                errorBuilder.AppendLine("Слишком короткий пароль, введите хотя бы 6 символов");
            }

            if (PBoxPassword1.Password != PBoxPassword2.Password)
            {
                errorBuilder.AppendLine("Пароли не совпадают");
            }

            bool en = true;
            bool symbol = false;
            bool number = false;

            for (int i = 0; i < PBoxPassword1.Password.Length; i++)
            {
                if (PBoxPassword1.Password[i] >= 'А' && PBoxPassword1.Password[i] <= 'Я') en = false;
                if (PBoxPassword1.Password[i] >= '0' && PBoxPassword1.Password[i] <= '9') number = true;
                if (PBoxPassword1.Password[i] == '_' || PBoxPassword1.Password[i] == '-' || PBoxPassword1.Password[i] == '!' || PBoxPassword1.Password[i] == '@') symbol = true;
            }
            if (!en)
            {
                errorBuilder.AppendLine("Доступна только английская раскладка");
            }
            else if (!symbol)
            {
                errorBuilder.AppendLine("Добавьте один из следующих символов: _ - ! @");
            }
            else if (!number)
            {
                errorBuilder.AppendLine("Добавьте хотя бы одну цифру");
            }

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
        //Метод для кнопки "Зарегистрироваться"
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на наличие ошибок
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    //Занесение информации в Базу Данных в таблицу "User"
                    if (_currentUser == null)
                    {
                        var user = new Entities.User
                        {
                            Login = TBoxLogin.Text,
                            Password = PBoxPassword1.Password,
                            RoleId = 2,
                        };
                        App.Context.Users.Add(user);
                        App.Context.SaveChanges();
                        MessageBox.Show("Вы успешно зарегестрировались!");
                    }
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}
