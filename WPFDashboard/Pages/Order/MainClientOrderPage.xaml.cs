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
    /// Логика взаимодействия для MainClientOrderPage.xaml
    /// </summary>
    public partial class MainClientOrderPage : Page
    {
        public MainClientOrderPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = crbEntities.GetContext().Заявки.Where(q=>q.КодПерсонала==Nav.pers.Код).ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new AddNewOrderPage());
        }

       
    }
}
