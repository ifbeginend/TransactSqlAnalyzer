using System;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    public static class ListExtensions
    {
        public static int IndexOfLast<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (predicate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int IndexOfFirst<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
