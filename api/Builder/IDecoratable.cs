using System;
using System.Linq.Expressions;

namespace Builder
{
    public interface IDecoratable : IBuildable
    {
        IDecoratable WithExpression(Expression<Func<double, double>> expr);
        IDecoratable WithTrend(Expression<Func<double, double>> expr);
        IDecoratable WithTimestamp(DateTime start, TimeSpan period);
        IDecoratable WithTimestamp();
    }
}
