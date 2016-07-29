using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class TabulatorRule : IRule
    {
        public string RuleTypeDescription => "Looks for TAB characters in the script.";

        public RuleConfiguration Configuration { get; set; } = new RuleConfiguration();

        public IReadOnlyCollection<RuleResult> Evaluate(string scriptText, TSqlScript script)
        {
            var results = new List<RuleResult>();

            var matches = Regex.Matches(scriptText, "\t");
            var sortedMatches = matches.OfType<Match>().OrderBy(x => x.Index).ToList();
            foreach (var match in sortedMatches)
            {
                var firstTokenIndex = script.ScriptTokenStream.IndexOfLast(x => x.Offset <= match.Index);
                var lastTokenIndex = script.ScriptTokenStream.IndexOfFirst(x => x.Offset > match.Index);
                results.Add(new RuleResult(this, firstTokenIndex, lastTokenIndex, $"File contains tabs instead of spaces, offset={match.Index}.", Configuration.Severity));
            }

            return results;
        }
    }
}
