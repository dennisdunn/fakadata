using System;
using System.Collections.Generic;
using System.Text;

namespace Sequences
{
    public static class Extensions
    {
        public static IEnumerable<T> AsCycle<T>(this IEnumerable<T> collection)
        {
            return new PerpetualEnumerable<T>(collection);
        }
    }
}
