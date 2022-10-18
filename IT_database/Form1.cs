using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_database
{

    public partial class Form1 : Form
    {
        private const string _titleError = "Error";
        private const string _titleWarning = "Warning";
        private const string _titleAddDatabase = "Add database";
        private const string _titleAddTable = "Add table";

        private const string _messageAddDatabase = "Name";
        private const string _messageAddTable = "Name";
        private const string _messageDeleteDatabase = "Are you sure?";
        private const string _messageDeleteTable = "Are you sure?";
        private const string _messageDeleteColumn = "Are you sure?";
        private const string _messageDeleteRow = "Are you sure?";

        private const string _errorEmptyDatabaseName = "Empty name of database";
        private const string _errorInvalidCharacters = "Name has invalid characters";
        private const string _errorEmptyTableName = "Empty name of table";
        private const string _errorDuplicateTableName = "Table with this name already exasts";
        private const string _errorEmptyColumnName = "Empty name of atribute";
        private const string _errorDuplicateColumnName = "Atribute with this name already exists";
        private const string _errorValidation = "Enter value of type  ";
        private string _cellOldValue = "";
        private string _cellNewValue = "";

        private readonly Manager _dbManager = Manager.Instance;

        public Form1()
        {
            InitializeComponent();
            tabControl.TabPages.Clear();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            addTableBtn.Enabled = true;
            AddDatabaseName();
                      

        }
        private void AddDatabaseName()
        {
            string dbName = "";
            bool done = false;

            while (!done)
            {
                var inputDialog = new Dialog(_messageAddDatabase, _titleAddDatabase, true);
                var dialogResult = inputDialog.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (dialogResult == DialogResult.OK)
                {
                    dbName = inputDialog.Input;

                    if (dbName.Equals(""))
                    {
                        MessageBox.Show(_errorEmptyDatabaseName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (inputDialog.Input2 != null)
                    {
                      done= importData(inputDialog.Input2);
                        _dbManager.Database.name = dbName;
                        List<string> tableNames = _dbManager.GetTableNames();

                        foreach (string name in tableNames)
                        {
                            tabControl.TabPages.Add(name);
                        }

                        int tableIndex = tabControl.SelectedIndex;

                        if (tableIndex != -1)
                        {
                           LoadTable(_dbManager.GetTable(tableIndex));
                            addAtributeBtn.Enabled = true;
                            

                            if (_dbManager.GetTable(tableIndex).rows.Count > 0)
                            {
                                deleteAtributeBtn.Enabled = true;
                                findToolStripMenuItem.Enabled = true;
                                deleteRowBtn.Enabled = true;
                                
                            }
                        }

                        createDatabaseBtn.Enabled = false;
                       // btnDeleteDatabase.Enabled = true;
                        addTableBtn.Enabled = true;

                    }
                    else if (!(done = _dbManager.CreateDatabase(dbName)))
                    {
                        MessageBox.Show(_errorInvalidCharacters, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //  databaseNameLabel.Text = dbName;

            createDatabaseBtn.Enabled = false;
            //btnDeleteDatabase.Enabled = true;
            addTableBtn.Enabled = true;
        }

        private bool importData(string path)
        {
            bool success=_dbManager.OpenDB(path);
            tabControl.TabPages.Clear();
          /*  List<string> tableNames = _dbManager.GetTableNames();

            foreach (string name in tableNames)
            {
                tabControl.TabPages.Add(name);
            }

            int tableIndex = tabControl.SelectedIndex;

            if (tableIndex != -1)
            {
                LoadTable(_dbManager.GetTable(tableIndex));

                if (_dbManager.GetTable(tableIndex).columns.Count > 0)
                {
                    findToolStripMenuItem.Enabled = true;
                }
            }

           createDatabaseBtn.Enabled = false;
           //delete.Enabled = true;
           addTableBtn.Enabled = true;*/
            return success;
        }


        private void addTableBtn_Click(object sender, EventArgs e)
        {
            string tableName = "";
            bool done = false;

            while (!done)
            {
                var inputDialog = new Dialog(_messageAddTable, _titleAddTable, false);
                var dialogResult = inputDialog.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (dialogResult == DialogResult.OK)
                {
                    tableName = inputDialog.Input;

                    if (tableName.Equals(""))
                    {
                        MessageBox.Show(_errorEmptyTableName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!(done = _dbManager.AddTable(tableName)))
                    {
                        MessageBox.Show(_errorDuplicateTableName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            tabControl.TabPages.Add(tableName);
            deleteTableBtn.Enabled = true;
            addAtributeBtn.Enabled = true;
        }

        private void deleteTableBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(_messageDeleteTable, _titleWarning,
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                int tableIndex = tabControl.SelectedIndex;

                _dbManager.DeleteTable(tableIndex);
                tabControl.TabPages.RemoveAt(tableIndex);

                if (tabControl.TabPages.Count == 0)
                {
                    deleteTableBtn.Enabled = false;
                    addAtributeBtn.Enabled = false;
                    deleteAtributeBtn.Enabled = false;
                    addRowBtn.Enabled = false;
                    deleteRowBtn.Enabled = false;
                }
                else
                {
                    LoadTable(_dbManager.GetTable(tabControl.SelectedIndex));
                }
            }
        }

        private void addAtributeBtn_Click(object sender, EventArgs e)
        {
            int tableIndex = tabControl.SelectedIndex;
            bool success = false;

            while (!success)
            {
                var columnDialog = new AtributeInputDialog();
                var dialogResult = columnDialog.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (dialogResult == DialogResult.OK)
                {
                    string columnName = columnDialog.ColumnName;
                    string columnType = columnDialog.ColumnType;

                    if (columnName.Equals(""))
                    {
                        MessageBox.Show(_errorEmptyColumnName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!(success = _dbManager.AddColumn(tableIndex, Manager.ColumnFromString(columnName, columnType))))
                    {
                        MessageBox.Show(_errorDuplicateColumnName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadTable(_dbManager.GetTable(tableIndex));
            addRowBtn.Enabled = true;
            findToolStripMenuItem.Enabled = true;
        }

        private void deleteAtributeBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(_messageDeleteColumn, _titleWarning,
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _dbManager.DeleteColumn(tabControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex);
                LoadTable(_dbManager.GetTable(tabControl.SelectedIndex));

                if (dataGridView.ColumnCount == 0)
                {
                    deleteAtributeBtn.Enabled = false;
                    addRowBtn.Enabled = false;
                    deleteRowBtn.Enabled = false;
                }
            }
        }

        private void addRowBtn_Click(object sender, EventArgs e)
        {
            int tableIndex = tabControl.SelectedIndex;

            _dbManager.AddRow(tableIndex);
            LoadTable(_dbManager.GetTable(tableIndex));
            deleteRowBtn.Enabled = true;
            deleteAtributeBtn.Enabled = true;
        }

        private void deleteRowBtn_Click(object sender, EventArgs e)
        {
            int tableIndex = tabControl.SelectedIndex;
            var dialogResult = MessageBox.Show(_messageDeleteRow, _titleWarning,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _dbManager.DeleteRow(tableIndex, dataGridView.CurrentCell.RowIndex);
                LoadTable(_dbManager.GetTable(tableIndex));

                if (dataGridView.RowCount == 0)
                {
                    deleteRowBtn.Enabled = false;
                    deleteAtributeBtn.Enabled = false;
                }
            }
        }
        private void LoadTable(Table table)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                LoadColumns(table);
                LoadRows(table);
            }
            catch { }
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
                dataGridView.Columns.Add(viewColumn);
                addRowBtn.Enabled = true;
                deleteAtributeBtn.Enabled = true;
            }
        }

        private void LoadRows(Table table)
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

                dataGridView.Rows.Add(viewRow);
            }
        }
        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _cellOldValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int tableIndex = tabControl.SelectedIndex;
            _cellNewValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (!_dbManager.ChangeCellValue(_cellNewValue, tableIndex, e.ColumnIndex, e.RowIndex))
            {
                dynamic column = _dbManager.GetTable(tableIndex).columns[e.ColumnIndex];

                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _cellOldValue;
                MessageBox.Show(_errorValidation + column.type, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tableIndex = tabControl.SelectedIndex;

            if (tableIndex != -1)
            {
                LoadTable(_dbManager.GetTable(tableIndex));

                bool columnsExist = dataGridView.ColumnCount > 0;
                bool rowsExist = dataGridView.RowCount > 0;

                addAtributeBtn.Enabled = true;
                addRowBtn.Enabled = columnsExist;
                deleteAtributeBtn.Enabled = columnsExist && rowsExist;
                deleteRowBtn.Enabled = columnsExist && rowsExist;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var findDialog = new FindInputDialog();
            var dialogResult = findDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }


            if (dialogResult == DialogResult.OK)
            {
                string searchingPattern = findDialog.searchingPattern;

                if (searchingPattern.Equals(""))
                {
                    MessageBox.Show(_errorEmptyColumnName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error); // TODO(protso):correct message
                }
                else
                {
                    Table result = _dbManager.Search(tabControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex, searchingPattern);

                    var findForm = new SearchingResult
                    {
                        Text = $"result"
                    };

                    findForm.LoadResult(result);
                    findForm.Show();
                }
            }

        }

        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;

            if (sfdSaveDB.ShowDialog() == DialogResult.OK)
            {
                if ((stream = sfdSaveDB.OpenFile()) != null)
                {
                    stream.Close();
                    _dbManager.SaveDB(sfdSaveDB.FileName);
                }
            }
        }
    }
}
