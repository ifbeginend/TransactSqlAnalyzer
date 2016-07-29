using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Plugin;

namespace TransactSqlAnalyzer.Rules
{
    public class AnalyzerRulePluginServices : IRulePluginServices
    {
        public IReadOnlyCollection<Type> GetRuleTypes()
        {
            var currentAssembly = Assembly.GetAssembly(typeof(AnalyzerRulePluginServices));
            var rules = currentAssembly.DefinedTypes
                .Where(x => x.IsPublic)
                .Where(x => x.ImplementedInterfaces.Contains(typeof(IRule)))
                .ToList();
            return rules;
        }

        public IDictionary<Type, Type> GetConfigControlTypes()
        {
            return new Dictionary<Type, Type>();
        }

        public PluginInformation Information => new PluginInformation("Analyzer rules", "Contains analyzer rules.");
    }
}
