using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TransactSqlAnalyzer.Rules.Common.Services
{
    /// <summary>
    /// Provides services to analyzer rules
    /// </summary>
    public interface IRuleServices
    {
        /// <summary>
        /// Returns true if it's an execute statement of the given stored procedure name.
        /// </summary>
        bool IsStoredProcedure(ExecuteStatement node, string storedProcedureName);

        /// <summary>
        /// Builds a string describing an deprecation violation that. Use e.g. for the finding message.
        /// </summary>
        string BuildDeprecatedWarning(string deprecatedFeature, int deprecatedFeatureId, string replacement);
    }
}
