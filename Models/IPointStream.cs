using System.Collections.Generic;

namespace Models
{
    public interface IPointStream : IEnumerable<IDatapoint>, INameable
    {
    }
}
