using DryIoc;
using log4net;
using log4net.Core;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.IO;
using System.Linq;
using TransactSqlAnalyzer.Core;
using TransactSqlAnalyzer.Core.Services;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Services;

namespace TransactSqlAnalyzer
{
    public class Analyzer
    {
        private static ILog Logger { get; } = LogManager.GetLogger(typeof(Program));

        private bool verboseOutput = true;

        public int Run(string[] args)
        {
            Logger.RegisterEventingAppender(LogMessage, Level.Info);

            var commandLine = new AnalyzerCommandLine().Parse(args);
            if (!commandLine.IsValid)
            {
                Logger.Error("The command line is not valid.");
                Logger.Info(commandLine.HelpText);
                Console.WriteLine("Press RETURN to continue...");
                Console.ReadLine();
                return -1;
            }
            else if (commandLine.DisplayHelp)
            {
                Logger.Info(commandLine.HelpText);
                Console.WriteLine("Press RETURN to continue...");
                Console.ReadLine();
                return -1;
            }
            else
            {
                verboseOutput = commandLine.VerboseOutput;
                int violationCount = 0;

                Logger.AssistedExecute(() =>
                {

                    Logger.Info("Command line is valid.");
                    Logger.Info($"Input file: {commandLine.InputFile}");
                    Logger.Info($"Config file: {commandLine.ConfigFile}");
                    Logger.Info($"Sql version: {commandLine.SqlVersion}");
                    Logger.Info($"InitialQuotedIdentifiers: {commandLine.InitialQuotedIdentifiers}");
                    Logger.Info($"VerboseOutput: {commandLine.VerboseOutput}");

                    RegisterServicesAndPlugins(commandLine.SqlVersion, commandLine.InitialQuotedIdentifiers);

                    violationCount = Analyze(commandLine, verboseOutput);
                },
                "Analyzer",
                true);

                Console.ReadLine();
                return violationCount;
            }
        }

        private static int Analyze(AnalyzerCommandLineResult commandLine, bool verboseOutput)
        {
            var configServices = IocContainer.Instance.Resolve<IConfigurationServices>();
            var rules = configServices.CreateConfiguredRules(commandLine.ConfigFile);

            var analyzer = IocContainer.Instance.Resolve<IAnalyzerServices>();
            var scriptText = File.ReadAllText(commandLine.InputFile);
            var script = analyzer.Parse(scriptText);

            var allRuleResults = analyzer.EvaluateRules(scriptText, script, commandLine.SqlVersion, rules);

            allRuleResults.ToList().ForEach(x =>
            {
                Console.WriteLine(
                    $"{x.Severity} Ln {script.ScriptTokenStream[x.FirstTokenIndex].Line}, Col {script.ScriptTokenStream[x.FirstTokenIndex].Column}: " +
                    $"{x.Rule.Configuration.FriendlyName} ({x.Rule.Configuration.Category}) {x.Message}");
                if (verboseOutput)
                {
                    var resultWithFragment = x as RuleResultWithFragment;
                    if (resultWithFragment != null)
                    {
                        Console.WriteLine($"{analyzer.GetFragmentText(resultWithFragment.Fragment)}");
                    }
                    else
                    {
                        Console.WriteLine($"{analyzer.GetTokenText(script, x.FirstTokenIndex, x.LastTokenIndex)}");
                    }
                    Console.WriteLine();
                }
            });
            return allRuleResults.Count;
        }

        private static void RegisterServicesAndPlugins(SqlVersion sqlVersion, bool initialQuotedIdentifiers)
        {
            var registrations = new Registrations();
            registrations.RegisterServices(sqlVersion, initialQuotedIdentifiers);

            Logger.Info("Plugins:");
            var pluginLoader = IocContainer.Instance.Resolve<IPluginLoaderService>();
            var pluginLoadResults = pluginLoader.LoadPlugins();
            foreach (var pluginLoadResult in pluginLoadResults)
            {
                Logger.Info($"  File: {pluginLoadResult.FileName}");
                Logger.Info($"  Success: {pluginLoadResult.SuccessfullyLoaded}");
                if (pluginLoadResult.SuccessfullyLoaded)
                {
                    Logger.Info($"  Assembly: {pluginLoadResult.AssemblyFullName}");
                    Logger.Info($"  Name: {pluginLoadResult.PluginServices.Information.Name}");
                    Logger.Info($"  Description: {pluginLoadResult.PluginServices.Information.Description}");
                    var ruleTypes = pluginLoadResult.PluginServices.GetRuleTypes();
                    Logger.Info($"  {ruleTypes.Count} Ruletypes: {string.Join(", ", ruleTypes)}");
                    registrations.RegisterRuleTypes(ruleTypes);
                }
                foreach (var loadMessage in pluginLoadResult.LoadMessages)
                {
                    Logger.Info($"    Message:{loadMessage.Severity} {loadMessage.Message}");
                }
            }
            IocContainer.Instance.VerifyResolutions();
        }

        private void LogMessage(LoggingEvent logInfo)
        {
            if (verboseOutput || logInfo.Level > Level.Info)
            {
                Console.WriteLine($"{logInfo.Level}  {logInfo.RenderedMessage}");
                if (logInfo.ExceptionObject != null)
                {
                    Console.WriteLine($"{logInfo.ExceptionObject}");
                }
            }
        }
    }
}
