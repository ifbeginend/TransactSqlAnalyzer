using log4net;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using TransactSqlAnalyzer.CommandLine;

namespace TransactSqlAnalyzer
{
    /// <summary>
    /// Defines the concrete command line arguments and translates the arguments to handy types
    /// </summary>
    public class AnalyzerCommandLine
    {
        private static ILog Logger { get; } = LogManager.GetLogger(typeof(AnalyzerCommandLine));

        private const string InitialQuotedIdentifiersKey = "InitialQuotedIdentifiers";
        private const string SqlVersionKey = "SqlVersion";
        private const string InputFileKey = "InputFile";
        private const string ConfigFileKey = "ConfigFile";
        private const string VerboseKey = "v";
        private const string DisplayHelpKey = "?";
        private const bool mandatory = true;
        private const bool optional = false;

        private CommandLineDefinition commandLineDefinition { get; }

        public AnalyzerCommandLine()
        {
            commandLineDefinition = new CommandLineDefinition(false);
            commandLineDefinition.AddOption(InitialQuotedIdentifiersKey, optional, "Quoted identifers enabled at the beginning");
            commandLineDefinition.AddOption(VerboseKey, optional, "Verbose output");
            commandLineDefinition.AddSettingKey(SqlVersionKey, optional, "Sql version to use, e.g. Sql120");
            commandLineDefinition.AddSettingKey(InputFileKey, mandatory, "Input file name");
            commandLineDefinition.AddSettingKey(ConfigFileKey, mandatory, "Config file name");
            commandLineDefinition.AddSettingKey(DisplayHelpKey, optional, "Display help");
        }

        public AnalyzerCommandLineResult Parse(string[] args)
        {
            SqlVersion sqlVersion = SqlVersion.Sql130;

            var commandLine = new CommandLineParser(commandLineDefinition).Parse(args);
            if (commandLine.IsValid)
            {
                var initialQuotedIdentifiers = commandLine.IsOptionDefined(InitialQuotedIdentifiersKey);
                if (commandLine.IsSettingDefined(SqlVersionKey))
                {
                    var versionString = commandLine.GetSettingValue(SqlVersionKey);
                    if (!Enum.TryParse(versionString, out sqlVersion))
                    {
                        Logger.Error($"Sql version '{versionString}' not recognized.");
                        Logger.Info($"Available values: {Enum.GetNames(typeof(SqlVersion))}");
                    }
                }
                return new AnalyzerCommandLineResult(
                    true,
                    sqlVersion,
                    commandLine.GetSettingValue(InputFileKey),
                    commandLine.GetSettingValue(ConfigFileKey),
                    initialQuotedIdentifiers,
                    commandLine.IsOptionDefined(VerboseKey),
                    commandLine.IsOptionDefined(DisplayHelpKey),
                    commandLineDefinition.GetHelpText());
            }
            else
            {
                return new AnalyzerCommandLineResult(false, sqlVersion, string.Empty, string.Empty, false, false, true, commandLineDefinition.GetHelpText());
            }
        }
    }
}
