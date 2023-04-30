using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDashboard.Model
{
    partial class ЭВМ
    {
        public string Remont
        {
            get
            {
                return Ремонт.Value ? "Да" : "Нет";
            }
        }
        public string Spisan
        {
            get
            {
                return Списан.Value ? "Да" : "Нет";
            }
        }

        public string Name
        {
            get
            {
                return $"{Имя} - №{Код}";
            }
        }
    }
}
