using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TransactSqlAnalyzer
{
    public class AnalyzerCommandLineResult
    {
        public AnalyzerCommandLineResult(
            bool isValid,
            SqlVersion version,
            string inputFile,
            string configFile,
            bool initialQuotedIdentifiers,
            bool verboseOutput,
            bool displayHelp,
            string helpText)
        {
            IsValid = isValid;
            SqlVersion = version;
            InputFile = inputFile;
            ConfigFile = configFile;
            InitialQuotedIdentifiers = initialQuotedIdentifiers;
            VerboseOutput = verboseOutput;
            DisplayHelp = displayHelp;
            HelpText = helpText;
        }

        public bool IsValid { get; }
        public SqlVersion SqlVersion { get; }
        public string InputFile { get; }
        public string ConfigFile { get; }
        public bool InitialQuotedIdentifiers { get; }
        public bool VerboseOutput { get; }
        public bool DisplayHelp { get; }
        public string HelpText { get; }
    }
}
