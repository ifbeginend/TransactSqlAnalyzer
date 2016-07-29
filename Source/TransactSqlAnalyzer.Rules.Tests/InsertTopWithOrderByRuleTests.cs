using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransactSqlAnalyzer.Tests;

namespace TransactSqlAnalyzer.Rules.Tests
{
    [TestClass]
    public class InsertTopWithOrderByRuleTests : TestBase
    {
        [TestMethod]
        public void InsertTopWithOrderBy_Warns()
        {
            // Arrange
            var rule = new InsertTopWithOrderByRule();

            var sqlStatement = @"INSERT TOP(5) INTO dbo.EmployeeSales
                                   OUTPUT inserted.EmployeeID, inserted.FirstName, inserted.LastName, inserted.YearlySales
                                   SELECT sp.BusinessEntityID, c.LastName, c.FirstName, sp.SalesYTD
                                   FROM Sales.SalesPerson AS sp
                                   INNER JOIN Person.Person AS c ON sp.BusinessEntityID = c.BusinessEntityID
                                   WHERE sp.SalesYTD > 250000.00  
                                   ORDER BY sp.SalesYTD DESC;";

            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 1);
            Assert.AreEqual(results.Single().Rule, rule);
        }

        [TestMethod]
        public void InsertTopWithoutOrderBy_NoWarning()
        {
            // Arrange
            var rule = new InsertTopWithOrderByRule();

            var sqlStatement = @"INSERT TOP(5) INTO dbo.EmployeeSales
                                   OUTPUT inserted.EmployeeID, inserted.FirstName, inserted.LastName, inserted.YearlySales
                                   SELECT sp.BusinessEntityID, c.LastName, c.FirstName, sp.SalesYTD
                                   FROM Sales.SalesPerson AS sp
                                   INNER JOIN Person.Person AS c ON sp.BusinessEntityID = c.BusinessEntityID
                                   WHERE sp.SalesYTD > 250000.00";

            var script = Analyzer.Parse(sqlStatement);

            // Act
            var results = rule.Evaluate(sqlStatement, script);

            // Assert
            Assert.IsTrue(results.Count == 0);

        }
    }
}
