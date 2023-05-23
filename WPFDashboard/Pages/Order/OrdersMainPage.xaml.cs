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
            DatePickerStart.SelectedDate= DateTime.Now;
            DatePickerEnd.SelectedDate= DateTime.Now;
            _loaded = true; 
        }
        private bool _loaded = false;
        private List<Заявки> _list;
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
            _list = crbEntities.GetContext().Заявки.OrderByDescending(q=>q.Код).ToList();
            DGrid.ItemsSource = _list;
        }

        private void DatePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_loaded)
            {
               var list = crbEntities.GetContext().Заявки.Where(q => q.ДатаРемонта > DatePickerStart.SelectedDate
                && q.ДатаРемонта < DatePickerEnd.SelectedDate).ToList();
                DGrid.ItemsSource = list;
                int repaired = list.Where(q=>q.Результат == "Отремонтирован").Count();
                int d = list.Where(q => q.Результат == "Списан").Count();
                TextBlockResult.Text = $"За данный период найдено {list.Count} заявок";
                TextBlockRepair.Text = $"Отремонтировано:{repaired}";
                TextBlockSpisan.Text = $"Списано {d}";
            }
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            TextBlockRepair.Text = "";
            TextBlockResult.Text = "";
            TextBlockSpisan.Text = "";
            DGrid.ItemsSource = _list;
        }
    }
}
