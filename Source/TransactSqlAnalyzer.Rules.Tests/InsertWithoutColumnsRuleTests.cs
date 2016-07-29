using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class InsertWithoutColumnsRuleTests : TestBase
    {
        [TestMethod]
        public void InsertValuesWithoutColumns_Warns()
        {
            // Arrange
            var rule = new InsertWithoutColumnsRule();

            var sqlStatement = "INSERT INTO dbo.GrowingTable VALUES (11, 2, 3)";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void InsertSelectWithoutColumns_Warns()
        {
            // Arrange
            var rule = new InsertWithoutColumnsRule();

            var sqlStatement = "INSERT INTO dbo.GrowingTable SELECT x, y FROM dbo.SourceTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void WithColumns_Passes()
        {
            // Arrange
            var rule = new InsertWithoutColumnsRule();

            var sqlStatement = "INSERT INTO dbo.GrowingTable (Col1, Col2) VALUES (11, 2)";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
