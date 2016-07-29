using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class DeleteWithoutWhereRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Detects DELETE statements without a WHERE clause.";

        public override void Visit(DeleteSpecification node)
        {
            base.Visit(node);

            if (node.WhereClause == null)
            {
                AddFinding(node, "DELETE without WHERE clause.");
            }
        }
    }
}
