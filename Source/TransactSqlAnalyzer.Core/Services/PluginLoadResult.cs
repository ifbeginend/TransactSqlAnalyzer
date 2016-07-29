using System.Collections.Generic;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Plugin;

namespace TransactSqlAnalyzer.Core.Services
{
    public class PluginLoadResult
    {
        private readonly List<PluginLoadMessage> loadMessages = new List<PluginLoadMessage>();

        public PluginLoadResult(string fileName, string assemblyFullName)
        {
            FileName = fileName;
            AssemblyFullName = assemblyFullName;
        }

        public IRulePluginServices PluginServices { get; set; }

        public string FileName { get; }

        public string AssemblyFullName { get; }

        public bool SuccessfullyLoaded { get; set; }

        public IEnumerable<PluginLoadMessage> LoadMessages => loadMessages;

        internal void AddMessage(MessageSeverity severity, string message)
        {
            loadMessages.Add(new PluginLoadMessage(severity, message));
        }
    }
}
