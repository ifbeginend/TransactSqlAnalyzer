using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class FragmentPresenceRuleTests : TestBase
    {
        private FragmentPresenceRule CreateRule()
        {
            var rule = new FragmentPresenceRule();
            rule.SpecificConfiguration.AffectedFragmentTypes.Add(typeof(SelectStarExpression));
            rule.SpecificConfiguration.ViolationMessage = "Don't use * in select clause";
            return rule;
        }

        [TestMethod]
        public void SelectWithStar_Warns()
        {
            // Arrange
            var rule = CreateRule();

            var sqlStatement = "SELECT * FROM dbo.MyFunkyTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void SelectWithoutStarRaises_NoWarning()
        {
            // Arrange
            var rule = CreateRule();

            var sqlStatement = "SELECT Funk, Rock FROM dbo.MyFunkyTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void SelectWithStarAndColums_Warns()
        {
            // Arrange
            var rule = CreateRule();

            var sqlStatement = "SELECT Funk, Rock, mht.* FROM dbo.MyFunkyTable mft INNER JOIN dbo.MyHouseTable mht ON mft.Id = mht.IdFunky";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }
    }
}
