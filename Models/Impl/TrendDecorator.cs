using Models.Impl;
using System;
using System.Linq.Expressions;

namespace Models
{
    internal class TrendDecorator : BasePointDecorator
    {
        public TrendDecorator(IPointStream target, Expression<Func<double, double>> expression) : base(target)
        {
            var trend = new ExpressionDecorator(new IndexPointStream(), expression).GetEnumerator();

            Apply = (IDatapoint point) =>
              {
                  trend.MoveNext();
                  point.Value += trend.Current.Value;

                  return point;
              };
        }
    }
}