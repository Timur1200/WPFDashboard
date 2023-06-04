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
using Word = Microsoft.Office.Interop.Word;

namespace WPFDashboard.Pages.Order
{
    /// <summary>
    /// Логика взаимодействия для ThisOrderPage.xaml
    /// </summary>
    public partial class ThisOrderPage : Page
    {
        public ThisOrderPage(Заявки ord)
        {
            InitializeComponent();
            _order = ord;
            DataContext = _order;
            if (ord.ДатаРемонта is null)
            {

            }
            else
            {
                Panel.IsEnabled= false;
            }
        }
        private Заявки _order;

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            _order.ДатаРемонта = DateTime.Now;
            _order.ЭВМ.Списан = btn1.IsChecked;
            _order.ЭВМ.Ремонт = false;
            _order.ЭВМ.Причина = _order.Ремонт;
            crbEntities.GetContext().SaveChanges();
            if (_order.ЭВМ.Списан.Value)
            {
                _order.ЭВМ.Причина = _order.Ремонт;
                
                _order.Результат = "Списан";
                crbEntities.GetContext().SaveChanges();
                // акт списания
                WordService word = new WordService("Word/актСписания.docx");
                for(int i = 0; i != 2; i++)
                {
                    word.ReplaceWordStub("(день)",_order.ДатаРемонта.Value.ToString("dd"));
                    word.ReplaceWordStub("(месяц)", _order.ДатаРемонта.Value.ToString("MMMM"));
                    word.ReplaceWordStub("(год)", _order.ДатаРемонта.Value.ToString("yyyy"));
                }
                word.ReplaceWordStub("(эвм)",$"{_order.ЭВМ.Name}") ;
                word.ReplaceWordStub("(причина)", $"{_order.Ремонт}");
                word.ReplaceWordStub("(код)", $"{_order.Код}");
                word.ToWord();
            }
            else
            {
                // акт выполненых работ
                _order.Результат = "Отремонтирован";
                WordService word = new WordService("Word/актРаботы.docx");
                for (int i = 0; i != 2; i++)
                {
                    word.ReplaceWordStub("(день)", _order.ДатаРемонта.Value.ToString("dd"));
                    word.ReplaceWordStub("(месяц)", _order.ДатаРемонта.Value.ToString("MMMM"));
                    word.ReplaceWordStub("(год)", _order.ДатаРемонта.Value.ToString("yyyy"));
                }
                word.ReplaceWordStub("(деньЗ)", _order.Дата.Value.ToString("dd"));
                word.ReplaceWordStub("(месяцЗ)", _order.Дата.Value.ToString("MMMM"));
                word.ReplaceWordStub("(годЗ)", _order.Дата.Value.ToString("yyyy"));
                word.ReplaceWordStub("(тип)", $"{_order.ЭВМ.Имя}");
                word.ReplaceWordStub("(кодЭВМ)", $"{_order.ЭВМ.Код}");
                word.ReplaceWordStub("(код)", $"{_order.Код}");
                word.ReplaceWordStub("(ремонт)", $"{_order.Ремонт}");
                word.ReplaceWordStub("(фио)", $"{_order.Персонал.Фио}");
                word.ReplaceWordStub("(инженер)", $"Гучиков Альберт Камилевич");
                word.ToWord();
            }
            MessageBox.Show("Информация сохранена!");
            Nav.Back();
            
        }
       
    }
}
