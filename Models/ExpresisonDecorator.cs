using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Models
{
    public class ExpresisonDecorator : IPointsource
    {
        private readonly IPointsource _target;

        public string Name => _target.Name;

        public IEnumerable<IDatapoint> Datapoints => Source();

        private readonly Func<double, double> _f;

        public ExpresisonDecorator(IPointsource target, Expression<Func<double, double>> f)
        {
            _target = target;
            _f = f.Compile();
        }

        private IEnumerable<IDatapoint> Source()
        {
            return _target.Datapoints.Select(x =>
            {
                x.Value = _f(x.Value);
                return x;
            });
        }
    }
}
