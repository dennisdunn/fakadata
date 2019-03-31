using System;
using System.Collections.Generic;

namespace Models.Streams
{
    public class NoiseStream : BasePointStream
    {
        readonly Random _rng = new Random();

        public NoiseStream() : base("Noise") { }

        public override IEnumerator<IDatapoint> GetEnumerator()
        {
            yield return new Datapoint { Value = _rng.NextDouble() };
        }
    }
}
