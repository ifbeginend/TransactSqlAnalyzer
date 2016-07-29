using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class InsertTopWithOrderByRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Detects INSERT statements with a TOP clause and a SELECT with an ORDER BY.";

        public override void Visit(InsertSpecification node)
        {
            base.Visit(node);

            var hasTopClause = node.TopRowFilter != null;
            var selectSource = node.InsertSource as SelectInsertSource;
            if (selectSource != null)
            {

                if (hasTopClause && selectSource?.Select?.OrderByClause != null)
                {
                    AddFinding(node, "The ORDER BY in the SELECT has no effect, TOP takes random rows.");
                }
            }
        }
    }
}
