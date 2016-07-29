namespace TransactSqlAnalyzer.Rules.Common.Plugin
{
    public class PluginInformation
    {
        public PluginInformation(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
