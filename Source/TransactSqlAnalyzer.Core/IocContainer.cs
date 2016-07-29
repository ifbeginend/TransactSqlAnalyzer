using DryIoc;

namespace TransactSqlAnalyzer.Core
{
    public static class IocContainer
    {
        // See https://bitbucket.org/dadhi/dryioc/wiki/SelectConstructorOrFactoryMethod

        public static Container Instance { get; private set; } = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments));

        public static void Reset()
        {
            Instance = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments));
        }
    }
}
