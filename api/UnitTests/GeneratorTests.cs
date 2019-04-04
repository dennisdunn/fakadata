using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GeneratorTests
    {
        ITsDescription Env;

        [TestInitialize]
        public void TestInitialize()
        {
            Env = new TsDescription
            {
                Start = new DateTime(1970, 1, 1),
                Period = TimeSpan.FromMinutes(1),
                Source = new List<string> { "1", "2*x", "x^2" }
            };
        }

        [TestMethod]
        public void ShouldGenerate5Timestamps()
        {
            var g = new TimestampGenerator(Env);
            var ts = g.Take(5).Last();
            Assert.AreEqual(4, ts.Minute);
        }

        [TestMethod]
        public void ShouldSkip10ThenGenerate5More()
        {
            var g = new TimestampGenerator(Env);
            var ts = g.Skip(10).Take(5).Last();
            Assert.AreEqual(14, ts.Minute);
        }

        [TestMethod]
        public void ShouldTake10ThenGenerate5MoreByRestarting()
        {
            var g = new TimestampGenerator(Env);
            g.Take(10).ToList(); // advance the pointer
            var ts = g.Take(5).Last();
            Assert.AreEqual(14, ts.Minute);
        }

        [TestMethod]
        public void ShouldTake5ThenSkip5AndGenerate5MoreByRestarting()
        {
            var g = new TimestampGenerator(Env);
            g.Take(5).ToList(); // advance the pointer
            var ts = g.Skip(5).Take(5).Last();
            Assert.AreEqual(14, ts.Minute);
        }

        [TestMethod]
        public void SudoMakeMeSomeDoubles()
        {
            var g = new ValueGenerator(Env);
            var v = g.Skip(5).Take(5).Last();
            Assert.AreEqual(100, v);
        }

        [TestMethod]
        public void SudoMakeMeSomeDatapoints()
        {
            var g = new DatapointGenerator(Env);
            var d = g.Skip(5).Take(5).Last();
            Assert.AreEqual(100, d.Value);
        }
    }
}
