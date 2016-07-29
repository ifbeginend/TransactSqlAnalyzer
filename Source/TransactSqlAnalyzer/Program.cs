using System;

namespace TransactSqlAnalyzer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            return new Analyzer().Run(args);
        }
    }
}
