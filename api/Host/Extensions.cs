using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;

namespace Timeseries.Api
{
    public static class Extensions
    {
        public static IEnumerable<IDatapoint> Next(this IGenerator<IDatapoint> generator)
        {
            return generator.Sample(1);
        }

        public static IEnumerable<IDatapoint> Sample(this IGenerator<IDatapoint> generator)
        {
            return generator.Sample(100);
        }

        public static IEnumerable<IDatapoint> Sample(this IGenerator<IDatapoint> generator, int count)
        {
            return generator.Take(count);
        }
    }
}
