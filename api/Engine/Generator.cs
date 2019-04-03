using Models;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class Generator : IGenerator
    {
        public IEnumerable<IDataPoint> Generate(ITsDescription  ts)
        {
            throw new NotImplementedException();
        }
    }
}
