using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TransactSqlAnalyzer.Rules.Common
{
    /// <summary>
    /// The result of a rule.
    /// </summary>
    public class RuleResultWithFragment : RuleResult
    {
        public RuleResultWithFragment(IRule rule, TSqlFragment fragment, string message, MessageSeverity severity)
            : base(rule, fragment.FirstTokenIndex, fragment.LastTokenIndex, message, severity)
        {
            Fragment = fragment;
        }

        /// <summary>
        /// The related fragment 
        /// </summary>
        public TSqlFragment Fragment { get; }
    }
}
