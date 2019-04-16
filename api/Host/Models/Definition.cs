using LiteDB;
using System;
using System.Collections.Generic;

namespace Timeseries.Api.Models
{
    public class Definition : IDefinition
    {
        public int _id { get; set; }
        public string Name { get; set; } = "Default";
        public DateTime Start { get; set; } = new DateTime(1970, 1, 1);
        public TimeSpan Period { get; set; } = TimeSpan.FromHours(1);
        public List<string> Expressions { get; set; } = new List<string>();
    }
}
