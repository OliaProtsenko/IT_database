using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using IT_database;
namespace TestProject
{
    public class SearchTest
    {
        [Fact]
        private void TestSearching1()
        {
            var database = new Database("");
            var table = new Table("");
            var column1 = new IntColumn("N");
            var column2 = new StringColumn("Name");
            var column3 = new StringColumn("Surname");
            var column4 = new IntColumn("Age");
            var row1 = new Row
            {
                values = new List<string> { "1", "Ivan", "Petrenko","23" }
            };
            var row2 = new Row
            {
                values = new List<string> { "2", "Petro", "Ivanenko", "27" }
            };
            var row3 = new Row
            {
                values = new List<string> { "2", "Pavlo", "Shumko", "35" }
            };

            database.tables.Add(table);
            database.tables[0].columns.Add(column1);
            database.tables[0].columns.Add(column2);
            database.tables[0].columns.Add(column3);
             database.tables[0].columns.Add(column4);
            database.tables[0].rows.Add(row1);
            database.tables[0].rows.Add(row2);
            database.tables[0].rows.Add(row3);


            var searchResult= new Table("")
            {
                columns = new List<Column> { column1,column2, column3,column4 },
                rows = new List<Row> {
                    new Row {                 values = new List<string> { "1", "Ivan", "Petrenko","23" }},
                    new Row {  values = new List<string> { "2", "Petro", "Ivanenko", "27" } }
                }
            };

            Manager.Instance.Database = database;
            var testSearch = Manager.Instance.Search(0, 3, "(^[1-2][0-9]$|^[0-9]$)"); //age less 30
            Assert.Equal(testSearch.columns[0], searchResult.columns[0]);
            Assert.Equal(testSearch.columns[1], searchResult.columns[1]);
            Assert.Equal(testSearch.columns[2], searchResult.columns[2]);
            Assert.Equal(testSearch.columns[3], searchResult.columns[3]);
            Assert.Equal(testSearch.rows[0].values[0], searchResult.rows[0].values[0]);
            Assert.Equal(testSearch.rows[0].values[1], searchResult.rows[0].values[1]);
            Assert.Equal(testSearch.rows[0].values[2], searchResult.rows[0].values[2]);
            Assert.Equal(testSearch.rows[0].values[3], searchResult.rows[0].values[3]);

            Assert.Equal(testSearch.rows[1].values[0], searchResult.rows[1].values[0]);
            Assert.Equal(testSearch.rows[1].values[1], searchResult.rows[1].values[1]);
            Assert.Equal(testSearch.rows[1].values[2], searchResult.rows[1].values[2]);
            Assert.Equal(testSearch.rows[1].values[3], searchResult.rows[1].values[3]);

        }
    }
}
