using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    public class FragmentPresenceRuleConfig : ISpecificConfiguration
    {
        public SqlFragmentTypeList AffectedFragmentTypes { get; } = new SqlFragmentTypeList();

        public string ViolationMessage { get; set; } = string.Empty;
    }
}
