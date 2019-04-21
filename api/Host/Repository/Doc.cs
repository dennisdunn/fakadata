using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Repository
{
    public class Doc : IDocument, IKeyValue
    {
        public int _id { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
