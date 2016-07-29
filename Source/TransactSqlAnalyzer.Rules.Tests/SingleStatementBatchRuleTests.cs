using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class SingleStatementBatchRuleTests : TestBase
    {
        [TestMethod]
        [Ignore]
        public void CreateFunctionWithSelect_Warns()
        {
            // Arrange
            var rule = new SingleStatementBatchRule();

            var sqlStatement =
                @"CREATE FUNCTION dbo.GetValue()
                  RETURNS int
                  BEGIN
                      RETURN 42
                  END

                  SELECT dbo.GetValue() FROM Dual
                  GO";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void CreateFunctionOnly_Passes()
        {
            // Arrange
            var rule = new SingleStatementBatchRule();

            var sqlStatement =
                @"SELECT GETDATE() FROM Dual
                  GO
                  CREATE FUNCTION dbo.GetValue()
                  RETURNS int
                  BEGIN
                      RETURN 42
                  END
                  GO

                  SELECT dbo.GetValue() FROM Dual
                  GO";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
