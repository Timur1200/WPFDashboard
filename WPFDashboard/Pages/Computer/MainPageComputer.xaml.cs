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

namespace WPFDashboard.Pages.Computer
{
    /// <summary>
    /// Логика взаимодействия для MainPageComputer.xaml
    /// </summary>
    public partial class MainPageComputer : Page
    {
        public MainPageComputer()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = crbEntities.GetContext().ЭВМ.ToList();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new AddEditComputerPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Nav.Go(new AddEditComputerPage(DGrid.SelectedItem as ЭВМ));
        }

        
    }
}
