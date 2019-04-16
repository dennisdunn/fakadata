using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timeseries.Api.Models.Collections;

namespace Timeseries.Api.Models
{
    public static class Extensions
    {
        public static IEnumerable<T> AsPerpetual<T>(this IEnumerable<T> target)
        {
            return new ForeverEnumerable<T>(target);
        }
    }
}
