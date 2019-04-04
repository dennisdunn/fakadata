using Engine;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Host
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
