using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.Core.Services
{
    public class PluginLoadMessage
    {
        public PluginLoadMessage(MessageSeverity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public MessageSeverity Severity { get; }
        public string Message { get; }
    }
}
