using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules.Common.Services
{
    public class AnalyzerServices : IAnalyzerServices
    {
        private TSqlParser parser { get; }

        public AnalyzerServices(TSqlParser parser)
        {
            this.parser = parser;
        }

        public IReadOnlyCollection<RuleResult> EvaluateRules(string scriptText, TSqlScript script, SqlVersion sqlVersion, IEnumerable<IRule> rules)
        {
            var allRuleResults = new List<RuleResult>();
            var activeRules = rules.Where(x => x.Configuration.IsRuleEnabled);
            var activeRulesMatchingSqlVersion = activeRules.Where(aX => aX.Configuration.SupportedSqlVersions.IsAnalyzableSqlVersion(sqlVersion));
            foreach (var rule in activeRulesMatchingSqlVersion)
            {
                try
                {
                    var ruleResults = rule.Evaluate(scriptText, script);
                    allRuleResults.AddRange(ruleResults);
                }
                catch (Exception exception)
                {
                    var exceptionResult = new RuleResult(rule, 0, 0, $"Exception in rule: {exception}", MessageSeverity.Error);
                    allRuleResults.Add(exceptionResult);
                }
            }
            return allRuleResults;
        }

        public TSqlScript Parse(string sqlStatement)
        {
            IList<ParseError> errors;
            var parseResult = parser.Parse(new StringReader(sqlStatement), out errors);

            if (errors.Count > 0)
            {
                var errorTexts = errors.Select(x => $"  {x.Number}: {x.Message} ({x.Line},{x.Column})");
                throw new InvalidOperationException("Parse errors: " + string.Join(Environment.NewLine, errorTexts));
            }
            return (TSqlScript)parseResult;
        }

        public string GetFragmentText(TSqlFragment fragment)
        {
            Check.NotNull(fragment, nameof(fragment));

            var fragmentTexts = fragment.ScriptTokenStream
                .Skip(fragment.FirstTokenIndex)
                .Take(fragment.LastTokenIndex - fragment.FirstTokenIndex + 1)
                .Select(x => x.Text);
            var fragmentText = string.Join("", fragmentTexts);
            return $"{fragmentText}";
        }

        public string GetTokenText(TSqlScript script, int firstTokenIndex, int lastTokenIndex)
        {
            var startIndex = Math.Max(firstTokenIndex, 0);
            var endIndex = Math.Min(lastTokenIndex, script.ScriptTokenStream.Count - 1);
            var sb = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                sb.Append(script.ScriptTokenStream[i].Text);
            }
            return sb.ToString();
        }
    }
}
