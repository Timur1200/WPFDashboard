using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDashboard.Model
{
    partial class Кабинет
    {
        public override string ToString()
        {
            return Имя + " №" + Код;
        }
    }
}
