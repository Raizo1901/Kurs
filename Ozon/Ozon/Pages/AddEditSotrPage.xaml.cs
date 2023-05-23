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
    /// Логика взаимодействия для AddEditSotrPage.xaml
    /// </summary>
    public partial class AddEditSotrPage : Page
    {
        private Entities.Sotrydnik _currentSotr = null;
        private byte[] _mainImageData;
        public AddEditSotrPage()
        {
            InitializeComponent();
            CBDoljnost.ItemsSource = App.Context.Doljnosts.Select(c => c.Name).ToList();
        }
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxF.Text))
                errorBuilder.AppendLine("Фамилия сотрудника обязательно для заполнения;");

            if (string.IsNullOrWhiteSpace(TBoxI.Text))
                errorBuilder.AppendLine("Имя сотрудника обязательно для заполнения;");

            if (string.IsNullOrWhiteSpace(TBoxO.Text))
                errorBuilder.AppendLine("Отчество сотрудника обязательно для заполнения;");

            if (string.IsNullOrWhiteSpace(CBDoljnost.Text))
                errorBuilder.AppendLine("Должность сотрудника обязательно для заполнения;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки: \n");

            return errorBuilder.ToString();
        }

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
                    //Добавление сотрудника
                    if (_currentSotr == null)
                    {
                        int Salary_per_hours = 0;
                        switch (CBDoljnost.Text)
                        {
                            case "Компоновщик":
                                Salary_per_hours = 170;
                                break;
                            case "Администратор":
                                Salary_per_hours = 200;
                                break;
                            case "Оператор":
                                Salary_per_hours = 190;
                                break;
                            case "Консультант":
                                Salary_per_hours = 150;
                                break;
                        }
                        //Занесение в базу данных в таблицу "Sotrydnik"
                        var idSotr = App.Context.Doljnosts.Where(c => c.Name == CBDoljnost.Text).Select(c => c.Id_doljnosti).FirstOrDefault();
                        var ozon = new Entities.Sotrydnik
                        {
                            Familia = TBoxF.Text,
                            Ima = TBoxI.Text,
                            Otchestvo = TBoxO.Text,
                            Id_doljnosti = idSotr,
                            Salary_per_hour = Salary_per_hours,
                            Image = _mainImageData
                        };
                        App.Context.Sotrydniks.Add(ozon);
                        App.Context.SaveChanges();
                        MessageBox.Show("Сотрудник успешно добавленна!");
                        NavigationService.Navigate(new SotrPage());
                    }         
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageSotr.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_mainImageData);
            }
            else
            {
                MessageBox.Show("Данная фотография недоступна, выберите другую");
            }
        }
        //Обработчик события для TextBox, которое разрешает вводить только буквы
        private void TBoxF_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }

        private void TBoxI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }

        private void TBoxO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!Char.IsPunctuation(e.Text, 0)))
                return;
            else
                e.Handled = true;
        }
    }
}
