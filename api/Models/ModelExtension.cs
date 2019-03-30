using Models.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Models
{
    public static class ModelExtension
    {
        public static IPointStream WithTimestamp(this IPointStream target, DateTime start, TimeSpan period)
        {
            return new TimestampDecorator(target, start, period);
        }

        public static IPointStream WithTimestamp(this IPointStream target)
        {
            return new TimestampDecorator(target, null, null);
        }

        public static IPointStream WithExpression(this IPointStream target, Expression<Func<double, double>> expression)
        {
            return new ExpressionDecorator(target, expression);
        }

        public static IPointStream WithTrend(this IPointStream target, Expression<Func<double, double>> expression)
        {
            return new TrendDecorator(target, expression);
        }

        public static IPointStream AsPerpetual(this IPointStream target)
        {
            return new PerpetualDecorator(target);
        }

        public static IEnumerable<object> WithKeys<T>(this IEnumerable<T> collection)
        {
            var i = 0;
            return collection.Select(o => new { key = i++, value = o });
        }
    }
}
