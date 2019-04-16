using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;
using Timeseries.Api.Signals;

namespace UnitTests
{
    [TestClass]
  public  class BuilderTests
    {
        [TestMethod]
        public void ShouldBuildMeAList()
        {
            var src = @"parabola
10
limit";

            var builder = new Builder();
            builder.Interpret(src);

            var seq = builder.Build().ToList();

            Assert.AreEqual(10, seq.Count);
            Assert.AreEqual(0, seq[0]);
            Assert.AreEqual(81, seq[9]);
        }
    }
}
