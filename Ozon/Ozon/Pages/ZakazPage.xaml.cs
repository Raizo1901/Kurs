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
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {
        public Entities.Tovar _currentTovar = null;
        public ZakazPage()
        {
            InitializeComponent();
            CBoxTovar.ItemsSource = App.Context.Tovars.Select(c => c.Nazvanie).ToList();
        }
        //Метод, в котором указаны условия для проверки введенных данных, при добавлении информации в товар
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(CBoxTovar.Text)) errorBuilder.AppendLine("Поле Товар обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(TBoxQuantity.Text)) errorBuilder.AppendLine("Поле Количество обязателен к заполнению;");

            if (string.IsNullOrWhiteSpace(CBoxPoint.Text)) errorBuilder.AppendLine("Поле Точка выдачи обязателен к заполнению;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
        int id_point = 0;
        //Метод для кнопки "Заказать"
        private void BtnZakaz_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на наличие ошибок
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (_currentTovar == null)
                {
                    switch (CBoxPoint.Text)
                    {
                        case "Г.Вологда,Ул.Мира,Д.38":
                            id_point = 1;
                            break;
                        case "Г.Вологда,Ул.Герцена,Д.27":
                            id_point = 2;
                            break;
                        case "Г.Вологда,Ул.Кирова,Д.21":
                            id_point = 3;
                            break;
                        case "Г.Вологда,Ул.Челюскинцев,Д.47":
                            id_point = 4;
                            break;
                        case "Г.Вологда,Ул.Ветошкина,Д.54":
                            id_point = 5;
                            break;
                    }
                    try
                    {
                        //Занесение информации в Базу Данных, в таблицу "Zakaz"
                        var buyer = App.Context.Buyers.OrderByDescending(p => p.Id_buyer).FirstOrDefault();
                        var idTovar = App.Context.Tovars.Where(c => c.Nazvanie == CBoxTovar.Text).Select(c => c.Id_tovar).FirstOrDefault();
                        var zakaz = new Entities.Zakaz
                        {
                            Id_buyer = buyer.Id_buyer,
                            Id_sotrydnik = 6,
                            Date = DateTime.Today,
                            Status = "Принят",
                            Id_tovar = idTovar,
                            Id_point_of_issue = id_point,
                            Quantity = Convert.ToInt32(TBoxQuantity.Text),
                        };
                        App.Context.Zakazs.Add(zakaz);
                        App.Context.SaveChanges();
                        var navigate = MessageBox.Show("Заказ успешно оформлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (navigate == MessageBoxResult.OK)
                            NavigationService.Navigate(new TovarPage());
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
}
