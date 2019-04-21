using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EmbeddedSequences
{
    public static class SequenceFactory
    {
        public static IEnumerable<double> Load(string key)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var s = new StreamReader(assembly.GetManifestResourceStream(Magic.EMBEDDED_RESOURCE)))
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

        public static IEnumerable<string> List()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var s = new StreamReader(assembly.GetManifestResourceStream(Magic.EMBEDDED_RESOURCE)))
            {
                return s.ReadLine().Split(',').Skip(1).ToList();
            }
        }

        public static IEnumerable<double> From(Func<double> f)
        {
            while (true)
            {
                yield return f();
            }
        }
    }
}
