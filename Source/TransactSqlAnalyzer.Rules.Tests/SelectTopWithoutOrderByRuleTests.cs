using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class SelectTopWithoutOrderByRuleTests : TestBase
    {
        [TestMethod]
        public void SimpleTopWithoutOrderBy_Warns()
        {
            // Arrange
            var rule = new SelectTopWithoutOrderByRule();

            var sqlStatement = "SELECT TOP 5 * FROM dbo.MyFunkyTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void SimpleTopWithOrderBy_Passes()
        {
            // Arrange
            var rule = new SelectTopWithoutOrderByRule();

            var sqlStatement = "SELECT TOP(5) * FROM dbo.MyFunkyTable ORDER BY Id";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void NestedSelectTopWithoutOrderBy_Warns()
        {
            // Arrange
            var rule = new SelectTopWithoutOrderByRule();

            var sqlStatement = "SELECT Anything FROM BaseTable bt INNER JOIN (SELECT TOP(5) Id FROM dbo.MyFunkyTable) mft ON bt.ID = mftID ORDER BY ModifiedDate";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void NestedStatementTopWithOrderBy_Passes()
        {
            // Arrange
            var rule = new SelectTopWithoutOrderByRule();

            var sqlStatement = "SELECT Anything FROM BaseTable WHERE Id IN (SELECT TOP(5)Id FROM dbo.MyFunkyTable ORDER BY Id DESC)";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
