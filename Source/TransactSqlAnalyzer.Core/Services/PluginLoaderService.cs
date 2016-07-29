using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Plugin;

namespace TransactSqlAnalyzer.Core.Services
{
    public class PluginLoaderService : IPluginLoaderService
    {
        public IEnumerable<PluginLoadResult> LoadPlugins()
        {
            // do not fail if one of the plugins is flawed
            var pluginLoadResults = new List<PluginLoadResult>();

            var potentialRuleAssemblyFileNames = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.TopDirectoryOnly);

            foreach (var fileName in potentialRuleAssemblyFileNames)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(fileName);
                    var currentPluginResult = new PluginLoadResult(fileName, assembly.FullName);

                    var pluginAttribute = assembly.GetCustomAttribute<TransactSqlAnalyzerRuleAssemblyAttribute>();
                    if (pluginAttribute != null)
                    {
                        var pluginServicesType = pluginAttribute.PluginServicesType;
                        currentPluginResult.PluginServices = (IRulePluginServices)Activator.CreateInstance(pluginServicesType);
                        currentPluginResult.SuccessfullyLoaded = true;
                    }
                    else
                    {
                        currentPluginResult.AddMessage(MessageSeverity.Info, $"Assembly has no {nameof(TransactSqlAnalyzerRuleAssemblyAttribute)} and is therefore not a plugin. {fileName}");
                    }
                    pluginLoadResults.Add(currentPluginResult);
                }
                catch (Exception ex)
                {
                    var currentPluginResult = new PluginLoadResult(fileName, string.Empty);
                    currentPluginResult.AddMessage(MessageSeverity.Warning, $"Unable to load assembly {fileName}. Exception: {ex}");
                    pluginLoadResults.Add(currentPluginResult);
                }
            }
            return pluginLoadResults;
        }
    }
}
