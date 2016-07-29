namespace TransactSqlAnalyzer.Rules.Common
{
    /// <summary>
    /// Settings that apply to every rule
    /// </summary>
    public class RuleConfiguration
    {
        public MessageSeverity Severity { get; set; } = MessageSeverity.Warning;

        public bool IsRuleEnabled { get; set; } = true;

        public string FriendlyName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public SqlVersionsRangeFilter SupportedSqlVersions { get; set; } = new SqlVersionsRangeFilter();
    }
}
