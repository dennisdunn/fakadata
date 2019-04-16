using System;
using System.Collections.Generic;

namespace Timeseries.Api.Models
{
    public interface IDefinition : IDocument
    {
        TimeSpan Period { get; set; }
        List<string> Expressions { get; set; }
        DateTime Start { get; set; }
    }
}