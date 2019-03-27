using Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Models
{
    public partial class Pointsource : IPointsource
    {
        internal const string EMBEDDED_RESOURCE = "Models.signal_data.csv";

        private Stream _stream;

        public string Name { get; private set; }
        public IEnumerable<IDatapoint> Datapoints { get; private set; }

        public Pointsource(string name, IEnumerable<IDatapoint> source)
        {
            Name = name;
            Datapoints = source;
        }
    }
}
