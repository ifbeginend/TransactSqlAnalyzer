using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class CreatedFunctionNotDroppedRuleTests : TestBase
    {
        [TestMethod]
        public void CreateWithoutDrop_Warns()
        {
            // Arrange
            var rule = new CreatedFunctionNotDroppedRule();

            var sqlStatement =
                @"CREATE FUNCTION dbo.GetUserId()
                  RETURNS int
                  BEGIN 
                      DECLARE @IDAdministrator int = (SELECT Id FROM dbo.Users WHERE UserName = 'Sales')
                      RETURN @IDAdministrator
                  END
                  GO";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void CreateWithDrop_Passes()
        {
            // Arrange
            var rule = new CreatedFunctionNotDroppedRule();

            var sqlStatement =
                @"CREATE FUNCTION dbo.GetUserId()
                  RETURNS int
                  BEGIN 
                      DECLARE @IDAdministrator int = (SELECT Id FROM dbo.Users WHERE UserName = 'Sales')
                      RETURN @IDAdministrator
                  END
                  GO

                  SELECT xyz, dbo.GetUserId() FROM Somewhere

                  DROP FUNCTION dbo.GetUserId
                  GO";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
