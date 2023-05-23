using Ozon.Entities;
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
    /// Логика взаимодействия для BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Page
    {
        public BuyerPage()
        {
            InitializeComponent();
            ListZakaz.ItemsSource = App.Context.Zakazs.ToList();
            OzonsUpdate();
        }
        //Метод OzonsUpdate, внутри которого все необходимые записи проходят условия отбора и затем выводятся в List
        private void OzonsUpdate()
        {
            var zakazs = App.Context.Zakazs.ToList();
        }
        //Обработчик события Loaded, которое срабатывает каждый раз, когда страница будет загружена
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListZakaz.ItemsSource = App.Context.Zakazs.ToList();
            OzonsUpdate();
        }
        //Метод кнопки "Печать"
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument doc = new FlowDocument();
            doc.FontFamily = new FontFamily("Times New Roman");
            doc.FontSize = 14;
            doc.ColumnWidth = 600;
            doc.Blocks.Add(new Paragraph(new Run("Список заказов\v")));
            foreach (var items in ListZakaz.Items)
            {
                doc.Blocks.Add(new Paragraph(new Run((items as Zakaz).Print())));
            }
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() != true) return;
            doc.PageHeight = pd.PrintableAreaHeight;
            doc.PageWidth = pd.PrintableAreaWidth;
            IDocumentPaginatorSource idocument = doc as IDocumentPaginatorSource;

            pd.PrintDocument(idocument.DocumentPaginator, "Печать документа");
        }
    }
}
