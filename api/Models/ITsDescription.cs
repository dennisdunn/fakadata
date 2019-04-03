using System;
using System.Collections.Generic;

namespace Models
{
    public interface ITsDescription
    {
        int Id { get; set; }
        string Name { get; set; }
        TimeSpan Period { get; set; }
        IEnumerable<string> Source { get; set; }
        DateTime Start { get; set; }
    }
}