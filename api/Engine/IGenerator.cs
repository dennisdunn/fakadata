using System.Collections.Generic;
using Models;

namespace Engine
{
    public interface IGenerator
    {
        IEnumerable<IDataPoint> Generate(ITsDescription ts);
    }
}