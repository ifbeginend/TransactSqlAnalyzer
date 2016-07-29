using System.Collections.Generic;

namespace TransactSqlAnalyzer.Core.Services
{
    public interface IPluginLoaderService
    {
        IEnumerable<PluginLoadResult> LoadPlugins();
    }
}
