using System;

namespace Models
{
    public interface IPointStreamDecorator
    {
        IPointStream Target { get; }
        Func<IDatapoint, IDatapoint> Apply { get; }
    }
}
