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
using WPFDashboard.Pages.Computer;
using WPFDashboard.Pages.Order;
using WPFDashboard.Pages.Personal;

namespace WPFDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Персонал p)
        {
            InitializeComponent();
            _pers = p;
            Nav.pers = _pers;
            if (p == null)
            {
                AdminPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                UserPanel.Visibility = Visibility.Visible;
            }
            Nav.frame = MainFrame;
        }
        private Персонал _pers;
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PersonalClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new PersonalMainPage());
        }

        private void computerClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new MainPageComputer());
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new MainClientOrderPage());
        }

        private void AllOrderClick(object sender, RoutedEventArgs e)
        {
            Nav.Go(new OrdersMainPage());   
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
