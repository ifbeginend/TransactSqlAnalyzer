using System.IO;
using System.Text;

namespace TransactSqlAnalyzer.Core.Services
{
    // Todo refine
    public class StorageServices : IStorageServices
    {
        public string LoadString(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void StoreString(string value, string fileName)
        {
            File.WriteAllText(fileName, value, Encoding.UTF8);
        }
    }
}
