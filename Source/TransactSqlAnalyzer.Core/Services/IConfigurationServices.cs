using System.Collections.Generic;
using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.Core.Services
{
    public interface IConfigurationServices
    {
        void StoreConfiguration(IReadOnlyCollection<IRule> rules, string targetUri);

        IReadOnlyCollection<IRule> CreateConfiguredRules(string sourceUri);
    }
}
