using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_database
{
    public partial class FindInputDialog : Form
    {
         public string searchingPattern { get; private set; }
         
        public FindInputDialog()
        {
            InitializeComponent();
        }

      

        private void okBtn_Click(object sender, EventArgs e)
        {
            searchingPattern = textBox1.Text;
        }
    }
}
