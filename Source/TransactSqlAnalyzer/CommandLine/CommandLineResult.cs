using System.Collections.Generic;
using System.Linq;

namespace TransactSqlAnalyzer.CommandLine
{
    public class CommandLineResult
    {
        private bool isCaseSensitive { get; }
        private IReadOnlyCollection<string> options { get; }
        private IReadOnlyDictionary<string, string> settings { get; }
        private StringComparer comparer { get; }

        public CommandLineResult(bool isCaseSensitive, bool isValid, IReadOnlyCollection<string> options, IReadOnlyDictionary<string, string> settings)
        {
            this.isCaseSensitive = isCaseSensitive;
            IsValid = isValid;
            this.options = options;
            this.settings = settings;
            comparer = new StringComparer(isCaseSensitive);
        }

        public bool IsValid { get; }

        public bool IsOptionDefined(string option)
        {
            return options.Any(x => comparer.Equals(x, option));
        }

        public bool IsSettingDefined(string key)
        {
            return settings.Any(x => comparer.Equals(x.Key, key));
        }

        public string GetSettingValue(string settingKey)
        {
            var keyValue = settings.Single(x => comparer.Equals(x.Key, settingKey));
            return keyValue.Value;
        }
    }
}
