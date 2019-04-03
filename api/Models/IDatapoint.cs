using System;

namespace Models
{
    public interface IDataPoint : IDataPoint<double>
    {
    }

    public interface IDataPoint<T>
    {
        DateTime Timestamp { get; set; }
        T Value { get; set; }
    }
}
