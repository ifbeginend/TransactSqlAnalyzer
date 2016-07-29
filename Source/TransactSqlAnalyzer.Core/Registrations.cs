using DryIoc;
using log4net;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using TransactSqlAnalyzer.Core.Services;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Services;

namespace TransactSqlAnalyzer.Core
{
    public class Registrations
    {
        private ILog Logger { get; } = LogManager.GetLogger(typeof(ConfigurationServices));

        // see https://bitbucket.org/dadhi/dryioc/wiki/RegisterResolve

        public void Reset()
        {
            IocContainer.Reset();
        }

        public void RegisterServices(SqlVersion sqlVersion, bool initialQuotedIdentifiers)
        {
            RegisterSqlParser(sqlVersion, initialQuotedIdentifiers);
            IocContainer.Instance.Register<IRuleServices, RuleServices>(Reuse.Singleton);
            IocContainer.Instance.Register<IAnalyzerServices, AnalyzerServices>(Reuse.Singleton);
            IocContainer.Instance.Register<IConfigurationServices, ConfigurationServices>(Reuse.Singleton);
            IocContainer.Instance.Register<IStorageServices, StorageServices>(Reuse.Singleton);
            IocContainer.Instance.Register<IPluginLoaderService, PluginLoaderService>(Reuse.Singleton);
        }

        public void RegisterRuleTypes(IEnumerable<Type> ruleTypes)
        {
            foreach (var ruleType in ruleTypes)
            {
                IocContainer.Instance.RegisterMany(new[] { typeof(IRule), ruleType }, ruleType, Reuse.Transient);
            }

        }

        public void RegisterConfigControlTypes(IDictionary<Type, Type> configControlTypes)
        {
            foreach (var configControlType in configControlTypes)
            {
                IocContainer.Instance.Register(configControlType.Key, configControlType.Value, setup: Setup.With(allowDisposableTransient: true));
            }
        }

        private void RegisterSqlParser(SqlVersion sqlVersion, bool initialQuotedIdentifiers)
        {
            Logger.Info($"Register requested parser: SqlVersion={sqlVersion}, InitialQuotedIdentifiers={initialQuotedIdentifiers}.");
            var aSqlParser = new TSql90Parser(initialQuotedIdentifiers);
            var requestedParser = aSqlParser.Create(sqlVersion, initialQuotedIdentifiers);
            IocContainer.Instance.RegisterInstance(requestedParser, Reuse.Singleton);
        }
    }
}
