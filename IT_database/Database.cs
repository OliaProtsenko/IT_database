using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_database
{
    class Database
    {
        public string name;
        public List<Table> tables = new List<Table>();
      public  Database(string name)
        {
            this.name = name;
        }
    }
}
