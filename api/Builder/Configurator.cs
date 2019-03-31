using Models;
using System;
using System.Linq.Expressions;

namespace Builder
{
    public class Configurator : IInitializable, IDecoratable, IBuildable
    {
        private IPointStream _source;

        public static IInitializable Instance => new Configurator();

        internal Configurator() { }

        // Initialize

        /// <summary>
        /// Set the source to the point stream.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public IDecoratable With(IPointStream points)
        {
            _source = points;
            return this;
        }

        /// <summary>
        /// Set the source from the builder.
        /// </summary>
        /// <param name="buiilder"></param>
        /// <returns></returns>
        public IDecoratable With(IBuildable buiilder)
        {
            _source = buiilder.Build();
            return this;
        }

        /// <summary>
        /// Set the source from the named catalog entry.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDecoratable With(string name)
        {
            _source = Catalog.Current[name];
            return this;
        }

        // Decorate

        /// <summary>
        /// Wrap the source with an expression that will alter the data points value.
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public IDecoratable WithExpression(Expression<Func<double, double>> expr)
        {
            _source = _source.WithExpression(expr);
            return this;
        }

        /// <summary>
        /// Configure the timestamps of the data points.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public IDecoratable WithTimestamp(DateTime start, TimeSpan period)
        {
            _source = _source.WithTimestamp(start, period);
            return this;
        }

        /// <summary>
        /// Configure the timestamps of the data points with the Unix epoch and a 1 minute period.
        /// </summary>
        /// <returns></returns>
        public IDecoratable WithTimestamp()
        {
            return WithTimestamp(new DateTime(1970, 1, 1), TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// Add the source to another point stream generated from the expression.
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public IDecoratable WithTrend(Expression<Func<double, double>> expr)
        {
            _source = _source.WithTrend(expr);
            return this;
        }

        // Build

        /// <summary>
        /// Build a point stream.
        /// </summary>
        /// <returns></returns>
        public IPointStream Build()
        {
            return _source;
        }

        /// <summary>
        /// Build a perputual point stream.
        /// </summary>
        /// <param name="isPerpetual"></param>
        /// <returns></returns>
        public IPointStream Build(bool isPerpetual)
        {
            return isPerpetual ? _source.AsPerpetual() : _source;
        }
    }
}
