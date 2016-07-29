using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Linq;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class InsertWithoutColumnsRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Looks for INSERT statements without column names.";

        public override void ExplicitVisit(InsertSpecification node)
        {
            base.ExplicitVisit(node);

            if (!node.Columns.Any())
            {
                AddFinding(node, "INSERT statement should specify the columns.");
            }
        }
    }
}
