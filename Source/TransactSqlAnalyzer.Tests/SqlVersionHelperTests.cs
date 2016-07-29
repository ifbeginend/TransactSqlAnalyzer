using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Tests
{
    [TestClass]
    public class SqlVersionHelperTests
    {
        [TestMethod]
        public void SqlVersionSequenceValid()
        {
            var sqlVersionHelper = new SqlVersionHelper();

            var v80 = sqlVersionHelper.GetVersion(SqlVersion.Sql80);
            Assert.AreEqual(80, v80);

            var v90 = sqlVersionHelper.GetVersion(SqlVersion.Sql90);
            Assert.AreEqual(90, v90);

            var v100 = sqlVersionHelper.GetVersion(SqlVersion.Sql100);
            Assert.AreEqual(100, v100);

            var v110 = sqlVersionHelper.GetVersion(SqlVersion.Sql110);
            Assert.AreEqual(110, v110);

            var v120 = sqlVersionHelper.GetVersion(SqlVersion.Sql120);
            Assert.AreEqual(120, v120);

            var v130 = sqlVersionHelper.GetVersion(SqlVersion.Sql130);
            Assert.AreEqual(130, v130);
        }
    }
}
