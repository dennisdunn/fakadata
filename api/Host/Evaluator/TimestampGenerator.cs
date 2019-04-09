using System;
using Timeseries.Api.Models;

namespace Timeseries.Api.Evaluator
{
    public class TimestampGenerator : BaseGenerator<DateTime>
    {
        public TimestampGenerator(IDefinition target) : base(target)
        { 
        }

        public override bool MoveNext()
        {
            if (Current == DateTime.MinValue)
                Current = Target.Start;
            else
                Current += Target.Period;

            return true;
        }
    }
}
