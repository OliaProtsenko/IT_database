using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_database
{
   public  class Table
    {
        public string name;
        public List<Column> columns = new List<Column>();
        public List<Row> rows = new List<Row>();
        public Table(string name)
        {
            this.name = name;
        }
    }
}
