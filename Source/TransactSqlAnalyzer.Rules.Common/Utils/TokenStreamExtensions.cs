using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// Extension methods for the script token stream (<see cref="IList{TSqlParserToken}"/>)
    /// </summary>
    public static class TokenStreamExtensions
    {
        public static readonly TSqlTokenType[] NonSqlTokens = new[]
        {
            TSqlTokenType.SingleLineComment,
            TSqlTokenType.MultilineComment,
            TSqlTokenType.WhiteSpace
        };

        /// <summary>
        /// Returns the token prior to <paramref name="tokenIndex"/> that is not a comment or whitespace token.
        /// Returns -1 if there is no such token in the stream.
        /// </summary>
        public static int FindPreviousNonCommentToken(this IList<TSqlParserToken> scriptTokenStream, int tokenIndex)
        {
            int result = tokenIndex - 1;
            while (result >= 0 && NonSqlTokens.Contains(scriptTokenStream[result].TokenType))
            {
                result--;
            }
            return result;
        }

        /// <summary>
        /// Returns the next token after <paramref name="tokenIndex"/> that is not a comment or whitespace token.
        /// Returns scriptTokenStream.Count if there is no such token in the stream.
        /// </summary>
        public static int FindNextNonCommentToken(this IList<TSqlParserToken> scriptTokenStream, int tokenIndex)
        {
            int result = tokenIndex + 1;
            while (result < scriptTokenStream.Count && NonSqlTokens.Contains(scriptTokenStream[result].TokenType))
            {
                result++;
            }
            return result;
        }
    }
}
