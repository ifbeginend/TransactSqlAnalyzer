using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.Tests
{
    [TestClass]
    public class SqlVersionsRangeFilterTests
    {
        [TestMethod]
        public void IncludeSqlVersionsRangeFilterAccepts()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MinSqlVersion = SqlVersion.Sql90;
            filter.MaxSqlVersion = SqlVersion.Sql110;

            // Act & Assert
            var isAccepted90 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql90);
            Assert.IsTrue(isAccepted90);

            var isAccepted100 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql100);
            Assert.IsTrue(isAccepted100);

            var isAccepted110 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql110);
            Assert.IsTrue(isAccepted110);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeFilterDenies()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MinSqlVersion = SqlVersion.Sql90;
            filter.MaxSqlVersion = SqlVersion.Sql110;

            // Act & Assert
            var isAccepted80 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql80);
            Assert.IsFalse(isAccepted80);

            var isAccepted120 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql120);
            Assert.IsFalse(isAccepted120);

            var isAccepted130 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql130);
            Assert.IsFalse(isAccepted130);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeOpenFilterAcceptsAll()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();

            // Act & Assert
            var isAccepted80 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql80);
            Assert.IsTrue(isAccepted80);

            var isAccepted90 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql90);
            Assert.IsTrue(isAccepted90);

            var isAccepted100 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql100);
            Assert.IsTrue(isAccepted100);

            var isAccepted110 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql110);
            Assert.IsTrue(isAccepted110);

            var isAccepted120 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql120);
            Assert.IsTrue(isAccepted120);

            var isAccepted130 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql130);
            Assert.IsTrue(isAccepted130);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeFilterMinVersionAccepts()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MinSqlVersion = SqlVersion.Sql100;

            // Act & Assert
            var isAccepted100 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql100);
            Assert.IsTrue(isAccepted100);

            var isAccepted120 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql120);
            Assert.IsTrue(isAccepted120);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeFilterMinVersionDenies()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MinSqlVersion = SqlVersion.Sql100;

            // Act & Assert
            var isAccepted80 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql80);
            Assert.IsFalse(isAccepted80);

            var isAccepted90 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql90);
            Assert.IsFalse(isAccepted90);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeFilterMaxVersionAccepts()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MaxSqlVersion = SqlVersion.Sql110;

            // Act & Assert
            var isAccepted90 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql90);
            Assert.IsTrue(isAccepted90);

            var isAccepted110 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql110);
            Assert.IsTrue(isAccepted110);
        }

        [TestMethod]
        public void IncludeSqlVersionsRangeFilterMaxVersionDenies()
        {
            // Arrange
            var filter = new SqlVersionsRangeFilter();
            filter.MaxSqlVersion = SqlVersion.Sql110;

            // Act & Assert
            var isAccepted120 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql120);
            Assert.IsFalse(isAccepted120);

            var isAccepted130 = filter.IsAnalyzableSqlVersion(SqlVersion.Sql130);
            Assert.IsFalse(isAccepted130);
        }
    }
}
