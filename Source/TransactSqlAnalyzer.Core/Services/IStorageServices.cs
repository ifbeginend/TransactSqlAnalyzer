namespace TransactSqlAnalyzer.Core.Services
{
    // Todo refine
    public interface IStorageServices
    {
        void StoreString(string value, string uri);

        string LoadString(string uri);
    }
}
