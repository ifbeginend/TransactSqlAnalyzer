using System;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// Method argument checks
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="item"/> is null.
        /// </summary>
        public static void NotNull(object item, string paramName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="value"/> is not of type <typeparamref name="T"/>.
        /// </summary>
        public static T OfType<T>(object value, string paramName)
        {
            if (!(value is T))
            {
                throw new ArgumentException($"An instance of type {typeof(T)} is expected, but the given type is {value.GetType()}.", paramName);
            }
            return (T)value;
        }
    }
}
