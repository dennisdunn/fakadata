using System.Collections.Generic;

namespace Engine
{
    public interface IGenerator<T> : IEnumerable<T>, IEnumerator<T>
    {
    }
}
