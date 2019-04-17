using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;

namespace UnitTests
{
    [TestClass]
 public   class SequrenceTests
    {
        [TestMethod]
        public void ShouldGetSomeNoise()
        {
            var b = new Sequences.Builder();
            b.Nosie();
            var seq = b.Build().Take(5).ToList();

            Assert.AreEqual(5,seq.Count);
        }
    }
}
