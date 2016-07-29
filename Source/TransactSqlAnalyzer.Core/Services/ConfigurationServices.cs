using DryIoc;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.Core.Services
{
    public class ConfigurationServices : IConfigurationServices
    {
        private IStorageServices storage { get; }

        private ILog Logger { get; } = LogManager.GetLogger(typeof(ConfigurationServices));

        private JsonSerializerSettings jsonSerializerSettings { get; } = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public ConfigurationServices(IStorageServices storage)
        {
            this.storage = storage;
        }

        public void StoreConfiguration(IReadOnlyCollection<IRule> rules, string targetUri)
        {
            var ruleInstances = new List<RuleInstance>(rules.Count);
            foreach (var rule in rules)
            {
                var ruleInstance = new RuleInstance();
                ruleInstance.AssemblyQualifiedRuleTypeName = rule.GetType().AssemblyQualifiedName;
                ruleInstance.GeneralConfig = JsonConvert.SerializeObject(rule.Configuration, Formatting.Indented);
                var specificRule = rule as IRuleWithConfiguration<ISpecificConfiguration>;
                if (specificRule != null)
                {
                    ruleInstance.SpecificConfig = JsonConvert.SerializeObject(specificRule.SpecificConfiguration, Formatting.Indented, jsonSerializerSettings);
                }
                ruleInstances.Add(ruleInstance);
            }

            var serializedRuleInstances = JsonConvert.SerializeObject(ruleInstances, Formatting.Indented);
            storage.StoreString(serializedRuleInstances, targetUri);
        }

        public IReadOnlyCollection<IRule> CreateConfiguredRules(string sourceUri)
        {
            var result = new List<IRule>();
            var serializedConfig = storage.LoadString(sourceUri);
            var ruleInstances = JsonConvert.DeserializeObject<IEnumerable<RuleInstance>>(serializedConfig);
            foreach (var ruleInstance in ruleInstances)
            {
                var ruleType = Type.GetType(ruleInstance.AssemblyQualifiedRuleTypeName, false);
                if (ruleType == null)
                {
                    Logger.Warn($"Unable to get rule type '{ruleInstance.AssemblyQualifiedRuleTypeName}'.");
                }
                else
                {
                    var rule = (IRule)IocContainer.Instance.Resolve(ruleType);
                    var configuration = JsonConvert.DeserializeObject<RuleConfiguration>(ruleInstance.GeneralConfig);
                    rule.Configuration = configuration;


                    var ruleWithConfig = (rule as IRuleWithConfiguration<ISpecificConfiguration>);
                    if (ruleWithConfig != null)
                    {
                        var specificConfiguration = JsonConvert.DeserializeObject(ruleInstance.SpecificConfig, jsonSerializerSettings);
                        ruleWithConfig.SetSpecificConfiguration((ISpecificConfiguration)specificConfiguration);
                    }
                    result.Add(rule);
                }
            }
            return result;
        }

        /// <summary>
        /// Must be always deserializable (e.g. if the rule type is missing)
        /// </summary>
        private class RuleInstance
        {
            public string AssemblyQualifiedRuleTypeName { get; set; }
            public string GeneralConfig { get; set; }
            public string SpecificConfig { get; set; }
        }
    }
}
