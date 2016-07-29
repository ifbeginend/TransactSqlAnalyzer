using System.Collections.Generic;

namespace TransactSqlAnalyzer.CommandLine
{
    public class StringComparer : IEqualityComparer<string>
    {
        private bool caseSensitive { get; }

        public StringComparer(bool caseSensitive)
        {
            this.caseSensitive = caseSensitive;
        }

        public bool Equals(string x, string y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return string.Compare(x, y, !caseSensitive) == 0;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
