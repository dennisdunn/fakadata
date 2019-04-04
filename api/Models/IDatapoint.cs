using System;

namespace Models
{
    public interface IDatapoint
    {
        DateTime Timestamp { get; set; }
        double Value { get; set; }
    }
}
