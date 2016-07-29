using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class UpdateWithoutWhereRuleTests : TestBase
    {
        [TestMethod]
        public void WithoutWhere_Warns()
        {
            // Arrange
            var rule = new UpdateWithoutWhereRule();

            var sqlStatement = "UPDATE BigTable SET Amount = 23";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void WithWhere_Passes()
        {
            // Arrange
            var rule = new UpdateWithoutWhereRule();

            var sqlStatement = "UPDATE BigTable SET Amount = 23 WHERE Owner = 15";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
