using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Signals
{
    public static class Probability
    {
        private static readonly Random _rng = new Random();

        public static double Random()
        {
            return _rng.NextDouble();
        }

        public static double Uniform()
        {
            return _rng.NextDouble();
        }

        public static double Gaussian(double mean, double standardDeviation)
        {
            var u1 = _rng.NextDouble();
            var u2 = _rng.NextDouble();
            var left = Math.Cos(2.0 * Math.PI * u1);
            var right = Math.Sqrt(-2.0 * Math.Log(u2));
            var z = left * right;
            return mean + (z * standardDeviation);
        }

        public static double Normal()
        {
            return Gaussian(0, 1);
        }
    }
}
