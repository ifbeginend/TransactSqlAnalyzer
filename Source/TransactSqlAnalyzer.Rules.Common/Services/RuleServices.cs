using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TransactSqlAnalyzer.Rules.Common.Services
{
    public class RuleServices : IRuleServices
    {
        public string BuildDeprecatedWarning(string deprecatedFeature, int deprecatedFeatureId, string replacement)
        {
            return $"{deprecatedFeature} (Feature ID={deprecatedFeatureId}). {replacement}";
        }

        public bool IsStoredProcedure(ExecuteStatement node, string storedProcedureName)
        {
            var execProcedureRef = node?.ExecuteSpecification.ExecutableEntity as ExecutableProcedureReference;
            if (execProcedureRef != null)
            {
                return execProcedureRef.ProcedureReference.ProcedureReference.Name.BaseIdentifier.Value.ToLowerInvariant() == storedProcedureName.ToLowerInvariant();
            }
            return false;
        }
    }
}
