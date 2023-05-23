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
    /// Логика взаимодействия для AddNewOrderPage.xaml
    /// </summary>
    public partial class AddNewOrderPage : Page
    {
        public AddNewOrderPage()
        {
            InitializeComponent();
            _list = crbEntities.GetContext().ЭВМ.Where(q => q.КодКабинета == Nav.pers.КодКабинета && q.Списан == false && q.Ремонт == false).ToList();
            
            evmComboBox.ItemsSource = _list;
            _order = new Заявки
            {
                Персонал = Nav.pers,           
                Дата = DateTime.Now,
            };
            DataContext= _order;
        }
        private Заявки _order;
        private List<ЭВМ> _list;
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            
            
            if (string.IsNullOrEmpty(_order.Описание) || evmComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните поле!");
                return;
            }
            crbEntities.GetContext().Заявки.Add(_order);
            var item = evmComboBox.SelectedItem as ЭВМ;
            item.Ремонт = true;
            crbEntities.GetContext().SaveChanges();
            MessageBox.Show("Заявка отправлена!");
            Nav.Back();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
