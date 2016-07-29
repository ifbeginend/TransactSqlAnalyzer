using System;
using System.Collections.Generic;
using TransactSqlAnalyzer.Rules;
using TransactSqlAnalyzer.Rules.Common.Plugin;
using TransactSqlAnalyzer.WinForms;

namespace TransactSqlAnalyzer.Rules.WinForms
{
    public class PluginServices : IRulePluginServices
    {
        public IReadOnlyCollection<Type> GetRuleTypes()
        {
            return new Type[0];
        }

        public IDictionary<Type, Type> GetConfigControlTypes()
        {
            var controlTypes = new Dictionary<Type, Type>();
            controlTypes.Add(typeof(IWinFormsSpecificConfigControl<FragmentPresenceRuleConfig>), typeof(FragmentPresenceRuleConfigControl));
            return controlTypes;
        }

        public PluginInformation Information => new PluginInformation("Analyzer rule controls", "Contains WinForms controls for the analyzer rules.");
    }
}
