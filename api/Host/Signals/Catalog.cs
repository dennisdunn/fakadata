using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Timeseries.Api.Signals
{
    public class Catalog
    {
        internal const string EMBEDDED_RESOURCE = "Timeseries.Api.Signals.signal_data.csv";

        public static IEnumerable<string> Names { get; private set; }

        static Catalog()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(EMBEDDED_RESOURCE))
            using (var reader = new StreamReader(stream))
            {
                var row = reader.ReadLine();
                Names = row.Split(',').Skip(1);
            }
        }
    }
}
