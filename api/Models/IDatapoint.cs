using System;

namespace Models
{
    public interface IDataPoint
    {
        DateTime Timestamp { get; set; }
        double Value { get; set; }
    }
}
