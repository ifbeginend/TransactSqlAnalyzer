using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules.Common
{
    public class SqlVersionsRangeFilter
    {
        public SqlVersion? MinSqlVersion { get; set; } = null;
        public SqlVersion? MaxSqlVersion { get; set; } = null;

        public bool IsAnalyzableSqlVersion(SqlVersion version)
        {
            var helper = new SqlVersionHelper();
            var versionNumber = helper.GetVersion(version);
            var isBelowRange = MinSqlVersion.HasValue && helper.GetVersion(MinSqlVersion.Value) > versionNumber;
            var isAboveRange = MaxSqlVersion.HasValue && helper.GetVersion(MaxSqlVersion.Value) < versionNumber;
            return !isBelowRange && !isAboveRange;
        }
    }
}
