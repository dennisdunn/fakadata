﻿using System;
using System.Collections.Generic;

namespace Timeseries.Api.Models
{
    public class TsDescription : ITsDescription
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Default";
        public DateTime Start { get; set; } = new DateTime(1970, 1, 1);
        public TimeSpan Period { get; set; } = TimeSpan.FromHours(1);
        public List<string> Expressions { get; set; } = new List<string>();
    }
}
