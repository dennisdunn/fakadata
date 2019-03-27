using Models.Impl;
using System;
using System.Linq.Expressions;

namespace Models
{
    public class ExpressionDecorator : BaseDecorator
    {
        public ExpressionDecorator(IPointStream target, Expression<Func<double, double>> func) : base(target)
        {
            var f = func.Compile();
            Apply = (IDatapoint point) =>
              {
                  point.Value = f(point.Value);
                  return point;
              };
        }
    }
}
