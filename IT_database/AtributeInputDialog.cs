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
    public partial class AtributeInputDialog : Form
    {
        public string ColumnName { get; private set; }
        public string ColumnType { get; private set; }

      
        private void ColumnInputDialog_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    
    public AtributeInputDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            ColumnName = textBox1.Text;
            ColumnType = comboBox1.Text;
        }
    }
}
