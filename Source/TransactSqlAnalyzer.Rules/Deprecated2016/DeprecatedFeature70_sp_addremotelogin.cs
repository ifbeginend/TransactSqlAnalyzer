using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Services;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules.Deprecated2016
{
    public class DeprecatedFeature70_sp_addremotelogin : VisitorRuleBase
    {
        private IRuleServices ruleServices { get; }

        public override string RuleTypeDescription => "Looks for deprecated use of the sp_addremotelogin stored procedure.";

        public DeprecatedFeature70_sp_addremotelogin(IRuleServices ruleServices)
        {
            this.ruleServices = ruleServices;
        }

        public override void Visit(ExecuteStatement node)
        {
            base.Visit(node);

            if (ruleServices.IsStoredProcedure(node, "sp_addremotelogin"))
            {
                AddFinding(
                    node,
                    ruleServices.BuildDeprecatedWarning(
                        "Stored procedure 'sp_addremotelogin' is deprecated.",
                        70,
                        "Replace remote servers by using linked servers."));
            }
        }
    }
}
