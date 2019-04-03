using Engine;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Host
{
    public static class Extensions
    {
        public static IEnumerable<IDataPoint> GetPage(this IEnumerable<IDataPoint> items, int? offset, int? limit)
        {
            return offset.HasValue && limit.HasValue ? items.Skip(offset.Value).Take(limit.Value) : items;
        }
    }
}
