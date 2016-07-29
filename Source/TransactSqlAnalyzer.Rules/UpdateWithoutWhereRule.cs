using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class UpdateWithoutWhereRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Detects UPDATE statements without a WHERE clause.";

        public override void Visit(UpdateSpecification node)
        {
            base.Visit(node);

            if (node.WhereClause == null)
            {
                AddFinding(node, "UPDATE without WHERE clause.");
            }
        }
    }
}
