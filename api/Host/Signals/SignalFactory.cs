using CsvHelper;
using Flee.PublicTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using Timeseries.Api.Evaluator;

namespace Timeseries.Api.Signals
{
    public class SignalFactory
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
            var context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Imports.AddType(typeof(Probability));
            context.Variables["x"] = idx;
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
    }
}
