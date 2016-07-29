using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TransactSqlAnalyzer.Tests
{
    [TestClass]
    public class TestBaseTests : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ParseErrorsThrowException()
        {
            // Arrange

            // Act
            Analyzer.Parse("SELECT X = invalid statement text FROM dbo.NoIdea");

            // Assert
            Assert.Fail("Exception expected.");
        }
    }
}
