using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// Supports the comparison of <see cref="SqlVersion"/>.
    /// Unfortunately, the <see cref="SqlVersion"/> enum values are not inorder of the sql versions.
    /// </summary>
    public class SqlVersionHelper
    {
        private Dictionary<SqlVersion, int> sqlVersions { get; } = new Dictionary<SqlVersion, int>();

        public SqlVersionHelper()
        {
            // Hack: extract the number of the enum string
            var versionNames = Enum.GetNames(typeof(SqlVersion));
            foreach (var versionName in versionNames)
            {
                if (versionName.Substring(0, 3) != "Sql")
                {
                    throw new InvalidOperationException($"Enum name of SqlVersion doesn't start with 'Sql': {versionName}.");
                }
                var numberString = versionName.Substring(3);
                int versionNumber;
                if (int.TryParse(numberString, out versionNumber))
                {
                    SqlVersion sqlVersion;
                    if (Enum.TryParse<SqlVersion>(versionName, out sqlVersion))
                    {
                        sqlVersions.Add(sqlVersion, versionNumber);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to parse SqlVersion name: {versionName}.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Enum name of SqlVersion doesn't have a number after 'Sql' prefix: {versionName}.");
                }
            }
        }

        public int GetVersion(SqlVersion version) => sqlVersions[version];
    }
}
