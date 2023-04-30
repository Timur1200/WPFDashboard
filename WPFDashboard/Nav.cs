using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFDashboard.Model;

namespace WPFDashboard
{
    internal class Nav
    {
        public static Frame frame;
        public static void Back()
        {
            if (frame.NavigationService.CanGoBack) frame.NavigationService.GoBack();
        }
        public static void Go(Page p)
        {
            frame.Navigate(p);
        }

        public static Персонал pers;
    }
}
