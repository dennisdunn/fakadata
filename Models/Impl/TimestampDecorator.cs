﻿using Models.Impl;
using System;

namespace Models
{
    public class TimestampDecorator : BaseDecorator
    {
        private DateTime _current = DateTime.Parse("01/01/1970");
        private TimeSpan _period = TimeSpan.FromSeconds(1);

        public TimestampDecorator(IPointStream target, DateTime? start, TimeSpan? period) : base(target)
        {
            _current = start ?? _current;
            _period = period ?? _period;

            Apply = (IDatapoint point) =>
             {
                 point.Timestamp = _current + _period;
                 _current = point.Timestamp.Value;
                 return point;
             };
        }
    }
}
