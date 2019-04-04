﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class DatapointGenerator : BaseGenerator<IDatapoint>
    {
        private readonly TimestampGenerator _timestamps;
        private readonly ValueGenerator _values;
        private readonly IEnumerable<Datapoint> _datapoints;

        public DatapointGenerator(ITsDescription target) : base(target)
        {
            _timestamps = new TimestampGenerator(target);
            _values = new ValueGenerator(target);
            _datapoints = _timestamps.Zip(_values, (ts, v) => new Datapoint { Timestamp = ts, Value = v });
        }

        public override bool MoveNext()
        {
            return _datapoints.GetEnumerator().MoveNext();
        }

        public override IEnumerator<IDatapoint> GetEnumerator()
        {
            return _datapoints.GetEnumerator();
        }
    }
}