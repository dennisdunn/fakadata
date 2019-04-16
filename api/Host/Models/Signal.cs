using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Models
{
    public class Signal : ISignal
    {
        public int _id { get; set; }
        public string Expression {get;set; }
        public string Name { get; set; }
    }
}
