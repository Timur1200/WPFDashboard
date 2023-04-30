using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDashboard.Model
{
    partial class crbEntities
    {
        private static crbEntities _context;
        public static crbEntities GetContext()
        {
            if (_context == null) _context = new crbEntities();
            return _context;
        }
    }
}
