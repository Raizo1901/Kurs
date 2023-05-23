using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Entities.Tovar _currentTovar = null;
        private byte[] _mainImageData;

        public AddEditPage()
        {
            InitializeComponent();
        }
        //Метод редактривания товара
        public AddEditPage(Entities.Tovar ozon)
        {
            InitializeComponent();

            _currentTovar = ozon;
            Title = "Редактировать";
            TBoxNazvanie.Text = _currentTovar.Nazvanie;
            TBoxCena.Text = _currentTovar.Cena.ToString("N2");
            if (_currentTovar.Image != null)
                ImageTovar.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_currentTovar.Image);
        }
        //Метод, в котором указаны условия для проверки введенных данных, при добавлении/редактировании информации о товарах
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxNazvanie.Text))
                errorBuilder.AppendLine("Название товара обязательно для заполнения;");

            var serviceFromDB = App.Context.Tovars.ToList()
                .FirstOrDefault(p => p.Nazvanie.ToLower() == TBoxNazvanie.Text.ToLower());
            if (serviceFromDB != null && serviceFromDB != _currentTovar)
                errorBuilder.AppendLine("Такой товар уже есть в базе данных;");

            decimal cena = 0;
            if (decimal.TryParse(TBoxCena.Text, out cena) == false || cena <= 0)
                errorBuilder.AppendLine("Стоимость товара должна быть положительным числом;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки: \n");

            return errorBuilder.ToString();

        }
        //Метод кнопки "Выбрать фотографию" 
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageTovar.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_mainImageData);
            }
            else
            {
                MessageBox.Show("Данная фотография недоступна, выберите другую");
            }
        }
        //Метод кнопки "Сохранить" 
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на наличие ошибок
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {


                    //Добавление товара
                    if (_currentTovar == null)
                    {
                        //Занесение в базу данных в таблицу "Tovar"
                        var ozon = new Entities.Tovar
                        {
                            Nazvanie = TBoxNazvanie.Text,
                            Cena = decimal.Parse(TBoxCena.Text),
                            Image = _mainImageData
                        };
                        App.Context.Tovars.Add(ozon);
                        App.Context.SaveChanges();
                        MessageBox.Show("Запись успешно добавленна!");
                    }
                    else
                    {
                        //Изменение товара из таблицы "Tovar"
                        _currentTovar.Nazvanie = TBoxNazvanie.Text;
                        _currentTovar.Cena = decimal.Parse(TBoxCena.Text);
                        if (_mainImageData != null)
                            _currentTovar.Image = _mainImageData;
                        App.Context.SaveChanges();
                        MessageBox.Show("Запись успешно редактированна!");
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
