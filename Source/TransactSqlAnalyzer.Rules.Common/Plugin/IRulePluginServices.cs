using System;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Plugin
{
    public interface IRulePluginServices
    {
        IReadOnlyCollection<Type> GetRuleTypes();

        IDictionary<Type, Type> GetConfigControlTypes();

        PluginInformation Information { get; }
    }
}
