using System;

namespace Timeseries.Api.Models
{
    public interface IDatapoint
    {
        DateTime Timestamp { get; set; }
        double Value { get; set; }
    }
}
