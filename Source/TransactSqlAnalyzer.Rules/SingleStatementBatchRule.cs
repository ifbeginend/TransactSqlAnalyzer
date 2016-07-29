using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Rules
{
    // Todo some parser versions seem to detect this already: is rule obsolete?
    public class SingleStatementBatchRule : VisitorRuleBase
    {
        public override string RuleTypeDescription => "Checks whether CREATE FUNCTION or CREATE PROCEDURE is the only statement in a batch.";

        public override void Visit(CreateFunctionStatement node)
        {
            base.Visit(node);

            CheckFirstStatementInBatch(node, "CREATE FUNCTION");
            CheckLastStatementInBatch(node, "CREATE FUNCTION");
        }

        public override void Visit(CreateProcedureStatement node)
        {
            base.Visit(node);

            CheckFirstStatementInBatch(node, "CREATE PROCEDURE");
            CheckLastStatementInBatch(node, "CREATE PROCEDURE");
        }

        private void CheckLastStatementInBatch(TSqlStatement node, string statementText)
        {
            // next token (if any) must be Go=219 or EndOfFile=1
            var nextNonCommentTokenIndex = node.ScriptTokenStream.FindNextNonCommentToken(node.LastTokenIndex);
            if (nextNonCommentTokenIndex >= 0 &&
                node.ScriptTokenStream[nextNonCommentTokenIndex].TokenType != TSqlTokenType.Go &&
                node.ScriptTokenStream[nextNonCommentTokenIndex].TokenType != TSqlTokenType.EndOfFile)
            {
                AddFinding(node, $"{statementText} must be the last and only statement in a batch.");
            }
        }

        private void CheckFirstStatementInBatch(TSqlStatement node, string statementText)
        {
            // previous token (if any) must be Go = 219
            var previousNonCommentTokenIndex = node.ScriptTokenStream.FindPreviousNonCommentToken(node.FirstTokenIndex);
            if (previousNonCommentTokenIndex >= 0 && node.ScriptTokenStream[previousNonCommentTokenIndex].TokenType != TSqlTokenType.Go)
            {
                AddFinding(node, $"{statementText} must be the first and only statement in a batch. ");
            }
        }
    }
}
