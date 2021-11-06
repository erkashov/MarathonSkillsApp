using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkillsApp
{
    public partial class MarathonEntities : DbContext
    {
        private static MarathonEntities _context;
        public static MarathonEntities GetContext()
        {
            if (_context == null) _context = new MarathonEntities();
            return _context;
        }
    }
}
