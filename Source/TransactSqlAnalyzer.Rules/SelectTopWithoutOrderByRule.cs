using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class SelectTopWithoutOrderByRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Detects SELECT statements with a TOP clause without an ORDER BY.";

        public override void Visit(QuerySpecification node)
        {
            base.Visit(node);

            var hasOrderBy = node.OrderByClause != null;
            var hasTopClause = node.TopRowFilter != null;

            if (hasTopClause && !hasOrderBy)
            {
                AddFinding(node, "TOP row filter without ORDER BY produces arbitrary result.");
            }
        }
    }
}
