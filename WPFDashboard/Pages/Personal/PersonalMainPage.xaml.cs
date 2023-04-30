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

namespace WPFDashboard.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для PersonalMainPage.xaml
    /// </summary>
    public partial class PersonalMainPage : Page
    {
        public PersonalMainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = crbEntities.GetContext().Персонал.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new PersonalAddEditPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Nav.Go(new PersonalAddEditPage(DGrid.SelectedItem as Персонал));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var item = DGrid.SelectedItem as Персонал;
            crbEntities.GetContext().Персонал.Remove(item);
            crbEntities.GetContext().SaveChanges();
            Page_Loaded(null, null);
        }
    }
}
