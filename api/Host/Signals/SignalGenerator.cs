using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Timeseries.Api.Evaluator;

namespace Timeseries.Api.Signals
{
    public class SignalGenerator : IGenerator<double>
    {
        private List<double> _values = new List<double>();

        public SignalGenerator(string key)
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
                        _values.Add(value);
                    }
                }
            }
        }

        public double Current => _values.GetEnumerator().Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
           _values = null;
        }

        public IEnumerator<double> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        public bool MoveNext()
        {
            return _values.GetEnumerator().MoveNext();
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
