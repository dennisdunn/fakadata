using System;
using System.Collections.Generic;

namespace Repository
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