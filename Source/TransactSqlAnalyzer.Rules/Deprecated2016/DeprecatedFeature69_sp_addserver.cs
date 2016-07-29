using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Linq;
using TransactSqlAnalyzer.Rules.Common.Services;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules.Deprecated2016
{
    public class DeprecatedFeature69_sp_addserver : VisitorRuleBase
    {
        private IRuleServices ruleServices { get; }

        public override string RuleTypeDescription => "Looks for deprecated use of the sp_addserver stored procedure.";

        public DeprecatedFeature69_sp_addserver(IRuleServices ruleServices)
        {
            this.ruleServices = ruleServices;
        }

        public override void Visit(ExecuteStatement node)
        {
            base.Visit(node);

            if (ruleServices.IsStoredProcedure(node, "sp_addserver"))
            {
                var execProcedureRef = node.ExecuteSpecification.ExecutableEntity as ExecutableProcedureReference;

                var secondParameterValue = execProcedureRef?.Parameters?.Skip(1).FirstOrDefault()?.ParameterValue as StringLiteral;
                var isLocal =
                    secondParameterValue != null &&
                    secondParameterValue.LiteralType == LiteralType.String &&
                    secondParameterValue.Value.ToLowerInvariant() == "local";
                if (!isLocal)
                {
                    AddFinding(
                        node,
                        ruleServices.BuildDeprecatedWarning(
                            "Stored procedure 'sp_addserver' is deprecated.",
                            69,
                            "Replace remote servers by using linked servers. sp_addserver can only be used with the local option."));
                }
            }
        }
    }
}
