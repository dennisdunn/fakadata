using System.Collections.Generic;

namespace Models
{
    public interface IPointsource
    {
        string Name { get; }
        IEnumerable<IDatapoint> Datapoints { get; }
    }
}