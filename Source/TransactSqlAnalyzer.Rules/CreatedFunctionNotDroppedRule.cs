using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class CreatedFunctionNotDroppedRule : VisitorRuleBase
    {
        private readonly Dictionary<string, CreateFunctionStatement> functions = new Dictionary<string, CreateFunctionStatement>();

        public override string RuleTypeDescription => "Checks whether functions created by the script are dropped later.";

        public override void Visit(CreateFunctionStatement node)
        {
            base.Visit(node);

            var name = node.Name.SchemaIdentifier.Value + '.' + node.Name.BaseIdentifier.Value;
            functions.Add(name, node);
        }

        public override void Visit(DropFunctionStatement node)
        {
            base.Visit(node);

            foreach (var obj in node.Objects)
            {
                var name = obj.SchemaIdentifier.Value + '.' + obj.BaseIdentifier.Value;
                functions.Remove(name);
            }
        }

        protected override void FinalizeResults()
        {
            base.FinalizeResults();

            foreach (var keyValuePair in functions)
            {
                AddFinding(keyValuePair.Value, $"Function '{keyValuePair.Key}' is not dropped.");
            }
        }
    }
}
