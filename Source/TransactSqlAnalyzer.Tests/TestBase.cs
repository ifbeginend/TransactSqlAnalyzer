using Microsoft.SqlServer.TransactSql.ScriptDom;
using TransactSqlAnalyzer.Rules.Common.Services;

namespace TransactSqlAnalyzer.Tests
{
    public class TestBase
    {
        protected TestBase()
        {
            // Todo version?
            Analyzer = new AnalyzerServices(new TSql130Parser(false));
        }

        protected IAnalyzerServices Analyzer { get; }
    }
}
