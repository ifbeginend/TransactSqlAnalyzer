using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransactSqlAnalyzer.CommandLine
{
    /// <summary>
    /// Simple command line parser
    /// </summary>
    public class CommandLineParser
    {
        private ILog Logger { get; } = LogManager.GetLogger(typeof(Program));

        // Todo improve parsing, support more features...
        // -initialquotentifier  or  -initialquotentifier:true  or  -initialquotentifier=false
        // -sqlversion:90   or  -sqlversion 90

        private CommandLineDefinition definition { get; }

        public CommandLineParser(CommandLineDefinition definition)
        {
            this.definition = definition;
        }

        public CommandLineResult Parse(string[] args)
        {
            bool isValid = true;
            List<string> options = new List<string>();
            Dictionary<string, string> settings = new Dictionary<string, string>();
            var comparer = new StringComparer(definition.IsCaseSensitive);

            bool isSetting = false;
            string settingKey = String.Empty;
            foreach (var arg in args)
            {
                if (isSetting)
                {
                    settings.Add(settingKey, arg);
                    isSetting = false;
                }
                else
                {
                    if (!arg.StartsWith("/") && !arg.StartsWith("-"))
                    {
                        Logger.Error($"Command line arguments must start with '/' or '-'. Argument: '{arg}'.");
                        isValid = false;
                        break;
                    }

                    // check whether it's an option or a setting
                    var key = arg.Substring(1);
                    if (definition.Options.Any(x => comparer.Equals(x.Key, key)))
                    {
                        options.Add(key);
                    }
                    else if (definition.SettingKeys.Any(x => comparer.Equals(x.Key, key)))
                    {
                        isSetting = true;
                        settingKey = key;
                    }
                    else
                    {
                        Logger.Error($"Unrecognized command line arguments: '{arg}'.");
                        isValid = false;
                        break;
                    }
                }
            }

            if (isSetting)
            {
                Logger.Error($"Setting key without argument: '{settingKey}'.");
                isValid = false;
            }

            // check whether all mandatory elements are present:
            foreach (var mandatoryOption in definition.Options.Where(x => x.Mandatory))
            {
                if (!options.Contains(mandatoryOption.Key, comparer))
                {
                    Logger.Error($"Mandatory option missing: '{mandatoryOption.Key}'.");
                    isValid = false;
                }
            }

            foreach (var mandatorySetting in definition.SettingKeys.Where(x => x.Mandatory))
            {
                if (!settings.Keys.Contains(mandatorySetting.Key, comparer))
                {
                    Logger.Error($"Mandatory setting missing: '{mandatorySetting.Key}'.");
                    isValid = false;
                }
            }

            return new CommandLineResult(definition.IsCaseSensitive, isValid, options, settings);
        }
    }
}
