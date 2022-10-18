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
    public partial class SearchingResult : Form
    {
        public SearchingResult()
        {
            InitializeComponent();
        }
        public void LoadResult(Table table)
        {
            LoadColumns(table);
            LoadRows(table);
        }
      private void LoadColumns(Table table)
        {
            foreach (dynamic column in table.columns)
            {
                var viewColumn = new DataGridViewTextBoxColumn
                {
                    Name = column.name,
                    HeaderText = $"{column.name} ({column.type})"
                };
                searchingResultView.Columns.Add(viewColumn);
            }
        }
        private void LoadRows (Table table)
        {
            foreach (var row in table.rows)
            {
                var viewRow = new DataGridViewRow();

                foreach (string value in row.values)
                {
                    var cell = new DataGridViewTextBoxCell
                    {
                        Value = value
                    };
                    viewRow.Cells.Add(cell);
                }

               searchingResultView.Rows.Add(viewRow);
            }
        } 
    }
}
