using System;

namespace Timeseries.Api.Models
{
    public class Datapoint : IDatapoint
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
    }
}
