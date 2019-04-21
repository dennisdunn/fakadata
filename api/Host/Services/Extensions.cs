using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Timeseries.Api.Services
{
    public static class Extensions
    {
        public static IEnumerable<string> Keys(this IMemoryCache cache)
        {
            var entries = typeof(IMemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            if (entries != null)
            {
                var keys = ((IEnumerable<object>)entries.GetValue(cache)).Select(key => key.GetType().GetProperty("Key").GetValue(key)).Cast<string>();

                return keys;
            }

            return new string[0];
        }
    }
}
