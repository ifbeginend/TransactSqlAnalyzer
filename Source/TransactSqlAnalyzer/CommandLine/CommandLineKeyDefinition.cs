using System;
using System.Text.RegularExpressions;

namespace TransactSqlAnalyzer.CommandLine
{
    /// <summary>
    /// Definition of an option or a settings key
    /// </summary>
    public class CommandLineKeyDefinition
    {
        public CommandLineKeyDefinition(string key, bool mandatory, string description)
        {
            CheckValidKeyString(key);

            Key = key;
            Mandatory = mandatory;
            Description = description;
        }

        public string Key { get; }
        public bool Mandatory { get; }
        public string Description { get; }

        private void CheckValidKeyString(string key)
        {
            // key must only contain characters, digits, underscore, 
            var isMatch = Regex.IsMatch(key, "^[a..zA..Z0..9_]");
            if (isMatch)
            {
                throw new InvalidOperationException($"The key '{key}'contains invalid characters. Only character a..z, digits and undercsore are allowed.");
            }
        }
    }
}
