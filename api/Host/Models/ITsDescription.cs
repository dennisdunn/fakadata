using System;
using System.Collections.Generic;

namespace Timeseries.Api.Models
{
    public interface ITsDescription
    {
        int Id { get; set; }
        string Name { get; set; }
        TimeSpan Period { get; set; }
        List<string> Source { get; set; }
        DateTime Start { get; set; }
    }
}