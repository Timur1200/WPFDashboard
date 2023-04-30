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
            crbEntities.GetContext().SaveChanges();
            ToWord();
            MessageBox.Show("Информация сохранена!");
            Nav.Back();
            
        }
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/Word.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void ToWord()
        {
            var wordApp = new Word.Application();

            wordApp.Visible = false;
            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("(код)", $"{_order.Код}", wordDocument);
            ReplaceWordStub("(эвм)", $"{_order.ЭВМ.Name}", wordDocument);
            ReplaceWordStub("(дата1)", $"{_order.Дата}", wordDocument);
            ReplaceWordStub("(дата2)", $"{_order.ДатаРемонта}", wordDocument);
            ReplaceWordStub("(ремонт)", $"{_order.Ремонт}", wordDocument);

            wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/{Guid.NewGuid()}.docx"));

            wordApp.Visible = true;
        }
    }
}
