using System;
using System.Collections.Generic;

namespace Models
{
    public class TsDescription : ITsDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Period { get; set; }
        public IEnumerable<string> Source { get; set; } 
    }
}
