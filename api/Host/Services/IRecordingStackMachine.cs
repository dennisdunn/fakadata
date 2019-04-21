using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Services
{
    public interface IRecordingStackMachine : IStackMachine
    {
        IList<string> History { get; }
    }
}
