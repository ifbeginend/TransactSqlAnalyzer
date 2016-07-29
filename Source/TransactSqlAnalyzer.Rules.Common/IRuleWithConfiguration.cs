namespace TransactSqlAnalyzer.Rules.Common
{
    public interface IRuleWithConfiguration<out TConfig> : IRule
    where TConfig : ISpecificConfiguration
    {
        TConfig SpecificConfiguration { get; }

        void SetSpecificConfiguration(ISpecificConfiguration specificConfiguration);
    }
}
