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
    /// Логика взаимодействия для AddEditComputerPage.xaml
    /// </summary>
    public partial class AddEditComputerPage : Page
    {
        public AddEditComputerPage(ЭВМ e)
        {
            InitializeComponent();
            DatePicker1.DisplayDateStart = DateTime.Today;
            KabinetComboBox.ItemsSource = crbEntities.GetContext().Кабинет.ToList();
            ProviderComboBox.ItemsSource = crbEntities.GetContext().Поставщик.ToList();
            if (e == null)
            {
                _comp = new ЭВМ {Списан =false , Ремонт = false,ДатаНачала = DateTime.Now};
            }
            else
            {
                _comp= e;
            }
            DataContext = _comp;
        }
        private ЭВМ _comp;
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_comp.Код == 0 ) crbEntities.GetContext().ЭВМ.Add( _comp );
            crbEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            Nav.Back();
        }
    }
}
