using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Services
{
    public interface IAnalyzerServices
    {
        TSqlScript Parse(string sqlStatement);

        IReadOnlyCollection<RuleResult> EvaluateRules(string scriptText, TSqlScript script, SqlVersion sqlVersion, IEnumerable<IRule> rules);

        string GetFragmentText(TSqlFragment fragment);

        string GetTokenText(TSqlScript script, int firstTokenIndex, int lastTokenIndex);
    }
}
