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
    /// Логика взаимодействия для AdditionalInformationPage.xaml
    /// </summary>
    public partial class AdditionalInformationPage : Page
    {
        public Entities.Buyer _currentBuyer = null;
        public AdditionalInformationPage()
        {
            InitializeComponent();
        }
        //Метод, в котором указаны условия для проверки введенных данных, при добавлении информации в покупатели
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxFam.Text)) errorBuilder.AppendLine("Поле Фамилия обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(TBoxIma.Text)) errorBuilder.AppendLine("Поле Имя обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(TBoxOtchestvo.Text)) errorBuilder.AppendLine("Поле Отчество обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(TBoxCity.Text)) errorBuilder.AppendLine("Поле Город обязателен к заполнению;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
        //Метод кнопки "Продолжить"
        private void BtnNext_Click(object sender, RoutedEventArgs e)
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
                    //Занесение в базу данных в таблицу "Buyer"
                    if (_currentBuyer == null)
                    {
                        var buyer1 = new Entities.Buyer
                        {
                            Familia = TBoxFam.Text,
                            Ima = TBoxIma.Text,
                            Otchestvo = TBoxOtchestvo.Text,
                            City = TBoxCity.Text,
                        };
                        App.Context.Buyers.Add(buyer1);
                        App.Context.SaveChanges();
                        NavigationService.Navigate(new ZakazPage());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        //Обработчик события для TextBox, которое разрешает вводить только буквы
        private void TBoxFam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }

        private void TBoxIma_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }

        private void TBoxOtchestvo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }

        private void TBoxCity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }
    }
}
