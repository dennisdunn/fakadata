using System;
using System.Collections.Generic;

namespace Timeseries.Api.Models
{
    public interface ITsDescription
    {
        int _id { get; set; }
        string Name { get; set; }
        TimeSpan Period { get; set; }
        List<string> Expressions { get; set; }
        DateTime Start { get; set; }
    }
}