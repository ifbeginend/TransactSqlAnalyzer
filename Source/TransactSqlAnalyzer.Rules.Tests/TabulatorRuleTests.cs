using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class TabulatorRuleTests : TestBase
    {
        [TestMethod]
        public void ScriptWithTabs_Warns()
        {
            // Arrange
            var rule = new TabulatorRule();

            var sqlStatement = "\t\tSELECT TOP 5 * \t\tFROM dbo.MyFunkyTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 4);
            Assert.IsTrue(results.All(x => x.Rule == rule));
        }

        [TestMethod]
        public void ScriptWithoutTabs_Passes()
        {
            // Arrange
            var rule = new TabulatorRule();

            var sqlStatement = "SELECT TOP 5 * FROM dbo.MyFunkyTable";
            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);
        }
    }
}
