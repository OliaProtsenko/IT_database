using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_database
{
   public class Row
    {
        public List<String> values = new List<String>();

        public string this[int i]
        {
            get => values[i];
            set => values[i] = value;
        }
    }
}
