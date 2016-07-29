using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Rules.Common.Services;
using TransactSqlAnalyzer.Rules.Deprecated2016;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests.Deprecated2016
{
    [TestClass]
    public class DeprecatedFeature69_sp_addserverTests : TestBase
    {
        [TestMethod]
        public void Deprecated69_Warns()
        {
            // Arrange
            var rule = new DeprecatedFeature69_sp_addserver(new RuleServices());

            var sqlStatement = "Exec sp_addserver";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void Deprecated69_AllowedUse_Passes()
        {
            // Arrange
            var rule = new DeprecatedFeature69_sp_addserver(new RuleServices());

            var sqlStatement = "Exec sp_addserver 'Accounts', 'local'";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
