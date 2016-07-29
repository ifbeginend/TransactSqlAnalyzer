using System;

namespace TransactSqlAnalyzer.Rules.Common.Plugin
{
    /// <summary>
    /// Marks assemblies that contain TransactSqlAnalyzer rules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class TransactSqlAnalyzerRuleAssemblyAttribute : Attribute
    {
        public TransactSqlAnalyzerRuleAssemblyAttribute(Type pluginServicesType)
        {
            if (pluginServicesType.GetInterface(nameof(IRulePluginServices)) != null)
            {
                PluginServicesType = pluginServicesType;
            }
            else
            {
                throw new ArgumentException($"{nameof(pluginServicesType)} must implement {nameof(IRulePluginServices)}, but the given type '{pluginServicesType.Name}' doesn't.", nameof(pluginServicesType));
            }
        }

        public Type PluginServicesType { get; }
    }
}
