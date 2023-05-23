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
    /// Логика взаимодействия для PersonalAddEditPage.xaml
    /// </summary>
    public partial class PersonalAddEditPage : Page
    {
        public PersonalAddEditPage(Персонал p)
        {
            InitializeComponent();
            var items = crbEntities.GetContext().Кабинет.ToList();
           
            CBoxKab.ItemsSource = items;
            if (p == null )
            {
                _personal = new Персонал();
            }
            else
            {
                _personal= p;
            }
            DataContext = _personal;
        }
        private Персонал _personal;
        
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_personal.Код == 0) crbEntities.GetContext().Персонал.Add(_personal);

            crbEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            Nav.Back();
        }
    }
}
