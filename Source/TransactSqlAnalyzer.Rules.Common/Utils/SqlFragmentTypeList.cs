using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// A list of <see cref="Type"/>s. The types must be the type or a subclass of <see cref="TSqlFragment"/>.
    /// </summary>
    public class SqlFragmentTypeList : IList<Type>
    {
        private readonly List<Type> types = new List<Type>();

        public Type this[int index]
        {
            get
            {
                return types[index];
            }

            set
            {
                Check.NotNull(value, "value");
                if (typeof(TSqlFragment).IsAssignableFrom(value))
                {
                    types[index] = value;
                }
                else
                {
                    throw new InvalidOperationException("Item must be TSqlFragment or descendant, but is " + value.Name);
                }
            }
        }

        public int Count => types.Count;

        public bool IsReadOnly => false;

        public void Add(Type item)
        {
            Check.NotNull(item, nameof(item));

            if (typeof(TSqlFragment).IsAssignableFrom(item))
            {
                types.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Item must be TSqlFragment or descendant, but is " + item.Name);
            }
        }

        public void Clear()
        {
            types.Clear();
        }

        public bool Contains(Type item)
        {
            return types.Contains(item);
        }

        public void CopyTo(Type[] array, int arrayIndex)
        {
            types.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return types.GetEnumerator();
        }

        public int IndexOf(Type item)
        {
            return types.IndexOf(item);
        }

        public void Insert(int index, Type item)
        {
            Check.NotNull(item, nameof(item));

            if (typeof(TSqlFragment).IsAssignableFrom(item))
            {
                types.Insert(index, item);
            }
            else
            {
                throw new InvalidOperationException("Item must be TSqlFragment or descendant, but is " + item.Name);
            }
        }

        public bool Remove(Type item)
        {
            return types.Remove(item);
        }

        public void RemoveAt(int index)
        {
            types.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return types.GetEnumerator();
        }
    }
}
