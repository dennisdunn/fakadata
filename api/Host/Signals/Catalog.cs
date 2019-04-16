using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Timeseries.Api.Evaluator;

namespace Timeseries.Api.Signals
{
    public class Catalog
    {
        internal const string EMBEDDED_RESOURCE = "Timeseries.Api.Signals.signal_data.csv";

        public static Catalog Current { get; } = new Catalog();

        public IEnumerable<string> Keys { get; private set; }

        public IGenerator<double> this[string key] { get => new SignalGenerator(key); }

        public Catalog()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(EMBEDDED_RESOURCE))
            using (var reader = new StreamReader(stream))
            {
                var row = reader.ReadLine();
                Keys = row.Split(',').Skip(1).ToList();
            }
        }
    }
}
