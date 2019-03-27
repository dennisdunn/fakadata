using System;
using System.Linq;
using System.Linq.Expressions;

namespace Models
{
    public static class DecoratorExtensions
    {
        public static IPointsource WithTimestamp(this IPointsource target, DateTime? start, TimeSpan? period)
        {
            return new TimestampDecorator(target, start, period);
        }

        public static IPointsource WithExpression(this IPointsource target, Expression<Func<double, double>> expression)
        {
            return new ExpresisonDecorator(target, expression);
        }

        public static IPointsource WithTrend(this IPointsource target, Expression<Func<double, double>> expression)
        {
            var trend = new ExpresisonDecorator(new IndexPointsource(), expression);
            var source = target.Datapoints.Zip(trend.Datapoints, (a, b) =>
            {
                a.Value += b.Value;
                return a;
            });

            return new Pointsource(target.Name, source);
        }
    }
}
