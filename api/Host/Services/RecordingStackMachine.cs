using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Services
{
    public class RecordingStackMachine : BaseDecorator, IRecordingStackMachine
    {

        public RecordingStackMachine(IStackMachine target) : base(target) { }

        public IList<string> History { get; private set; } = new List<string>();

        public override void Eval(string text)
        {
            History.Add(text);
            base.Eval(text);
        }

        public override void Reset()
        {
            History.Clear();
            base.Reset();
        }
    }
}
