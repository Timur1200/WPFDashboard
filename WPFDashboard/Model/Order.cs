using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDashboard.Model
{
    partial class Заявки
    {
        public string Status
        {
            get
            {
                return (ДатаРемонта is null) ? "Отправлен" : "Завершен";
            }
        }
    }
}
