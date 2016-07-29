using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactSqlAnalyzer.CommandLine
{
    /// <summary>
    /// Simple definition of command line options and settings
    /// </summary>
    public class CommandLineDefinition
    {
        private List<CommandLineKeyDefinition> options { get; } = new List<CommandLineKeyDefinition>();
        private List<CommandLineKeyDefinition> settingKeys { get; } = new List<CommandLineKeyDefinition>();
        private StringComparer comparer { get; }

        public CommandLineDefinition(bool isCaseSensitive)
        {
            IsCaseSensitive = isCaseSensitive;
            comparer = new StringComparer(isCaseSensitive);
        }

        public IReadOnlyCollection<CommandLineKeyDefinition> Options => options.AsReadOnly();

        public IReadOnlyCollection<CommandLineKeyDefinition> SettingKeys => settingKeys.AsReadOnly();

        public bool IsCaseSensitive { get; }

        public string GetHelpText()
        {
            var result = new StringBuilder();

            result.AppendLine("Command line syntax");
            result.AppendLine("  Options:");
            Options.ToList().ForEach(x => result.AppendLine($"    /{x.Key}      {(x.Mandatory ? "(optional) " : "(mandatory)")}  {x.Description}"));

            result.AppendLine("  Settings:");
            SettingKeys.ToList().ForEach(x => result.AppendLine($"    /{x.Key} <value>  {(x.Mandatory ? "(optional) " : "(mandatory)")}  {x.Description}"));
            result.AppendLine();
            result.AppendLine("The options and settings are " + (IsCaseSensitive ? "case-sensitive" : "not case-sensitive") + ".");

            return result.ToString();
        }

        public void AddOption(string key, bool mandatory, string description)
        {
            if (options.Exists(x => comparer.Equals(x.Key, key)))
            {
                throw new InvalidOperationException($"Adding the same option twice is not supported, Option='{key}', IsCaseSensitive={IsCaseSensitive}.");
            }
            options.Add(new CommandLineKeyDefinition(key, mandatory, description));
        }

        public void AddSettingKey(string key, bool mandatory, string description)
        {
            if (settingKeys.Exists(x => comparer.Equals(x.Key, key)))
            {
                throw new InvalidOperationException($"Adding the same key twice is not supported, Key='{key}', IsCaseSensitive={IsCaseSensitive}.");
            }
            settingKeys.Add(new CommandLineKeyDefinition(key, mandatory, description));
        }
    }
}
