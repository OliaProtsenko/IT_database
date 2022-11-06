using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IT_database;

namespace IT_database.Test
{
    public class ValidationTests
    {
        private Column _column;

        [Fact]
        public void TestIntColumnValidation1()
        {
            _column = new IntColumn("");
            Assert.True(_column.Validate("42"));
        }

        [Fact]
        public void TestIntColumnValidation2()
        {
            _column = new IntColumn("");
            Assert.False(_column.Validate("str"));
        }

        [Fact]
        public void TestRealColumnValidation1()
        {
            _column = new RealColumn("");
            Assert.True(_column.Validate("234,79"));
        }

        [Fact]
        public void TestRealColumnValidation2()
        {
            _column = new RealColumn("");
            Assert.False(_column.Validate("234d79"));
        }

        [Fact]
        public void TestCharColumnValidation1()
        {
            _column = new CharColumn("");
            Assert.True(_column.Validate("C"));
        }

        [Fact]
        public void TestCharColumnValidation2()
        {
            _column = new CharColumn("");
            Assert.False(_column.Validate("jkg"));
        }

        [Fact]
        public void TestStringColumnValidation()
        {
            _column = new StringColumn("");
            Assert.True(_column.Validate("str"));
        }

        [Fact]
        public void TestColorColumnValidation()
        {
            _column = new ColorColumn("");
            Assert.True(_column.Validate("#FF0000"));
        }

        [Fact]
        public void TestColorIntervalValidation()
        {
            _column = new ColorIntervalColumn("");
            Assert.False(_column.Validate("#FF0000 - #FBG000"));
        }

       
    
}
}
