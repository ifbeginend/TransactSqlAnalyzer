using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// Base class for rules that visit the TSqlScript.
    /// Descendants must override one or several Visit() methods and add any rule results to Results.
    /// </summary>
    /// <remarks>There is also a <see cref="TSqlConcreteFragmentVisitor"/>, 
    /// see https://social.msdn.microsoft.com/Forums/sqlserver/en-US/24fd8fa5-b1af-44e0-89a2-a278bbf11ae0/parsing?forum=ssdt</remarks>
    public abstract class VisitorRuleBase : TSqlFragmentVisitor, IRule
    {
        private IList<RuleResult> results = new List<RuleResult>();

        public RuleConfiguration Configuration { get; set; } = new RuleConfiguration();

        public abstract string RuleTypeDescription { get; }

        public IReadOnlyCollection<RuleResult> Evaluate(string scriptText, TSqlScript script)
        {
            results = new List<RuleResult>();

            script.Accept(this);

            FinalizeResults();

            return new List<RuleResult>(results);
        }

        /// <summary>
        /// Adds a finding to the results.
        /// </summary>
        /// <param name="node">The affected script node</param>
        /// <param name="message">The error message</param>
        protected void AddFinding(TSqlFragment node, string message)
        {
            results.Add(new RuleResultWithFragment(this, node, message, Configuration.Severity));
        }

        /// <summary>
        /// Is called at the end and allows the rule to add final findings.
        /// </summary>
        protected virtual void FinalizeResults()
        {
        }
    }
}
