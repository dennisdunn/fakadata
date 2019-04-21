using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Repository
{
    public interface IDocument 
    {
        int _id { get; set; }
        string Key { get; set; }
        object Value { get; set; }
    }
}
