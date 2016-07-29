using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common
{
    public interface IRule
    {
        IReadOnlyCollection<RuleResult> Evaluate(string scriptText, TSqlScript script);

        RuleConfiguration Configuration { get; set; }

        string RuleTypeDescription { get; }
    }
}
