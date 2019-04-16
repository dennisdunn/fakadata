using CsvHelper;
using Flee.PublicTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Timeseries.Api.Evaluator;

namespace Timeseries.Api.Signals
{
    public static class SignalFactory
    {
        public static IEnumerable<double> FromCatalog(string key)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var s = new StreamReader(assembly.GetManifestResourceStream(Catalog.EMBEDDED_RESOURCE)))
            using (var csv = new CsvReader(s))
            {
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                csv.Read();
                csv.ReadHeader();
                var idx = csv.GetFieldIndex(key);
                while (csv.Read())
                {
                    if (csv.TryGetField<double>(idx, out double value))
                    {
                        yield return value;
                    }
                }
            }
        }

        public static IEnumerable<double> FromExpression(string expr)
        {
            var idx = 0;
            var context = NewContext();
            var expression = context.CompileGeneric<double>(expr);

            while (true)
            {
                context.Variables["x"] = idx++;
                yield return expression.Evaluate();
            }
        }

        public static IEnumerable<double> FromExpression(Expression<Func<int, double>> expr)
        {
            var idx = 0;
            var f = expr.Compile();

            while (true)
            {
                yield return f(idx++);
            }
        }

        public static IEnumerable<double> Noise()
        {
            while (true)
            {
                yield return Probability.Normal();
            }
        }

        public static IEnumerable<double> Cardinal()
        {
            var i = 0;
            while (true)
            {
                yield return i++;
            }
        }

        public static IEnumerable<double> Parabola()
        {
            return Cardinal().Select(x => Math.Pow(x, 2));
        }

        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Expression<Func<T, T>> f)
        {
            return source.Select(f.Compile());
        }

        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, string f)
        {
            var context = NewContext();
            var expression = context.CompileGeneric<T>(f);

            while (true)
            {
                context.Variables["x"] = source.GetEnumerator().Current;
                yield return expression.Evaluate();
            }
        }

        internal static ExpressionContext NewContext()
        {
            var context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Imports.AddType(typeof(Probability));
            return context;
        }
    }
}
