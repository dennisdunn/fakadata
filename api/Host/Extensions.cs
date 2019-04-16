using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Evaluator;

namespace Timeseries.Api
{
    public static class Extensions
    {
        public static T Next<T>(this IGenerator<T> generator)
        {
            return generator.First();
        }

        public static IEnumerable<T> Sample<T>(this IGenerator<T> generator)
        {
            return generator.Take(100);
        }

        public static IEnumerable<T> Sample<T>(this IGenerator<T> generator, int count)
        {
            return generator.Take(count);
        }
    }
}
