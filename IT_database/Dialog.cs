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
    public partial class Dialog : Form
    {
        public string Input { get; private set; }
        public string Input2 { get; private set; }
        private bool _isDB;

        public Dialog(string message, string title, bool isDB)
        {
            InitializeComponent();
            messageLabel.Text = message;
            Text = title;
            _isDB = isDB;
            if (_isDB) {
                label1.Enabled = true;
                label1.Visible = true;
                path.Enabled = true;
                path.Visible = true;
                selectPathButton.Enabled = true;
                selectPathButton.Visible = true;
            }
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            Input = textBox.Text;
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            if (ofdOpenDB.ShowDialog() == DialogResult.OK)
            {
                Input2 = ofdOpenDB.FileName;
                path.Text = ofdOpenDB.FileName;
            }
        }
    }
}
