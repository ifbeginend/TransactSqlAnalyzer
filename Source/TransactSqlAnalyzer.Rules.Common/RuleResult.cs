using System.Diagnostics;

namespace TransactSqlAnalyzer.Rules.Common
{
    /// <summary>
    /// The result of a rule.
    /// </summary>
    [DebuggerDisplay("{Rule.Configuration.FriendlyName}: {FirstTokenIndex} {Message}")]
    public class RuleResult
    {
        public RuleResult(IRule rule, int firstTokenIndex, int lastTokenIndex, string message, MessageSeverity severity)
        {
            Rule = rule;
            FirstTokenIndex = firstTokenIndex;
            LastTokenIndex = lastTokenIndex;
            Message = message;
            Severity = severity;
        }

        /// <summary>
        /// Rule that created the result.
        /// </summary>
        public IRule Rule { get; }

        /// <summary>
        /// The first token index in script's token stream
        /// </summary>
        public int FirstTokenIndex { get; }

        /// <summary>
        /// The last token index in script's token stream
        /// </summary>
        public int LastTokenIndex { get; }

        /// <summary>
        /// The rule's message (user-readable)
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Severity of the message.
        /// </summary>
        public MessageSeverity Severity { get; }
    }
}
