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
using WSUniversalLib;

namespace Ozon.Pages
{
    /// <summary>
    /// Логика взаимодействия для SalaryPage.xaml
    /// </summary>
    public partial class SalaryPage : Page
    {
        public SalaryPage()
        {
            InitializeComponent();
            OzonsUpdate();
        }
        //Метод OzonsUpdate, внутри которого все необходимые записи проходят условия отбора и затем выводятся в List
        private void OzonsUpdate()
        {
            var ozon = App.Context.Sotrydniks.ToList();
        }
        //Метод, в котором указаны условия для проверки введенных данных, при добавлении информации
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(ComboTypeSalary.Text)) errorBuilder.AppendLine("Поле Должность обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(BoxPeriod.Text)) errorBuilder.AppendLine("Поле Часы работы обязателен к заполнению;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
        //Метод для кнопки "Расчитать"
        private void ButtRashet_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на наличие ошибок
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (int.Parse(BoxPeriod.Text) > 24)
                    MessageBox.Show("Сотрудник не может работать более 24-х часов");
                else
                {
                    var Salary_hours = App.Context.Sotrydniks.Where(p => p.Doljnost.Name == ComboTypeSalary.Text)
                    .Select(p => p.Salary_per_hour).FirstOrDefault();

                    var Salary = WSUniverasl.SalaryTime((decimal)Salary_hours, Convert.ToInt32(BoxPeriod.Text));
                    MessageBox.Show($"Зарплата за {BoxPeriod.Text} часа(-ов): {Salary:N2} рублей");
                    OzonsUpdate();
                }
            }
        }
        //Обработчик события для TextBox, которое разрешает вводить только цифры
        private void BoxPeriod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
