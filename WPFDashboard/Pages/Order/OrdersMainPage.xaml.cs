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
using WPFDashboard.Model;

namespace WPFDashboard.Pages.Order
{
    /// <summary>
    /// Логика взаимодействия для OrdersMainPage.xaml
    /// </summary>
    public partial class OrdersMainPage : Page
    {
        public OrdersMainPage()
        {
            InitializeComponent();
        }

        private void DescClick(object sender, RoutedEventArgs e)
        {
            var item = DGrid.SelectedItem as Заявки;
            MessageBox.Show(item.Описание,"Описание");
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new ThisOrderPage(DGrid.SelectedItem as Заявки));
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = crbEntities.GetContext().Заявки.OrderByDescending(q=>q.Код).ToList();
        }
    }
}
