﻿using Models;
using System;

namespace Engine
{
    public class TimestampGenerator : BaseGenerator<DateTime>
    {
        public TimestampGenerator(ITsDescription target) : base(target)
        {
            Reset();
        }

        public override bool MoveNext()
        {
            if (Current == DateTime.MinValue)
                Current = Target.Start;
            else
                Current += Target.Period;

            return true;
        }

        public override void Reset()
        {
            Current = DateTime.MinValue;
        }
    }
}
