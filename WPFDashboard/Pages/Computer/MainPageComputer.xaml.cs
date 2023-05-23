using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            _list = crbEntities.GetContext().ЭВМ.ToList();
            DGrid.ItemsSource = _list;

        }
        private List<ЭВМ> _list;
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

        private void AcrPriemaClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись из таблицы!");
                return;
            }
            ЭВМ evm = DGrid.SelectedItem as ЭВМ;
            WordService word = new WordService("Word/актПриема.docx");
            word.ReplaceWordStub("(код)", $"{evm.Код}");
            word.ReplaceWordStub("(день)", $"{evm.ДатаНачала.Value.ToString("dd")}");
            word.ReplaceWordStub("(месяц)", $"{evm.ДатаНачала.Value.ToString("MM")}");
            word.ReplaceWordStub("(год)", $"{evm.ДатаНачала.Value.ToString("yyyy")}");
            word.ReplaceWordStub("(эвм)", $"{evm.Имя} {evm.Модель} №{evm.Код}");
            word.ToWord();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text.Length == 0)
            {
                DGrid.ItemsSource = _list;
                return;
            }
            string text = SearchTextBox.Text.ToLower();
            DGrid.ItemsSource = _list.Where(q=>q.Код.ToString().Contains(text) || q.Имя.ToLower().Contains(text) 
            || q.Модель.Contains(text));
        }
    }
}
